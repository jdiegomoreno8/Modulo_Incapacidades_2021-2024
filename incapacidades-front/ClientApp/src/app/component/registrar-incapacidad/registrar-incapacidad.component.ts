import { Component, OnInit, ViewChild, ChangeDetectorRef, AfterContentChecked, Input } from '@angular/core';
import Stepper from 'bs-stepper';
import {NgbModal,NgbModalOptions} from '@ng-bootstrap/ng-bootstrap';
import * as FileSaver from 'file-saver';
import { DownloadService } from 'src/app/services/download.service';


import { ParametrosIncapacidadesService } from 'src/app/services/parametros-incapacidades.service';
import { ModalListaDiagnosticoComponent } from 'src/app/component/registrar-incapacidad/modal-lista-diagnostico/modal-lista-diagnostico.component';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IIncapacidad, Incapacidad } from 'src/app/models/incapacidad.model';
import { NotificationesService } from 'src/app/services/notificaciones.service';
import { IPacienteModel } from 'src/app/models/paciente.model';
import { ModalConfirmacionComponent } from './modal-confirmacion/modal-confirmacion.component';
import { AlertasService } from 'src/app/services/alertas.service';
import { ModalIncapacidadAnteriorComponent } from './modal-incapacidad-anterior/modal-incapacidad-anterior.component';
import { ServiciosIntegracionService } from 'src/app/services/servicios-integracion.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { EditarPacienteComponent } from '../editar-paciente/editar-paciente.component';
import { ModalListaIncapacidadesAnterioresComponent } from './modal-lista-incapacidades-anteriores/modal-lista-incapacidades-anteriores.component';
import { DatosRegistroIncapacidadDTO } from 'src/app/models/DatosRegistroIncapacidadDTO.model';
import { IAportanteModel } from 'src/app/models/Aportante.model';
import { ModalAportantesComponent } from './modal-aportantes/modal-aportantes.component';

// WS I
import { ActivatedRoute} from '@angular/router';
import { IPerfil } from 'src/app/interfaces/IPerfil';
import { formatDate } from '@angular/common';
import { IPerfilComple } from 'src/app/interfaces/IPerfilComple';
import { environment } from 'src/environments/environment';
// WS F

@Component({
  selector: 'app-registrar-incapacidad',
  templateUrl: './registrar-incapacidad.component.html',
  styleUrls: ['./registrar-incapacidad.component.scss']
})
export class RegistrarIncapacidadComponent implements OnInit, AfterContentChecked {
  //@Input() public IncapacidadIn:IIncapacidad;
  @Input() name: string;

  @ViewChild(EditarPacienteComponent, { static: false }) datosDesdeElPadre: EditarPacienteComponent;

  // @ViewChild("checkbox1") input1;
  // @ViewChild("checkbox2") input2;
  
  listaGrupoServicios : any;
  listaGrupoServiciosPorFiltro : any;
  listaFinalidadConsulta: any;
  listaModalidadRealizacionConsulta: any;
  listaModalidadRealizacionConsultaPorFiltro: any;
  listaRetroactivaMotivoR: any;
  listaOrigen: any;
  listaCausaAtencion: any;
  listaCausaAtencionByOrigen: any;
  listaTipoDocumento: any;
  listaMotivaRetroactiva: any;
  listaMotivaRetroactivaPorFiltro: any;
  listaGenero: any;
  listaTrastornoMemoria: any;
  listaDepartamentos: any;
  listaMunicipios: any;
  listaIncapacidadesAnteriores: any;
  diagnosticoCodigoSeleccionado : string = '';
  diagnosticoRelacionado1CodigoSeleccionado : string = '';
  diagnosticoRelacionado2CodigoSeleccionado : string = '';
  diagnosticoCodigoAnteriorSeleccionado: string = '';
  deshabilitarComponentePaciente: boolean;

  paciente : IPacienteModel;
  incapacidadAnterior: IIncapacidad;
  
  baseUrlSIIN = environment.baseSiteSIIN;
  //aportante: IAportanteModel;
  
  codigo_diagnostico_principal : string; 
  keyword = 'codigo';
  fechaHoy: number = Date.now();
  fechaMinimaIncapacidad: number = Date.now();

  listaDiagnosticosCie10_principal: Array<any> = [];
  listaDiagnosticosCie10_relacion_1: Array<any> = [];
  listaDiagnosticosCie10_relacion_2: Array<any> = [];
  tieneListaMotivoRetroactivo: boolean = false;
  tieneTrastornoMemoria: boolean = false;
  tieneProrroga: boolean = false;
  deshabilitarSeleccionProrroga: boolean = false;
  deshabilitarSeleccionRetroactiva: boolean = false;
  tieneOrigenLaboral: boolean = false;
  error : any;

  esVisibleDiagnosticorelacionado1: boolean = false ; // hidden by default
  esVisibleDiagnosticorelacionado2: boolean = false ; // hidden by default

  _id_servicio_internacion:string ='3';
  //perfilUbicacionExpecidicion : IPerfilComple;
  //perfilUbicacion: IPerfilComple;

  optionsModal: NgbModalOptions = {
    size: 'lg',
    backdrop:'static',
    backdropClass: "light-blue-backdrop",
    windowClass: 'dark-modal',
    centered: true
  };

  private stepper: Stepper;

  
  personaForm: FormGroup;
  submittedPersona = false;
  incapacidadForm: FormGroup;
  submittedIncapacidad = false;

  showCountryErrorMessage: boolean = false;

  // WS I
  id: number;
  retroactividoSelected = false;
  prorrogaSelected = false;
  IncapacidadDetalles: any;
  IncapacidadDetalles2: any;
  retroactivaInconsistente: any;
  PacienteDetalles: any;
  causaAnulacion: any;
  causaAtencionAnulada = false;
  lugardeExpedicionEntidad: string;
  idUsuarioEntidadRolActual: any;
  idEntidad: any;
  reexpedir= false;
  proviene_anulado = false;
  bttnBack = false;
  // WS F

  constructor(private cd: ChangeDetectorRef, private parametrosIncapacidadesService: ParametrosIncapacidadesService,
    private modalService: NgbModal,
    private formBuilder: FormBuilder,

    private Alertas: AlertasService,
    private serviciosIntegracionService: ServiciosIntegracionService,
    //WS I
    private route: ActivatedRoute,
    //WS F
    private spinnerService: NgxSpinnerService,
    private downloadService: DownloadService) { 

  }
  
  ngAfterViewInit() {
    this.cd.detectChanges();
  }

  ngAfterContentChecked(): void {
    this.cd.detectChanges();
  }

   ngOnInit() {

    this.spinnerService.show('spinnerCargaInicial');
    this.stepper = new Stepper(document.querySelector('#stepper1'), {
      linear: true,
      animation: true
    });
    
    //const perfilUbicacionExpecidicion: IPerfilComple = JSON.parse(localStorage.getItem('complementario2')) || '';
    const  perfilUbicacion: IPerfilComple = JSON.parse(localStorage.getItem('complementario2')) || '';

     if (this.route.snapshot.params.idIncapacidad != null) {
       this.spinnerService.show('spinnerCargaAnulacion');
     }

    this.listaIncapacidadesAnteriores = [];
    this.paciente = this.inicializarPaciente();

    this.createPersonaForm();
    this.createIncapacidadForm();
    
    this.cargarListas();  

    this.proviene_anulado = false;
    // WS I
    console.log(this.route.snapshot.params.idIncapacidad);   
      
    /*   console.log(this.causaAnulacion)*/
    /*this.openModalIncapacidadesAnteriores();*/
    // WS F
    
  }

