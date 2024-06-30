import { Component, OnInit } from '@angular/core';
import { Repository } from '../services/repository';
import { Category } from '../models/category.model';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent {
  selectedCategory: string = "";
  selectedSubcategory: string = "";
  categories: Category[] = [];

  constructor(public repository: Repository) {
    this.repository.getCategories(() => {
      this.categories = this.repository.categories;
    });
    this.selectedCategory = "Shop by categories";
    this.selectedSubcategory = "";
  }

  //get selectedCategory(): string {
  //  return this._selectedCategory;
  //}

  //set selectedCategory(value: string) {
  //  this._selectedCategory = value;
  //  this.navigationService.currentCategory = value;
  //}

  setCurrentCategory(category: string, subcategory: string | ""): void {
    this.selectedCategory = category;
    this.selectedSubcategory = subcategory;
    this.repository.filter.category = category;
    this.repository.filter.subcategory = subcategory;
    //this.navigationService.currentCategory = category;
    //this.navigationService.currentSubcategory = subcategory;
  }

  //onCategoryChange(event: Event): void {
  //  const target = event.target as HTMLSelectElement;
  //  const value = target?.value || '';
  //  this.setCurrentCategory(value, '');
  //}

  //updateCurrentCategory(category: string): void {
  //  this.navigationService.currentCategory = category;
  //  this.selectedCategory = category;
  //}
}
