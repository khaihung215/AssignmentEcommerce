import axios, { AxiosInstance, AxiosRequestConfig } from "axios";

import { Backend_url } from "../config";

const config: AxiosRequestConfig = {
    baseURL: Backend_url
}

class RequestService {
    public axios: AxiosInstance;

    constructor() {
        this.axios = axios.create(config);
    }

    public setAuthentication(accessToken: string) {
        this.axios.defaults.headers.common['Authorization'] = `Bearer ${accessToken}`;
    }
}

export default new RequestService();