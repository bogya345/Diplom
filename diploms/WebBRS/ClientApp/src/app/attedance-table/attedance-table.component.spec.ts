import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AttedanceTableComponent } from './attedance-table.component';

describe('AttedanceTableComponent', () => {
  let component: AttedanceTableComponent;
  let fixture: ComponentFixture<AttedanceTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AttedanceTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AttedanceTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
