import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileforviewComponent } from './profileforview.component';

describe('ProfileforviewComponent', () => {
  let component: ProfileforviewComponent;
  let fixture: ComponentFixture<ProfileforviewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfileforviewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileforviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
