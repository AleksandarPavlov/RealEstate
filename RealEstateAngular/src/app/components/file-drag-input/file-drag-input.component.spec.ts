import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FileDragInputComponent } from './file-drag-input.component';

describe('FileDragInputComponent', () => {
  let component: FileDragInputComponent;
  let fixture: ComponentFixture<FileDragInputComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FileDragInputComponent]
    });
    fixture = TestBed.createComponent(FileDragInputComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
