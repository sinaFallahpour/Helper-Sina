//respoinse model for get currentUser
export interface IUser {
    id: string;
    userName: string;
    nickname: string;
    photoAddress?: string;
    token: string;
    email: string;
}


//request model for login and register
export interface IUserFormValues {
    username: string;
    password: string;
    email?: string;
    acceptRules: boolean,
    rememberMe: boolean
}



