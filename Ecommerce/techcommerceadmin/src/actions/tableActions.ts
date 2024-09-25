import { ProductDTO, FiltersState} from "../models/product.dto";



export const filterProducts = (products: ProductDTO[], searchTerm: string): ProductDTO[] => {
    return products.filter((product: ProductDTO) => {
        return (
            product.name.toLowerCase().includes(searchTerm.toLowerCase()) ||
            product.description.toLowerCase().includes(searchTerm.toLowerCase()) ||
            product.price.toString().includes(searchTerm)
        );
    });
};