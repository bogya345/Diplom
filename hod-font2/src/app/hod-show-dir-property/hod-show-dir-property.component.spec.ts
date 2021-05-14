import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HodShowDirPropertyComponent } from './hod-show-dir-property.component';

describe('HodShowDirPropertyComponent', () => {
  let component: HodShowDirPropertyComponent;
  let fixture: ComponentFixture<HodShowDirPropertyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HodShowDirPropertyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HodShowDirPropertyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
