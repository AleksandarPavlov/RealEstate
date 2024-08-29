import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchInputGroupComponent } from './search-input-group.component';

describe('SearchInputGroupComponent', () => {
  let component: SearchInputGroupComponent;
  let fixture: ComponentFixture<SearchInputGroupComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchInputGroupComponent]
    });
    fixture = TestBed.createComponent(SearchInputGroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
