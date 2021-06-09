import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AttedancetableforpdfComponent } from './attedancetableforpdf.component';

describe('AttedancetableforpdfComponent', () => {
  let component: AttedancetableforpdfComponent;
  let fixture: ComponentFixture<AttedancetableforpdfComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AttedancetableforpdfComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AttedancetableforpdfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
