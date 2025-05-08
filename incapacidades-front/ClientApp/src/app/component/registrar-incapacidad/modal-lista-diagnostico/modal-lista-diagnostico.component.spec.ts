import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalListaDiagnosticoComponent } from './modal-lista-diagnostico.component';

describe('ModalListaDiagnosticoComponent', () => {
  let component: ModalListaDiagnosticoComponent;
  let fixture: ComponentFixture<ModalListaDiagnosticoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalListaDiagnosticoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalListaDiagnosticoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
