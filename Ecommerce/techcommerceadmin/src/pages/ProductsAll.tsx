import React, {ChangeEvent, useEffect, useState} from 'react';
import DataTable, {TableColumn} from 'react-data-table-component';
import { useDispatch, useSelector } from "react-redux";
import { AppDispatch, RootState } from "../store/store";
import { fetchProducts, setPage, setPageSize } from '../store/productsSlice';
import { productColumns } from '../components/data/productColumns';
import {filterProducts} from "../actions/tableActions";
import '../components/css/dataTable.css'

const ProductsAll = () => {     
    const dispatch: AppDispatch = useDispatch();
    const { products, loading, pageNumber, pageSize } = useSelector((state: RootState) => state.products);
    const [searchTerm, setSearchTerm] = useState('');

    useEffect(() => {
        dispatch(fetchProducts({ page: pageNumber, pageSize }));
    }, [dispatch, pageNumber, pageSize]);
    
    const filteredProducts = filterProducts(products, searchTerm);

    return (
        <div>
            <div className="search-container">
                <input
                    type="text"
                    placeholder="Search all parameters..."
                    value={searchTerm}
                    onChange={(e) => setSearchTerm(e.target.value)}
                    className="search-input"
                />
            </div>
            <DataTable
                className={'dataTable'}
                title="Products"
                columns={productColumns}
                data={filteredProducts}
                progressPending={loading}
                pagination
                paginationServer
                    paginationTotalRows={filteredProducts.length}
                onChangePage={(page) => dispatch(setPage(page))}
                onChangeRowsPerPage={(rowsPerPage) => dispatch(setPageSize(rowsPerPage))}
                noDataComponent="No products available"
            />
        </div>
    );
};

export default ProductsAll;