import React, {useEffect} from 'react';
import {useSelector, useDispatch} from 'react-redux';
import {RootState, AppDispatch} from '../store/store';
import {fetchProducts, setPage, setPageSize} from '../store/productsSlice';

const Products = () => {
    const dispatch = useDispatch<AppDispatch>();
    const {
        products,
        loading,
        error,
        pageNumber,
        pageSize,
        totalPages,
        hasPreviousPage,
        hasNextPage
    } = useSelector((state: RootState) => state.products);

    useEffect(() => {
        dispatch(fetchProducts({page: pageNumber, pageSize}));
    }, [dispatch, pageNumber, pageSize]);

    if (loading) return <div>Загрузка...</div>;
    if (error) return <div>Ошибка: {error}</div>;

    return (
        <div>
            <ul>
                {products.map((product) => (
                        <li key={product.id}>
                            <img src={product.imageUrl} alt={product.name}/>
                            <p>{product.name}</p>
                            <p>{product.description}</p>
                            <p>{product.price} ₽</p>
                        </li>
                ))}
            </ul>

            <div>
                <button
                    onClick={() => dispatch(setPage(pageNumber - 1))}
                    disabled={!hasPreviousPage}
                >
                    Предыдущая страница
                </button>

                <span>Страница {pageNumber} из {totalPages}</span>

                <button
                    onClick={() => dispatch(setPage(pageNumber + 1))}
                    disabled={!hasNextPage}
                >
                    Следующая страница
                </button>
            </div>

            <div>
                <label>Количество на странице: </label>
                <select value={pageSize} onChange={(e) => dispatch(setPageSize(Number(e.target.value)))}>
                    <option value={5}>5</option>
                    <option value={10}>10</option>
                    <option value={20}>20</option>
                </select>
            </div>
        </div>
    );
};

export default Products;
