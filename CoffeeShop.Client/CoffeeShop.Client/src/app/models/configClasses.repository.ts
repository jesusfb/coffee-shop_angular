export class Filter {
  [key: string]: string | undefined;

  category?: string = "";
  subcategory?: string = "";
  search?: string = "";
}


export class Pagination {
  productsPerPage: number = 4;
  currentPage = 1;
}
