import {
  Component,
  EventEmitter,
  Input,
  Output,
  SimpleChanges,
} from '@angular/core';
import { MAX_FILES } from 'src/app/models/constants/constants';
import { ToastType } from 'src/app/models/toastType.enum';

@Component({
  selector: 'app-file-drag-input',
  templateUrl: './file-drag-input.component.html',
  styleUrls: ['./file-drag-input.component.css'],
})
export class FileDragInputComponent {
  @Input() selectedFiles: File[] = [];
  @Input() maxNumberOfFiles: number = MAX_FILES;
  @Output() filesChanged = new EventEmitter<File[]>();

  filePreviews: string[] = [];
  toastType = ToastType;
  showDangerToast: boolean = false;

  ngOnChanges(changes: SimpleChanges) {
    if (changes['selectedFiles']) {
      this.updatePreviews();
    }
  }

  onFilesSelected(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files) {
      this.addFiles(Array.from(input.files));
    }
  }

  onDrop(event: DragEvent) {
    event.preventDefault();
    if (event.dataTransfer?.files) {
      this.addFiles(Array.from(event.dataTransfer.files));
    }
  }

  onDragOver(event: DragEvent) {
    event.preventDefault();
  }

  addFiles(files: File[]) {
    const remainingSlots = this.maxNumberOfFiles - this.selectedFiles.length;

    if (remainingSlots <= 0) {
      this.toggleErrorToast(true);
      return;
    }

    const validFiles = files
      .filter((file) => file.type.startsWith('image/'))
      .slice(0, remainingSlots);

    for (const file of validFiles) {
      if (!this.selectedFiles.some((f) => f.name === file.name)) {
        this.selectedFiles.push(file);
      }
    }

    this.filesChanged.emit(this.selectedFiles);
    this.updatePreviews();
  }

  updatePreviews() {
    this.filePreviews = this.selectedFiles.map((file) =>
      URL.createObjectURL(file)
    );
  }

  removeFile(index: number) {
    this.selectedFiles.splice(index, 1);
    this.filesChanged.emit(this.selectedFiles);
    this.updatePreviews();
  }

  toggleErrorToast(state: boolean) {
    this.showDangerToast = state;
  }

  ngOnDestroy() {
    this.filePreviews.forEach((url) => URL.revokeObjectURL(url));
  }
}
