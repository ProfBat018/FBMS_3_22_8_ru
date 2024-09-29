import React, { useState } from 'react';
import { AddProductRequestDTO } from '../models/product.dto';
import { useCategories, transformCategories } from '../hooks/useCategories';
import {addNewProduct} from "../actions/productActions";
import TextEditor from '../components/TextEditor'; 

const ProductsAdd: React.FC = () => {
    const { categories, loading, error } = useCategories();
    const [formData, setFormData] = useState<AddProductRequestDTO>({
        name: '',
        imagePath: '',
        description: '',
        price: 0
    });
    const [imageFile, setImageFile] = useState<File | null>(null); // Изменяем тип состояния для файла
    const [selectedCategory, setSelectedCategory] = useState<number | null>(null);
    const [selectedSubcategory, setSelectedSubcategory] = useState<number | null>(null);
    const [selectedModel, setSelectedModel] = useState<number | null>(null);
    const [loadingOverlay, setLoadingOverlay] = useState(false);

    const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
        const { name, value } = e.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleImageChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        if (e.target.files) {
            setImageFile(e.target.files[0]); 
        }
    };

    const handleCategoryChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
        console.log(selectedCategory);  
        setSelectedCategory(Number(e.target.value));
        setSelectedSubcategory(null);
        setSelectedModel(null);
    };

    const handleSubcategoryChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
        setSelectedSubcategory(Number(e.target.value));
        setSelectedModel(null);
    };

    const handleModelChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
        setSelectedModel(Number(e.target.value));
    };

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();
        if (!selectedSubcategory) {
            alert('Пожалуйста, выберите подкатегорию!');
            return;
        }
        if (formData.price < 0) {
            alert('Цена не может быть отрицательной!');
            return;
        }
        if (!imageFile) {
            alert('Пожалуйста, загрузите изображение!');
            return;
        }

        setLoadingOverlay(true);
        try {
            await addNewProduct(formData, imageFile); // Передаем объект и файл изображения
            alert('Продукт успешно добавлен!');
        } catch (error: any) {
            console.error('Ошибка при добавлении продукта:', error);
            alert('Ошибка при добавлении продукта: ' + error.message);
        } finally {
            setLoadingOverlay(false);
        }
    };

    if (loading) return <div>Загрузка категорий...</div>;
    if (error) return <div>Ошибка: {error.message}</div>;

    const findSubcategories = (categoryId: number) => {
        return categories.find(cat => cat.id === categoryId)?.subcategories || [];
    };

    const subcategories = selectedCategory ? findSubcategories(selectedCategory) : [];
    const models = selectedSubcategory ? findSubcategories(selectedSubcategory) : [];

    return (
        <div className="max-w-xl mx-auto p-4">
            <h1 className="text-2xl font-bold mb-4">Добавить продукт</h1>
            {loadingOverlay && (
                <div className="absolute inset-0 bg-gray-600 bg-opacity-50 flex items-center justify-center">
                    <div className="loader">Загрузка...</div>
                    <button onClick={() => { /* Логика отмены */ }} className="bg-red-500 text-white p-2 rounded ml-4">Отмена</button>
                </div>
            )}
            <form onSubmit={handleSubmit} className="space-y-4">
                <div>
                    <label className="block mb-1" htmlFor="name">Название продукта:</label>
                    <input
                        type="text"
                        id="name"
                        name="name"
                        value={formData.name}
                        onChange={handleInputChange}
                        required
                        className="border border-gray-300 rounded p-2 w-full"
                    />
                </div>
                <div>
                    <label className="block mb-1" htmlFor="imagePath">Изображение:</label>
                    <input
                        type="file"
                        id="imagePath"
                        name="imagePath"
                        onChange={handleImageChange} // Обновлено здесь
                        required
                        className="border border-gray-300 rounded p-2 w-full"
                    />
                </div>
                <div>
                    <label className="block mb-1" htmlFor="description">Описание продукта:</label>
                    <TextEditor
                        value={formData.description}
                        onChange={(value: string) => setFormData({ ...formData, description: value })}
                    />
                </div>
                <div>
                    <label className="block mb-1" htmlFor="price">Цена:</label>
                    <input
                        type="number"
                        id="price"
                        name="price"
                        value={formData.price}
                        onChange={handleInputChange}
                        required
                        className="border border-gray-300 rounded p-2 w-full"
                    />
                </div>
                <div>
                    <label htmlFor="category">Категория:</label>
                    <select id="category" onChange={handleCategoryChange} className="border border-gray-300 rounded p-2 w-full">
                        <option value="">Выберите категорию</option>
                        {categories.map(category => (
                            <option key={category.id} value={category.id}>
                                {category.name}
                            </option>
                        ))}
                    </select>
                </div>
                {selectedCategory && (
                    <div>
                        <label htmlFor="subcategory">Подкатегория:</label>
                        <select id="subcategory" onChange={handleSubcategoryChange} className="border border-gray-300 rounded p-2 w-full">
                            <option value="">Выберите подкатегорию</option>
                            {subcategories.map(subcategory => (
                                <option key={subcategory.id} value={subcategory.id}>
                                    {subcategory.name}
                                </option>
                            ))}
                        </select>
                    </div>
                )}
                {selectedSubcategory && models.length > 0 && (
                    <div>
                        <label htmlFor="model">Модель:</label>
                        <select id="model" onChange={handleModelChange} className="border border-gray-300 rounded p-2 w-full">
                            <option value="">Выберите модель</option>
                            {models.map(model => (
                                <option key={model.id} value={model.id}>
                                    {model.name}
                                </option>
                            ))}
                        </select>
                    </div>
                )}
                <button type="submit" className="bg-blue-500 text-white p-2 rounded">Добавить продукт</button>
            </form>
        </div>
    );
};

export default ProductsAdd;
