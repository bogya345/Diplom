import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CuratorstatforPDFComponent } from './curatorstatfor-pdf.component';

describe('CuratorstatforPDFComponent', () => {
  let component: CuratorstatforPDFComponent;
  let fixture: ComponentFixture<CuratorstatforPDFComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CuratorstatforPDFComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CuratorstatforPDFComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
