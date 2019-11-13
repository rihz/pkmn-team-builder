import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PkmnSelectorComponent } from './pkmn-selector.component';

describe('PkmnSelectorComponent', () => {
  let component: PkmnSelectorComponent;
  let fixture: ComponentFixture<PkmnSelectorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PkmnSelectorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PkmnSelectorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
