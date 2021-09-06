import { Component, OnInit } from '@angular/core';
import { ItemDetailsService } from '../../shared/item-details.service';
import { NgForm } from '@angular/forms';
import { ItemDetails } from '../../shared/item-details.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-item-details-form',
  templateUrl: './item-details-form.component.html',
  styles: [
  ]
})
export class ItemDetailsFormComponent implements OnInit {

  constructor(public service:ItemDetailsService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
  }

  onSubmit(form:NgForm){
    if (this.service.formData.itemId == 0){
      this.insertRecord(form);
    }
    else{
      this.updateRecord(form);
    }
  }

  insertRecord(form:NgForm){
    this.service.postItemDetails().subscribe(
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
    this.service.putItemDetails().subscribe(
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
    this.service.formData = new ItemDetails();
  }
}