  async cargarReexpedicion() {
    this.spinnerService.show('spinnerCargaAnulacion');
    try {

    /*let camposAnulacion2 = [{ "nombreColumna": "grupoServiciosId", "desc": "Grupo Servicios", "valorColumna": "Internación", "idColumna": 3, "checked": true, "disabled": false }, { "nombreColumna": "Diagnostico", "desc": "Diagnostico", "valorColumna": "Colera debido a Vibrio cholerae 01, biotipo el Tor", "idColumna": "A001", "checked": true, "disabled": false }];*/
    //console.info(camposAnulacion.includes("grupoServiciosId")); // true

    let camposAnulacion = await this.parametrosIncapacidadesService.getCamposAnulacion('/Incapacidad', this.route.snapshot.params.idIncapacidad);

    console.log(camposAnulacion);

    //this.parametrosIncapacidadesService.getCamposAnulacion('/Incapacidad',
    //  this.route.snapshot.params.idIncapacidad).subscribe(data2 => {
        /*this.causaAnulacion = "";*/
    var str = camposAnulacion.toString();
        /*console.log(data2)*/

    this.IncapacidadDetalles = await this.parametrosIncapacidadesService.getIncapacidad('/Incapacidad/' + this.route.snapshot.params.idIncapacidad + '/' + ' ' + '/' + '0');
    console.log(this.IncapacidadDetalles);

        //this.parametrosIncapacidadesService.getIncapacidadAnular('/Incapacidad',
        //  this.route.snapshot.params.idIncapacidad,
        //  ' ', '0').subscribe(data => {
        //    this.IncapacidadDetalles = data;

            console.log(this.IncapacidadDetalles);

            if (this.IncapacidadDetalles.id_incapacidad.indexOf('20', 0) == -1 /*|| this.IncapacidadDetalles.id_incapacidad.anulada == false*/) {
              console.log("no encontrado" + this.IncapacidadDetalles.id_incapacidad);
              
              return;
            }
            else {
              this.reexpedir = true;
              this.stepper.to(3);
              console.log("encontrado" + this.reexpedir)
            }


            this.paciente.id_incapacidad_anulado = this.route.snapshot.params.idIncapacidad;
            
            this.proviene_anulado = true;
            this.bttnBack = true;

            this.incapacidadForm.patchValue({
              paciente_encontrado: this.IncapacidadDetalles.paciente_encontrado,
              diagnostico_principal: !str.includes('"Diagnostico"') ? this.IncapacidadDetalles.diagnostico.id_diagnosticos : 0,
              codigo_diagnostico_principal: !str.includes('"Diagnostico"') ? this.IncapacidadDetalles.diagnostico.cod_diagnostico : '',
              diagnostico_relacion_1: !str.includes('"DiagnosticoRealacionUno"') ? this.IncapacidadDetalles.diagnosticoRelacionUno?.id_diagnostico_uno : 0,
              codigo_diagnostico_relacion_1: !str.includes('"DiagnosticoRealacionUno"') ? this.IncapacidadDetalles.diagnosticoRelacionUno?.cod_diag_relacion_uno : '',
              diagnostico_relacion_2: !str.includes('"DiagnosticoRealacionDos"') ? this.IncapacidadDetalles.diagnosticoRelacionDos?.id_diagnostico_dos : 0,
              codigo_diagnostico_relacion_2: !str.includes('"DiagnosticoRealacionDos"') ? this.IncapacidadDetalles.diagnosticoRelacionDos?.cod_diag_relacion_dos : '',
              id_servicio: !str.includes('"grupoServiciosId"') ? this.IncapacidadDetalles.grupoServicios.id_servicio : 0,
              id_modalidad: !str.includes('"Modalidad"') ? this.IncapacidadDetalles.modalidad.id_modalidad : 0,
              id_origen: !str.includes('"Origen"') ? this.IncapacidadDetalles.origen.id_origen : 0,
              id_causa: !str.includes('"CausaAtencion"') ? this.IncapacidadDetalles.causaAtencion.id_causa : 0,
              retroactiva: !str.includes('"Retroactiva"') ? this.IncapacidadDetalles.retroactiva : false,
              id_retroactiva: !str.includes('"Retroactiva"') ? this.IncapacidadDetalles.id_retroactiva : 0,
              id_trastorno_memoria: !str.includes('"Retroactiva"') ? this.IncapacidadDetalles.id_trastorno_memoria : 0,
              prorroga: !str.includes('"Prorroga"') ? this.IncapacidadDetalles.prorroga : 0,
              fecha_inicio_string: !str.includes('"FechaInicio"') ? this.IncapacidadDetalles.fecha_inicio_string : '',
              dias_incapacidad: !str.includes('"DiasIncapacidad"') ? [this.IncapacidadDetalles.dias_incapacidad, Validators.required] : '',
              diasAcumuladosProrroga: [''],
              id_incapacidad_anterior: !str.includes('"Prorroga"') ? [this.IncapacidadDetalles.id_incapacidad_anterior] : '',
              descripcion_incapacidad_anterior: [''],
            });


            if (this.IncapacidadDetalles.retroactiva && !str.includes('"Retroactiva"')) {
              this.retroactividoSelected = true;
              this.seleccionRetroactiva(true);
              console.log(this.IncapacidadDetalles.retroactiva);
              this.f_incapacidad.id_retroactiva.setValue(this.IncapacidadDetalles.id_retroactiva);
/*              if (this.IncapacidadDetalles.id_retroactiva == 2) {*/
                this.changeValueRetroactivaMotivoR()
              /*}*/
              if (this.listaGrupoServicios) {
                this.listaGrupoServiciosPorFiltro = this.listaGrupoServicios.filter(x => x.id_servicio == 3 || x.id_servicio == 5);
              }
            }

            if (this.IncapacidadDetalles.retroactiva && str.includes('"Retroactiva"')) {
              this.retroactividoSelected = false;
              this.seleccionRetroactiva(false);

              this.retroactivaInconsistente = 1;

              console.log(this.IncapacidadDetalles.retroactiva);
              this.incapacidadForm.patchValue({
                fecha_inicio_string: !str.includes('"FechaInicio"') ? this.IncapacidadDetalles.fecha_expedicion_string : ''
              });

            }

            if (!this.IncapacidadDetalles.retroactiva && str.includes('"Retroactiva"')) {
              this.retroactividoSelected = true;

              this.retroactivaInconsistente = 2;

              this.seleccionRetroactiva(true);
              console.log(this.IncapacidadDetalles.retroactiva);

      }

      //if (this.incapacidadForm.get('id_origen')?.value == '2') {
      //  this.causaAtencionAnulada = true;
      //  this.changeValueOrigen();
      //}

      if (this.IncapacidadDetalles.grupoServicios != null && !str.includes('"grupoServiciosId"')) {
        this.f_incapacidad.id_servicio.setValue(this.IncapacidadDetalles.grupoServicios.id_servicio);
      }



            console.log(this.IncapacidadDetalles.fecha_inicio_string);

            this.paciente.id_regimen = this.IncapacidadDetalles.id_tipo_afiliado;

            if (!str.includes('"DiasIncapacidad"')) {
              this.f_incapacidad.dias_incapacidad.setValue(this.IncapacidadDetalles.dias_incapacidad);

              if (this.incapacidadForm.value.fecha_inicio_string != "") {
                this.calcularFechaFinal();
              }

            }

            if (!str.includes('"Diagnostico"')) {
              /*this.f_incapacidad.diagnostico_principal.setValue(parseInt(item.id));*/
              this.diagnosticoCodigoSeleccionado = this.IncapacidadDetalles.diagnostico.cod_diagnostico;
              this.f_incapacidad.codigo_diagnostico_principal.setValue(this.IncapacidadDetalles.diagnostico.cod_diagnostico);
              this.f_incapacidad.descripcion_diagnostico_principal.setValue(this.IncapacidadDetalles.diagnostico.descripcion);

            }

            if (!str.includes('"DiagnosticoRealacionUno"') && this.IncapacidadDetalles.diagnosticoRelacionUno != null) {
              /*this.f_incapacidad.diagnostico_relacion_1.setValue(parseInt(result.id));*/
              this.diagnosticoRelacionado1CodigoSeleccionado = this.IncapacidadDetalles.diagnosticoRelacionUno.cod_diag_relacion_uno;
              this.f_incapacidad.codigo_diagnostico_relacion_1.setValue(this.IncapacidadDetalles.diagnosticoRelacionUno.cod_diag_relacion_uno);
              this.f_incapacidad.descripcion_diagnostico_relacion_1.setValue(this.IncapacidadDetalles.diagnosticoRelacionUno.descripcion);

              this.mostrarOcultarDiagnosticorelacionado1()
            }

            if (!str.includes('"DiagnosticoRealacionDos"') && this.IncapacidadDetalles.diagnosticoRelacionDos != null) {
              /*this.f_incapacidad.diagnostico_relacion_2.setValue(parseInt(item.id));*/
              this.diagnosticoRelacionado2CodigoSeleccionado = this.IncapacidadDetalles.diagnosticoRelacionDos.cod_diag_relacion_dos;
              this.f_incapacidad.codigo_diagnostico_relacion_2.setValue(this.IncapacidadDetalles.diagnosticoRelacionDos.cod_diag_relacion_dos);
              this.f_incapacidad.descripcion_diagnostico_relacion_2.setValue(this.IncapacidadDetalles.diagnosticoRelacionDos.descripcion);

              this.mostrarOcultarDiagnosticorelacionado2()
            }


            if (!str.includes('"CausaAtencion"')) {
              this.f_incapacidad.id_causa.setValue(this.IncapacidadDetalles.causaAtencion.id_causa);
            }


            this.paciente.tipo_documento = this.IncapacidadDetalles.tipoDocumento.cod_tipo_documento;
            this.paciente.numero_documento = this.IncapacidadDetalles.numero_documento_pac;

            this.paciente.primer_nombre = this.IncapacidadDetalles.primer_nombre_pac;
            this.paciente.segundo_nombre = this.IncapacidadDetalles.segundo_nombre_pac;

            this.paciente.primer_apellido = this.IncapacidadDetalles.primer_apellido_pac;
            this.paciente.segundo_apellido = this.IncapacidadDetalles.segundo_apellido_pac;


            this.f_persona.tipoDocumentoPacienteaBuscar.setValue(this.IncapacidadDetalles.tipoDocumento.cod_tipo_documento);
            this.f_persona.numeroDocumentoPacienteaBuscar.setValue(this.IncapacidadDetalles.numero_documento_pac);



      if (this.IncapacidadDetalles.id_modalidad != null && !str.includes('"Modalidad"')) {
        this.f_incapacidad.id_modalidad.setValue(this.IncapacidadDetalles.modalidad.id_modalidad);
      }

      // Se consulta la información del paciente

      let pacienteResult = await this.parametrosIncapacidadesService.getPaciente('/Paciente',
        this.IncapacidadDetalles.tipoDocumento.cod_tipo_documento, this.paciente.numero_documento, this.IncapacidadDetalles.id_incapacidad);

    console.log(pacienteResult)

            //this.parametrosIncapacidadesService.getPaciente('/Paciente',
            //  this.IncapacidadDetalles.tipoDocumento.cod_tipo_documento, this.paciente.numero_documento).subscribe(data => {
    /*   this.PacienteDetalles = data;*/
    this.PacienteDetalles = pacienteResult
    this.paciente.sexo = this.PacienteDetalles.sexo;
      console.log(this.PacienteDetalles);

      this.buscarRelacionPaciente();

    //this.paciente.fecha_nacimiento = this.PacienteDetalles.fecha_nacimiento != null ? this.PacienteDetalles.fecha_nacimiento : new Date(Date.now()), 'yyyy-mm-dd', 'en';
    //console.log(this.paciente);
    //this.paciente.fecha_nacimiento_string = this.getFormattedDate(this.paciente.fecha_nacimiento);
    //console.log(this.PacienteDetalles);

      // Aportante
      //this.paciente.aportantes[0].razon_social = this.PacienteDetalles.aportanteSeleccionado.razon_social;
      //this.paciente.aportantes[0].tipo_documento = this.PacienteDetalles.aportanteSeleccionado.tipo_documento;
      //this.paciente.aportantes[0].numero_documento = this.PacienteDetalles.aportanteSeleccionado.numero_documento;

      
            /*  });*/

      /* }, error => this.error = error);*/

      if (this.IncapacidadDetalles.prorroga && !str.includes('"Prorroga"')) {
        this.prorrogaSelected = true;
        this.seleccionProrroga(true);
        this.buscarIncapacidadesAnteriores(); 
      }
 
      this.spinnerService.hide('spinnerCargaAnulacion');
  }
    catch {
      this.spinnerService.hide('spinnerCargaAnulacion');
}
  }

  async buscarRelacionPaciente() {
    console.log(this.paciente);
    let result = await this.serviciosIntegracionService.consultarPersonaEnServiciosExternos(
      {
        codigoOperador: '',
        tipo_documento: this.paciente.tipo_documento,
        numero_documento: this.paciente.numero_documento,
        bolInfoActual: true
      });
    if (result.relacionPacienteAfiliacionSalud != null) {
      this.paciente.id_regimen = result.relacionPacienteAfiliacionSalud.regimen;
      this.paciente.eps = result.relacionPacienteAfiliacionSalud.codigo_eps;
    }
    console.log(result);
    this.paciente.relacionPacienteAfiliacionSalud = result.relacionPacienteAfiliacionSalud;
    this.paciente.relacionesPacienteAportante = result.relacionesPacienteAportante;

    if (this.IncapacidadDetalles.paciente_encontrado == false) {
      this.paciente.fecha_nacimiento = new Date(this.PacienteDetalles.fecha_nacimiento);
      this.paciente.fecha_nacimiento_string = this.PacienteDetalles.fecha_nacimiento_string;
    }
    else {
      this.paciente.fecha_nacimiento = new Date(result.fecha_nacimiento);
      // let fecha = new Date(this.paciente.fecha_nacimiento_string)
      this.paciente.fecha_nacimiento_string = this.getFormattedDate(this.paciente.fecha_nacimiento);
    }
    
    this.paciente.aportantes = result.aportantes;
    console.log(this.paciente);

    if (this.incapacidadForm.get('id_origen')?.value == '2') {
      this.causaAtencionAnulada = true;
      this.changeValueOrigen();
    }
  }

