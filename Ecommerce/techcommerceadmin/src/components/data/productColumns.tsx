import { TableColumn } from 'react-data-table-component';
import { ProductDTO } from '../../models/product.dto';

import React from "react";

export const productColumns: TableColumn<ProductDTO>[] = [
    {
        name: 'Name',
        selector: (row) => row.name,
        sortable: true,
    },
    {
        name: 'Description',
        selector: (row) => row.description,
        sortable: true,
    },
    {
        name: 'Price',
        selector: (row) => row.price.toFixed(2),
        sortable: true,
    },
    {
        name: 'Actions',
        cell: (row) => (
            <>
                <button className="edit" onClick={() => alert(`Edit ${row.name}`)}>Edit</button>
                <button className="delete" onClick={() => alert(`Delete ${row.name}`)}>Delete</button>
            </>
        ),
    }
];
