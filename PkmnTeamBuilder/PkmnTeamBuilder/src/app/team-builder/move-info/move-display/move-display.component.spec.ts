import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MoveDisplayComponent } from './move-display.component';

describe('MoveDisplayComponent', () => {
  let component: MoveDisplayComponent;
  let fixture: ComponentFixture<MoveDisplayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MoveDisplayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MoveDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
