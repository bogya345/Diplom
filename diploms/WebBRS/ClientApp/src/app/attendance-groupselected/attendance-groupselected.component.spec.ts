import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AttendanceGroupselectedComponent } from './attendance-groupselected.component';

describe('AttendanceGroupselectedComponent', () => {
  let component: AttendanceGroupselectedComponent;
  let fixture: ComponentFixture<AttendanceGroupselectedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AttendanceGroupselectedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AttendanceGroupselectedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
