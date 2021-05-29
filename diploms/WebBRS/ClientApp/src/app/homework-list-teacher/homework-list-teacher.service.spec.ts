import { TestBed } from '@angular/core/testing';

import { homeworkListTeacher_HttpService } from './http.serviceHomeworkListTeacher';

describe('HomeworkListTeacherService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: homeworkListTeacher_HttpService = TestBed.get(homeworkListTeacher_HttpService);
    expect(service).toBeTruthy();
  });
});
