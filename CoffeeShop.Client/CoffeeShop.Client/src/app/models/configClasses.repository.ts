export class Filter {
  category?: string | "";
  subcategory?: string | "";
  search?: string | "";

  //reset() {
  //  this.category = this.search = '';
}

export class Pagination {
  productsPerPage: number = 4;
  currentPage = 1;
}
