import { Component } from '@angular/core';

@Component({
  selector: 'app-property-page',
  templateUrl: './property-page.component.html',
  styleUrls: ['./property-page.component.css'],
})
export class PropertyPageComponent {
  ngOnInit() {
    window.scroll(0, 0);
  }
}
