import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { lista-pagoIncapacidadesComponent } from './lista-pago-incapacidades.component';

describe('lista-pagoIncapacidadesComponent', () => {
  let component: listaPagoIncapacidadesComponent;
  let fixture: ComponentFixture<listaPagoIncapacidadesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ listaPagoIncapacidadesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(listaPagoIncapacidadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
