import { CommonModule } from "@angular/common";
import { HeaderComponent } from "./header.component";
import { CartComponent } from "./cart.component";
import { SearchComponent } from "./search.component";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";

@NgModule({
  declarations: [
    HeaderComponent,
    CartComponent,
    SearchComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports: [
    HeaderComponent
  ]
})
export class HeaderModule { }
