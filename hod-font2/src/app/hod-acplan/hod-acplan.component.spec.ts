import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HodAcplanComponent } from './hod-acplan.component';

describe('HodAcplanComponent', () => {
  let component: HodAcplanComponent;
  let fixture: ComponentFixture<HodAcplanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HodAcplanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HodAcplanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
