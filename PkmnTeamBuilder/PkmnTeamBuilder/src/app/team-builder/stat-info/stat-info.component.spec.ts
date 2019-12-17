import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StatInfoComponent } from './stat-info.component';

describe('StatInfoComponent', () => {
  let component: StatInfoComponent;
  let fixture: ComponentFixture<StatInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StatInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StatInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
