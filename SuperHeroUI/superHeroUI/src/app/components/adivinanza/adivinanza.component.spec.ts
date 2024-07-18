import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdivinanzaComponent } from './adivinanza.component';

describe('AdivinanzaComponent', () => {
  let component: AdivinanzaComponent;
  let fixture: ComponentFixture<AdivinanzaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdivinanzaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdivinanzaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
