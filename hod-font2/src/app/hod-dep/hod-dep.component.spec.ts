import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HodDepComponent } from './hod-dep.component';

describe('HodDepComponent', () => {
  let component: HodDepComponent;
  let fixture: ComponentFixture<HodDepComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HodDepComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HodDepComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
