import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrikazCuratorPDFComponent } from './prikaz-curator-pdf.component';

describe('PrikazCuratorPDFComponent', () => {
  let component: PrikazCuratorPDFComponent;
  let fixture: ComponentFixture<PrikazCuratorPDFComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrikazCuratorPDFComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrikazCuratorPDFComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
