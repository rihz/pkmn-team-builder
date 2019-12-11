import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SuppInfoComponent } from './supp-info.component';

describe('SuppInfoComponent', () => {
  let component: SuppInfoComponent;
  let fixture: ComponentFixture<SuppInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SuppInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SuppInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
