import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CuratorConfirmedListComponent } from './curator-confirmed-list.component';

describe('CuratorConfirmedListComponent', () => {
  let component: CuratorConfirmedListComponent;
  let fixture: ComponentFixture<CuratorConfirmedListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CuratorConfirmedListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CuratorConfirmedListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
