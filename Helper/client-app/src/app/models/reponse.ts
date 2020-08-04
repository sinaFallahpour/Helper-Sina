export interface IRespon {
    status: number,
    message: string,
    
}




export interface IResponse<T>  extends IRespon {
    // status: number,
    // message: string,
    data: T
}

