import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { ErrorHandlerService } from './errorHandler.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { StoreModule } from './store/store.module';
import { ModelModule } from './models/model.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    StoreModule,
    ModelModule
   // AppRoutingModule
    //BrowserAnimationsModule,
    //MatMenuModule,
    //MatButtonModule
  ],
  providers: [
    [
      ErrorHandlerService,
      {
        provide: HTTP_INTERCEPTORS,
        useExisting: ErrorHandlerService,
        multi: true
      }
    ]
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
