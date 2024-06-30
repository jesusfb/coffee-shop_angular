import { NgModule } from "@angular/core";
import { HttpClientModule } from '@angular/common/http';
import { Repository } from "../services/repository";
import { NavigationService } from "../services/navigation.service";
@NgModule({
  imports: [HttpClientModule],
  providers: [Repository, NavigationService]
})
export class ModelModule { }
