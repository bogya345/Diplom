import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrikazCuratorListComponent } from './prikaz-curator-list.component';

describe('PrikazCuratorListComponent', () => {
  let component: PrikazCuratorListComponent;
  let fixture: ComponentFixture<PrikazCuratorListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrikazCuratorListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrikazCuratorListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
