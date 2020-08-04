import UserStore from './userStore';
import { createContext } from 'react';
import { configure } from 'mobx';
import CommonStore from './commonStore';
import ModalStore from './modalStore';
import ProfileStore from './profileStore';
import SlidesStore from './slidesStore';
import NewsStore from './newsStore';

configure({ enforceActions: 'always' });

export class RootStore {
    userStore: UserStore;
    commonStore: CommonStore;
    modalStore: ModalStore;
    profileStore: ProfileStore;

    slideStore: SlidesStore;
    newsStore: NewsStore;


    constructor() {
        this.userStore = new UserStore(this);
        this.commonStore = new CommonStore(this);
        this.modalStore = new ModalStore(this);
        this.profileStore = new ProfileStore(this);

        this.slideStore = new SlidesStore(this);
        this.newsStore = new NewsStore(this);

    }
}

export const RootStoreContext = createContext(new RootStore());