  recibiRespuestaEditarPaciente(respuesta) {
        
    this.paciente = this.datosDesdeElPadre.pacienteOut;
    this.buscarIncapacidadesAnteriores();
    this.datosDesdeElPadre.ActualizarValoresdeHabilitacion();
    this.datosDesdeElPadre.ActualizarValoresFormulario(this.paciente);

    this.next();
   }


  async buscarIncapacidadesAnteriores(){
    let valuesParam = {tipo_documento_pac : this.paciente.tipo_documento, numero_documento_pac: this.paciente.numero_documento, id_usuario_hercules: this.idUsuarioEntidadRolActual};
    this.listaIncapacidadesAnteriores = await this.parametrosIncapacidadesService.postIncapacidad('/Incapacidad/ConsultaPorPaciente', valuesParam);
    this.incapacidadAnterior = (this.listaIncapacidadesAnteriores != null && this.listaIncapacidadesAnteriores[0] != null) ? this.listaIncapacidadesAnteriores[0] : null; 
    
    console.log('this.listaIncapacidadesAnteriores')
    console.log(this.listaIncapacidadesAnteriores)
    console.log('this.incapacidadAnterior')
    console.log(this.incapacidadAnterior)

    // WS I
    if (this.f_incapacidad.prorroga.value) {
      let incapacidadAnteriorValue = this.f_incapacidad.id_incapacidad_anterior.value;
      let index = this.listaIncapacidadesAnteriores.findIndex(x => x.id_incapacidad === incapacidadAnteriorValue.toString());
      if (index != -1) {
        this.incapacidadAnteriorEvent(this.listaIncapacidadesAnteriores[index]);
      }
      // WS F
    }
    
    //Deshabilitar boton prorroga
    this.deshabilitarSeleccionProrroga = (this.listaIncapacidadesAnteriores != null && this.listaIncapacidadesAnteriores.length > 0) ? false : true;

  }

  /********* Formulario buscar persona *************/
  createPersonaForm() {
    this.personaForm = this.formBuilder.group({
      tipoDocumentoPacienteaBuscar: ['CC', Validators.required ],
      numeroDocumentoPacienteaBuscar: ['', Validators.required ]
    });
  }

  // convenience getter for easy access to form fields
  get f_persona() { return this.personaForm.controls; }

  createIncapacidadForm() {

    let fechaInicial = new Date(Date.now());

    this.incapacidadForm = this.formBuilder.group({
      
      id_incapacidad: [''],

      paciente_encontrado:[false],
      diagnostico_principal: [0, Validators.required ],
      codigo_diagnostico_principal: ['', Validators.required ],
      descripcion_diagnostico_principal: [''],

      diagnostico_relacion_1: [0],
      codigo_diagnostico_relacion_1: [''],
      descripcion_diagnostico_relacion_1: [''],

      diagnostico_relacion_2: [0],
      codigo_diagnostico_relacion_2: [''],
      descripcion_diagnostico_relacion_2: [''],

      id_servicio: ['', Validators.required ],
      id_origen: [1, Validators.required ],
      id_causa :  ['', Validators.required ],
      id_modalidad: ['', Validators.required ],

      retroactiva:  [false],
      id_retroactiva: [{ value: 0, disabled: true }, Validators.required],
      id_trastorno_memoria: [{ value: 0, disabled: true }, Validators.required],

      //fecha_inicio_string: [fechaInicial, Validators.required ],
      //fecha_inicio_string: [this.getFormattedDateTime(fechaInicial), Validators.required ],
      fecha_inicio_string: [formatDate(fechaInicial, 'yyyy-MM-dd', 'en'), Validators.required],
      dias_incapacidad: [0, Validators.required],/*[Validators.required, Validators.max(30)],*/
      fecha_fin_string: ['', Validators.required],

      prorroga:  [false],
      dias_acumulados_prorroga: [0],
      id_incapacidad_anterior: [{ value: '', disabled: true }, Validators.required ],
      descripcion_incapacidad_anterior: [''],

      lugar_expedicion: [''],
      lugar_expedicion_descripcion: [''],
      fecha_expedicion: [fechaInicial, Validators.required ],
      fecha_expedicion_string: [''],

      id_aportante: [{ value: '', disabled: true }, Validators.required ],
      nombre_aportante: [''],
      nombre_arl: [''],

      laboralNoVigente: [false],

    });

  }

  // convenience getter for easy access to form fields
  get f_incapacidad() { return this.incapacidadForm.controls; }

  async buscarPersona(){

    this.submittedPersona = true;
    
    // stop here if form is invalid
    if (this.personaForm.invalid && !this.reexpedir) {
        return;
    }

    this.spinnerService.show('spinnerConsultaPaciente');
    try{
      let result = await this.serviciosIntegracionService.consultarPersonaEnServiciosExternos(
      { 
        codigoOperador: '',
        tipo_documento: this.f_persona.tipoDocumentoPacienteaBuscar.value,
        numero_documento: this.f_persona.numeroDocumentoPacienteaBuscar.value,
        bolInfoActual: true
        });
      this.spinnerService.hide('spinnerConsultaPaciente');

      //si encuentra un codigo de error es porque fallo la consulta
      if(result.codigo){
        
        this.datosDesdeElPadre.deshabilitar =  this.deshabilitarComponentePaciente = false;
        
        this.paciente = this.inicializarPaciente();
        this.paciente.tipo_documento = this.f_persona.tipoDocumentoPacienteaBuscar.value;
        this.paciente.numero_documento = this.f_persona.numeroDocumentoPacienteaBuscar.value;

        // this.paciente.fecha_nacimiento = new Date("1990-01-01");  
        // this.paciente.fecha_nacimiento_string = this.getFormattedDate(this.paciente.fecha_nacimiento);;  
        
        this.f_incapacidad.paciente_encontrado.setValue(false);
        await this.Alertas.alertaInformativa('Advertencia','Paciente no encontrado en las bases de datos consultadas','Cerrar');   

      } else {

        //Paciente encontrado pero don defuncion
        if(result.numeroCertificadoDefuncion != null && result.numeroCertificadoDefuncion != ''){
          await this.Alertas.alertaInformativa('Advertencia','El paciente se encuentra registrado con certificado de defunción. No se puede expedir la incapacidad.','Cerrar');   
          this.spinnerService.hide('spinnerConsultaPaciente');
          return;
        }
        
        //Paciente encontrado
        this.datosDesdeElPadre.deshabilitar = this.deshabilitarComponentePaciente = true;
        this.paciente = result;   

        if(result.relacionPacienteAfiliacionSalud != null){
          this.paciente.id_regimen = result.relacionPacienteAfiliacionSalud.regimen; 
          this.paciente.eps = result.relacionPacienteAfiliacionSalud.codigo_eps; 
        }

        this.paciente.fecha_nacimiento = new Date(result.fecha_nacimiento);    
        // let fecha = new Date(this.paciente.fecha_nacimiento_string)
        this.paciente.fecha_nacimiento_string = this.getFormattedDate(this.paciente.fecha_nacimiento);

        if(!this.paciente.info_consulta.includes("SIPE")){
            this.f_incapacidad.paciente_encontrado.setValue(true);
        }
        this.buscarIncapacidadesAnteriores();
       
      }
      this.spinnerService.hide('spinnerConsultaPaciente');
      this.next();

      if(!this.paciente.info_consulta.includes("SIPE")){
        this.datosDesdeElPadre.ActualizarValoresdeHabilitacion();
      }
      this.datosDesdeElPadre.ActualizarValoresFormulario(this.paciente);      
     
    }catch{
      this.spinnerService.hide('spinnerConsultaPaciente');
    }
  }
  
  /****** Stepper ******/

  next() {
    this.stepper.next();
    return false;
  }

  goBack(){
    this.stepper.previous();
  }

  refresh(): void { 
    location.href = this.baseUrlSIIN + '/incapacidades/registrar-incapacidad/'
  }

  /*********** Diagnostico prinical eventos **************/
  
  eventoSeleccionDiagnostico(item:any) {
    
    if(item == null){
      this.f_incapacidad.diagnostico_principal.setValue(0);
      this.diagnosticoCodigoSeleccionado = '';
      this.f_incapacidad.codigo_diagnostico_principal.setValue('');
      this.f_incapacidad.descripcion_diagnostico_principal.setValue('');

      this.showCountryErrorMessage = true;      
    }else{
      this.f_incapacidad.diagnostico_principal.setValue(parseInt(item.id));
      this.diagnosticoCodigoSeleccionado = item.codigo;
      this.f_incapacidad.codigo_diagnostico_principal.setValue(item.codigo);
      this.f_incapacidad.descripcion_diagnostico_principal.setValue(item.descripcion);

      this.showCountryErrorMessage = false;
    }
  }

  async verificarSeleccion(codigoSeleccionado: any){

    if(typeof codigoSeleccionado === 'string'){

      this.listaDiagnosticosCie10_principal = await this.parametrosIncapacidadesService.get('/Cie10/' + codigoSeleccionado);
      let diagnosticoEncontrado = this.listaDiagnosticosCie10_principal.find(function(element) {
        return element.codigo == codigoSeleccionado;
      });

      this.eventoSeleccionDiagnostico(diagnosticoEncontrado);
    }

  }

  async cambiarBusquedaDiagnostico(search: string) {
     this.listaDiagnosticosCie10_principal = await this.parametrosIncapacidadesService.get('/Cie10/' + search);
  }

  openModalDiagnostico(){
   
    const modalRef = this.modalService.open(ModalListaDiagnosticoComponent,this.optionsModal);
    modalRef.componentInstance.dataIn = {name: '', id: 0};
    modalRef.result.then((result) => {
      if (result) {
        this.f_incapacidad.diagnostico_principal.setValue(parseInt(result.id));
        this.f_incapacidad.codigo_diagnostico_principal.setValue(result.codigo);
        this.diagnosticoCodigoSeleccionado = result.codigo;
        this.f_incapacidad.descripcion_diagnostico_principal.setValue(result.descripcion);
        this.showCountryErrorMessage = false;
      }
    });
  }
 
