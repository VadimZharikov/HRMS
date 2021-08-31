import { Component, OnInit } from '@angular/core';
import { EmployeeDetailsService } from '../../shared/employee-detail.service';
import { NgForm } from '@angular/forms';
import { EmployeeDetails } from '../../shared/employee-detail.model';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-employee-details-form',
  templateUrl: './employee-details-form.component.html',
  styles: [
  ]
})
export class EmployeeDetailsFormComponent implements OnInit {

  constructor(public service:EmployeeDetailsService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if (this.service.formData.employeeId == 0){
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
          this.toastr.success('Submited successfully', 'Employee Register');
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
          this.toastr.info('Submited successfully', 'Employee Register');
        },
        err =>{
          console.log(err);
        }
      );
  }

  resetForm(form:NgForm){
    form.form.reset();
    this.service.formData = new EmployeeDetails();
  }
}
