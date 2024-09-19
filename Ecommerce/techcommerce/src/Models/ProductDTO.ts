export interface ProductDTO {
    id: number
    name: string,
    description: string,
    price: number
}

export interface ProductSearchDTO {
    page: number,
    pageSize: number
}

export interface PaginatedListDTO<T> {
    items: T[];        // Array of items of type T
    totalCount: number; // Total number of items available
    pageNumber: number; // Current page number
    pageSize: number;   // Number of items per page
    totalPages: number; // Total number of pages
    hasPreviousPage: boolean; // Indicates if there's a previous page
    hasNextPage: boolean;     // Indicates if there's a next page
}
