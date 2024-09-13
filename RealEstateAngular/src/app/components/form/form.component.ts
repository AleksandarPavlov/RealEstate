import { Component } from '@angular/core';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css'],
})
export class FormComponent {
  activeTab: string = 'dashboard';

  selectTab(tab: string): void {
    this.activeTab = tab;
  }
}
