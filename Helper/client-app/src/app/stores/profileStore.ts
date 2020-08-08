import { RootStore } from './rootStore';
import { observable, action, runInAction, computed, reaction } from 'mobx';
import { IProfile, IChangePasswordRQ, IChangeBankRQ, IChangePersonalInfoRE } from '../models/profile';
import agent from '../api/agent';
import { toast } from 'react-toastify';
import { toJS } from 'mobx'
import { history } from '../..'
import { FORM_ERROR } from 'final-form';

export default class ProfileStore {
  rootStore: RootStore;
  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }

  @observable profile: IProfile | null = null;
  @observable loadingProfile = true;



  // @computed get isCurrentUser() {
  //   if (this.rootStore.userStore.user && this.profile) {
  //     return this.rootStore.userStore.user.username === this.profile.username;
  //   } else {
  //     return false;
  //   }
  // }



  @action loadProfile = async (username: string) => {
    this.loadingProfile = true;
    try {
      const res = await agent.Profiles.get(username);
      if (res && res.status === 1) {
        runInAction(() => {
          this.profile = toJS(res.data);
          this.loadingProfile = false;
        });
      }
      else if (res && res.status === 0 && res.statusCode === 404) {
        // runInAction(() => {
        //   this.loadingProfile = false;
        // })
        return history.push('/notFound');
        // toast.error('کاربر یافت نشد  لطفا وارد شوید')

      }
    } catch (error) {
      runInAction(() => {
        this.loadingProfile = false;
      });
      console.log(error);
    }
  };


  //change Password
  @action changePassword = async (model: IChangePasswordRQ) => {
    try {
      const currentusername = toJS(this.rootStore.userStore.user)!.userName
      const res = await agent.Profiles.changePassword(currentusername!, model);
      const { status, statusCode, data, message } = res
      if (res && status === 1) {
        runInAction(() => {
          this.rootStore.userStore.user = res.data;
          this.rootStore.commonStore.setToken(res.data.token, true);
        });
        toast.success('پسورد تغییر یافت')
      }
      else if (res && status === 0 && statusCode === 400) {
        return res;
      }
      else if (res && status == 0)
        return res
    } catch (error) {
      toast.error('خطایی رخداده');
    }
  };





  //change BankAccount
  @action chnageBankAccount = async (model: IChangeBankRQ) => {
    try {
      const currentusername = toJS(this.rootStore.userStore.user)!.userName
      const res = await agent.Profiles.changeAccountBank(currentusername!, model);
      const { status, statusCode, data, message } = res
      if (res && status === 1) {
        runInAction(() => {
          this.rootStore.userStore.user = res.data.currentUser;
          this.rootStore.commonStore.setToken(res.data.currentUser.token, true);
          const body = { ...res.data }
          delete body.currentUser;
           this.profile! = { ...this.profile, ...body }
        });
        toast.success('ثبت موفقیت آمیز تغییرات')
      }
      else if (res && status === 0 && statusCode === 400) {
        return res;
      }
      else if (res && status == 0)
        return res
    } catch (error) {
      toast.error('خطایی رخداده');
    }
  };




  //change personalInformation
  @action changePersonalInformation = async (model: IChangePersonalInfoRE) => {
    try {
      const currentusername = toJS(this.rootStore.userStore.user)!.userName
      console.log(this.rootStore.userStore.user)
      const res = await agent.Profiles.changePeronalInfo(currentusername!, model);
      const { status, statusCode, data, message } = res
      if (res && status === 1) {
        runInAction(() => {
           this.rootStore.userStore.user = res.data.currentUser;
          // this.rootStore.commonStore.setToken(res.data.currentUser.token, true);
          const body = { ...res.data }
          delete body.currentUser;
          this.profile! = { ...this.profile, ...body }
        });
     
        // window.location.href=`/accountSettingsPage/${res.data.currentUser.userName}`
        //history.push(`/accountSettingsPage/${res.data.currentUser.userName}`)

        toast.success('ثبت موفقیت آمیز تغییرات')
      }
      else if (res && status === 0 && statusCode === 400) {
        return res;
      }
      else if (res && status == 0)
        return res
    } catch (error) {
      toast.error('خطایی رخداده');
    }
  };


}
