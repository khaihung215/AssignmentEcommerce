import axios from "axios";
import { Backend_url } from "../config"

const product_url = Backend_url + "/api/product";

export const GetProducts = () => {
    return axios.get(product_url)
        .then(response => response.data)
        .catch((error) => {
            console.log(error.response);
            return [];
        });
};