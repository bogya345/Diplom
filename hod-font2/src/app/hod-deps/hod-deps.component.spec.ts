import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HodDepsComponent } from './hod-deps.component';

describe('HodDepsComponent', () => {
  let component: HodDepsComponent;
  let fixture: ComponentFixture<HodDepsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HodDepsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HodDepsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
