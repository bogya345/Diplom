import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PrikazCuratorComponent } from './prikaz-curator.component';

describe('PrikazCuratorComponent', () => {
  let component: PrikazCuratorComponent;
  let fixture: ComponentFixture<PrikazCuratorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PrikazCuratorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PrikazCuratorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
