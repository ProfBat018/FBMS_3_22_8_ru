export interface CategoryDTO {
    id: number,
    name: string, 
    parentCategoryId: number
}

export interface HierarchicalCategory {
    id: number,
    name: string;
    subcategories: HierarchicalCategory[];
}