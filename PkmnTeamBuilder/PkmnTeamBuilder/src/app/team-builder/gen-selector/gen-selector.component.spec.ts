import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GenSelectorComponent } from './gen-selector.component';

describe('GenSelectorComponent', () => {
  let component: GenSelectorComponent;
  let fixture: ComponentFixture<GenSelectorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GenSelectorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GenSelectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
