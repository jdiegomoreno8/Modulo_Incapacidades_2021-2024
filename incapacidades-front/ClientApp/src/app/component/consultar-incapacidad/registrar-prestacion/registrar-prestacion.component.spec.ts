import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistrarPrestacionComponent } from './registrar-prestacion.component';

describe('RegistrarPrestacionComponent', () => {
  let component: RegistrarPrestacionComponent;
  let fixture: ComponentFixture<RegistrarPrestacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistrarPrestacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrarPrestacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
