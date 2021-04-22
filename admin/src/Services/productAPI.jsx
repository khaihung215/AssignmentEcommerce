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

export const PostProduct = (formData) => {
    return axios({
        method: "post",
        url: product_url,
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

export const PutProduct = (id, formData) => {
    return axios({
        method: "put",
        url: product_url + '/' + id,
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

export const DeleteProduct = (id) => {
    return axios({
        method: "delete",
        url: product_url + '/' + id,
    })
        .then((response) => {
            return response.data;
        })
        .catch((error) => {
            console.log(error.response);
            return null;
        });
};
