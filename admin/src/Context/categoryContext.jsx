import React, { createContext, useEffect, useState } from 'react';
import { GetCategories } from "../Services/categoryAPI";

export const CategoryContext = createContext({});

const CategoryContextProvider = ({ children }) => {
    const [categoryItems, setCategoryItems] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            setCategoryItems(await GetCategories());
        };

        fetchData();
    }, []);

    return (
        <CategoryContext.Provider value={{
            categoryItems,
        }}>
            {children}
        </CategoryContext.Provider>
    );
};

export default CategoryContextProvider;