import { Component } from '@angular/core';
import { Subject, takeUntil } from 'rxjs';
import { LATEST_PROPERTIES_AMOUNT } from 'src/app/models/constants/constants';
import { Property } from 'src/app/models/property.model';
import { PropertyResponse } from 'src/app/models/propertyResponse.model';
import { PropertyService } from 'src/app/services/property.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent {
  properties: PropertyResponse[] = [];

  private unsubscribe$ = new Subject<void>();

  constructor(private propertyService: PropertyService) {}

  ngOnInit() {
    window.scroll(0, 0);
    this.fetchLatestProperties(LATEST_PROPERTIES_AMOUNT);
  }

  fetchLatestProperties(amount: number) {
    this.propertyService
      .fetchLatest(amount)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe((response) => {
        this.properties = response;
      });
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
