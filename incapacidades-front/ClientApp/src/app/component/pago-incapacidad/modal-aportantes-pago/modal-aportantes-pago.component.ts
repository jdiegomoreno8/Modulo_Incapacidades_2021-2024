import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ParametrosIncapacidadesService } from 'src/app/services/parametros-incapacidades.service';

@Component({
  selector: 'app-modal-aportantes-pago',
  templateUrl: './modal-aportantes-pago.component.html',
  styleUrls: ['./modal-aportantes-pago.component.scss']
})
export class ModalAportantesPagoComponent implements OnInit {

  @Input() public dataIn: any;
  @Output() passEntry: EventEmitter<any> = new EventEmitter();

  listaRelacionesPacienteAportante: Array<any> = [];
  //listaAdministradorasByCodRegimen: Array<any> = [];
  page=1; 
  pageSize=7;

  constructor(
    public activeModal: NgbActiveModal
    //,private parametrosIncapacidadesService: ParametrosIncapacidadesService    
  ) { 
  }

  async ngOnInit() {

    console.log('this.dataIn.aportantes')
    console.log(this.dataIn)
    this.listaRelacionesPacienteAportante = this.dataIn.relacionesPacienteAportante;
    
  }

  clickedRow(index: number){  
    this.passEntry.emit(this.listaRelacionesPacienteAportante[(this.pageSize*(this.page-1)) + index]);
    this.activeModal.close(this.listaRelacionesPacienteAportante[(this.pageSize*(this.page-1)) + index]);
  }

  closeModal(){  
    this.activeModal.close(
        {
          tipo_documento_pac: '',
          numero_documento_pac: '', 
          razon_social_descripcion: '' //ARL
        }
      );
  }
  
}