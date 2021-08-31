import { Injectable } from '@angular/core';
import { DepartmentDetails } from './department-details.model';
import { HttpClient } from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class DepartmentDetailsService {

  constructor(private http:HttpClient) { }

  formData: DepartmentDetails = new DepartmentDetails();
  readonly URL = 'https://localhost:5001/api/Departments';
  list : DepartmentDetails[];

  postEmployeeDetails(){
    return this.http.post(this.URL, this.formData);
  }

  putEmployeeDetails(){
    return this.http.put(`${this.URL}/${this.formData.departmentId}`, this.formData);
  }

  deleteEmployeeDetails(id:number){
    return this.http.delete(`${this.URL}/${id}`);
  }

  refreshList(){
    this.http.get(this.URL)
    .toPromise()
    .then(res =>{
      this.list = res as DepartmentDetails[]
    });
  }
}
