import React, { createContext, useEffect, useState } from 'react';
import { GetCategories, PostCategory, PutCategory, DeleteCategory } from "../Services/categoryAPI";

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

    const deleteCategory = (id) => {
        (async () => {
            await DeleteCategory(id);
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
            putCategory,
            deleteCategory
        }}>
            {children}
        </CategoryContext.Provider>
    );
};

export default CategoryContextProvider;