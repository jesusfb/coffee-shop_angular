import { Component } from "@angular/core";
import { Repository } from "../services/repository";
import { Category } from "../models/category.model";
@Component({
  selector: "store-body",
  templateUrl: "store.component.html"
})
export class StoreComponent {
  constructor(private repository: Repository) {
   // this.repository.getProducts();
    this.repository.getCategories();
    
  }
}