  /*********** Diagnostico relacionado 1 eventos **************/
  
  eventoSeleccionDiagnosticoRelacionado1(item:any) {    
    if(item == null){
      this.f_incapacidad.diagnostico_relacion_1.setValue(0);
      this.diagnosticoRelacionado1CodigoSeleccionado = '';
      this.f_incapacidad.diagnostico_relacion_1.setValue('');
      this.f_incapacidad.descripcion_diagnostico_relacion_1.setValue('');   
    }else{
      this.f_incapacidad.diagnostico_relacion_1.setValue(parseInt(item.id));
      this.diagnosticoRelacionado1CodigoSeleccionado = item.codigo;
      this.f_incapacidad.codigo_diagnostico_relacion_1.setValue(item.codigo);
      this.f_incapacidad.descripcion_diagnostico_relacion_1.setValue(item.descripcion);
    }
  }

  async verificarSeleccionDiagnosticoRelacionado1(codigoSeleccionado: any){

    if(typeof codigoSeleccionado === 'string'){

      this.listaDiagnosticosCie10_relacion_1 = await this.parametrosIncapacidadesService.get('/Cie10/' + codigoSeleccionado);
      let diagnosticoEncontrado = this.listaDiagnosticosCie10_relacion_1.find(function(element) {
        return element.codigo == codigoSeleccionado;
      });

      this.eventoSeleccionDiagnosticoRelacionado1(diagnosticoEncontrado);
    }

  }

  async cambiarBusquedaDiagnosticoRelacionado1(search: string) {
     this.listaDiagnosticosCie10_relacion_1 = await this.parametrosIncapacidadesService.get('/Cie10/' + search);
  }

  openModalDiagnosticoRelacionado1(){
   
    const modalRef = this.modalService.open(ModalListaDiagnosticoComponent,this.optionsModal);
    modalRef.componentInstance.dataIn = {name: '', id: 0};
    modalRef.result.then((result) => {
      if (result) {

        this.f_incapacidad.diagnostico_relacion_1.setValue(parseInt(result.id));
        this.f_incapacidad.codigo_diagnostico_relacion_1.setValue(result.codigo);
        this.diagnosticoRelacionado1CodigoSeleccionado = result.codigo;
        this.f_incapacidad.descripcion_diagnostico_relacion_1.setValue(result.descripcion);
      }
    });
  }

   /*********** Diagnostico relacionado 2 eventos **************/
  
   eventoSeleccionDiagnosticoRelacionado2(item:any) {    
    if(item == null){
      this.f_incapacidad.diagnostico_relacion_2.setValue(0);
      this.diagnosticoRelacionado2CodigoSeleccionado = '';
      this.f_incapacidad.diagnostico_relacion_2.setValue('');
      this.f_incapacidad.descripcion_diagnostico_relacion_2.setValue('');   
    }else{
      this.f_incapacidad.diagnostico_relacion_2.setValue(parseInt(item.id));
      this.diagnosticoRelacionado2CodigoSeleccionado = item.codigo;
      this.f_incapacidad.codigo_diagnostico_relacion_2.setValue(item.codigo);
      this.f_incapacidad.descripcion_diagnostico_relacion_2.setValue(item.descripcion);
    }
  }

  async verificarSeleccionDiagnosticoRelacionado2(codigoSeleccionado: any){

    if(typeof codigoSeleccionado === 'string'){

      this.listaDiagnosticosCie10_relacion_2 = await this.parametrosIncapacidadesService.get('/Cie10/' + codigoSeleccionado);
      let diagnosticoEncontrado = this.listaDiagnosticosCie10_relacion_2.find(function(element) {
        return element.codigo == codigoSeleccionado;
      });

      this.eventoSeleccionDiagnosticoRelacionado2(diagnosticoEncontrado);
    }

  }

  async cambiarBusquedaDiagnosticoRelacionado2(search: string) {
     this.listaDiagnosticosCie10_relacion_2 = await this.parametrosIncapacidadesService.get('/Cie10/' + search);
  }

  openModalDiagnosticoRelacionado2(){
   
    const modalRef = this.modalService.open(ModalListaDiagnosticoComponent,this.optionsModal);
    modalRef.componentInstance.dataIn = {name: '', id: 0};
    modalRef.result.then((result) => {
      if (result) {

        this.f_incapacidad.diagnostico_relacion_2.setValue(parseInt(result.id));
        this.f_incapacidad.codigo_diagnostico_relacion_2.setValue(result.codigo);
        this.diagnosticoRelacionado2CodigoSeleccionado = result.codigo;
        this.f_incapacidad.descripcion_diagnostico_relacion_2.setValue(result.descripcion);
      }
    });
  }

  /*********** Modal Aportantes **************/
  async openModalAportantes(){
    const modalRef = this.modalService.open(ModalAportantesComponent, this.optionsModal);
    console.log(this.paciente.aportantes)
    modalRef.componentInstance.dataIn = {
      name: '', 
      id: 0, 
      aportantes : this.paciente.aportantes,
      relacionesPacienteAportante : this.paciente.relacionesPacienteAportante};     
    modalRef.result.then(async (result) => {

      this.paciente.aportanteSeleccionado = result;
      if(this.paciente.relacionesPacienteAportante != null){
        this.paciente.relacionPacienteAportanteSeleccionada = this.paciente.relacionesPacienteAportante.find(x=>x.tipo_documento_ap == this.paciente.aportanteSeleccionado.tipo_documento && x.numero_documento_ap == this.paciente.aportanteSeleccionado.numero_documento);
      }

      if(this.paciente.aportanteSeleccionado.tipo_documento != null && this.paciente.aportanteSeleccionado.tipo_documento != ''){
        this.f_incapacidad.id_aportante.setValue(this.paciente.aportanteSeleccionado.tipo_documento + '-' + this.paciente.aportanteSeleccionado.numero_documento);
      }else{
        this.f_incapacidad.id_aportante.setValue('');
      }

      this.f_incapacidad.nombre_aportante.setValue(this.paciente.aportanteSeleccionado.razon_social);

      if(this.paciente.relacionPacienteAportanteSeleccionada != null){
        this.f_incapacidad.nombre_arl.setValue(this.paciente.relacionPacienteAportanteSeleccionada.desc_administradora_arl);
      }

      
    });
  } 

    /*********** Modal Incapacidades anteriores **************/
    async openModalIncapacidadesAnteriores(){
      const modalRef = this.modalService.open(ModalListaIncapacidadesAnterioresComponent,this.optionsModal);
      modalRef.componentInstance.dataIn = { name: '', id: 0, listaIncapacidadesAnteriores : this.listaIncapacidadesAnteriores};
      modalRef.result.then(async (result) => {
        console.log(result);
        this.incapacidadAnteriorEvent(result);
      });
    }
  
    async calcularNuevasFechaSegunProrrogaSeleccionada(fecha_final_string){
      let nuevaFechaInicioConsecutiva = new Date(fecha_final_string);
      nuevaFechaInicioConsecutiva.setDate(nuevaFechaInicioConsecutiva.getDate() + 2);//sumar 1 dia por la conversion y uno mas para el calculo
      this.f_incapacidad.fecha_inicio_string.setValue(this.getFormattedDate(nuevaFechaInicioConsecutiva));
      return true;
    }
  
    // WS I
  
    async incapacidadAnteriorEvent(result) {
      if (result.id_incapacidad != null && result.id_incapacidad != 0) {

        //Validaciones
        if(this.f_incapacidad.prorroga.value){ //prospectiva
        
          const esValido = await this.validacionesProrrogaAdicionales(result);
          if(!esValido){
            return;
          }
        }


        this.f_incapacidad.id_incapacidad_anterior.setValue(result.id_incapacidad);
        this.f_incapacidad.descripcion_incapacidad_anterior.setValue(this.getFormattedDateEstandarfromDate(result.fecha_inicio)
          + ' - ' + this.getFormattedDateEstandarfromDate(result.fecha_fin)
          + ' - ' + result.diagnostico.cod_diagnostico
          + ((result.diagnosticoRelacionUno != null && result.diagnosticoRelacionUno.cod_diag_relacion_uno != null) ? ' - ' + result.diagnosticoRelacionUno.cod_diag_relacion_uno : '')
          + ((result.diagnosticoRelacionDos != null && result.diagnosticoRelacionDos.cod_diag_relacion_dos != null) ? ' - ' + result.diagnosticoRelacionDos.cod_diag_relacion_dos : ''));
  
        this.incapacidadAnterior = result;
  
        await this.Alertas.alertaInformativa('Advertencia', 'Verificar las fechas según la prórroga seleccionada', 'Cerrar');
  
        //Validaciones importantes
        await this.calcularNuevasFechaSegunProrrogaSeleccionada(result.fecha_fin_string);
        await this.calcularFechaFinal();
  
      } else {
        this.f_incapacidad.id_incapacidad_anterior.setValue(null);
        this.f_incapacidad.descripcion_incapacidad_anterior.setValue('');
        this.incapacidadAnterior = null;
      }
    }
  
    // WS F

  /*********** Modal Confirmacion Incapacidad **************/

  async validarSeleccionGrupoServicioMotivoInternacion() : Promise<boolean> {
    if( this.f_incapacidad.id_servicio.value != '0' && this.f_incapacidad.id_retroactiva.value != '0' && (this.f_incapacidad.id_servicio.value == this._id_servicio_internacion || this.f_incapacidad.id_retroactiva.value == '1')){
      if(this.f_incapacidad.id_retroactiva.value == '1' && this.f_incapacidad.id_servicio.value != this._id_servicio_internacion){
        return true;
      }
    }
    return false;
  }

