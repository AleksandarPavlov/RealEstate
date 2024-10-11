import { Component } from '@angular/core';
import { PropertyType } from 'src/app/models/propertyType.enum';
import { RadioSize } from 'src/app/models/radioSize.enum';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css'],
})
export class FormComponent {
  activeTab: PropertyType = PropertyType.APARTMENT;
  propertyType = PropertyType;
  isFurnishedOptions = ['Da', 'Ne'];
  sellOrRentOptions = ['Prodaja', 'Izdavanje'];
  radioSize = RadioSize;
  apartmentBanner = '../../../assets/images/apartment-banner1.jpg';
  houseBanner = '../../../assets/images/house-banner2.jpg';
  landBanner = '../../../assets/images/land-banner.jpeg';
  currentBanner: string = this.apartmentBanner;
  currentStep = 1;

  selectTab(tab: PropertyType): void {
    this.activeTab = tab;
    switch (tab) {
      case PropertyType.APARTMENT:
        this.currentBanner = this.apartmentBanner;
        break;
      case PropertyType.HOUSE:
        this.currentBanner = this.houseBanner;
        break;
      case PropertyType.LAND:
        this.currentBanner = this.landBanner;
        break;
      default:
        this.currentBanner = this.apartmentBanner;
    }
  }

  nextStep() {
    if (this.currentStep < 3) {
      this.currentStep++;
    }
  }

  prevStep() {
    if (this.currentStep > 1) {
      this.currentStep--;
    }
  }
}
