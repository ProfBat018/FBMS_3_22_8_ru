import React, { ChangeEvent, useState } from 'react';
import DataTable from 'react-data-table-component';
import { useProducts } from '../hooks/useProducts';
import '../components/css/dataTable.css';
import { productColumns } from "../components/data/productColumns";


const ProductsAll: React.FC = () => {
    
    const [pageNumber, setPageNumber] = useState<number>(1);
    const [pageSize, setPageSizeState] = useState<number>(10);

    const {
        products,
        totalCount,
        totalPages,
        hasPreviousPage,
        hasNextPage,
        loading,
        error
    } = useProducts({ page: pageNumber, pageSize });

    const handlePageChange = (page: number) => {
        setPageNumber(page);
    };

    const handlePageSizeChange = (size: number) => {
        setPageSizeState(size);
    };

    if (loading) return <div>Loading...</div>;
    if (error) return <div>Error loading products: {error.message}</div>;

    return (
        <div>
            <DataTable
                className={'dataTable'}
                title="Products"
                columns={productColumns}
                data={products}
                pagination
                paginationServer
                paginationDefaultPage={pageNumber}
                paginationTotalRows={totalCount}
                onChangePage={handlePageChange}
                onChangeRowsPerPage={handlePageSizeChange}
                noDataComponent="No products available"
            />
        </div>
    );
};

export default ProductsAll;
