import { createContext } from 'react';
//import ProjectStore from './projectStore';
// configure({enforceActions: 'always'});
var RootStore = /** @class */ (function () {
    //projectStore: ProjectStore
    function RootStore() {
        //this.projectStore = new ProjectStore(this);
    }
    return RootStore;
}());
export { RootStore };
export var RootStoreContext = createContext(new RootStore());
//# sourceMappingURL=rootStore.js.map