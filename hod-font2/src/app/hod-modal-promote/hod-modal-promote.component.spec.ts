import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HodModalPromoteComponent } from './hod-modal-promote.component';

describe('HodModalPromoteComponent', () => {
  let component: HodModalPromoteComponent;
  let fixture: ComponentFixture<HodModalPromoteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HodModalPromoteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HodModalPromoteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
