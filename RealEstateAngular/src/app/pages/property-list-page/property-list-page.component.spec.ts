import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PropertyListPageComponent } from './property-list-page.component';

describe('PropertyListPageComponent', () => {
  let component: PropertyListPageComponent;
  let fixture: ComponentFixture<PropertyListPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [PropertyListPageComponent]
    });
    fixture = TestBed.createComponent(PropertyListPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
