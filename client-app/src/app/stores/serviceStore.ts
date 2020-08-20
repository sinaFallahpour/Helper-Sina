import { RootStore } from "./rootStore";
import { observable, action, runInAction, computed, reaction } from "mobx";
import {
  IProfile,
  IChangePasswordRQ,
  IChangeBankRQ,
  IChangePersonalInfoRE,
} from "../models/accountSettings";
import agent from "../api/agent";
import { toast } from "react-toastify";
import { toJS } from "mobx";
import { history } from "../..";
import { FORM_ERROR } from "final-form";
import { IService, ISelectInfo } from "../models/service";

export default class ServiceStore {
  rootStore: RootStore;
  constructor(rootStore: RootStore) {
    this.rootStore = rootStore;
  }

  //   @observable profile: IProfileRE | null = null;
  @observable loadingSubmitingForm= false;
  @observable hasAcceptedPlan = false;
  @observable loading = false;
  @observable selectValue: ISelectInfo | null = null;

  @action hasUserAcceptedPlan = async () => {
    this.loading = true;
    try {
      const res = await agent.Services.hasAcceptedPlan();
      const { status, statusCode, message } = res;
      if (res && status === 1) {
        runInAction("hasaccespedt plan  ", () => {
          this.hasAcceptedPlan = true;
          this.loading = false;
        });
      } else if (res && status === 0 && statusCode == 404) {
        runInAction("hasaccespedt plan   ", () => {
          this.hasAcceptedPlan = false;
          this.loading = false;

          toast.error(message);
          setTimeout(() => {
            history.push("/login");
          }, 5000);
        });
        return res;
      } else {
        runInAction("hasaccespedt plan", () => {
          this.hasAcceptedPlan = false;
          this.loading = false;
          // toast.error(message);
        });
        return res;
      }
    } catch (error) {
      runInAction("creating service error ", () => {
        this.hasAcceptedPlan = false;
        this.loading = false;
      });
      toast.error("خطایی رخ داده");
    }
  };

  //CreateService
  @action createService = async (model: IService) => {
    this.loadingSubmitingForm = true;
    try {
      const res = await agent.Services.Create(model);
      const { status, statusCode, message } = res;
      if (res && status === 1) {
        runInAction("creating service ", () => {
          this.loadingSubmitingForm = false;
        });
        toast.success("ثبت موفقیت آمیز ");
      } else if (res && status === 0 && statusCode === 400) {
        runInAction("creating service ", () => {
          this.loadingSubmitingForm = false;
        });
        return res;
      } else if (res && status == 0) {
        runInAction("creating service  ", () => {
          this.loadingSubmitingForm = false;
        });
        return res;
      }
    } catch (error) {
      runInAction("creating service error ", () => {
        this.loadingSubmitingForm = false;
      });
      toast.error("خطایی رخ داده");
    }
  };

  //CreateService
  @action loadSelectValue = async () => {
    this.loading = true;
    try {
      const res = await agent.Services.getServiceSelect();
      const { status, statusCode, message } = res;
      if (res && status === 1) {
        runInAction("loading select ", () => {
          this.selectValue = res.data;
          this.loading = false;
        });
        return;
      }
      this.loading = false;
    } catch (error) {
      runInAction("loading select", () => {
        this.loading = false;
      });
      // toast.error("خطایی رخ داده");
    }
  };
}
