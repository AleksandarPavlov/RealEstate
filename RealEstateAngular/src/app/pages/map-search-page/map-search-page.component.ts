import { Component } from '@angular/core';

@Component({
  selector: 'app-map-search-page',
  templateUrl: './map-search-page.component.html',
  styleUrls: ['./map-search-page.component.css'],
})
export class MapSearchPageComponent {
  ngOnInit() {
    window.scroll(0, 0);
  }
}
