import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PortfoliocardComponent } from './portfoliocard.component';

describe('PortfoliocardComponent', () => {
  let component: PortfoliocardComponent;
  let fixture: ComponentFixture<PortfoliocardComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PortfoliocardComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PortfoliocardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
