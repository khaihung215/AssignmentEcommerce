import React, { createContext, useEffect, useState } from 'react';
import { GetCategories, PostCategory } from "../Services/categoryAPI";

export const CategoryContext = createContext({});

const CategoryContextProvider = ({ children }) => {
    const [categoryItems, setCategoryItems] = useState([]);

    const postCategory = (formData) => {
        (async () => {
            await PostCategory(formData);
            setCategoryItems(await GetCategories());
        }
        )();
    };

    useEffect(() => {
        (async () => {
            setCategoryItems(await GetCategories());
        }
        )();
    }, []);

    return (
        <CategoryContext.Provider value={{
            categoryItems,
            postCategory
        }}>
            {children}
        </CategoryContext.Provider>
    );
};

export default CategoryContextProvider;