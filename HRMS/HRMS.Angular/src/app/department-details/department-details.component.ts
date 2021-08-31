import { Component, OnInit } from '@angular/core';
import { DepartmentDetailsService } from '../shared/department-details.service';
import { DepartmentDetails } from '../shared/department-details.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-department-details',
  templateUrl: './department-details.component.html',
  styles: [
  ]
})
export class DepartmentDetailsComponent implements OnInit {

  constructor(public service: DepartmentDetailsService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord:DepartmentDetails){
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if (confirm('Are you sure you want to delete this employee?')){
    this.service.deleteEmployeeDetails(id).subscribe(
      res =>{
        this.service.refreshList();
        this.service.formData = new DepartmentDetails();
        this.toastr.error("Deleted successfully", "Employee Register");
      },
      err =>{
        console.log(err);
      });
    }
  }

}
