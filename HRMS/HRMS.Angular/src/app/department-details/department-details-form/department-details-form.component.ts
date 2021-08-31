import { Component, OnInit } from '@angular/core';
import { DepartmentDetailsService } from '../../shared/department-details.service';
import { NgForm } from '@angular/forms';
import { DepartmentDetails } from '../../shared/department-details.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-department-details-form',
  templateUrl: './department-details-form.component.html',
  styles: [
  ]
})
export class DepartmentDetailsFormComponent implements OnInit {

  constructor(public service:DepartmentDetailsService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if (this.service.formData.departmentId == 0){
      this.insertRecord(form);
    }
    else{
      this.updateRecord(form);
    }
  }

  insertRecord(form:NgForm){
    this.service.postEmployeeDetails().subscribe(
        res =>{
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.success('Submited successfully', 'Department Register');
        },
        err =>{
          console.log(err);
        }
      );
  }

  updateRecord(form:NgForm){
    this.service.putEmployeeDetails().subscribe(
        res =>{
          this.resetForm(form);
          this.service.refreshList();
          this.toastr.info('Submited successfully', 'Department Register');
        },
        err =>{
          console.log(err);
        }
      );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new DepartmentDetails();
  }
}
