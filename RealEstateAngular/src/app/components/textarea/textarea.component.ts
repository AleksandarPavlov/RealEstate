import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-textarea',
  templateUrl: './textarea.component.html',
  styleUrls: ['./textarea.component.css'],
})
export class TextareaComponent {
  @Input() label: string = '';
  @Input() hasAiIcon: boolean = false;
  @Input() isLoading: boolean = false;
  @Input() text: string | undefined = '';

  @Output() tooltipIconClick = new EventEmitter<void>();

  handleTooltipClick() {
    this.tooltipIconClick.emit();
  }
}
