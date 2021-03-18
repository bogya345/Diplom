import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BrsHomeComponent } from './brs-home.component';

describe('BrsHomeComponent', () => {
  let component: BrsHomeComponent;
  let fixture: ComponentFixture<BrsHomeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BrsHomeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BrsHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
