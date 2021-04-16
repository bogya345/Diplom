import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HodModalReloadAcPlanComponent } from './hod-modal-reload-ac-plan.component';

describe('HodModalReloadAcPlanComponent', () => {
  let component: HodModalReloadAcPlanComponent;
  let fixture: ComponentFixture<HodModalReloadAcPlanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HodModalReloadAcPlanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HodModalReloadAcPlanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
