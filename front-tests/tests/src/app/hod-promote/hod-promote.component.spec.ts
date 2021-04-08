import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HodPromoteComponent } from './hod-promote.component';

describe('HodPromoteComponent', () => {
  let component: HodPromoteComponent;
  let fixture: ComponentFixture<HodPromoteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HodPromoteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HodPromoteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