  async abrirModalConfirmacion(modeloIncapacidad: IIncapacidad, modeloPaciente: IPacienteModel) {

    this.submittedIncapacidad = true;

    console.log(modeloIncapacidad);
    
    if(this.diagnosticoCodigoSeleccionado == ''){
      this.showCountryErrorMessage = true;
      return;
    }
    this.showCountryErrorMessage = false;
    
    // stop here if form is invalid
    if (this.incapacidadForm.invalid) {
      return;
    }

    let validarServicioInternacion = await this.validarSeleccionGrupoServicioMotivoInternacion();
    if(validarServicioInternacion){
      await this.Alertas.alertaInformativa('Advertencia','Grupo de Servicios diferente a Internación','Cerrar');
      return;
    } 
    
    //Si hay prorroga se deben validar los diagnosticos principales y el # de dias de diferencia
    if(this.f_incapacidad.prorroga.value){

      if(this.f_incapacidad.diagnostico_principal.value == ''){
        await this.Alertas.alertaInformativa('Advertencia','Debe seleccionar un diagnóstico principal para continuar','Cerrar');
        return;
      }

      if(this.f_incapacidad.id_origen.value != this.incapacidadAnterior.id_origen){
        await this.Alertas.alertaInformativa('Advertencia','Para la prórroga el origen de la incapacidad actual debe coincidir con el origen de la incapacidad anterior','Cerrar');
        return;
      }

      if(this.f_incapacidad.diagnostico_principal.value != '' && this.incapacidadAnterior.diagnostico.id_diagnosticos != null){
          
          const coincideDiagnosticoPrincipal = this.f_incapacidad.diagnostico_principal.value != 0 &&
                                              (this.f_incapacidad.diagnostico_principal.value == this.incapacidadAnterior.diagnostico.id_diagnosticos 
                                              || this.f_incapacidad.diagnostico_principal.value == (this.incapacidadAnterior.diagnosticoRelacionUno != null ? this.incapacidadAnterior.diagnosticoRelacionUno.id_diagnosticos : 0) 
                                              || this.f_incapacidad.diagnostico_principal.value == (this.incapacidadAnterior.diagnosticoRelacionDos != null ? this.incapacidadAnterior.diagnosticoRelacionDos.id_diagnosticos : 0) ); 

          // const coincideDiagnosticoRelacion1 = this.f_incapacidad.diagnostico_relacion_1.value != 0 &&
          //                                     (this.f_incapacidad.diagnostico_relacion_1.value == this.incapacidadAnterior.diagnostico_principal 
          //                                     || this.f_incapacidad.diagnostico_relacion_1.value == this.incapacidadAnterior.diagnostico_relacion_1 
          //                                     || this.f_incapacidad.diagnostico_relacion_1.value == this.incapacidadAnterior.diagnostico_relacion_2);

          // const coincideDiagnosticoRelacion2 = this.f_incapacidad.diagnostico_relacion_2.value != 0 &&
          //                                     (this.f_incapacidad.diagnostico_relacion_2.value == this.incapacidadAnterior.diagnostico_principal 
          //                                     || this.f_incapacidad.diagnostico_relacion_2.value == this.incapacidadAnterior.diagnostico_relacion_1 
          //                                     || this.f_incapacidad.diagnostico_relacion_2.value == this.incapacidadAnterior.diagnostico_relacion_2);
            
          if(coincideDiagnosticoPrincipal == false /*&& coincideDiagnosticoRelacion1 == false && coincideDiagnosticoRelacion2 == false*/){
            await this.Alertas.alertaInformativa('Advertencia','El diagnóstico de la incapacidad actual no coinciden con los diagnóstico principal y relacionados de la incapacidad anterior','Cerrar');
            return;
          }
      }

      //validaciones de Prorroga adicionales
      const esValido = await this.validacionesProrrogaAdicionales(this.incapacidadAnterior);
      if(!esValido){
        return;
      }
     
    }
    this.determinarFechaIncapacidadActualEntreRango(modeloIncapacidad, modeloPaciente);
  
  }

  async validacionesProrrogaAdicionales(result){

      if(this.f_incapacidad.diagnostico_principal.value == ''){
        await this.Alertas.alertaInformativa('Advertencia','Debe seleccionar un diagnóstico principal para continuar','Cerrar');
        return false;
      }

      //# de dias de diferencia
      let calculosdeDiasDiferenciaEntreIncapacidadActualYAnterior = this.calcularDiasDiferenciaEntreIncapacidadActualYAnterior(new Date(this.f_incapacidad.fecha_inicio_string.value),this.incapacidadAnterior);
      if(calculosdeDiasDiferenciaEntreIncapacidadActualYAnterior >= 30){
        await this.Alertas.alertaInformativa('Advertencia','Prorroga no viable - La fecha fin de la incapacidad anterior supera 30 días'/*'La incapacidad tiene '+ calculosdeDiasDiferenciaEntreIncapacidadActualYAnterior + ' días de diferencia con la anterior'*/,'Cerrar');
        return false;
      }

      // let fechaInicial = new Date(this.f_incapacidad.fecha_inicio_string.value);
      // fechaInicial.setDate(fechaInicial.getDate()+1);  
      // let fechaActualmenos30 = new Date(Date.now());
      // fechaActualmenos30.setDate(fechaActualmenos30.getDate()-29);    
      // if(fechaInicial.getTime() < fechaActualmenos30.getTime()){
      //   await this.Alertas.alertaInformativa('Advertencia','Prorroga no viable - La fecha fin de la incapacidad anterior supera 30 días','Cerrar');
      //   return false;
      // }

      //fechaPropectivaMinima.setDate(fechaPropectivaMinima.getDate()+1-8);
      let fecha=new Date(Date.now());
      let fechaActual = new Date(fecha.getFullYear()+"-"+(fecha.getMonth()+1)+"-"+fecha.getDate());//new Date(Date.now());
      fechaActual.setDate(fechaActual.getDate()); 
      let fechaFinincapacidadAnterior = new Date(result.fecha_fin_string);
      fechaFinincapacidadAnterior.setDate(fechaFinincapacidadAnterior.getDate()+1);
      let fechaPropectivaMinima = new Date(result.fecha_fin_string);
      fechaPropectivaMinima.setDate(fechaPropectivaMinima.getDate()+1);

      let diasDiferencia = parseInt(Math.ceil((fechaActual.getTime() - fechaPropectivaMinima.getTime())/(1000 * 3600 * 24))+'',10);
      console.log('diasDiferencia:'+diasDiferencia)
      if(fechaActual.getDate() < fechaFinincapacidadAnterior.getDate()){
          if(diasDiferencia <= -7){
            await this.Alertas.alertaInformativa('Advertencia','La incapacidad con prórroga prospectiva no puede ser mayor a 8 dias.','Cerrar');
            return false;
          }
      }

      return true;
  }

  async guardarIncapacidad(modeloIncapacidad: IIncapacidad, modeloPaciente: IPacienteModel){

    //datos adicionales obtenidos de las listas y modelos para informacion paciente
    let origenEncontrado = this.listaOrigen.find(function(element:any) {
      return element.id_origen == modeloIncapacidad.id_origen;
    })

    let causaatencionEncontrado = this.listaCausaAtencion.find(function(element:any) {
      return element.id_causa == modeloIncapacidad.id_causa;
    })

    let sexoEncontrado = this.listaGenero.find(function(element:any) {
      return element.cod_sexo == modeloPaciente.sexo;
    })

    let ciudadEncontrado = this.listaMunicipios.find(function(element:any) {
      return element.cod_municipio == modeloPaciente.cod_mun_residencia;
    })

    let departamentoEncontrado = this.listaDepartamentos.find(function(element:any) {
      return element.cod_depto == modeloPaciente.cod_depto_residencia;
    })

    /*let regimenEncontrado = this.listaDepartamentos.find(function(element:any) {
      return element.cod_depto == modeloPaciente.cod_depto_residencia;
    })*/

    this.paciente.origen_pac_descripcion = (origenEncontrado!= null) ? origenEncontrado.descripcion : '';
    this.paciente.retroactiva_pac_descripcion=modeloIncapacidad.retroactiva ? 'Si' : 'No';
    this.paciente.causaatencion_pac_descripcion= (causaatencionEncontrado!= null) ? causaatencionEncontrado.descripcion : '';
    this.paciente.sexo_descripcion = (sexoEncontrado!= null) ? sexoEncontrado.descripcion : '';
    this.paciente.ciudad_residencia_descripcion = (ciudadEncontrado!= null) ? ciudadEncontrado.nom_ciudad : '';
    this.paciente.depto_residencia_descripcion = (departamentoEncontrado!= null) ? departamentoEncontrado.nom_depto : '';
    //this.paciente.regimen_descripcion = (regimenEncontrado!=null)?regimenEncontrado.descripcion:'';
    
    //Datos adicionales incapacidad
    let fecha_ini = new Date(modeloIncapacidad.fecha_inicio_string);
    fecha_ini.setDate(fecha_ini.getDate()+1);
    modeloIncapacidad.fecha_inicio = fecha_ini;

    let fecha_fin = new Date(modeloIncapacidad.fecha_fin_string);
    fecha_fin.setDate(fecha_fin.getDate()+1);
    modeloIncapacidad.fecha_fin = fecha_fin;
  
    const modalRef = this.modalService.open(ModalConfirmacionComponent,this.optionsModal);
    modalRef.componentInstance.dataIn = {name: '', id: 0, 'incapacidad_data':this.incapacidadForm.value, 'paciente_data': this.paciente};
    await modalRef.result.then(async (result) => {
        console.log(result)

        if(result.resultado == 'si'){
          console.log('confirmado')
          //Datos tomados de paciente
          modeloIncapacidad.tipo_documento_pac = this.paciente.tipo_documento          
          modeloIncapacidad.numero_documento_pac = this.paciente.numero_documento;
          //modeloIncapacidad.paciente_encontrado = true;
          modeloIncapacidad.primer_nombre_pac = this.paciente.primer_nombre;
          modeloIncapacidad.segundo_nombre_pac =     this.paciente.segundo_nombre;
          modeloIncapacidad.primer_apellido_pac = this.paciente.primer_apellido;
          modeloIncapacidad.segundo_apellido_pac = this.paciente.segundo_apellido;
          
          modeloIncapacidad.sexo_pac = this.paciente.sexo;
          modeloIncapacidad.fecha_expedicion_string = this.getFormattedDate(new Date(Date.now()));//this.getFormattedDateTime(new Date(Date.now()));

          //modelo.fecha_nacimiento_pac = "25/05/1990";
          const  perfilUbicacion: IPerfilComple = JSON.parse(localStorage.getItem('complementario2')) || '';
          modeloIncapacidad.lugar_expedicion = perfilUbicacion.codDepto + perfilUbicacion.codMunicipio;
          modeloIncapacidad.lugar_expedicion_descripcion = this.lugardeExpedicionEntidad;
          
          //WS I
          modeloIncapacidad.id_incapacidad_anulado = this.paciente.id_incapacidad_anulado;
          modeloIncapacidad.proviene_anulado = this.proviene_anulado;
          //WS F
          
         
          let modelo = new DatosRegistroIncapacidadDTO();
          modelo.incapacidad = modeloIncapacidad;          
          modelo.paciente = this.paciente;

          
          //modelo.aportante = this.aportante;//this.paciente.aportantes[0];
          let result = await this.parametrosIncapacidadesService.guardarDatosIncapacidad(modelo); 

          console.log(result);
          if(result.codigo){

            await this.Alertas.alertaInformativa('Advertencia',result.mensaje,'Cerrar');
            return;
          }
          //let result = await this.parametrosIncapacidadesService.post('/incapacidad', modelo);
          
          modeloIncapacidad.id_incapacidad = result.id_incapacidad;
          this.f_incapacidad.id_incapacidad.setValue(result.id_incapacidad);
          this.next();
      }else{
        console.log('no confirmado')
      }
    });
  }

  
  mostrarOcultarDiagnosticorelacionado1() {
      this.esVisibleDiagnosticorelacionado1 = ! this.esVisibleDiagnosticorelacionado1;
  }

