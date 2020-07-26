import { ProjectStatus } from './enums/projectStatus'

export interface IServiceResponse {

    IsSuccessful: boolean;
    Message: string;
}


export interface IServiceResponsase<T> extends IServiceResponse {
    ResponseObject: T;
}