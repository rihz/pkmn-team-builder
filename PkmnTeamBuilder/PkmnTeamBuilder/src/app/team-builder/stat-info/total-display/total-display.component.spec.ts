import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TotalDisplayComponent } from './total-display.component';

describe('TotalDisplayComponent', () => {
  let component: TotalDisplayComponent;
  let fixture: ComponentFixture<TotalDisplayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TotalDisplayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TotalDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
