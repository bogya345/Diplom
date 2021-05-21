import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CuratorConfirmedComponent } from './curator-confirmed.component';

describe('CuratorConfirmedComponent', () => {
  let component: CuratorConfirmedComponent;
  let fixture: ComponentFixture<CuratorConfirmedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CuratorConfirmedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CuratorConfirmedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
