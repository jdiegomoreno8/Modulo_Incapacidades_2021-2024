import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalIncapacidadAnteriorComponent } from './modal-incapacidad-anterior.component';

describe('ModalConfirmacionComponent', () => {
  let component: ModalIncapacidadAnteriorComponent;
  let fixture: ComponentFixture<ModalIncapacidadAnteriorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalIncapacidadAnteriorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalIncapacidadAnteriorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
