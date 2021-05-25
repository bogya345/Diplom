import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CuratorStatisticComponent } from './curator-statistic.component';

describe('CuratorStatisticComponent', () => {
  let component: CuratorStatisticComponent;
  let fixture: ComponentFixture<CuratorStatisticComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CuratorStatisticComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CuratorStatisticComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
