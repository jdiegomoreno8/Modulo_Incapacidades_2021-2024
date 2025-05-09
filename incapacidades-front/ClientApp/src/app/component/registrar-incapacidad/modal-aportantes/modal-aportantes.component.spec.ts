import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ModalAportantesComponent } from './modal-aportantes.component';


describe('ModalAportantesComponent', () => {
  let component: ModalAportantesComponent;
  let fixture: ComponentFixture<ModalAportantesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModalAportantesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalAportantesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
