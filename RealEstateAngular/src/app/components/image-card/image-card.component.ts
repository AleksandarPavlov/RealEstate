import { Component, Input } from '@angular/core';
import { Property } from 'src/app/models/property.model';

@Component({
  selector: 'app-image-card',
  templateUrl: './image-card.component.html',
  styleUrls: ['./image-card.component.css'],
})
export class ImageCardComponent {
  @Input() property!: Property;
}
