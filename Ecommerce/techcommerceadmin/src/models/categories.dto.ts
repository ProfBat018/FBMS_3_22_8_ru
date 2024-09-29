interface Category {
    name: string;
    subcategories?: string[];
  }


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
  export const categories: Category[] = [
    {
      name: 'Products',
      subcategories: ['All', 'Add'],
    },
    {
      name: 'Categories',
      subcategories: ['All', 'Add'],
    },
    {
      name: 'Users',
      subcategories: ['All', 'Add'],
    },
  ];
  
