import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TimetablePartComponent } from './timetable-part.component';

describe('TimetablePartComponent', () => {
  let component: TimetablePartComponent;
  let fixture: ComponentFixture<TimetablePartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TimetablePartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TimetablePartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