  mostrarOcultarDiagnosticorelacionado2() {
    this.esVisibleDiagnosticorelacionado2 = ! this.esVisibleDiagnosticorelacionado2;
  }

  /************* Fechas y dias Calculados ***************/

  async calcularFechaFinal2(){
    if(!this.deshabilitarSeleccionProrroga){
      return;
    }
  }

  async calcularFechaFinal(){

    

    if(this.f_incapacidad.dias_incapacidad.value < 1 || this.f_incapacidad.dias_incapacidad.value > 30)
    {
      this.f_incapacidad.dias_incapacidad.setValue(0);
    }

    if(this.f_incapacidad.fecha_inicio_string.value !=null && this.f_incapacidad.dias_incapacidad.value != null){
      let fechaInicial = new Date(this.f_incapacidad.fecha_inicio_string.value);
      fechaInicial.setDate(fechaInicial.getDate()+1);

      if(this.f_incapacidad.retroactiva.value){
        if(fechaInicial.getTime() < this.fechaMinimaIncapacidad){
          await this.Alertas.alertaInformativa('Advertencia','La fecha inicial de la incapacidad no puede ser anterior a mas de 30 días','Cerrar');
          
          this.f_incapacidad.fecha_inicio_string.setValue(this.getFormattedDate(new Date(Date.now())));
          fechaInicial = new Date(this.f_incapacidad.fecha_inicio_string.value);
          fechaInicial.setDate(fechaInicial.getDate()+1);
        }
      }
      else if (!this.f_incapacidad.prorroga.value){
        this.f_incapacidad.fecha_inicio_string.setValue(this.getFormattedDate(new Date(Date.now())));
        fechaInicial = new Date(this.f_incapacidad.fecha_inicio_string.value);
        fechaInicial.setDate(fechaInicial.getDate()+1);
      }


      let diasEnMilisegundos = (this.f_incapacidad.dias_incapacidad.value != 0 ? (this.f_incapacidad.dias_incapacidad.value-1) : 0) * 1000 * 60 * 60 * 24;
      let sumaFechas = fechaInicial.getTime() + diasEnMilisegundos; //getTime devuelve milisegundos de esa fecha

      // if(sumaFechas < fechaInicial.getTime()){
      //   alert('fecha menor')
      //   sumaFechas = fechaInicial.getTime();
      // }

      let fechaFinal = new Date(sumaFechas);
      let fechaFinalString = this.getFormattedDate(fechaFinal);          

      this.f_incapacidad.fecha_inicio_string.setValue(this.getFormattedDate(fechaInicial));
      this.f_incapacidad.fecha_fin_string.setValue(fechaFinalString);

      console.log(this.f_incapacidad.fecha_inicio_string.value); 
      console.log(this.f_incapacidad.fecha_fin_string.value); 

      this.calcularDiasIncapacidadRetroactiva(fechaInicial);
     
      if(this.f_incapacidad.prorroga.value){
        await this.calcularDiasDeProrroga(this.incapacidadAnterior);
      }else{
        this.f_incapacidad.dias_acumulados_prorroga.setValue(0);
      }
    }
  }

  async calcularDiasIncapacidadRetroactiva(fechaInico:Date){
    if(this.f_incapacidad.retroactiva.value && this.f_incapacidad.id_servicio.value == this._id_servicio_internacion){
      let fechaSistema = new Date(Date.now());
      let diff = fechaSistema.getTime() - fechaInico.getTime();
      let dias_retroactiva= Math.round(diff/(1000*60*60*24));
      console.log('dias_retroactiva:'+dias_retroactiva)
      if(dias_retroactiva>=30){
        await this.Alertas.alertaInformativa('Advertencia','La incapacidad tiene '+ dias_retroactiva + ' días de retroactiva','Cerrar');
      }
    }
  }

  public  calcularDiasDiferenciaEntreIncapacidadActualYAnterior(fechaInico:Date, incapacidadAnterior:any): number{
      let fechaFinincapacidadAnterior = new Date(incapacidadAnterior.fecha_fin_string);
      let diff = fechaInico.getTime() - fechaFinincapacidadAnterior.getTime();
      let dias_diferencia_entre_incapacidades= Math.round(diff/(1000*60*60*24));
      console.log('dias_diferencia_entre_incapacidades:' + dias_diferencia_entre_incapacidades)
      return dias_diferencia_entre_incapacidades;
  }

  async calcularDiasDeProrroga(incapacidadAnterior:any){
    if(incapacidadAnterior && this.f_incapacidad.dias_incapacidad.value != null){

      //verificar si la anterior incapacidad ya tiene prorroga, si la tiene debe calcular los dias con los dias acumulados
      if(incapacidadAnterior.prorroga){
        this.f_incapacidad.dias_acumulados_prorroga.setValue(incapacidadAnterior.dias_acumulados_prorroga + this.f_incapacidad.dias_incapacidad.value);
      }
      //verificar si la anterior incapacidad ya tiene prorroga, sino la tiene debe calcular los dias con los dias de incapacidad
      else{
        this.f_incapacidad.dias_acumulados_prorroga.setValue(incapacidadAnterior.dias_incapacidad + this.f_incapacidad.dias_incapacidad.value);
      }
      
    }else{
      this.f_incapacidad.dias_acumulados_prorroga.setValue(0);
    }
  }

  /*********** Eventos selects y radiobuttons ********/
  public changeValueGrupoServicio() {
    // if(this.f_incapacidad.id_servicio.value != this._id_servicio_internacion){
    //   let fechaInicial = new Date(Date.now());
    //   this.f_incapacidad.fecha_inicio_string.setValue(this.getFormattedDate(fechaInicial));
    // }else{
    //   this.f_incapacidad.fecha_inicio_string.setValue('');
    // }

    if(this.f_incapacidad.prorroga.value == false){
      let fechaInicial = new Date(Date.now());
      this.f_incapacidad.fecha_inicio_string.setValue(this.getFormattedDate(fechaInicial));
    }
  }

  public changeValueRetroactivaMotivoR() {
    
    if(this.f_incapacidad.id_retroactiva.value == 2){
      this.f_incapacidad.id_trastorno_memoria.enable();
      this.tieneTrastornoMemoria = true;
    }
    else{
      this.f_incapacidad.id_trastorno_memoria.setValue('');
      this.f_incapacidad.id_trastorno_memoria.disable();
      this.tieneTrastornoMemoria = false;
    }
    console.log('change select ret')
   
  }



  async changeValueOrigen() {
    
    this.causaAtencionAnulada == false ? this.f_incapacidad.id_causa.setValue('') : "";
    /* this.f_incapacidad.id_causa.setValue('');*/
    this.listaCausaAtencionByOrigen = this.listaCausaAtencion.filter(x => x.id_origen == this.f_incapacidad.id_origen.value);
    
    this.f_incapacidad.laboralNoVigente.setValue(false);

    if(this.f_incapacidad.id_origen.value == 2){
      
      //Aportante obligatorio cuando existen aportantes en paciente de SAT
      if(this.paciente.aportantes != null && this.paciente.aportantes.length > 0){
        this.f_incapacidad.id_aportante.enable();
      }else{
        await this.Alertas.alertaInformativa('Advertencia','La incapacidad se guardará sin aportantes y ARL sasociados','Cerrar');
     
        this.f_incapacidad.id_aportante.disable();
        this.f_incapacidad.laboralNoVigente.setValue(true);
      }

      if(this.paciente.aportantes != null && this.paciente.aportantes.length == 1){ 
        
        this.paciente.aportanteSeleccionado = this.paciente.aportantes[0];
        this.paciente.relacionPacienteAportanteSeleccionada = this.paciente.relacionesPacienteAportante != null ? this.paciente.relacionesPacienteAportante[0] : null;

        if(this.paciente.aportanteSeleccionado.tipo_documento != null && this.paciente.aportanteSeleccionado.tipo_documento != ''){
          this.f_incapacidad.id_aportante.setValue(this.paciente.aportanteSeleccionado.tipo_documento + '-' + this.paciente.aportanteSeleccionado.numero_documento);
        }else{
          this.f_incapacidad.id_aportante.setValue('');
        }
        this.f_incapacidad.nombre_aportante.setValue(this.paciente.aportanteSeleccionado.razon_social);
      }else{
        this.paciente.aportanteSeleccionado = null;
        this.paciente.relacionPacienteAportanteSeleccionada = null;
        this.f_incapacidad.id_aportante.setValue('');
        this.f_incapacidad.nombre_aportante.setValue('');
      }

      if (this.proviene_anulado && this.PacienteDetalles.aportanteSeleccionado?.numero_documento != null) {
        console.log(this.paciente);
        console.log(this.PacienteDetalles)
        //this.f_incapacidad.id_aportante.setValue(this.PacienteDetalles.aportanteSeleccionado.tipo_documento + '-' + this.PacienteDetalles.aportanteSeleccionado.numero_documento);
        if(this.paciente.aportanteSeleccionado.tipo_documento != null && this.paciente.aportanteSeleccionado.tipo_documento != ''){
          this.f_incapacidad.id_aportante.setValue(this.paciente.aportanteSeleccionado.tipo_documento + '-' + this.paciente.aportanteSeleccionado.numero_documento);
        }else{
          this.f_incapacidad.id_aportante.setValue('');
        }
        this.f_incapacidad.nombre_aportante.setValue(this.PacienteDetalles.aportanteSeleccionado.razon_social);
        this.paciente.aportanteSeleccionado = this.PacienteDetalles.aportanteSeleccionado
        this.paciente.relacionPacienteAportanteSeleccionada = this.paciente.relacionesPacienteAportante?.find(x => x.tipo_documento_ap == this.paciente.aportanteSeleccionado.tipo_documento && x.numero_documento_ap == this.paciente.aportanteSeleccionado.numero_documento);
      }

      this.tieneOrigenLaboral = true;
    }else{
      this.paciente.aportanteSeleccionado = null;
      this.paciente.relacionPacienteAportanteSeleccionada = null;
      this.f_incapacidad.id_aportante.setValue('');
      this.f_incapacidad.nombre_aportante.setValue('');      
      this.tieneOrigenLaboral = false;
      this.f_incapacidad.id_aportante.disable();
    }

  }

