import { RootStore } from "./rootStore";
import { observable, action, runInAction, computed, toJS } from "mobx";

import { INews } from '../models/news'
import agent from "../api/agent";
import { toast } from "react-toastify";
import { NewsType } from "../models/enums/newsType";


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
    @observable loadingLike = false;


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


    //like article
    @action Like = async (model: INews) => {
        if (!this.rootStore.userStore.isLoggedIn) {
            toast.warn('لطفا ابتدا وارد سایت شوید')
            return
        }
        this.loadingLike = true;
        try {

            const res = await agent.Newses.Like(model.id);

            runInAction('like article', () => {
                if (res.status === 1) {

                    if (model.newsType === NewsType.arrticle) {
                        const oldArticle = this.articles.find(c => c.id == model.id);
                        if(oldArticle!.isLiked){
                            oldArticle!.isLiked = !oldArticle?.isLiked
                            oldArticle!.likesCount--;
                        }
                        else{
                            oldArticle!.isLiked = !oldArticle?.isLiked
                            oldArticle!.likesCount++;
                        }
                       
                    }
                    else if (model.newsType === NewsType.videos) {
                        const oldvideos = this.videos.find(c => c.id == model.id);
                        if(oldvideos!.isLiked){
                            oldvideos!.isLiked = !oldvideos?.isLiked;
                            oldvideos!.likesCount--;
                        }
                        else{
                            oldvideos!.isLiked = !oldvideos?.isLiked;
                            oldvideos!.likesCount++;
                        }
                     
                    }
                    else if (model.newsType === NewsType.news) {
                        const oldnews = this.newses.find(c => c.id == model.id);
                        if (oldnews!.isLiked) {
                            oldnews!.isLiked = !oldnews?.isLiked
                            oldnews!.likesCount++;
                        }else{
                            oldnews!.isLiked = !oldnews?.isLiked
                            oldnews!.likesCount--;
                        }
                    }
                }
                this.loadingLike = false;
            });
        } catch (error) {
            runInAction('like artcle  error', () => {
                toast.error('خطا در ثبت لایک')
                this.loadingLike = false;
            });
        }
    };




}