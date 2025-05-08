import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ModalListaIncapacidadesAnterioresComponent } from './modal-lista-incapacidades-anteriores.component';


describe('ModalListaDiagnosticoComponent', () => {
  let component: ModalListaIncapacidadesAnterioresComponent;
  let fixture: ComponentFixture<ModalListaIncapacidadesAnterioresComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalListaIncapacidadesAnterioresComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalListaIncapacidadesAnterioresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
