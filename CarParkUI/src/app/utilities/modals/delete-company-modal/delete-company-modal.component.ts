import { Component, EventEmitter, Input, Output, ViewEncapsulation } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';
import { Company } from 'src/app/services/models';
import { SysAdminService } from 'src/app/services/sys-admin.service';
import { ToastService } from 'src/app/services/toast.service';

@Component({
  selector: 'app-delete-company-modal',
  templateUrl: './delete-company-modal.component.html',
  styleUrls: ['./delete-company-modal.component.css'],
  standalone: true,
  imports: [FormsModule,ReactiveFormsModule],
  encapsulation: ViewEncapsulation.None,
})
export class DeleteCompanyModalComponent {
  @Input() companies: Company[] = [];
  @Input() viewCompanies: Company[] = [];
  @Input() companyId: number = 0;
  @Output() handleCompaniesPageChangesEvent = new EventEmitter<number>();

  modalOptions: NgbModalOptions | undefined;
  constructor(private modalService: NgbModal, private sysAdminService: SysAdminService,private toastService: ToastService) { }

  open(content: any) {
    this.modalService.open(content, this.modalOptions);
  }
  deleteCompany(id: number) {
    const deletedCompany = this.companies.findIndex(company => company.id == id);
    if (deletedCompany != -1) {
      this.companies.splice(deletedCompany, 1);
      this.viewCompanies.splice(deletedCompany, 1);
      this.sysAdminService.deleteCompany(id).subscribe();
      this.handleCompaniesPageChangesEvent.emit();
      this.toastService.show('Company deleted successfully!', { classname: 'bg-success text-light', delay: 3000 });
    }
    else{
      this.toastService.show('Something went wrong!', { classname: 'bg-danger text-light', delay: 3000 });
    }
  }
}