  async changeValueCausaAtencion(e) {
    if(this.f_incapacidad.retroactiva.value && this.f_incapacidad.id_retroactiva.value == 3){

      if((this.f_incapacidad.id_origen.value == 1 && this.f_incapacidad.id_causa.value != 2) || (this.f_incapacidad.id_origen.value == 2 && this.f_incapacidad.id_causa.value != 26)){
        await this.Alertas.alertaInformativa('Advertencia','La causa motivo debe corresponder on el origen','Cerrar');
      }
      return;
    }
  }     

  public seleccionRetroactiva(value:boolean) {    
    this.tieneListaMotivoRetroactivo = value;
    this.f_incapacidad.retroactiva.setValue(value);

    this.f_incapacidad.id_retroactiva.setValue('');
    this.f_incapacidad.id_servicio.setValue('');      
    this.f_incapacidad.id_modalidad.setValue('');

    if(value){
      this.f_incapacidad.id_retroactiva.enable();
      this.f_incapacidad.id_trastorno_memoria.enable();

      let dateValidacionDias = new Date();
      dateValidacionDias.setDate(dateValidacionDias.getDate() - 29); //Ajuste detectado -30 -29
      this.fechaMinimaIncapacidad = dateValidacionDias.getTime();

      let fechaDiaAnterior = new Date();
      fechaDiaAnterior.setDate(fechaDiaAnterior.getDate() - 1);
      this.f_incapacidad.fecha_inicio_string.setValue(this.getFormattedDate(fechaDiaAnterior));

      //activar opciones para opcion motivo retroactiva 1.2,4
      
      if(this.listaMotivaRetroactiva){
        this.listaMotivaRetroactivaPorFiltro = this.listaMotivaRetroactiva.filter(x => x.id_retroactiva == 1 || x.id_retroactiva == 2 || x.id_retroactiva == 4); 
      }  

      if(this.listaGrupoServicios){
        this.listaGrupoServiciosPorFiltro = this.listaGrupoServicios.filter(x => x.id_servicio == 3 || x.id_servicio == 5); 
      }

      if(this.listaModalidadRealizacionConsulta){
        this.listaModalidadRealizacionConsultaPorFiltro = this.listaModalidadRealizacionConsulta.filter(x => x.id_modalidad == 1); 
        this.f_incapacidad.id_modalidad.setValue(1);
      }

    }
    else
    {
      this.f_incapacidad.id_retroactiva.setValue(null);
      this.f_incapacidad.id_trastorno_memoria.setValue(null);
      this.f_incapacidad.id_retroactiva.disable();
      this.f_incapacidad.id_trastorno_memoria.disable();
      this.fechaMinimaIncapacidad = Date.now();
      // this.f_incapacidad.fecha_inicio.setValue(Date.now());
      this.f_incapacidad.fecha_inicio_string.setValue(formatDate(new Date(Date.now()), 'yyyy-MM-dd', 'en'));

      if(this.listaMotivaRetroactiva){
        this.listaMotivaRetroactivaPorFiltro = this.listaMotivaRetroactiva;//.filter(x => x.id_retroactiva == 1 || x.id_retroactiva == 2 || x.id_retroactiva == 4); 
      }  

      if(this.listaGrupoServicios){
        this.listaGrupoServiciosPorFiltro = this.listaGrupoServicios;//.filter(x => x.id_servicio == 3 || x.id_servicio == 5); 
      }

      if(this.listaModalidadRealizacionConsulta){
        this.listaModalidadRealizacionConsultaPorFiltro = this.listaModalidadRealizacionConsulta; 
      }
    }
  }

  public seleccionProrroga(value:boolean) {    
    
    this.tieneProrroga = value;
    this.f_incapacidad.prorroga.setValue(value);
    
    if(!this.tieneProrroga){
      //Si no es prorroga
        this.deshabilitarSeleccionRetroactiva = false;
          this.f_incapacidad.id_incapacidad_anterior.setValue(null);
          this.f_incapacidad.descripcion_incapacidad_anterior.setValue('');
          this.incapacidadAnterior = (this.listaIncapacidadesAnteriores != null && this.listaIncapacidadesAnteriores[0] != null) ? this.listaIncapacidadesAnteriores[0] : null;
          this.f_incapacidad.id_incapacidad_anterior.disable();
          
          this.fechaMinimaIncapacidad = Date.now();
          // this.f_incapacidad.fecha_inicio.setValue(Date.now());
          this.f_incapacidad.fecha_inicio_string.setValue(formatDate(new Date(Date.now()), 'yyyy-MM-dd', 'en'));
    }else{
      //Si es prorroga
      //this.retroactividoSelected = true;
      let element = document.getElementById('radiobutton1') as HTMLInputElement;
      element.checked = true;
      if(this.f_incapacidad.retroactiva.value){
        this.seleccionRetroactiva(false);
      }
      this.deshabilitarSeleccionRetroactiva = true;
      this.f_incapacidad.retroactiva.setValue(false);
      this.f_incapacidad.id_incapacidad_anterior.enable();
    }
  }

  async determinarFechaIncapacidadActualEntreRango(modeloIncapacidad: IIncapacidad, modeloPaciente: IPacienteModel){
    
    let existeIntercepcionFechas: boolean = false; 
    modeloIncapacidad.acumula_dias_pago = true;
    let listaIncapacidadesIntercepcion: any = [];

    //modeloIncapacidad.lugar_expedicion = this.lugardeExpedicionEntidad;

    //const perfil: IPerfil = JSON.parse(localStorage.getItem('complementario')) || [];

    modeloIncapacidad.id_usuario_hercules = this.idUsuarioEntidadRolActual;//perfil[0].idUsuario2;
    //modeloIncapacidad.id_rol = perfil[0].idRol;
    modeloIncapacidad.id_entidad = this.idEntidad;

    //const perfilUbicacion: IPerfil = JSON.parse(localStorage.getItem('complementario2')) || [];

    //modeloIncapacidad.lugar_expedicion = perfilUbicacion[0].codDepto;
    //modeloIncapacidad.id_rol = perfilUbicacion[0].codMunicipio;
      //modeloIncapacidad.id_entidad = 1;ghhgf
    
    
    if(this.listaIncapacidadesAnteriores){

      this.listaIncapacidadesAnteriores.forEach(elemento => {
        
        const check1 = new Date(elemento.fecha_inicio_string);  
        const check2   = new Date(elemento.fecha_fin_string);
        const from = new Date(this.f_incapacidad.fecha_inicio_string.value);
        const to = new Date(this.f_incapacidad.fecha_fin_string.value);
        console.log('check dates interval');

        if(check1 >= from && check1 <= to || check2 >= from && check2 <= to){
          listaIncapacidadesIntercepcion.push(elemento);
          existeIntercepcionFechas = true;
        }
      });
    }
    

    if(existeIntercepcionFechas){

      //No se puede crear una incapacidad 'laboral' con una incapacidad 'comun' existente
      if(this.incapacidadAnterior.id_origen == 1 && this.f_incapacidad.id_origen.value == 2){
        await this.Alertas.alertaInformativa('Advertencia','No se puede generar una incapacidad de origen LABORAL cuando existe una incapacidad de origen COMUN vigente','Cerrar');
        return;
      }

      //si no hay prorroga
      if(!this.f_incapacidad.prorroga.value){

        //Si el sistema detecta una incapacidad traslapada con el mismo diagnostico se debe mostrar una alerta 
        if(this.incapacidadAnterior.diagnostico.id_diagnosticos == this.f_incapacidad.diagnostico_principal.value){
          await this.Alertas.alertaInformativa('Advertencia','Existe una incapacidad anterior con el mismo diagnóstico principal y no requiere otra incapacidad, salvo si procede prórroga','Cerrar');
          return;
        }

        //Traslapadas 
        const modalRef = this.modalService.open(ModalIncapacidadAnteriorComponent,this.optionsModal);
        modalRef.componentInstance.dataIn = {name: '', id: 0, 'lista_incapacidades': listaIncapacidadesIntercepcion, 'incapacidad_data': this.incapacidadForm.value};
        modalRef.result.then(async (result) => {
            console.log(result)
            if(result.resultado == 'si'){
              
              modeloIncapacidad.dias_incapacidad = result.nuevos_dias_incapacidad;
              modeloIncapacidad.fecha_inicio_string = result.nueva_fecha_inicio_string;
              modeloIncapacidad.fecha_fin_string = result.nueva_fecha_fin_string;

              //modificar tambien formulario
              this.f_incapacidad.dias_incapacidad.setValue(result.nuevos_dias_incapacidad);

              let dateIni = new Date(result.nueva_fecha_inicio_string);
              dateIni.setDate(dateIni.getDate() + 1);
              this.f_incapacidad.fecha_inicio_string.setValue(this.getFormattedDate(dateIni)); 
              let dateFin = new Date(result.nueva_fecha_fin_string);
              dateFin.setDate(dateFin.getDate() + 1);
              this.f_incapacidad.fecha_fin_string.setValue(this.getFormattedDate(dateFin)); 
              

              //Verificar si sigue estando traslapada

              let existeNuevaIntercepcionFechas = false;
              
                this.listaIncapacidadesAnteriores.forEach(elemento => {
                  
                  const check_n1 = new Date(elemento.fecha_inicio_string);  
                  const check_n2   = new Date(elemento.fecha_fin_string);
                  const from_n = new Date(this.f_incapacidad.fecha_inicio_string.value);
                  const to_n = new Date(this.f_incapacidad.fecha_fin_string.value);

                  console.log('check dates interval nuevo');
                  if(check_n1 >= from_n && check_n1 <= to_n || check_n2 >= from_n && check_n2 <= to_n){
                    existeNuevaIntercepcionFechas = true;
                  }
                });
              
                if(existeNuevaIntercepcionFechas){
                  modeloIncapacidad.acumula_dias_pago = false;
                }
              console.log('si cambio de fechas')
            }else{
              modeloIncapacidad.acumula_dias_pago = false;
              console.log('no cambio de fechas')
            }
            this.guardarIncapacidad(modeloIncapacidad, modeloPaciente);
        });
      }else{
        console.log('hay intercepcion de fechas y hay  prorroga')
        this.guardarIncapacidad(modeloIncapacidad, modeloPaciente);
      }       
    }else{
        console.log('no hay cambio de fechas')
        this.guardarIncapacidad(modeloIncapacidad, modeloPaciente);
    }
    
  }

