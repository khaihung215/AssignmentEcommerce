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

export const PostCategory = (formData) => {
    return axios({
        method: "post",
        url: category_url,
        data: formData,
    })
        .then((response) => {
            return response.data;
        })
        .catch((error) => {
            console.log(error.response);
            return null;
        });
};

export const PutCategory = (id, formData) => {
    return axios({
        method: "put",
        url: category_url + '/' + id,
        data: formData,
    })
        .then((response) => {
            return response.data;
        })
        .catch((error) => {
            console.log(error.response);
            return null;
        });
};