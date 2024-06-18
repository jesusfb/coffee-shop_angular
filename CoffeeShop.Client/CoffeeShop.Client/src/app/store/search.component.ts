import { AfterViewInit, Component, ElementRef, ViewChild } from "@angular/core";
import { Repository } from "../models/repository";
import { SearchStateService } from "../models/searchState";

@Component({
  selector: "store-search",
  template: `
    <div class="p-2 bg-info text-white">
      <form class="form-inline">
        <input
          type="text"
          class="form-control"
          #textInput
          name="searchTerm"
          placeholder="Enter search term"
        />
        <button class="btn btn-primary m-1" (click)="getSearchResult()">Search</button>

        <span *ngIf="!searchTerm">No results to display</span>
        <span *ngIf="searchTerm" class="ml-3">{{productCount}} products, total price is {{totalPrice | currency:"USD":"symbol"}}</span>
      </form>
    </div>
  `
})

export class SearchComponent implements AfterViewInit {
  constructor(private repo: Repository, private searchStateService: SearchStateService) { }

  @ViewChild('textInput', { static: false }) textInputRef!: ElementRef<HTMLInputElement>;
  searchTerm = "";

  ngAfterViewInit(): void {
    this.searchTerm = this.searchStateService.getSearchTerm();
    this.textInputRef.nativeElement.value = this.searchTerm;
    }

  getSearchResult() { 
    this.searchTerm = this.textInputRef.nativeElement.value;
    this.searchStateService.setSearchTerm(this.searchTerm);
    this.repo.filter.search = this.searchTerm;
    this.repo.getProducts();
  }

  get productCount() {
    return this.repo.products.length;
  }

  get totalPrice() {
    return this.repo.products.reduce((sum, product) => sum + product.price, 0);
  }
}


