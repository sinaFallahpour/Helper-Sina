import { RootStore } from './rootStore';
import { observable, action, reaction } from 'mobx';
// import   asdsds  from 'js-cookie/src/js.cookie'
import Cookies from 'js-cookie';

export default class CommonStore {
    rootStore: RootStore;
    constructor(rootStore: RootStore) {
        this.rootStore = rootStore;

        // reaction(
        //     () => this.token,
        //     token => {
        //         if (token) {

        //             window.localStorage.setItem('jwt', token);
        //         } else {
        //             window.localStorage.removeItem('jwt')
        //         }
        //     }
        // )
    }

    @observable token: string | undefined = Cookies.get('jwt')
    //   window.localStorage.getItem('jwt');
    @observable appLoaded = false;

    @action setToken = (token: string | undefined, rememberMe: boolean) => {
        //if user check remamber Me
        if (token && rememberMe) {
            //delete last cookie
            sessionStorage.removeItem('jwt');
            Cookies.remove('jwt')

            this.token = token;
            Cookies.set('jwt', token!, { expires: 7 })
            return;
        }
        //if user dont check remeber Mes
        else if (token) {
            //delete last cookie
            Cookies.remove('jwt')

            sessionStorage.setItem('jwt', token!)
            return
        }
        //LogOUT
        Cookies.remove('jwt')
    }

    @action setAppLoaded = () => {
        this.appLoaded = true;
    }
}