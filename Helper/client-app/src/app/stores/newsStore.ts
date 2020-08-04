import { RootStore } from "./rootStore";
import { observable, action, runInAction, computed, toJS } from "mobx";

import { INews } from '../models/news'
import agent from "../api/agent";



export default class NewsStore {
    rootStore: RootStore;
    constructor(rootStore: RootStore) {
        this.rootStore = rootStore;
    }

    @observable newses: INews[] = [];
    @observable videos: INews[] = [];
    @observable articles: INews[] = [];
    @observable loadingNews = false;
    @observable loadingVideos = false;
    @observable loadingArticle = false;



    //get newses
    @computed get newsesList() {
        return this.newses;
    }


    //get newses
    @computed get videosList() {
        return this.videos;
    }

    //get newses
    @computed get articlesList() {
        return this.articles;
    }


    //load newses
    @action loadNews = async () => {
        this.loadingNews = true;
        try {
            const res = await agent.Newses.list(0);
            runInAction('loading newses', () => {
                if (res.status === 1) {
                    this.newses = toJS(res.data);
                }
                this.loadingNews = false;
            });
        } catch (error) {
            runInAction('load newses error', () => {
                this.loadingNews = false;
            });
        }
    };


    //load videos
    @action loadVideos = async () => {
        this.loadingVideos = true;
        try {
            const res = await agent.Newses.list(2);
            runInAction('loading vidos', () => {
                if (res.status === 1) {
                    this.videos = toJS(res.data);
                }
                this.loadingVideos = false;
            });
        } catch (error) {
            runInAction('load vidos error', () => {
                this.loadingVideos = false;
            });
        }
    };


    //load articles
    @action loadArticles = async () => {
        this.loadingArticle = true;
        try {
            const res = await agent.Newses.list(1);
            runInAction('loading articles', () => {
                if (res.status === 1) {
                    this.articles = toJS(res.data);
                }
                this.loadingArticle = false;
            });
        } catch (error) {
            runInAction('load articles error', () => {
                this.loadingArticle = false;
            });
        }
    };

}