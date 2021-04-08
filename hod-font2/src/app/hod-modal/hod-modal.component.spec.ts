import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HodModalComponent } from './hod-modal.component';

describe('HodModalComponent', () => {
  let component: HodModalComponent;
  let fixture: ComponentFixture<HodModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HodModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HodModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
