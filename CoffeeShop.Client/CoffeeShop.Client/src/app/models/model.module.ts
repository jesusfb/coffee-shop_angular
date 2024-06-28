import { NgModule } from "@angular/core";
import { HttpClientModule } from '@angular/common/http';
import { Cart } from "./cart.model";
import { Order } from "./order.model";
import { Repository } from "../services/repository";
@NgModule({
  imports: [HttpClientModule],
  providers: [Repository, /*NavigationService,*/ Cart, Order]
})
export class ModelModule { }
