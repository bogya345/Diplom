import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HodModalShowGroupStatusComponent } from './hod-modal-show-group-status.component';

describe('HodModalShowGroupStatusComponent', () => {
  let component: HodModalShowGroupStatusComponent;
  let fixture: ComponentFixture<HodModalShowGroupStatusComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HodModalShowGroupStatusComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HodModalShowGroupStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
