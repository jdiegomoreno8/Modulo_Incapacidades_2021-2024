import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AnularIncapacidadComponent } from './anular-incapacidad.component';

describe('AnularIncapacidadComponent', () => {
  let component: AnularIncapacidadComponent;
  let fixture: ComponentFixture<AnularIncapacidadComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AnularIncapacidadComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AnularIncapacidadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
