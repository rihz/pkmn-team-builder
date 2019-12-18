import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NicknameEntryComponent } from './nickname-entry.component';

describe('NicknameEntryComponent', () => {
  let component: NicknameEntryComponent;
  let fixture: ComponentFixture<NicknameEntryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NicknameEntryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NicknameEntryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
