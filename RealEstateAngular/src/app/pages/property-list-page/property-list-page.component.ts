import { Component } from '@angular/core';
import { Property } from 'src/app/models/property.model';

@Component({
  selector: 'app-property-list-page',
  templateUrl: './property-list-page.component.html',
  styleUrls: ['./property-list-page.component.css'],
})
export class PropertyListPageComponent {
  ngOnInit() {
    window.scroll(0, 0);
  }

  properties: Property[] = [
    {
      id: 1,
      address: 'Cara Dušana, Novi Sad',
      floorNumber: 'Prizemlje',
      isForRent: false,
      isFurnished: true,
      numberOfRooms: 3,
      price: 120000,
      pricePerMmSquared: 2157,
      propertyName: 'Novogradnja, Cara Dušana',
      sizeInMmSquared: 55,
      image:
        'https://www.decorilla.com/online-decorating/wp-content/uploads/2022/11/Minimalist-apartment-design-Apartment-therapy.jpeg',
      isPremium: false,
    },
    {
      id: 2,
      address: 'Novi Beograd, Beograd',
      floorNumber: '4',
      isForRent: true,
      isFurnished: true,
      numberOfRooms: 2,
      price: 520,
      pricePerMmSquared: 0,
      propertyName: 'Novi Beograd Residence',
      sizeInMmSquared: 50,
      image:
        'https://media.self.com/photos/630635c30b7f36ce816f374a/4:3/w_2560%2Cc_limit/DAB03919-10470989.jpg',
      isPremium: true,
    },
    {
      id: 3,
      address: 'Novosadskog Sajma, Novi Sad',
      floorNumber: '3',
      isForRent: false,
      isFurnished: true,
      numberOfRooms: 2,
      price: 110000,
      pricePerMmSquared: 2100,
      propertyName: 'Dream Home Residence',
      sizeInMmSquared: 55,
      image:
        'https://www.home-designing.com/wp-content/uploads/2019/12/grey-modern-sofa.jpg',
      isPremium: false,
    },
    {
      id: 4,
      address: 'Adice, Novi Sad',
      floorNumber: 'Prizemlje',
      isForRent: false,
      isFurnished: true,
      numberOfRooms: 5,
      price: 145000,
      pricePerMmSquared: 1759,
      propertyName: 'Kuća, Adice',
      sizeInMmSquared: 105,
      image:
        'https://cf.bstatic.com/xdata/images/hotel/max1024x768/353742714.jpg?k=bcee6772c5eeb8549b16d03f382e2a3920aa7ba49cb86934c3f141c2fa284ad7&o=&hp=1',
      isPremium: false,
    },
  ];
}
