import { Component, Input } from '@angular/core';
import { Product } from '../models/product.model';

@Component({
  selector: 'store-ratings',
  templateUrl: './ratings.component.html'
})
export class RatingsComponent {

  @Input()
  product: Product | undefined;

  get stars(): boolean[] {
    if (!this.product || !this.product.ratings) {
      return []; // Return an empty array if there is no data
    }

    // Calculate the total sum of stars
    const totalStars = this.product.ratings.reduce((acc, rating) => {
      return acc + (rating.stars || 0); // Include only numeric values for stars
    }, 0);

    const averageStars = Math.round(totalStars / this.product.ratings.length);

    // Generate an array of boolean values for displaying stars
    return Array(5).fill(false).map((_, index) => index < averageStars);
  }
}
