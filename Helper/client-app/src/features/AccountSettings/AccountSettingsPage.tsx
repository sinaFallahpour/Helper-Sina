import React, { useState, FormEvent, useContext, useEffect } from 'react'
import { observer } from 'mobx-react-lite';
import ChangePassword from './ChangePassword';
import BacnkAccount from './BacnkAccount';
import PersonalInformation from './PersonalInformation';
import { RouteComponentProps } from 'react-router-dom';
import { RootStoreContext } from '../../app/stores/rootStore';
// import LoadingComponent from '../../app/layout/LoadingComponent';
import LoadingTransparent from '../../app/common/Loading/LoadingTransparent';




interface RouteParams {
    id: string;
}

interface IProps extends RouteComponentProps<RouteParams> { }

const AccountSettingsPage: React.FC<IProps> = ({ match }) => {

    const rootStore = useContext(RootStoreContext);

    const {
        loadingProfile,
        profile,
        loadProfile,
    } = rootStore.accountSettingsStore;

    useEffect(() => {
        loadProfile(match.params.id);
    }, [loadProfile, match]);

    if (loadingProfile) return <LoadingTransparent />;

    return (
        <>
            <div className="container">
                <div className="row mt-md-5 pt-md-5">
                    <div className="col-md-5 col-12 ml-lg-5 order-md-0 order-1 hj-intro-h">
                        <div className="row mx-auto">
                            <span className="text-justify size-33">
                                <b>
                                    ایجاد خدمت
                    </b>
                            </span>
                        </div>
                        <div className="row w-100 mx-auto pt-3 pt-md-2">


                            <img src={window.location.origin + "/hj/img/border-bottom.png"} className="img-fluid" alt="Responsive images" />
                        </div>
                        <div className="row mt-3 mx-auto">
                            <span className="text-justify hj-intro-text">لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</span>
                        </div>

                    </div>
                    <div className="col-md-6 col-12 mr-lg-4 order-md-1 order-0">
                        <img src={window.location.origin + "/hj/img/Group 2665.svg"} className="img-fluid" alt="Responsive images" />
                    </div>

                </div>
            </div>

            {/* @*--------------------*@ */}
            <div className="container mx-auto">
                {/* -- Tabs -- */}
                <section id="tabs">
                    <div className="container p-0 m-0">

                        <div className="row w-100 mx-auto">
                            <div className="col-xs-12 p-0 m-0 ">
                                <nav>
                                    <div className="nav nav-tabs nav-fill p-0 m-0 w-100" id="nav-tab" role="tablist">
                                        <a className="nav-item nav-link w-25 active" id="nav-Personal-tab" data-toggle="tab" href="#nav-Personal" role="tab" aria-controls="nav-profile" aria-selected="false"> اطلاعات شخصی</a>
                                        <a className="nav-item nav-link w-25" id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false"> حساب بانکی</a>
                                        <a className="nav-item nav-link  w-25" id="nav-password-tab" data-toggle="tab" href="#nav-password" role="tab" aria-controls="nav-password" aria-selected="true"> رمز عبور</a>
                                    </div>
                                </nav>
                                <div className="tab-content py-3 px-sm-0 mt-5" id="nav-tabContent">

                                    {/* ---------tab1-------------- */}
                                    <PersonalInformation profile={profile!}/>
                                    {/* -----------tab2------------------ */}
                                    <BacnkAccount profile={profile!} />

                                    {/* --------tab3-------- */}
                                    <ChangePassword profile={profile!} />
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                {/* ..... ./Tabs .......... */}
            </div>

        </>
    )
}



export default observer(AccountSettingsPage) 