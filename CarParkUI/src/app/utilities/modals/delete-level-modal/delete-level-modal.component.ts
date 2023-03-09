import { Component, EventEmitter, Input, Output, ViewEncapsulation } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { CompanyAdminService } from 'src/app/services/company-admin.service';
import { Level } from 'src/app/services/models';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-delete-level-modal',
  templateUrl: './delete-level-modal.component.html',
  styleUrls: ['./delete-level-modal.component.css'],
  standalone: true,
  imports: [FormsModule,ReactiveFormsModule],
  encapsulation: ViewEncapsulation.None,
})
export class DeleteLevelModalComponent{
  @Input() levels: Level[] = [];
  @Input() viewLevels: Level[] = [];
  @Input() levelId: number = 0;
  @Output() handleLevelsPageChangesEvent = new EventEmitter<number>();
  modalOptions: NgbModalOptions | undefined;
  constructor(private modalService: NgbModal, private companyAdminService: CompanyAdminService, private toastService: ToastService) { }
  open(content: any) {
    this.modalService.open(content, this.modalOptions);
  }
  deleteLevel(id: number) {
    const deletedLevel = this.levels.findIndex(level => level.id == id);
    if (deletedLevel != -1) {
      this.levels.splice(deletedLevel, 1);
      this.viewLevels.splice(deletedLevel, 1);
      this.companyAdminService.deleteLevel(id).subscribe();
      this.handleLevelsPageChangesEvent.emit();
      this.toastService.show('Level deleted successfully!', { classname: 'bg-success text-light', delay: 3000 });
    }
    else{
      this.toastService.show('Something went wrong!', { classname: 'bg-danger text-light', delay: 3000 });
    }
  }
}
