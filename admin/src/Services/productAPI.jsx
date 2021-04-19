import axios from "axios";

const product_url = "https://localhost:44311/api/product";

export const GetProducts = () => {
    return axios.get(product_url)
        .then(response => response.data)
        .catch((error) => {
            console.log(error.response);
            return [];
        });
};