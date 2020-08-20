import { observable, computed, action, runInAction, toJS } from 'mobx';
import { IUser, IUserFormValues } from '../models/user';
import agent from '../api/agent';
import { RootStore } from './rootStore';
import { history } from '../..';


export default class UserStore {
  rootStore: RootStore;
  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }

  @observable user: IUser | null = null;

  @computed get isLoggedIn() {
    return !!this.user;
  }

  @action login = async (values: any, returnURL: string) => {
    values.username = values.username2;
    values.password = values.password2;

    // values.username2
    // values.password
    // console.log(values)
    try {
      const res = await agent.User.login(values);

      if (res && res.status === 1) {
        runInAction(() => {
          this.user = res.data;
        });
        this.rootStore.commonStore.setToken(res.data.token, values.rememberMe);
        // اگر تیکمرا بخاطر بسپار را نزده بود دیگه صفحه را رفرش نکن چونتو سشن استورج ریختی توکنو
        if (!values.rememberMe)
          return

        // window.location.href = returnURL ? returnURL : `/profile/${res.data.id}`;
        history.push(returnURL ? returnURL : `/profile/${res.data.id}`);

        return

      }
      throw res

    } catch (error) {
      throw error;
    }
  };

  @action register = async (values: IUserFormValues, returnURL: string) => {
    try {
      const res = await agent.User.register(values);
      if (res && res.status === 1) {
        runInAction(() => {
          this.user = res.data;
        });
        this.rootStore.commonStore.setToken(res.data.token, true);
        // window.location.href = returnURL ? returnURL : `/profile/${res.data.id}`;
        history.push(returnURL ? returnURL : `/profile/${res.data.id}`);
        return
      }
      throw res;

    } catch (error) {
      throw error;
    }
  }

  @action getUser = async () => {
    try {
      const res = await agent.User.current();
      if (res && res.status === 1) {
        runInAction(() => {
          this.user = res.data;
        });
      }
    } catch (error) {
      console.log(error);
    }
  };


  @action logout = () => {
    this.rootStore.commonStore.setToken(undefined, false);
    this.user = null;
    history.push('/');
  };
}
