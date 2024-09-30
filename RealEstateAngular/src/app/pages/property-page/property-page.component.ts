import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject, takeUntil } from 'rxjs';
import { PropertyResponse } from 'src/app/models/propertyResponse.model';
import { PropertyService } from 'src/app/services/property.service';

@Component({
  selector: 'app-property-page',
  templateUrl: './property-page.component.html',
  styleUrls: ['./property-page.component.css'],
})
export class PropertyPageComponent {
  property!: PropertyResponse;
  id!: number;
  private unsubscribe$ = new Subject<void>();

  constructor(
    private propertyService: PropertyService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    window.scroll(0, 0);
    this.route.params.subscribe((params) => {
      this.id = +params['id'];
      this.fetchProperty(this.id);
    });
  }

  fetchProperty(id: number) {
    this.propertyService
      .fetchById(id)
      .pipe(takeUntil(this.unsubscribe$))
      .subscribe(
        (response) => {
          this.property = response;
        },
        (error) => {
          if (error.status === 404) {
            this.router.navigate(['/not-found']);
          }
        }
      );
  }

  ngOnDestroy(): void {
    this.unsubscribe$.next();
    this.unsubscribe$.complete();
  }
}
