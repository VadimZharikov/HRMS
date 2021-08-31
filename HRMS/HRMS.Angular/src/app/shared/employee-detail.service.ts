import { Injectable } from '@angular/core';
import { EmployeeDetails } from './employee-detail.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeeDetailsService {

  constructor(private http:HttpClient) { }

  formData: EmployeeDetails = new EmployeeDetails();
  readonly URL = 'https://localhost:5001/api/Employee';
  list : EmployeeDetails[];

  postEmployeeDetails(){
    return this.http.post(this.URL, this.formData);
  }

  putEmployeeDetails(){
    return this.http.put(`${this.URL}/${this.formData.employeeId}`, this.formData);
  }

  deleteEmployeeDetails(id:number){
    return this.http.delete(`${this.URL}/${id}`);
  }

  refreshList(){
    this.http.get(this.URL)
    .toPromise()
    .then(res =>{
      this.list = res as EmployeeDetails[]
    });
  }
}
