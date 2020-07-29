import axios, { AxiosResponse } from 'axios';
import { IProjectList } from '../models/project';
import { IServiceResponsase } from '../models/ServiceResponse';
//import ProjectStore from '../stores/projectStore';
import { toast } from 'react-toastify';

 axios.defaults.baseURL = 'https://localhost:44340/api';



axios.interceptors.request.use(
  config => {
    const token = window.localStorage.getItem('jwt');
    if (token) config.headers.Authorization = `Bearer ${token}`;
    return config;
  },
  error => {
    return Promise.reject(error);
  }
);




axios.interceptors.response.use(undefined, error => {
    if (error.message === 'Network Error' && !error.response) {
      toast.error('خطایه رخ داده!');
    }
    const { status, data, config } = error.response;
    // if (status === 404) {
    //   history.push('/notfound');
    // }
    // if (
    //   status === 400 &&
    //   config.method === 'get' &&
    //   data.errors.hasOwnProperty('id')
    // ) {
    //   history.push('/notfound');
    // }
    if (status === 500) {
        toast.error('خطایه رخ داده!');
    }
    throw error.response;
  });




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

const AboutUs = {
    aboutUs: () => requests.get(`/Home/aboutUs`),
};

const ContactUs = {
    contactUs: () => requests.get(`/Home/ContactUs`),
};



export default {
    AboutUs,
    ContactUs
};
