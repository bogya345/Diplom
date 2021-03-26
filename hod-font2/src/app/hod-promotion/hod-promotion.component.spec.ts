import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HodPromotionComponent } from './hod-promotion.component';

describe('HodPromotionComponent', () => {
  let component: HodPromotionComponent;
  let fixture: ComponentFixture<HodPromotionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HodPromotionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HodPromotionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
