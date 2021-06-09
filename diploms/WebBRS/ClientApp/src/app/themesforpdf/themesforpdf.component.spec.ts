import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThemesforpdfComponent } from './themesforpdf.component';

describe('ThemesforpdfComponent', () => {
  let component: ThemesforpdfComponent;
  let fixture: ComponentFixture<ThemesforpdfComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThemesforpdfComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThemesforpdfComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
