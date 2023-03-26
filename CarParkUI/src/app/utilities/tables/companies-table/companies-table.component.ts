import { Component, OnInit } from '@angular/core';
import { Company } from 'src/app/services/models';
import { SysAdminService } from 'src/app/services/sys-admin.service';

@Component({
  selector: 'app-companies-table',
  templateUrl: './companies-table.component.html',
  styleUrls: ['./companies-table.component.css']
})
export class CompaniesTableComponent implements OnInit{
  companies: Company[] = [];
  pageNumbersCompanies: number[] = [];
  viewCompanies: Company[] = [];
  pageNumberCompanies: number = 1;

  constructor(private sysAdminService: SysAdminService){

  }
  ngOnInit(): void {
    this.sysAdminService.getCompanies().subscribe(
      (data) => {
        this.companies = data;
        let i = 0;
        while (i < Math.ceil(this.companies.length / 15)) {
          this.pageNumbersCompanies.push(++i);
        }
        this.viewCompanies = this.companies.slice(0, 15);
        this.viewCompanies.splice(this.viewCompanies.findIndex(company => company.id == 1), 1);
      }
    );
  }
  handleCompanyChanges(id: number) {
    const changedCompany = this.companies.findIndex(company => company.id == id);
    if (changedCompany != -1) {
      this.companies[changedCompany].isValid = this.companies[changedCompany].isValid == 1 ? 0 : 1;
      this.sysAdminService.updateCompany(this.companies[changedCompany]).subscribe();
    }
  }
  handleCompanyPageChanges(pageNumber: number) {
    if(Math.ceil(this.companies.length / 15)>this.pageNumbersCompanies.length){
      this.pageNumbersCompanies.push(this.pageNumbersCompanies.length+1);
    }
    else if(Math.ceil(this.companies.length / 15)<this.pageNumbersCompanies.length){
      this.pageNumbersCompanies.pop();
    }
    this.viewCompanies = this.companies.slice((pageNumber - 1) * 15, pageNumber * 15);
    this.pageNumberCompanies = pageNumber;
  }
  filterCompanies(search: HTMLInputElement) {
    if (search.value == "") { this.viewCompanies = this.companies.slice(0, 15); return; }
    this.viewCompanies = this.companies.filter(company => company.name.toLowerCase().includes(search.value.toLowerCase()));
  }
}
