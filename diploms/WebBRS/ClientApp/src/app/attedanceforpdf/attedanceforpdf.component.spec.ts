import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AttedanceforpdfComponent } from './attedanceforpdf.component';

describe('AttedanceforpdfComponent', () => {
  let component: AttedanceforpdfComponent;
  let fixture: ComponentFixture<AttedanceforpdfComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AttedanceforpdfComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AttedanceforpdfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
