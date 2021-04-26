import RequestService from "../Services/request";
import { Backend_url } from "../config"

const category_url = Backend_url + "/api/categories";

export const GetCategories = () => {
    return RequestService.axios.get(category_url)
        .then(response => response.data)
        .catch((error) => {
            console.log(error.response);
            return [];
        });
};

export const PostCategory = (formData) => {
    return RequestService.axios({
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
    return RequestService.axios({
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

export const DeleteCategory = (id) => {
    return RequestService.axios({
        method: "delete",
        url: category_url + '/' + id,
    })
        .then((response) => {
            return response.data;
        })
        .catch((error) => {
            console.log(error.response);
            return null;
        });
};