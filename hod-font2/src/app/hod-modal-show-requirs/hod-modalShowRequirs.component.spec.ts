import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HodModalShowRequirsComponent } from './hod-modalShowRequirs.component';

describe('HodModalComponent', () => {
  let component: HodModalShowRequirsComponent;
  let fixture: ComponentFixture<HodModalShowRequirsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HodModalShowRequirsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HodModalShowRequirsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
