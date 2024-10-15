import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Input,
  Output,
} from '@angular/core';
import { SelectOption } from 'src/app/models/select-option.model';

@Component({
  selector: 'app-select',
  templateUrl: './select.component.html',
  styleUrls: ['./select.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SelectComponent {
  @Input() icon: string = '';
  @Input() placeholder: string = '';
  @Input() options: SelectOption[] = [];
  @Input() fontSize: 'small' | 'medium' | 'large' = 'medium';

  selectedOption: string | null = null;

  @Output() selectionChange = new EventEmitter<string | null>();

  handleSelectionChange(event: Event) {
    const selectElement = event.target as HTMLSelectElement;
    this.selectedOption = selectElement.value;
    this.selectionChange.emit(this.selectedOption);
  }
}
