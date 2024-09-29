import { Component, Input } from '@angular/core';
import { SelectOption } from 'src/app/models/select-option.model';

@Component({
  selector: 'app-select',
  templateUrl: './select.component.html',
  styleUrls: ['./select.component.css'],
})
export class SelectComponent {
  @Input() icon: string = '';
  @Input() placeholder: string = '';
  @Input() options: SelectOption[] = [];
}
