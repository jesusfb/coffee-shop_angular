import { NgModule } from "@angular/core";
import { HttpClientModule } from '@angular/common/http';
import { Repository } from "../services/repository";
@NgModule({
  imports: [HttpClientModule],
  providers: [Repository]
})
export class ModelModule { }
