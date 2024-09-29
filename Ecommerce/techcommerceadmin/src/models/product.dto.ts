export interface ProductDTO {
    id: number,
    name: string,
    imageUrl: string,
    description: string,
    price: number
};

export interface ImageResponseDTO {
    message: string;  // Ссылка на загруженное изображение
    code: number;     // Код ответа (например, 200 для успешного запроса)
}

export interface AddProductRequestDTO {
    name: string,
    imagePath: string,
    description: string,
    price: number
}

export interface ProductsRequestDTO {
    page: number,
    pageSize: number
}

export interface ProductsResponseDTO {
    items: ProductDTO[];
    totalCount: number;
    pageNumber: number;
    pageSize: number;
    totalPages: number;
    hasPreviousPage: boolean;
    hasNextPage: boolean;
}

export interface FiltersState {
    name: string;
    description: string;
    price: string;
}