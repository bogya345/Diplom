import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HodShowAcPlanComponent } from './hod-show-ac-plan.component';

describe('HodShowAcPlanComponent', () => {
  let component: HodShowAcPlanComponent;
  let fixture: ComponentFixture<HodShowAcPlanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HodShowAcPlanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HodShowAcPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
