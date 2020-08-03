import { observable, computed, action, runInAction } from 'mobx';
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

  @action login = async (values: IUserFormValues, returnURL: string) => {
    try {
      const res = await agent.User.login(values);
      if (res && res.status === 1) {
        runInAction(() => {
          this.user = res.data;
        });
        this.rootStore.commonStore.setToken(res.data.token,values.rememberMe);
        window.location.href = returnURL;
        // history.push('/profile')

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
        this.rootStore.commonStore.setToken(res.data.token, true);
        window.location.href = returnURL;
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
