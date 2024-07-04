import { Product } from "../models/product.model";
import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Filter, Pagination } from "../models/configClasses.repository";
import { Supplier } from "../models/supplier.model";
import { plainToClass } from 'class-transformer';
import { Observable, catchError, of, tap } from "rxjs";
import { Category } from "../models/category.model";
//const productsUrl = "/api/products";

export const API_BASE_URL = 'https://localhost:8081/api';

const productsUrl = `${API_BASE_URL}/products`;
const suppliersUrl = `${API_BASE_URL}/suppliers`;
const sessionUrl = `${API_BASE_URL}/session`;
const ordersUrl = `${API_BASE_URL}/orders`;


@Injectable()
export class Repository {
  product: Product = new Product();
  products: Product[] = [];
  suppliers: Supplier[] = [];
  categories: Category[] = [];
  filter: Filter = new Filter();
  paginationObject = new Pagination();
  constructor(private http: HttpClient) {
    this.getCategories();
  }

  getProduct(id: number) {
    this.http.get<Product>(`${productsUrl}/${id}`)
      .subscribe(p => this.product = p);
  }

  getProducts(): void {
    let params = new HttpParams();

    if (this.filter) {
      Object.keys(this.filter).forEach(key => {
        const value = this.filter[key];
        if (value !== undefined && value !== null && value !== '') {
          params = params.set(key, value);
        }
      });
    }

    this.http.get<Product[]>(productsUrl, { params }).pipe(
      catchError(error => {
        console.error('Error loading products:', error);
        throw error;
      })
    ).subscribe(
      products => {
        this.products = products;
        console.log('Products loaded:', this.products);
      },
      error => {
        console.error('Error loading products:', error);
      }
    );
  }

  //getProducts() {
  //  let url = `${productsUrl}`;
  //  const queryParams = [];

  //  if (this.filter.category !== undefined && this.filter.category !== "") {
  //    queryParams.push(`category=${encodeURIComponent(this.filter.category)}`);
  //  }

  //  if (this.filter.subcategory !== undefined && this.filter.subcategory !== "") {
  //    queryParams.push(`subcategory=${encodeURIComponent(this.filter.subcategory)}`);
  //  }

  //  if (this.filter.search !== undefined && this.filter.search !== "") {
  //    queryParams.push(`search=${encodeURIComponent(this.filter.search)}`);
  //  }

  //  if (queryParams.length > 0) {
  //    url += `?${queryParams.join('&')}`;
  //  }

  //  this.http.get<Product[]>(url).subscribe(
  //    prods => {
  //      this.products = prods;
  //      console.log(this.products);
  //    },
  //    error => {
  //      console.error('Error loading products:', error);
  //    }
  //  );

  //  console.log(url);
  //}

  getSuppliers() {
    this.http.get<Supplier[]>(suppliersUrl)
      .subscribe(sups => this.suppliers = sups);
  }

  updateData() {
    this.getProducts();
    this.getSuppliers();
  }

  //createProduct(prod: Product): string {
  //  const data = plainToClass(Product, prod);
  //  let id: string;
  //  this.http.post<string>(productsUrl, data).subscribe(responseId => { this.updateData(); id = responseId; });
  //  return id;
  //}

  async createProduct(prod: Product): Promise<number> {
    try {
      const data = plainToClass(Product, prod);
      const responseId = await this.http.post<number>(productsUrl, data).toPromise();
      return responseId as number;
    } catch (error) {
      console.error('Error creating product:', error);
      throw error;
    }
  }

  //createSupplier(supplier: Supplier): number {
  //  const data = plainToClass(Supplier, supplier);
  //  let id: number;
  //  this.http.post<number>(suppliersUrl, data).subscribe(responseId => { this.updateData(); id = responseId; });
  //  return id;
  //}

  async createSupplier(supplier: Supplier): Promise<number> {
    const data = plainToClass(Supplier, supplier);

    try {
      const responseId = await this.http.post<number>(suppliersUrl, data).toPromise();
      this.updateData();
      return responseId as number;
    } catch (error) {
      console.error('Error creating supplier', error);
      throw error;
    }
  }

  replaceProduct(product: Product) {
    let data = plainToClass(Product, product);
    this.http.put(productsUrl, data).subscribe(() => this.updateData());
  }

  replaceSupplier(supplier: Supplier) {
    let data = plainToClass(Supplier, supplier);
    this.http.put(suppliersUrl, data).subscribe(() => this.updateData());
  }

  replaceProductAndSupplier(product: Product) {
    let data = plainToClass(Product, product);
    this.http.put(`${productsUrl}/complete-supplier-and-product-update`, data)
      .subscribe(() => this.updateData());
  }

  updateProduct(changes: Map<string, any>) {
    let patch: any[] = [];
    changes.forEach((value, key) => patch.push({ op: "replace", path: key, value: value }));
    this.http.patch(`${productsUrl}`, patch).subscribe(() => this.updateData());
  }

  updateSupplier(changes: Map<string, any>) {
    let patch: any[] = [];
    changes.forEach((value, key) => patch.push({ op: "replace", path: key, value: value }));
    this.http.patch(`${suppliersUrl}`, patch).subscribe(() => this.updateData());
  }

  deleteProduct(id: number) {
    this.http.delete<void>(`${productsUrl}/${id}`).subscribe(() => this.updateData());
  }

  deleteSupplier(id: number) {
    this.http.delete(`${suppliersUrl}/${id}`).subscribe(() => this.updateData());
  }

  getCategories() {
    console.log(`${productsUrl}/categories`);
    this.http.get<Category[]>(`${productsUrl}/categories`).subscribe(categories => this.categories = categories);
  }

  storeSessionData<T>(dataType: string, data: T) {
    return this.http.post(`${sessionUrl}/${dataType}`, data).subscribe(response => { });
  }

  getSessionData<T>(dataType: string): Observable<T> {
    console.log(dataType);
    console.log(sessionUrl);
    return this.http.get<T>(`${sessionUrl}/${dataType}`);
  }

  //getOrders() {
  //  this.http.get<Order[]>(ordersUrl)
  //    .subscribe(data => this.orders = data);
  //}

  //createOrder(order: Order) {
  //  this.http.post<OrderConfirmation>(ordersUrl, {
  //    name: order.name,
  //    address: order.address,
  //    payment: order.payment,
  //    products: order.products
  //  }).subscribe(data => {
  //    order.orderConfirmation = data
  //    order.cart.clear();
  //    order.clear();
  //  });
  //}

  //shipOrder(order: Order) {
  //  this.http.post(`${ordersUrl}/${order.id}`, {})
  //    .subscribe(() => this.getOrders())
  //}

  login(name: string, password: string): Observable<boolean> {
    return this.http.post<boolean>("/api/account/login", { name: name, password: password });
  }

  logout() {
    this.http.post("/api/account/logout", null).subscribe(response => { });
  }
}
