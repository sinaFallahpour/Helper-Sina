import axios, { AxiosResponse } from 'axios';
import { IProjectList } from '../models/project';
import { IServiceResponsase } from '../models/ServiceResponse';
//import ProjectStore from '../stores/projectStore';


// axios.defaults.baseURL = 'http://localhost:5000/api';


const responseBody = (response: AxiosResponse) => response.data;

const sleep = (ms: number) => (response: AxiosResponse) =>
    new Promise<AxiosResponse>(resolve =>
        setTimeout(() => resolve(response), ms)
    );

const requests = {
    get: (url: string) =>
        axios
            .get(url)
            .then(responseBody),
    post: (url: string, body: {}) =>
        axios
            .post(url, body)
            .then(responseBody),
    put: (url: string, body: {}) =>
        axios
            .put(url, body)
            .then(responseBody),
    del: (url: string) =>
        axios
            .delete(url)
            .then(responseBody),
    postForm: (url: string, file: Blob) => {
        let formData = new FormData();
        formData.append('File', file);
        return axios
            .post(url, formData, {
                headers: { 'Content-type': 'multipart/form-data' }
            })
            .then(responseBody);
    }
};

const Projecets = {
    list: (params: URLSearchParams): Promise<IServiceResponsase<IProjectList[]>> =>
        axios.get('/Admin/Projects/List', { params: params }).then(responseBody),
    delete: (project: IProjectList) => {
        axios.post(`/Admin/Projects/Delete/${project.Id}`, project);
    }
};



export default {
    Projecets,
};
