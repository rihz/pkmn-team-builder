import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EvDisplayComponent } from './ev-display.component';

describe('EvDisplayComponent', () => {
  let component: EvDisplayComponent;
  let fixture: ComponentFixture<EvDisplayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EvDisplayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EvDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
