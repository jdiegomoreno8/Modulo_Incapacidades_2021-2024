import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaIncapacidadesComponent } from './lista-incapacidades.component';

describe('ListaIncapacidadesComponent', () => {
  let component: ListaIncapacidadesComponent;
  let fixture: ComponentFixture<ListaIncapacidadesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListaIncapacidadesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaIncapacidadesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
