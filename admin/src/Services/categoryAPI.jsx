import axios from "axios";
import { Backend_url } from "../config"

const category_url = Backend_url + "/api/categories";

export const GetCategories = () => {
    return axios.get(category_url)
        .then(response => response.data)
        .catch((error) => {
            console.log(error.response);
            return [];
        });
};