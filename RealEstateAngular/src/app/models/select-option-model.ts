export class SelectOption {
  label: string;
  value: string;
  icon?: string;

  constructor(label: string, value: string, icon?: string) {
    this.label = label;
    this.value = value;
    this.icon = icon;
  }
}
