import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { pagoIncapacidadComponent } from './pago-incapacidad.component';

describe('pagoIncapacidadComponent', () => {
  let component: pagoIncapacidadComponent;
  let fixture: ComponentFixture<pagoIncapacidadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ pagoIncapacidadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(pagoIncapacidadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
