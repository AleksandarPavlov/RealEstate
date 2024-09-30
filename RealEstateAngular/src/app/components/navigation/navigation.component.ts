import { Component, ElementRef, HostListener } from '@angular/core';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css'],
})
export class NavigationComponent {
  isSellMenuOpen: boolean = false;
  isRentMenuOpen: boolean = false;

  cities = [
    { name: 'Beograd', displayName: 'Beograd' },
    { name: 'Novi Sad', displayName: 'Novi Sad' },
    { name: 'Niš', displayName: 'Niš' },
    { name: 'Kragujevac', displayName: 'Kragujevac' },
  ];

  propertyTypes = [
    { name: 'Apartment', displayName: 'stanova' },
    { name: 'House', displayName: 'kuća' },
    { name: 'Land', displayName: 'zemljišta' },
  ];

  constructor(private eRef: ElementRef) {}

  toggleSellMenu(): void {
    this.isSellMenuOpen = !this.isSellMenuOpen;
    this.isRentMenuOpen = false;
  }

  toggleRentMenu(): void {
    this.isRentMenuOpen = !this.isRentMenuOpen;
    this.isSellMenuOpen = false;
  }

  closeSellMenu(): void {
    this.isSellMenuOpen = false;
  }

  closeRentMenu(): void {
    this.isRentMenuOpen = false;
  }

  @HostListener('document:click', ['$event'])
  clickOutside(event: Event) {
    if (!this.eRef.nativeElement.contains(event.target)) {
      this.closeSellMenu();
      this.closeRentMenu();
    }
  }
}
