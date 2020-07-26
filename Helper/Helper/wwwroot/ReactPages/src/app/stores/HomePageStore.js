var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
import { observable, action, computed, runInAction, reaction } from 'mobx';
import agent from '../api/agent';
import { ProjectStatus } from '../models/enums/projectStatus';
var ProjectStore = /** @class */ (function () {
    function ProjectStore(rootStore) {
        var _this = this;
        this.projectRegistry = new Map();
        this.project = null;
        this.loadingInitial = false;
        this.deleteSaubmiting = false;
        this.projectCount = 0;
        this.page = 0;
        this.limit = 10;
        this.searchedWord = '';
        this.projectStatus = null;
        this.hasTask = null;
        this.predicate = new Map();
        //set current page  (page witch we arein that  now)
        this.setPage = function (page) {
            if (page == _this.page) {
                return;
            }
            _this.page = page;
            _this.clearActivity();
            _this.loadProjects();
        };
        //set PrevPage
        this.setPrevPage = function () {
            if (_this.page != 0) {
                _this.page--;
                _this.loadProjects();
            }
        };
        //set NextPage
        this.setNextPage = function () {
            if (_this.page + 1 != _this.totalPages) {
                _this.page++;
                _this.loadProjects();
            }
        };
        //is in the last page or not
        this.isLastPage = function () {
            if (_this.page + 1 == _this.totalPages) {
                return true;
            }
            return false;
        };
        //set  projectStatus
        this.setProjectStatus = function (projectStatus) {
            if (projectStatus == '-1') {
                _this.page = 0;
                _this.projectStatus = null;
                _this.loadProjects();
            }
            else if (projectStatus == '0') {
                _this.page = 0;
                _this.projectStatus = ProjectStatus.Done;
                _this.loadProjects();
            }
            else if (projectStatus == '1') {
                _this.page = 0;
                _this.projectStatus = ProjectStatus.inProgress;
                _this.loadProjects();
            }
            else if (projectStatus == '2') {
                _this.page = 0;
                _this.projectStatus = ProjectStatus.Todo;
                _this.loadProjects();
            }
            else {
                _this.page = 0;
                _this.projectStatus = null;
                _this.loadProjects();
            }
        };
        //set  taskStatus
        this.setTaskStatus = function (hasTask) {
            if (hasTask == '0') {
                _this.page = 0;
                _this.hasTask = false;
                _this.loadProjects();
                // this.loadProjects()
            }
            else if (hasTask == '1') {
                _this.page = 0;
                _this.hasTask = true;
                _this.loadProjects();
            }
            else {
                _this.page = 0;
                _this.hasTask = null;
                _this.loadProjects();
            }
        };
        //set  limit
        this.setLimit = function (limit) {
            if (limit == '10') {
                _this.limit = 10;
                _this.page = 0;
                _this.loadProjects();
            }
            else if (limit == '20') {
                _this.limit = 20;
                _this.page = 0;
                _this.loadProjects();
            }
            else if (limit == '50') {
                _this.limit = 50;
                _this.page = 0;
                _this.loadProjects();
            }
            else {
                _this.limit = 1;
                _this.page = 0;
                _this.loadProjects();
            }
        };
        //set  seqrchedWord
        this.setSearchedWord = function (searchedWord) {
            _this.searchedWord = searchedWord;
        };
        //search project from server after clicked  search buttom
        this.searchSearchWord = function () {
            _this.page = 0;
            _this.loadProjects();
        };
        //load project from server  with axios param 
        this.loadProjects = function () { return __awaiter(_this, void 0, void 0, function () {
            var ProjecetsList_1, projectCountCounter_1, error_1;
            var _this = this;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        this.loadingInitial = true;
                        _a.label = 1;
                    case 1:
                        _a.trys.push([1, 3, , 4]);
                        return [4 /*yield*/, agent.Projecets.list(this.axiosParams)];
                    case 2:
                        ProjecetsList_1 = _a.sent();
                        projectCountCounter_1 = 0;
                        runInAction('loading Projects', function () {
                            _this.clearProjectRegistry();
                            ProjecetsList_1.ResponseObject.forEach(function (project) {
                                _this.projectRegistry.set(project.Id, project);
                                projectCountCounter_1 = project.Count;
                            });
                            _this.projectCount = projectCountCounter_1;
                            _this.loadingInitial = false;
                            // alert('ok')
                        });
                        return [3 /*break*/, 4];
                    case 3:
                        error_1 = _a.sent();
                        runInAction('load projects error', function () {
                            // alert('fail')
                            _this.loadingInitial = false;
                        });
                        return [3 /*break*/, 4];
                    case 4: return [2 /*return*/];
                }
            });
        }); };
        // @action loadActivity = async (id: string) => {
        //     let project = this.getActivity(id);
        //     if (activity) {
        //         this.activity = activity;
        //         return activity;
        //     } else {
        //         this.loadingInitial = true;
        //         try {
        //             activity = await agent.Activities.details(id);
        //             runInAction('getting activity', () => {
        //                 setActivityProps(activity, this.rootStore.userStore.user!);
        //                 this.activity = activity;
        //                 this.projectRegistry.set(activity.id, activity);
        //                 this.loadingInitial = false;
        //             });
        //             return activity;
        //         } catch (error) {
        //             runInAction('get activity error', () => {
        //                 this.loadingInitial = false;
        //             });
        //             console.log(error);
        //         }
        //     }
        // };
        // if (response && response.data.IsSuccessful) {
        //     //vueInstance.employies.delete(employee.Id);
        //     vueInstance.deleteSaubmiting = false;
        //     //vueInstance.employeeCunt--;
        //     vueInstance.getListemployee();
        //     if (vueInstance.page != 0 && vueInstance.employeeCunt % 10 == 1) {
        //         vueInstance.setPage(vueInstance.page - 1);
        //     }
        //     vueInstance.selectedEmployee = null;
        // }
        // else {
        //     Swal.fire({ icon: 'error', title: 'خطا', text: response.data.Message, })
        //     vueInstance.deleteSaubmiting = false;
        //     vueInstance.selectedEmployee = null;
        // }
        this.deleteProject = function (event, project) { return __awaiter(_this, void 0, void 0, function () {
            var deletedProject, error_2;
            var _this = this;
            return __generator(this, function (_a) {
                switch (_a.label) {
                    case 0:
                        event.preventDefault();
                        this.deleteSaubmiting = true;
                        this.project = project;
                        _a.label = 1;
                    case 1:
                        _a.trys.push([1, 3, , 4]);
                        return [4 /*yield*/, agent.Projecets.delete(project)];
                    case 2:
                        deletedProject = _a.sent();
                        runInAction('delete  Projects', function () {
                            _this.deleteSaubmiting = false;
                            if (_this.page != 0 && _this.isLastPage() && _this.projectCount % _this.limit == 1) {
                                _this.setPage(_this.page - 1);
                            }
                            _this.loadProjects();
                            _this.project = null;
                            // alert('ok')
                        });
                        return [3 /*break*/, 4];
                    case 3:
                        error_2 = _a.sent();
                        runInAction('delete projects error', function () {
                            alert('مشکل حذف پروژه');
                            _this.deleteSaubmiting = false;
                            _this.project = null;
                        });
                        console.log(error_2);
                        return [3 /*break*/, 4];
                    case 4: return [2 /*return*/];
                }
            });
        }); };
        //clean a curent project
        this.clearActivity = function () {
            _this.project = null;
        };
        //clean a curent project
        this.clearProjectRegistry = function () {
            _this.projectRegistry.clear();
        };
        //get a project by Id
        this.getActivity = function (id) {
            return _this.projectRegistry.get(id);
        };
        this.rootStore = rootStore;
        reaction(function () { return _this.predicate.keys(); }, function () {
            _this.page = 0;
            _this.projectRegistry.clear();
            _this.loadProjects();
        });
    }
    Object.defineProperty(ProjectStore.prototype, "axiosParams", {
        // @action setPredicate = (predicate: string, value: string | Date) => {
        //     this.predicate.clear();
        //     if (predicate !== 'all') {
        //         this.predicate.set(predicate, value);
        //     }
        // }
        //get parametr of query string for api
        get: function () {
            var params = new URLSearchParams();
            params.append('limit', String(this.limit));
            params.append('offset', "" + (this.page ? this.page * this.limit : 0));
            params.append('searchedWord', String(this.searchedWord));
            params.append('projectStatus', String(this.projectStatus));
            params.append('hasTask', String(this.hasTask));
            return params;
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ProjectStore.prototype, "totalPages", {
        //get number  of  page fo pagination
        get: function () {
            return Math.ceil(this.projectCount / this.limit);
        },
        enumerable: true,
        configurable: true
    });
    Object.defineProperty(ProjectStore.prototype, "getProjectsList", {
        //change Map  to Arraye
        get: function () {
            //console.log(this.projectRegistry)
            return Array.from(this.projectRegistry.values());
        },
        enumerable: true,
        configurable: true
    });
    __decorate([
        observable
    ], ProjectStore.prototype, "projectRegistry", void 0);
    __decorate([
        observable
    ], ProjectStore.prototype, "project", void 0);
    __decorate([
        observable
    ], ProjectStore.prototype, "loadingInitial", void 0);
    __decorate([
        observable
    ], ProjectStore.prototype, "deleteSaubmiting", void 0);
    __decorate([
        observable
    ], ProjectStore.prototype, "projectCount", void 0);
    __decorate([
        observable
    ], ProjectStore.prototype, "page", void 0);
    __decorate([
        observable
    ], ProjectStore.prototype, "limit", void 0);
    __decorate([
        observable
    ], ProjectStore.prototype, "searchedWord", void 0);
    __decorate([
        observable
    ], ProjectStore.prototype, "projectStatus", void 0);
    __decorate([
        observable
    ], ProjectStore.prototype, "hasTask", void 0);
    __decorate([
        observable
    ], ProjectStore.prototype, "predicate", void 0);
    __decorate([
        computed
    ], ProjectStore.prototype, "axiosParams", null);
    __decorate([
        computed
    ], ProjectStore.prototype, "totalPages", null);
    __decorate([
        action
    ], ProjectStore.prototype, "setPage", void 0);
    __decorate([
        action
    ], ProjectStore.prototype, "setPrevPage", void 0);
    __decorate([
        action
    ], ProjectStore.prototype, "setNextPage", void 0);
    __decorate([
        action
    ], ProjectStore.prototype, "isLastPage", void 0);
    __decorate([
        action
    ], ProjectStore.prototype, "setProjectStatus", void 0);
    __decorate([
        action
    ], ProjectStore.prototype, "setTaskStatus", void 0);
    __decorate([
        action
    ], ProjectStore.prototype, "setLimit", void 0);
    __decorate([
        action
    ], ProjectStore.prototype, "setSearchedWord", void 0);
    __decorate([
        action
    ], ProjectStore.prototype, "searchSearchWord", void 0);
    __decorate([
        computed
    ], ProjectStore.prototype, "getProjectsList", null);
    __decorate([
        action
    ], ProjectStore.prototype, "loadProjects", void 0);
    __decorate([
        action
    ], ProjectStore.prototype, "deleteProject", void 0);
    __decorate([
        action
    ], ProjectStore.prototype, "clearActivity", void 0);
    __decorate([
        action
    ], ProjectStore.prototype, "clearProjectRegistry", void 0);
    return ProjectStore;
}());
export default ProjectStore;
//# sourceMappingURL=HomePageStore.js.map