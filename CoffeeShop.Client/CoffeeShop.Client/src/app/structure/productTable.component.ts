import { Component, OnInit } from "@angular/core";
import { Product } from "../models/product.model";
import { Repository } from "../models/repository";
import { Router } from "@angular/router";

@Component(
  {
    selector: "product-table",
    templateUrl: "./productTable.component.html"
  }
)
export class ProductTableComponent {
  constructor(private repo: Repository, private router: Router) { }

  get products() {
    return this.repo.products;
  }

  //selectProduct(id: string) {
  //  this.repo.getProduct(id);
  //  this.router.navigateByUrl("/detail")
  //}
}
