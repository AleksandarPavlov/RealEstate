import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MapSearchPageComponent } from './map-search-page.component';

describe('MapSearchPageComponent', () => {
  let component: MapSearchPageComponent;
  let fixture: ComponentFixture<MapSearchPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MapSearchPageComponent]
    });
    fixture = TestBed.createComponent(MapSearchPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
