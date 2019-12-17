import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IvDisplayComponent } from './iv-display.component';

describe('IvDisplayComponent', () => {
  let component: IvDisplayComponent;
  let fixture: ComponentFixture<IvDisplayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IvDisplayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IvDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
