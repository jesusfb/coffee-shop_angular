import { Component } from '@angular/core';
import { Repository } from './models/repository';
import { Product } from './models/product.model';
import { Supplier } from './models/supplier.model';
import { ErrorHandlerService } from './errorHandler.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  title = 'CoffeeShop.ClientApp';

  private lastError: string[] = [];

  constructor(private repo: Repository, errorService: ErrorHandlerService) {

    errorService.errors.subscribe(error => { this.lastError = error; });
  }

  get error(): string[] {
    return this.lastError;
  }

  clearError() {
    this.lastError = [];
  }

  get product(): Product {
    return this.repo.product;
  }

  get products(): Product[] {
    return this.repo.products;
  }

  get suppliers(): Supplier[] {
    return this.repo.suppliers;
  }

  async createProduct() {
    let product = new Product(
      "X-Ray Scuba Mask",
      "Watersports",
      "See what the fish are hiding",
      49.99,
      this.suppliers[0].id
    );
    await this.repo.createProduct(product);
  }

  async createProductAndSupplier() {
    let addedSupplier = new Supplier("Rocket Shoe Corp", "Boston", "MA");
    let product = new Product("Rocket-Powered Shoes", "Running", "Set a new record", 100, addedSupplier.id);
    let supplierId = await this.repo.createSupplier(addedSupplier);
    product.supplierId = supplierId;
    this.repo.createProduct(product);
  }

  replaceProduct() {
    let product = this.repo.products[0];
    product.name = "First product";
    product.category = "Category 1";
    product.price = 1400;
    product.supplierId = this.repo.products[2].supplierId;
    this.repo.replaceProduct(product);
  }

  replaceSupplier() {
    let supplier = this.repo.suppliers[this.repo.suppliers.length - 1];
    supplier.name = "Last supplier";
    supplier.city = "City 1";
    supplier.state = "ST";
    this.repo.replaceSupplier(supplier);
  }

  replaceProductAndSupplier() {
    let supplier = this.repo.suppliers[0];
    supplier.name = "First supplier";
    supplier.city = "City 1";
    supplier.state = "ST";

    let product = this.repo.products[0];
    product.name = "First product";
    product.category = "Category 1";
    product.price = 1400;
    product.supplierId = supplier.id;
    product.supplier = supplier;

    this.repo.replaceProductAndSupplier(product);
  }

  updateProduct() {
    let changes = new Map<string, any>();
    changes.set("name", "Green Kayak");
    changes.set("supplier", null);
    changes.set("id", this.repo.products[0].id);
    this.repo.updateProduct(changes);
  }

  updateSupplier() {
    let changes = new Map<string, any>();
    changes.set("name", "Green Supl");
    changes.set("city", "Chicago");
    changes.set("state", "IL");
    changes.set("id", this.repo.suppliers[this.repo.suppliers.length - 1].id);
    this.repo.updateSupplier(changes);
  }

  deleteProduct() {
    let product = this.repo.products[this.repo.products.length - 1];
    this.repo.deleteProduct(product.id!);
  }

  deleteSupplier() {
    let supplier = this.repo.suppliers[this.repo.suppliers.length - 1];
    this.repo.deleteSupplier(supplier.id!);
  }

  logProduct(product: any) {
    console.log('Product:', product);
  }
}
