import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ModalAportantesPagoComponent } from './modal-aportantes-pago.component';


describe('ModalAportantesPagoComponent', () => {
  let component: ModalAportantesPagoComponent;
  let fixture: ComponentFixture<ModalAportantesPagoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalAportantesPagoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalAportantesPagoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
