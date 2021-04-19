import React, { createContext, useEffect, useState } from 'react';
import { GetProducts } from "../Services/productAPI";

export const ProductContext = createContext({});

export default ({ children }) => {
    const [productItems, setProductItems] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            setProductItems(await GetProducts());
        };

        fetchData();
    }, []);

    return (
        <ProductContext.Provider value={{
            productItems,
        }}>
            {children}
        </ProductContext.Provider>
    );
};