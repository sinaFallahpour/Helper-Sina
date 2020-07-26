import { observable, action, computed, runInAction, reaction } from 'mobx';
import { IProjectList } from '../models/project';
import agent from '../api/agent';
import { RootStore } from './rootStore';
import { ProjectStatus } from '../models/enums/projectStatus';



export default class ProjectStore {
    rootStore: RootStore;
    constructor(rootStore: RootStore) {
        this.rootStore = rootStore;

        reaction(
            () => this.predicate.keys(),
            () => {
                this.page = 0;
                this.projectRegistry.clear();
                this.loadProjects();
            }
        )
    }





    @observable projectRegistry = new Map();
    @observable project: IProjectList | null = null;
    @observable loadingInitial = false;
    @observable deleteSaubmiting = false;

    @observable projectCount = 0;
    @observable page = 0;
    @observable limit = 10;
    @observable searchedWord = '';
    @observable projectStatus: ProjectStatus | null = null;
    @observable hasTask: any = null;
    @observable predicate = new Map();





    // @action setPredicate = (predicate: string, value: string | Date) => {
    //     this.predicate.clear();
    //     if (predicate !== 'all') {
    //         this.predicate.set(predicate, value);
    //     }
    // }




    //get parametr of query string for api
    @computed get axiosParams() {
        const params = new URLSearchParams();
        params.append('limit', String(this.limit));
        params.append('offset', `${this.page ? this.page * this.limit : 0}`);
        params.append('searchedWord', String(this.searchedWord));
        params.append('projectStatus', String(this.projectStatus));
        params.append('hasTask', String(this.hasTask));

        return params;
    }




    //get number  of  page fo pagination
    @computed get totalPages() {
        return Math.ceil(this.projectCount / this.limit);
    }




    //set current page  (page witch we arein that  now)
    @action setPage = (page: number) => {
        if (page == this.page) {
            return
        }
        this.page = page;
        this.clearActivity()
        this.loadProjects()


    }





    //set PrevPage
    @action setPrevPage = () => {
        if (this.page != 0) {
            this.page--;
            this.loadProjects()
        }
    }




    //set NextPage
    @action setNextPage = () => {
        if (this.page + 1 != this.totalPages) {
            this.page++;
            this.loadProjects()
        }
    }

    //is in the last page or not
    @action isLastPage = (): boolean => {
        if (this.page + 1 == this.totalPages) {
            return true
        }
        return false
    }



    //set  projectStatus
    @action setProjectStatus = (projectStatus: string) => {

        if (projectStatus == '-1') {
            this.page = 0;
            this.projectStatus = null;
            this.loadProjects();
        }
        else if (projectStatus == '0') {
            this.page = 0;
            this.projectStatus = ProjectStatus.Done;
            this.loadProjects();
        }
        else if (projectStatus == '1') {
            this.page = 0;
            this.projectStatus = ProjectStatus.inProgress;
            this.loadProjects()
        }
        else if (projectStatus == '2') {
            this.page = 0;
            this.projectStatus = ProjectStatus.Todo
            this.loadProjects()
        }

        else {
            this.page = 0;
            this.projectStatus = null;
            this.loadProjects()
        }
    }




    //set  taskStatus
    @action setTaskStatus = (hasTask: string) => {
        if (hasTask == '0') {
            this.page = 0;
            this.hasTask = false;
            this.loadProjects()

            // this.loadProjects()
        }
        else if (hasTask == '1') {
            this.page = 0;
            this.hasTask = true;
            this.loadProjects()
        }
        else {
            this.page = 0;
            this.hasTask = null;
            this.loadProjects()
        }
    }





    //set  limit
    @action setLimit = (limit: string) => {
        if (limit == '10') {
            this.limit = 10;
            this.page = 0;
            this.loadProjects()
        }
        else if (limit == '20') {
            this.limit = 20;
            this.page = 0;
            this.loadProjects()
        }
        else if (limit == '50') {
            this.limit = 50;
            this.page = 0;
            this.loadProjects()
        }
        else {
            this.limit = 1;
            this.page = 0;
            this.loadProjects()
        }
    }





    //set  seqrchedWord
    @action setSearchedWord = (searchedWord: string) => {
        this.searchedWord = searchedWord;
    }




    //search project from server after clicked  search buttom
    @action searchSearchWord = () => {
        this.page = 0;
        this.loadProjects()
    }

    //change Map  to Arraye
    @computed get getProjectsList() {
        //console.log(this.projectRegistry)
        return Array.from(this.projectRegistry.values())
    }





    //load project from server  with axios param 
    @action loadProjects = async () => {
        this.loadingInitial = true;
        try {

            const ProjecetsList = await agent.Projecets.list(this.axiosParams);
            let projectCountCounter = 0
            runInAction('loading Projects', () => {
                this.clearProjectRegistry();
                ProjecetsList.ResponseObject.forEach(project => {
                    this.projectRegistry.set(project.Id, project);
                    projectCountCounter = project.Count
                });
                this.projectCount = projectCountCounter;
                this.loadingInitial = false;
                // alert('ok')
            });
        } catch (error) {
            runInAction('load projects error', () => {
                // alert('fail')
                this.loadingInitial = false;
            });
        }
    };





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







    @action deleteProject = async (event: React.SyntheticEvent, project: IProjectList) => {
        event.preventDefault()
        this.deleteSaubmiting = true
        this.project = project

        try {
            const deletedProject = await agent.Projecets.delete(project);
            runInAction('delete  Projects', () => {

                this.deleteSaubmiting = false;
               
                if (this.page != 0 && this.isLastPage() && this.projectCount % this.limit == 1) {
                    this.setPage(this.page - 1);
                }
                this.loadProjects();
                this.project = null;
                // alert('ok')
            });
        } catch (error) {
            runInAction('delete projects error', () => {
                alert('مشکل حذف پروژه')
                this.deleteSaubmiting = false;
                this.project = null;
            });
            console.log(error);
        }




        // setTimeout(() => {
        //     this.deleteSaubmiting = false

        // }, 1200);
    }





    //clean a curent project
    @action clearActivity = () => {
        this.project = null;
    };





    //clean a curent project
    @action clearProjectRegistry = () => {
        this.projectRegistry.clear();
    };





    //get a project by Id
    getActivity = (id: string) => {
        return this.projectRegistry.get(id);
    };





}
