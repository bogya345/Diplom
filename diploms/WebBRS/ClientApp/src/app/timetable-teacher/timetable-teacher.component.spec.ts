import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TimetableTeacherComponent } from './timetable-teacher.component';

describe('TimetableTeacherComponent', () => {
  let component: TimetableTeacherComponent;
  let fixture: ComponentFixture<TimetableTeacherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TimetableTeacherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TimetableTeacherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
