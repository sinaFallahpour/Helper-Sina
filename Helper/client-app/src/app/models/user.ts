export interface IUser {
    username: string;
    nickname: string;
    photoAddress?: string;
    token: string;
    Email: string;
}

export interface IUserFormValues {
    username: string;
    password: string;
    email?: string;
    acceptRules:boolean,
    rememberMe:boolean
}