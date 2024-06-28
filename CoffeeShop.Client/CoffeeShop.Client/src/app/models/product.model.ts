import { Supplier } from "./supplier.model";
import { Rating } from "./rating.model";
export class Product {
  constructor(
    public name?: string,
    public category?: string,
    public description?: string,
    public price: number = 0,
    public supplierId?: number,
    public ratings?: Rating[] | null,
    public supplier?: Supplier | null,
    public ratingsCount?: number | 0,
    public id?: number)
  { }
}


