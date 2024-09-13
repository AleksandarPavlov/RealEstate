import { Component, Input } from '@angular/core';
import { Property } from 'src/app/models/property.model';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css'],
})
export class TableComponent {
  @Input() properties!: Property[];
}
