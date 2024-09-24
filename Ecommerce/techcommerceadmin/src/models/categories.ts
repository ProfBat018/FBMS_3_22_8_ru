interface Category {
    name: string;
    subcategories?: string[];
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
  