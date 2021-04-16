import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HodMapSubDepComponent } from './hod-map-sub-dep.component';

describe('HodMapSubDepComponent', () => {
  let component: HodMapSubDepComponent;
  let fixture: ComponentFixture<HodMapSubDepComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HodMapSubDepComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HodMapSubDepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
