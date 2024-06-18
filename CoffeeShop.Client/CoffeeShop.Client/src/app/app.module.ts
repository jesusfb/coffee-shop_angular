import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ModelModule } from './models/model.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { StoreModule } from './store/store.module';
import { ErrorHandlerService } from './errorHandler.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
//import { ProductTableComponent } from './structure/productTable.component';
//import { CategoryFilterComponent } from './structure/categoryFilter';
//import { ProductDetailComponent } from './structure/productDetail';

@NgModule({
  declarations: [
    AppComponent
    //ProductTableComponent,
    //CategoryFilterComponent,
    //ProductDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ModelModule,
    StoreModule,
    BrowserAnimationsModule,
    MatMenuModule,
    MatButtonModule
  ],
  providers: [
    [ErrorHandlerService,
      {
        provide: HTTP_INTERCEPTORS,
        useExisting: ErrorHandlerService, multi: true
      },
    
    provideAnimationsAsync()
  ]
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
