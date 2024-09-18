export interface CategoryDTO {
    name: string, 
    parentCategory: CategoryDTO
}

export interface HierarchicalCategory {
    name: string;
    subcategories: HierarchicalCategory[];
}