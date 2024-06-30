import { Component } from "@angular/core";
import { Repository } from "../services/repository";
@Component({
  selector: "store-body",
  templateUrl: "store.component.html"
})
export class StoreComponent {
  constructor(private repository: Repository) {
  }
}
