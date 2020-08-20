export interface IRespon {
    status: number,
    message: string,
    statusCode?:number
}


export interface IResponse<T>  extends IRespon {
    // status: number,
    // message: string,
    data: T
}

