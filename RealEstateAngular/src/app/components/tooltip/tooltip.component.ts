import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-tooltip',
  templateUrl: './tooltip.component.html',
  styleUrls: ['./tooltip.component.css'],
})
export class TooltipComponent {
  @Input() icon: string = '';
  @Input() text: string = '';
  @Input() size: 'large' | 'medium' = 'large';
}
