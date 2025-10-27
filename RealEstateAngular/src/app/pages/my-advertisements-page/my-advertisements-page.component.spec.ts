import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyAdvertisementsPageComponent } from './my-advertisements-page.component';

describe('MyAdvertisementsPageComponent', () => {
  let component: MyAdvertisementsPageComponent;
  let fixture: ComponentFixture<MyAdvertisementsPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MyAdvertisementsPageComponent]
    });
    fixture = TestBed.createComponent(MyAdvertisementsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
