import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { RouterModule } from '@angular/router'
import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { EmployeeDetailsFormComponent } from './employee-details/employee-details-form/employee-details-form.component';
import { DepartmentDetailsComponent } from './department-details/department-details.component';
import { DepartmentDetailsFormComponent } from './department-details/department-details-form/department-details-form.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeDetailsComponent,
    EmployeeDetailsFormComponent,
    DepartmentDetailsComponent,
    DepartmentDetailsFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: 'employees', component: EmployeeDetailsComponent },
      { path: 'departments', component: DepartmentDetailsComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
