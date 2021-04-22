import React, { createContext, useEffect, useState } from 'react';
import { GetProducts, PostProduct, PutProduct } from "../Services/productAPI";
import { GetCategories } from "../Services/categoryAPI";

export const ProductContext = createContext({});

const ProductContextProvider = ({ children }) => {
    const [productItems, setProductItems] = useState([]);
    const [categoryItems, setCategoryItems] = useState([]);

    const postProduct = (formData) => {
        (async () => {
            await PostProduct(formData);
            setProductItems(await GetProducts());
        }
        )();
    };

    const putProduct = (formData) => {
        (async () => {
            await PutProduct(formData);
            setProductItems(await GetProducts());
        }
        )();
    };

    useEffect(() => {
        (async () => {
            setProductItems(await GetProducts());
            setCategoryItems(await GetCategories());
        }
        )();
    }, []);

    return (
        <ProductContext.Provider value={{
            productItems,
            categoryItems,
            postProduct,
            putProduct
        }}>
            {children}
        </ProductContext.Provider>
    );
};

export default ProductContextProvider;