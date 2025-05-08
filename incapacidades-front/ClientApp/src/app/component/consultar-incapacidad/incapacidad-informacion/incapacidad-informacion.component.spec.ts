import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IncapacidadInformacionComponent } from './incapacidad-informacion.component';

describe('IncapacidadInformacionComponent', () => {
  let component: IncapacidadInformacionComponent;
  let fixture: ComponentFixture<IncapacidadInformacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IncapacidadInformacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IncapacidadInformacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
