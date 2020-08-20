import React, { useState, useEffect, useContext } from 'react'

import { observer } from 'mobx-react-lite';



import DonnerCreateService from './DonnerCreateService'

import { RouteComponentProps } from 'react-router-dom'
import { Button } from 'semantic-ui-react';
import { RootStoreContext } from '../../app/stores/rootStore';
import LoadingTransparent from '../../app/common/Loading/LoadingTransparent';
import { history } from '../..';
import { toast, ToastContainer } from 'react-toastify';




interface RouteParams {
    id: string;
}

interface IProps extends RouteComponentProps<RouteParams> { }
const CreateServicePage: React.FC<IProps> = (props) => {

    const [startrLoading, setStartrLoading] = useState(true)

    setTimeout(() => {
        setStartrLoading(false)
    }, 2000);



    const rootStore = useContext(RootStoreContext);

    const {
        loading,
        hasAcceptedPlan,
        hasUserAcceptedPlan,
        loadSelectValue,
        selectValue
    } = rootStore.serviceStore



    useEffect(() => {
        hasUserAcceptedPlan();
        if (!hasAcceptedPlan && !loading && !startrLoading) {
            toast.error('پلن فعالی برای شمل موجود نیست .')
            setTimeout(() => {
                history.push('/plan')
            }, 5000);
            return
        }
        loadSelectValue();
    }, [hasUserAcceptedPlan, hasAcceptedPlan, loadSelectValue]);


    if (loading || startrLoading) {
        return <LoadingTransparent />;
    }

    if (!hasAcceptedPlan && !loading && !startrLoading) {
        // <ToastContainer  />
        toast.error('پلن فعالی برای شمل موجود نیست .')
        setTimeout(() => {
            history.push('/plan')
        }, 5000);
    }


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
                            <img src={window.location.origin + "/hj/img/border-bottom.png"} className="img-fluid" alt='Responsive images' />

                        </div>
                        <div className="row mt-3 mx-auto">
                            <span className="text-justify hj-intro-text">لورم ایپسوم متن ساختگی با تولید سادگی نامفی متنوع با هدف</span>
                        </div>

                    </div>
                    <div className="col-md-6 col-12 mr-lg-4 order-md-1 order-0">
                        <img src={window.location.origin + "/hj/img/Group 2665.svg"} className="img-fluid" alt='Responsive images' />
                    </div>

                </div>
                {/* ...................end intro..................... */}
            </div>


            {/* -----------------form----------------- */}
            <div className="container mx-auto">
                {/* -- Tabs -- */}
                <section id="tabs">
                    <div className="container p-0 m-0">

                        <div className="row w-100 mx-auto">
                            <div className="col-xs-12 p-0 m-0 ">

                                <nav>

                                    <div className="nav nav-tabs nav-fill p-0 m-0 w-100" id="nav-tab" role="tablist">

                                        <a className="nav-item nav-link active w-50" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">درخواست خدمت</a>
                                        <a className="nav-item nav-link w-50" id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">ارائه خدمت</a>

                                    </div>

                                </nav>
                                <div className="tab-content py-3 px-sm-0 mt-5" id="nav-tabContent">
                                    <div className="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
                                        aaaaaaaaaa

                                    </div>
                                    {/* ------dashbord----- */}
                                    <div className="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
                                        <DonnerCreateService selectList={selectValue!} />
                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                </section>
                {/* <!-- ./Tabs --> */}
            </div>
        </>
    )
}



export default observer(CreateServicePage)