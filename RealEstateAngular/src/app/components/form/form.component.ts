import { Component } from '@angular/core';
import { GenerateDescriptionRequest } from 'src/app/models/generateDescriptionRequest.model';
import { ListingType } from 'src/app/models/propertyListingType.enum';
import { PropertyType } from 'src/app/models/propertyType.enum';
import { RadioSize } from 'src/app/models/radioSize.enum';
import { PropertyService } from 'src/app/services/property.service';

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
  generatedDescription: string | undefined = '';
  isLoading = false;

  constructor(private propertyService: PropertyService) {}

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
  onTooltipClick() {
    var generateDescriptionRequest = new GenerateDescriptionRequest(
      '55m²',
      'Mise Dimitrijevica 24, Novi Sad',
      ListingType.SELL,
      PropertyType.APARTMENT
    );
    this.isLoading = true;
    this.propertyService
      .generateDescription(generateDescriptionRequest)
      .subscribe(
        (response: string) => {
          this.generatedDescription = response;
          this.isLoading = false;
          console.log('Generated Description:', response);
        },
        (error) => {
          console.log('I am here');
          this.isLoading = false;
          console.error('Error:', error);
        }
      );
  }
}
