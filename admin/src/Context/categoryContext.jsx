import React, { createContext, useEffect, useState } from 'react';
import { GetCategories, PostCategory, PutCategory } from "../Services/categoryAPI";

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

    const putCategory = (id, formData) => {
        (async () => {
            await PutCategory(id, formData);
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
            postCategory,
            putCategory
        }}>
            {children}
        </CategoryContext.Provider>
    );
};

export default CategoryContextProvider;