  /************* Funciones generales *****************/
  public getFormattedDate(date: Date) : string {
    var year = date.getFullYear();
  
    var month = (1 + date.getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;
  
    var day = date.getDate().toString();
    day = day.length > 1 ? day : '0' + day;
    
    return year + '-' +  month + '-' + day;
  }

  public getFormattedDateTime(date: Date) : string {
    var year = date.getFullYear();
  
    var month = (1 + date.getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;
  
    var day = date.getDate().toString();
    day = day.length > 1 ? day : '0' + day;

    let hour = date.getHours().toString().length > 1 ? date.getHours().toString() : '0' +date.getHours().toString();
    let minutes = date.getMinutes().toString().length > 1 ? date.getMinutes().toString() : '0' +date.getMinutes().toString();
    let seconds = date.getSeconds().toString().length > 1 ? date.getSeconds().toString() : '0' +date.getSeconds().toString();
    
    return year + '-' +  month + '-' + day + ' ' + hour  + ':' + minutes + ':'+ seconds
  }
  

  public getFormattedDateEstandar(dateString: string) : string {
    return dateString.split('-')[2] + '/' +  dateString.split('-')[1] + '/' + dateString.split('-')[0];
  }

  public getFormattedDateEstandarfromDate(dateString: string) : string {
    if(dateString){
      let dateStringDMY = dateString.split('T')[0];
      return dateStringDMY.split('-')[2] + '/' +  dateStringDMY.split('-')[1] + '/' + dateStringDMY.split('-')[0];
    }else{
      return '';
    }
  }

  async generarPDF(){

  
    let valuesParam = { 
      tipo_documento_pac : this.f_persona.tipoDocumentoPacienteaBuscar.value, 
      numero_documento_pac: this.f_persona.numeroDocumentoPacienteaBuscar.value, 
      id_usuario_hercules: this.idUsuarioEntidadRolActual, 
      id_incapacidad: this.f_incapacidad.id_incapacidad.value 
    };
    this.downloadFile(valuesParam,'certificado_INC'+this.f_incapacidad.id_incapacidad.value+'.pdf');
  }


  downloadFile(params:any, filename: string): void {
    this.downloadService
      .download(params,filename)
      .subscribe(blob => FileSaver.saveAs(blob, filename));
  }


  async cargarListas() {
      
    try{
    this.listaTipoDocumento = await this.parametrosIncapacidadesService.get('/tipodocumento');
    console.log('listaTipoDocumento cargada con exito');  
    this.spinnerService.hide('spinnerCargaInicial');

    this.listaDepartamentos = await this.parametrosIncapacidadesService.get('/departamentos');
    console.log('listaDepartamentos cargada con exito');

    this.listaMunicipios = await this.parametrosIncapacidadesService.get('/municipios');
    console.log('listaMunicipios cargada con exito');
  
    this.listaGrupoServicios = await this.parametrosIncapacidadesService.get('/GrupoServicios');
    this.listaGrupoServiciosPorFiltro = this.listaGrupoServicios;
    console.log('listaGrupoServicios cargada con exito');

    this.listaModalidadRealizacionConsulta = await this.parametrosIncapacidadesService.get('/modalidadRealizacionConsulta');
    this.listaModalidadRealizacionConsultaPorFiltro = this.listaModalidadRealizacionConsulta; 
    console.log('listaModalidadRealizacionConsulta cargada con exito');


    // this.listaFinalidadConsulta = await this.parametrosIncapacidadesService.get('/finalidadconsulta');
    // console.log('listaFinalidadConsulta cargada con exito');

    this.listaOrigen = await this.parametrosIncapacidadesService.get('/origen');
    console.log('listaOrigen cargada con exito');
    
    this.listaCausaAtencion = await this.parametrosIncapacidadesService.get('/causaatencion');
    console.log('listaCausaAtencion cargada con exito');
    //// WS I

    //if (this.incapacidadForm.get('id_origen')?.value == '2') {
    //  this.causaAtencionAnulada = true;
    //  this.changeValueOrigen();
    //}

    //// WS F

    this.listaCausaAtencionByOrigen = this.listaCausaAtencion.filter(x => x.id_origen == this.f_incapacidad.id_origen.value);

    // WS I COMENTADO PARA SETEAR VALOR CAUSA MOTIVO ATENCIÓN DESDE ANULACIÓN

    /*this.f_incapacidad.id_causa.setValue(''*//*this.listaCausaAtencionByOrigen[0].id_causa*//*);*/

    // WS F    
    // this.listaTipoDocumento = await this.parametrosIncapacidadesService.get('/tipodocumento');
    // console.log('listaTipoDocumento cargada con exito');

    this.listaGenero = await this.parametrosIncapacidadesService.get('/sexo');
    console.log('listaGenero cargada con exito');
    
    this.listaMotivaRetroactiva = await this.parametrosIncapacidadesService.get('/motivaretroactiva');
    this.listaMotivaRetroactivaPorFiltro = this.listaMotivaRetroactiva;
    console.log('listaMotivaRetroactiva cargada con exito');
    
    this.listaTrastornoMemoria = await this.parametrosIncapacidadesService.get('/TranstornoMental');
    console.log('listaTrastornoMemoria cargada con exito');

    const  perfilUbicacion: IPerfilComple = JSON.parse(localStorage.getItem('complementario2')) || '';
    
    //consultar Lugar de expedicion
    let ciudadExpedicion = this.listaMunicipios.find(function(element) {
      return element.cod_municipio == perfilUbicacion.codMunicipio && element.cod_depto == perfilUbicacion.codDepto;
    });

    let departamentoExpedicion = this.listaDepartamentos.find(function(element) {
      return element.cod_depto == perfilUbicacion.codDepto;
    });

    this.lugardeExpedicionEntidad = (ciudadExpedicion != null ? ciudadExpedicion.nom_ciudad : '') + (departamentoExpedicion != null ? ' (' + departamentoExpedicion.nom_depto + ')' : '') ;

    this.f_incapacidad.lugar_expedicion.setValue(perfilUbicacion.codDepto + perfilUbicacion.codMunicipio);
    this.f_incapacidad.lugar_expedicion_descripcion.setValue(this.lugardeExpedicionEntidad);
    this.idUsuarioEntidadRolActual =  perfilUbicacion.idUsuarioEntidadRol
    this.idEntidad = perfilUbicacion.idEntidad;


    const listaDiagnosticosAuxiliar =  await this.parametrosIncapacidadesService.get('/Cie10/' + 'Fiebre');
    this.listaDiagnosticosCie10_principal = listaDiagnosticosAuxiliar
    this.listaDiagnosticosCie10_relacion_1 = listaDiagnosticosAuxiliar;
    this.listaDiagnosticosCie10_relacion_2 = listaDiagnosticosAuxiliar;
    console.log('listaDiagnosticosCie10 cargada con exito');

    console.log('snpashot:'+this.route.snapshot.params.idIncapacidad);

    if (this.route.snapshot.params.idIncapacidad != null) {
      await this.cargarReexpedicion();

    }

    }finally{
      this.spinnerService.hide("spinnerCargaInicial");
    }

  }


  inicializarPaciente(){
    return {
      tipo_documento: '',
      numero_documento: '',
      // paciente_encontrado: boolean;
      primer_nombre: '',
      segundo_nombre: '',
      primer_apellido: '',
      segundo_apellido: '',

      depto_residencia_descripcion: '',
      ciudad_residencia_descripcion: '',

      // WS I
      id_incapacidad_anulado: '',
       // WS F

      origen_pac_descripcion:"",
      retroactiva_pac_descripcion:"",
      causaatencion_pac_descripcion:"",
      sexo_descripcion: '',
      eps_nombre: '',
  
      sexo: '',
      fecha_nacimiento: null,//new Date('1990-02-02'),
      fecha_nacimiento_string: '',//this.getFormattedDate(new Date('1990-02-02')),
      cod_depto_residencia: '',
      cod_mun_residencia: '',
      
      id_regimen: '',
      regimen_descripcion:'',

      eps: '', 
      /*razon_social:"",
      tipo_documento_empleador:"",
      numero_documento_empleador:"",
      ubicacion_empleador:"",*/

      relacionPacienteAfiliacionSalud: null
      // {
      //   id_incapacidad: '',
      //   id_paciente: 0,   
      //   codigo_eps: '',
      //   tipo_afiliado: '',
      //   estado: '',
      //   regimen: '',
      //   departamento_afil: '',
      //   municipio_afil: '',
      //   afiliado_PVS: 0,
      //   fecha_inicio_contrato: new Date(),
      //   fecha_fin_contrato: new Date(),
      //   afiliado_INPEC: 0,
      //   fecha_ingreso_inpec: new Date(),
      //   fecha_retiro_inpec: new Date(),
      // }
      ,

      aportantes : [
      //   {
      //   tipo_documento: '',
      //   numero_documento: '',
      //   razon_social: '',
      //   cod_depto: '',
      //   cod_municipio: '',
      //   direccion: '',
      //   correo_electronico: '',

      // }
    ],

      aportanteSeleccionado : null,
      //{
        // tipo_documento: '',
        // numero_documento: '',
        // razon_social: '',
        // cod_depto: '',
        // cod_municipio: '',
        // direccion: '',
        // correo_electronico: ''
      //},

      relacionPacienteAportanteSeleccionada : null,
      // {
      //   id_incapacidad: '',
      //   tipo_documento_pac: '',
      //   numero_documento_pac: '',
      //   ultimo_periodo_salud: '',
      //   ultimo_periodo_afp_arl: '',
      //   cod_administradora_eps: '',
      //   cod_administradora_afp: '',
      //   cod_administradora_arl: '',
      //   desc_administradora_arl: '',
      //   desc_administradora_eps: '',
      //   IBC: 0,
      //   tipo_documento_ap: '',
      //   numero_documento_ap: ''
      // },

      relacionesPacienteAportante : [
        // {
        // id_incapacidad: '',
        // tipo_documento_pac: '',
        // numero_documento_pac: '',
        // ultimo_periodo_salud: '',
        // ultimo_periodo_afp_arl: '',
        // cod_administradora_eps: '',
        // cod_administradora_afp: '',
        // cod_administradora_arl: '',
        // desc_administradora_arl: '',
        // desc_administradora_eps: '',
        // IBC: 0,
        // tipo_documento_ap: '',
        // numero_documento_ap: ''
        //}
    ],

      info_consulta: ''
     };
     
  }
  

}
 

