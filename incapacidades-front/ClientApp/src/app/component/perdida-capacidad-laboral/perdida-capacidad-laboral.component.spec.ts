import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PerdidaCapacidadLaboralComponent } from './perdida-capacidad-laboral.component';

describe('PerdidaCapacidadLaboralComponent', () => {
  let component: PerdidaCapacidadLaboralComponent;
  let fixture: ComponentFixture<PerdidaCapacidadLaboralComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PerdidaCapacidadLaboralComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PerdidaCapacidadLaboralComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
