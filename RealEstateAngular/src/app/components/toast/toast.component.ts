import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ToastType } from 'src/app/models/toastType.enum';

@Component({
  selector: 'app-toast',
  templateUrl: './toast.component.html',
  styleUrls: ['./toast.component.css'],
})
export class ToastComponent {
  @Input() message: string = '';
  @Input() toastType: ToastType = ToastType.Success;
  @Output() close = new EventEmitter<void>();
  icon: string = '';

  ngOnInit() {
    this.setIcon();
  }

  setIcon() {
    const icons = {
      [ToastType.Success]: '../../../assets/images/success.svg',
      [ToastType.Warning]: '../../../assets/images/warning.svg',
      [ToastType.Danger]: '../../../assets/images/danger.svg',
    };

    this.icon = icons[this.toastType] || icons[ToastType.Success];
  }

  handleClose() {
    this.close.emit();
  }
}
