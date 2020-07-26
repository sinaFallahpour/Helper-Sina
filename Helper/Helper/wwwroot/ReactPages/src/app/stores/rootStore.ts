import { createContext } from 'react';
import { configure } from 'mobx';
//import ProjectStore from './projectStore';

// configure({enforceActions: 'always'});

export class RootStore {
    //projectStore: ProjectStore

    constructor() {
        //this.projectStore = new ProjectStore(this);
    }

}

export const RootStoreContext = createContext(new RootStore());