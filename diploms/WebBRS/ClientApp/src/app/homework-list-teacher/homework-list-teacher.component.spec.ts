import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeworkListTeacherComponent } from './homework-list-teacher.component';

describe('HomeworkListTeacherComponent', () => {
  let component: HomeworkListTeacherComponent;
  let fixture: ComponentFixture<HomeworkListTeacherComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomeworkListTeacherComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomeworkListTeacherComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
