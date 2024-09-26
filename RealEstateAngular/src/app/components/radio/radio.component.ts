import { Component, Input } from '@angular/core';
import { RadioSize } from 'src/app/models/radioSize.enum';

@Component({
  selector: 'app-radio',
  templateUrl: './radio.component.html',
  styleUrls: ['./radio.component.css'],
})
export class RadioComponent {
  @Input() options: string[] = [];
  @Input() name: string = '';
  @Input() size: RadioSize = RadioSize.Medium;
  radioSize = RadioSize;
}
