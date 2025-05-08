import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalConfirmacionPacienteComponent } from './modal-confirmacion-paciente.component';

describe('ModalConfirmacionPacienteComponent', () => {
  let component: ModalConfirmacionPacienteComponent;
  let fixture: ComponentFixture<ModalConfirmacionPacienteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalConfirmacionPacienteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalConfirmacionPacienteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
