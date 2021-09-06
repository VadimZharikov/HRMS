import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { OAuthModule } from "angular-oauth2-oidc";

import { RouterModule } from '@angular/router'
import { ToastrModule } from 'ngx-toastr';
import { AppComponent } from './app.component';
import { EmployeeDetailsComponent } from './employee-details/employee-details.component';
import { EmployeeDetailsFormComponent } from './employee-details/employee-details-form/employee-details-form.component';
import { DepartmentDetailsComponent } from './department-details/department-details.component';
import { DepartmentDetailsFormComponent } from './department-details/department-details-form/department-details-form.component';
import { ItemDetailsComponent } from './item-details/item-details.component';
import { ItemDetailsFormComponent } from './item-details/item-details-form/item-details-form.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeeDetailsComponent,
    EmployeeDetailsFormComponent,
    DepartmentDetailsComponent,
    DepartmentDetailsFormComponent,
    ItemDetailsComponent,
    ItemDetailsFormComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    OAuthModule.forRoot({
      resourceServer: {
      allowedUrls: ['https://localhost:5500'],
        sendAccessToken: true
    }}),
    ToastrModule.forRoot(),
    RouterModule.forRoot([
      { path: 'employees', component: EmployeeDetailsComponent },
      { path: 'departments', component: DepartmentDetailsComponent },
      { path: 'Inventory', component: ItemDetailsComponent },

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
