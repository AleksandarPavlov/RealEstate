import { Component, ElementRef, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { UserInfo } from 'src/app/models/userInfo';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css'],
})
export class NavigationComponent {
  isSellMenuOpen: boolean = false;
  isRentMenuOpen: boolean = false;
  isLoggedIn = false;
  userRole: string | null = null;
  userInfo: UserInfo | null = null;
  userInitials: string = 'NK';
  fullName: string = 'Nepoznati Korisnik';
  contactNumber: string = '';
  emailAddress: string = '';
  showProfile = false;

  constructor(
    private eRef: ElementRef,
    private authService: AuthService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.checkAuth();
  }

  toggleProfile() {
    this.showProfile = !this.showProfile;
  }

  checkAuth() {
    this.isLoggedIn = this.authService.isLoggedIn();
    this.userRole = this.authService.getRole();
    this.userInfo = this.authService.getUserInfo();
    this.fullName = this.userInfo?.fullName ?? '';
    this.contactNumber = this.userInfo?.contactNumber ?? '';
    this.emailAddress = this.userInfo?.emailAddress ?? '';
    this.userInitials = this.getUserInitials(this.fullName);
  }

  logout() {
    this.authService.logout();
    this.isLoggedIn = false;
    this.userRole = null;
    this.router.navigate(['/login']);
  }

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

  getUserInitials(fullName: string): string {
    const initials = fullName
      .split(' ')
      .filter((part) => part.length > 0)
      .map((part) => part[0].toUpperCase())
      .join('');
    return initials;
  }

  @HostListener('document:click', ['$event'])
  clickOutside(event: Event) {
    if (!this.eRef.nativeElement.contains(event.target)) {
      this.closeSellMenu();
      this.closeRentMenu();
    }
  }
}
