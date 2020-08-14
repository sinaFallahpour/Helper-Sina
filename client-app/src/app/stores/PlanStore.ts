import { RootStore } from "./rootStore";
import { observable, action, runInAction, computed, toJS } from "mobx";

import { IPlan } from '../models/Plan'
import agent from "../api/agent";



export default class ModalStore {
    rootStore: RootStore;
    constructor(rootStore: RootStore) {
        this.rootStore = rootStore;
    }

    @observable planses: IPlan[] = [];
    @observable loadingPlanses = false;






    @computed get plansesList() {
        return this.planses;
    }

    


    //load planses
    @action loadPlanses = async () => {
        this.loadingPlanses = true;
        try {
            const res = await agent.Planses.list();
            runInAction('loading sliplansesdes', () => {
                if (res.status === 1) {
                    this.planses = toJS(res.data);
                }
                this.loadingPlanses = false;
            });
        } catch (error) {
            runInAction('load planses error', () => {
                this.loadingPlanses = false;
            });
        }
    };



}