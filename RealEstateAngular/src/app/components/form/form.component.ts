import { Component } from '@angular/core';
import { PropertyType } from 'src/app/models/propertyType.enum';
import { RadioSize } from 'src/app/models/radioSize.enum';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css'],
})
export class FormComponent {
  activeTab: PropertyType = PropertyType.Apartment;
  propertyType = PropertyType;
  isFurnishedOptions = ['Da', 'Ne'];
  sellOrRentOptions = ['Prodaja', 'Izdavanje'];
  radioSize = RadioSize;

  selectTab(tab: PropertyType): void {
    this.activeTab = tab;
  }
}
