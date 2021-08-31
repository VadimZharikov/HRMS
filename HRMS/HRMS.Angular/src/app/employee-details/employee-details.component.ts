import { Component, OnInit } from '@angular/core';
import { EmployeeDetailsService } from '../shared/employee-detail.service';
import { EmployeeDetails } from '../shared/employee-detail.model';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-employee-details',
  templateUrl: './employee-details.component.html',
  styles: [
  ]
})
export class EmployeeDetailsComponent implements OnInit {

  constructor(public service: EmployeeDetailsService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord:EmployeeDetails){
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if (confirm('Are you sure you want to delete this employee?')){
    this.service.deleteEmployeeDetails(id).subscribe(
      res =>{
        this.service.refreshList();
        this.service.formData = new EmployeeDetails();
        this.toastr.error("Deleted successfully", "Employee Register");
      },
      err =>{
        console.log(err);
      });
    }
  }
}
