import { Component } from '@angular/core';
import { ErrorHandlerService } from './errorHandler.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'CoffeeShop.Client';

  private lastError: string[] = [];

  constructor(private errorService: ErrorHandlerService) {

    errorService.errors.subscribe(error => { this.lastError = error; });
  }

  get error(): string[] {
    return this.lastError;
  }

  clearError() {
    this.lastError = [];
  }
}
