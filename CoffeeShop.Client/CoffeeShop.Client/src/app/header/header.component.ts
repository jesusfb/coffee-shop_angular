import { Component } from '@angular/core';
import { Repository } from '../services/repository';
import { Category } from '../models/category.model';
import { NavigationService } from '../services/navigation.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html'
})
export class HeaderComponent {
  selectedCategory: string = "";
  selectedSubcategory: string = "";
  categories: Category[] = [];

  constructor(public repository: Repository, private navigation: NavigationService) {
    this.selectedCategory = "All categories";
    this.selectedSubcategory = "";
  }

  setCurrentCategory(category: string, subcategory: string | ""): void {
    this.selectedCategory = category;
    this.selectedSubcategory = subcategory;
    this.navigation.currentCategory = category;
    this.navigation.currentSubcategory = subcategory;
  }
}
