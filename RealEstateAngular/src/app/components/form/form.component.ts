import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {
  MAX_PROPERTY_FLOOR_NUMBER,
  MAX_PROPERTY_NUMBER_OF_ROOMS,
  MAX_PROPERTY_PRICE,
  MAX_PROPERTY_SIZE,
} from 'src/app/models/constants/constants';
import { CreateApartmentRequest } from 'src/app/models/createApartmentRequest';
import { CreateHouseRequest } from 'src/app/models/createHouseRequest';
import { CreateLandRequest } from 'src/app/models/createLandRequest';
import { GenerateDescriptionRequest } from 'src/app/models/generateDescriptionRequest.model';
import {
  ListingType,
  toListingType,
} from 'src/app/models/propertyListingType.enum';
import {
  PropertyType,
  propertyTypeToSerbianLanguage,
} from 'src/app/models/propertyType.enum';
import { RadioSize } from 'src/app/models/radioSize.enum';
import { EMAIL_REGEX, PHONE_NUMBER_REGEX } from 'src/app/models/regex/regex';
import { ToastType } from 'src/app/models/toastType.enum';
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
  isLoading = false;
  propertyForm: FormGroup;
  propertyImages: File[] = [];
  selectedPropertyType: string = propertyTypeToSerbianLanguage(this.activeTab);
  toastMessage = '';
  toastVisible = false;
  toastType: ToastType = ToastType.Success;

  constructor(
    private propertyService: PropertyService,
    private fb: FormBuilder
  ) {
    this.propertyForm = this.fb.group({
      advertismentName: ['', Validators.required],
      city: ['', Validators.required],
      address: '',
      sizeInMmSquared: [
        0,
        [
          Validators.required,
          Validators.min(0),
          Validators.max(MAX_PROPERTY_SIZE),
        ],
      ],
      price: [
        0,
        [
          Validators.required,
          Validators.min(0),
          Validators.max(MAX_PROPERTY_PRICE),
        ],
      ],
      floorNumber: [
        0,
        [
          Validators.required,
          Validators.min(0),
          Validators.max(MAX_PROPERTY_FLOOR_NUMBER),
        ],
      ],
      numberOfRooms: [
        0,
        [
          Validators.required,
          Validators.min(0),
          Validators.max(MAX_PROPERTY_NUMBER_OF_ROOMS),
        ],
      ],
      isFurnished: this.isFurnishedOptions[0],
      description: '',
      sellOrRent: this.sellOrRentOptions[0],
    });
  }

  ngOnInit() {}

  selectTab(tab: PropertyType): void {
    this.activeTab = tab;
    this.selectedPropertyType = propertyTypeToSerbianLanguage(this.activeTab);
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

  onFilesChanged(files: File[]) {
    this.propertyImages = files;
  }

  nextStep() {
    if (this.currentStep < 4) {
      this.currentStep++;
    }
  }

  prevStep() {
    if (this.currentStep > 1) {
      this.currentStep--;
    }
  }

  isAiTooltipDisabled() {
    const form = this.propertyForm;
    const sizeInMmSquared = form.get('sizeInMmSquared')?.value;
    const address = form.get('address')?.value;
    const listingType = form.get('sellOrRent')?.value;

    return !sizeInMmSquared || !address || !listingType;
  }

  onTooltipClick() {
    const form = this.propertyForm;
    var generateDescriptionRequest = new GenerateDescriptionRequest(
      form.get('sizeInMmSquared')?.value + 'm²',
      form.get('address')?.value + ',' + form.get('city')?.value,
      toListingType(form.get('sellOrRent')?.value),
      this.activeTab
    );
    this.isLoading = true;
    this.propertyService
      .generateDescription(generateDescriptionRequest)
      .subscribe(
        (response: string) => {
          this.propertyForm.get('description')?.setValue(response);
          this.isLoading = false;
        },
        () => {
          this.isLoading = false;
        }
      );
  }

  handleSubmit() {
    switch (this.activeTab) {
      case PropertyType.APARTMENT:
        this.propertyService
          .createApartment(
            CreateApartmentRequest.fromForm(this.propertyForm),
            this.propertyImages
          )
          .subscribe({
            next: () => this.showSuccessToast(),
            error: () => this.showErrorToast(),
          });
        break;

      case PropertyType.HOUSE:
        this.propertyService
          .createHouse(
            CreateHouseRequest.fromForm(this.propertyForm),
            this.propertyImages
          )
          .subscribe({
            next: () => this.showSuccessToast(),
            error: () => this.showErrorToast(),
          });
        break;

      case PropertyType.LAND:
        this.propertyService
          .createLand(
            CreateLandRequest.fromForm(this.propertyForm),
            this.propertyImages
          )
          .subscribe({
            next: () => this.showSuccessToast(),
            error: () => this.showErrorToast(),
          });
        break;
    }
  }

  private showSuccessToast() {
    this.toastMessage =
      'Uspešno ste poslali zahtev za postavljanje oglasa, biće dostupan nakon odobrenja admina.';
    this.toastType = ToastType.Success;
    this.toastVisible = true;
  }

  private showErrorToast() {
    this.toastMessage = 'Došlo je do greške prilikom postavljanja oglasa.';
    this.toastType = ToastType.Danger;
    this.toastVisible = true;
  }
}
