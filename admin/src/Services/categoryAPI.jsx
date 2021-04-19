import axios from "axios";

const category_url = "https://localhost:44311/api/categories";

export const GetCategories = () => {
    return axios.get(category_url)
        .then(response => response.data)
        .catch((error) => {
            console.log(error.response);
            return [];
        });
};