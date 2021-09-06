import { Component, OnInit } from '@angular/core';
import { ItemDetailsService } from '../shared/item-details.service';
import { ItemDetails } from '../shared/item-details.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styles: [
  ]
})
export class ItemDetailsComponent implements OnInit {

  constructor(public service: ItemDetailsService,
    private toastr:ToastrService) { }

  ngOnInit(): void {
    this.service.refreshList();
  }

  populateForm(selectedRecord:ItemDetails){
    this.service.formData = Object.assign({}, selectedRecord);
  }

  onDelete(id:number){
    if (confirm('Are you sure you want to delete this employee?')){
    this.service.deleteItemDetails(id).subscribe(
      res =>{
        this.service.refreshList();
        this.service.formData = new ItemDetails();
        this.toastr.error("Deleted successfully", "Employee Register");
      },
      err =>{
        console.log(err);
      });
    }
  }

}
