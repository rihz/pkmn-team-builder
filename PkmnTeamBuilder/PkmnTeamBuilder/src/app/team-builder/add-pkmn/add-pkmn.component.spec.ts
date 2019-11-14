import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPkmnComponent } from './add-pkmn.component';

describe('AddPkmnComponent', () => {
  let component: AddPkmnComponent;
  let fixture: ComponentFixture<AddPkmnComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPkmnComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPkmnComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
