import { TestBed } from '@angular/core/testing';

import { HomeworkListTeacherService } from './homework-list-teacher.service';

describe('HomeworkListTeacherService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HomeworkListTeacherService = TestBed.get(HomeworkListTeacherService);
    expect(service).toBeTruthy();
  });
});
