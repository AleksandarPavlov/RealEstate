import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { PropertyQueryParams } from 'src/app/models/propertyFilterParams.model';
import { PropertyResponse } from 'src/app/models/propertyResponse.model';
import { PropertyService } from 'src/app/services/property.service';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.css'],
})
export class AdminPageComponent {
  properties: PropertyResponse[] = [];
  private unsubscribe$ = new Subject<void>();
  isFetching = false;
  currentFilters: Partial<PropertyQueryParams> = {};
  currentPage = 0;

  constructor(
    private propertyService: PropertyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      this.currentPage = params['Page'] ? +params['Page'] : 0;

      this.fetchCurrentPage();
    });
  }

  fetchCurrentPage() {
    window.scroll(0, 0);
    const queryParams = new PropertyQueryParams({
      ...this.currentFilters,
      Page: this.currentPage,
    });

    this.fetchPropertiesForApproval(queryParams);
  }

  fetchPropertiesForApproval(queryParams: PropertyQueryParams) {
    this.isFetching = true;
    this.propertyService
      .fetchPropertiesForApproval(queryParams)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        (response) => {
          this.properties = response;
          this.isFetching = false;
        },
        () => {
          this.isFetching = false;
        }
      );
  }

  handleNextPage() {
    this.currentPage++;
    this.fetchCurrentPage();
  }

  handlePreviousPage() {
    if (this.currentPage > 0) {
      this.currentPage--;
      this.fetchCurrentPage();
    }
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
