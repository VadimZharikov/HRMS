import { Injectable } from '@angular/core';
import { ItemDetails } from './item-details.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ItemDetailsService {

  constructor(private http:HttpClient) { }

  formData: ItemDetails = new ItemDetails();
  readonly URL = 'https://localhost:5500/Items';
  list : ItemDetails[];

  postItemDetails(){
    return this.http.post(this.URL, this.formData);
  }

  putItemDetails(){
    return this.http.put(`${this.URL}/${this.formData.itemId}`, this.formData);
  }

  deleteItemDetails(id:number){
    return this.http.delete(`${this.URL}/${id}`);
  }

  refreshList(){
    this.http.get(this.URL)
    .toPromise()
    .then(res =>{
      this.list = res as ItemDetails[]
    });
  }
}
