import UserStore from './userStore';
import { createContext } from 'react';
import { configure } from 'mobx';
import CommonStore from './commonStore';
import ModalStore from './modalStore';
import AccountSettingsStore from './accountSettingsStore';
import SlidesStore from './slidesStore';
import NewsStore from './newsStore';
import ProfileStore from './profileStore'
import PlaneStore from './PlanStore'
import ServiceStore from './serviceStore'


configure({ enforceActions: 'always' });

export class RootStore {
    userStore: UserStore;
    commonStore: CommonStore;
    modalStore: ModalStore;
    accountSettingsStore: AccountSettingsStore;

    slideStore: SlidesStore;
    newsStore: NewsStore;
    profileStore: ProfileStore;
    planStore: PlaneStore;
    serviceStore: ServiceStore;


    constructor() {
        this.userStore = new UserStore(this);
        this.commonStore = new CommonStore(this);
        this.modalStore = new ModalStore(this);
        this.accountSettingsStore = new AccountSettingsStore(this);

        this.slideStore = new SlidesStore(this);
        this.newsStore = new NewsStore(this);
        this.profileStore = new ProfileStore(this);
        this.planStore = new PlaneStore(this);
        this.serviceStore = new ServiceStore(this);

    }
}

export const RootStoreContext = createContext(new RootStore());