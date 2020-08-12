import { RootStore } from "./rootStore";
import { observable, action, runInAction, computed,toJS } from "mobx";

import { ISlide } from '../models/slide'
import agent from "../api/agent";



export default class ModalStore {
    rootStore: RootStore;
    constructor(rootStore: RootStore) {
        this.rootStore = rootStore;
    }

    @observable slides: ISlide[] = [];
    @observable loadingSlides = false;





   
    @computed get slidesList() {
        return this.slides;
    }

    // @action slidesList = () => {
    //     console.log(this.slides)
    //     return this.slides;

    // }


    //load slides
    @action loadSlides = async () => {
        this.loadingSlides = true;
        try {
            const res = await agent.Slides.list(1);
            runInAction('loading slides', () => {
                if (res.status === 1) {
                    this.slides = toJS(res.data) ;
                }
                this.loadingSlides = false;
            });
        } catch (error) {
            runInAction('load slides error', () => {
                this.loadingSlides = false;
            });
        }
    };



}