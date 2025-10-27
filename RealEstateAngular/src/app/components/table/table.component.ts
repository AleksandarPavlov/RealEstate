import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ChangePropertyStatusRequest } from 'src/app/models/changePropertyStatusRequest';
import { ListingType } from 'src/app/models/propertyListingType.enum';
import { PropertyResponse } from 'src/app/models/propertyResponse.model';
import { PropertyStatus } from 'src/app/models/propertyStatus.enum';
import { PropertyService } from 'src/app/services/property.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TableComponent {
  @Input() properties: PropertyResponse[] = [];
  @Input() isFetching: boolean = false;
  @Input() currentPage: number = 0;
  @Input() backgroundColor: string = '#fce4e4';
  @Input() adminView: boolean = false;
  @Input() showStatus: boolean = false;
  @Output() nextPage = new EventEmitter<void>();
  @Output() previousPage = new EventEmitter<void>();
  listingType = ListingType;
  PropertyStatus = PropertyStatus;

  constructor(private propertyService: PropertyService) {}

  handleNextPage() {
    this.nextPage.emit();
  }

  handlePreviousPage() {
    this.previousPage.emit();
  }

  approveProperty(propertyId: number) {
    const changePropertyStatusRequest = new ChangePropertyStatusRequest(
      PropertyStatus.APPROVED
    );
    this.propertyService
      .changePropertyStatus(changePropertyStatusRequest, propertyId)
      .subscribe({
        next: () => {
          this.properties = this.properties.filter((p) => p.id !== propertyId);
        },
        error: (err) => {
          console.error('Failed to approve property', err);
        },
      });
  }

  declineProperty(propertyId: number) {
    const changePropertyStatusRequest = new ChangePropertyStatusRequest(
      PropertyStatus.DECLINED
    );
    this.propertyService
      .changePropertyStatus(changePropertyStatusRequest, propertyId)
      .subscribe({
        next: () => {
          this.properties = this.properties.filter((p) => p.id !== propertyId);
        },
        error: (err) => {
          console.error('Failed to decline property', err);
        },
      });
  }
}
