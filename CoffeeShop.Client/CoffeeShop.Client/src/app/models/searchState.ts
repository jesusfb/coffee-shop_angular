import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root", // Сервис будет единым для всего приложения
})

export class SearchStateService {
  private searchTerm = "";

  getSearchTerm(): string {
    return this.searchTerm;
  }

  setSearchTerm(term: string): void {
    this.searchTerm = term;
  }
}
