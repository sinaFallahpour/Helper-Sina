import React, { Fragment, useContext, useEffect, useState } from 'react';
import ReactDOM from 'react-dom';
import { observer } from 'mobx-react-lite';
import ReactHtmlParser from 'react-html-parser';

import agent from '../../app/api/agent'

import borderbig from '../../../assets/hj/img/borderbig green.png';



const HoemContactUsView: React.FC = () => {
    const [ContactUs, setContactUs] = useState(undefined);
    const [loading, setloading] = useState(false);

    useEffect(() => {
        async function fetchMyAPI() {
            setloading(true);
            try {
                let res = await agent.ContactUs.contactUs();
                if (res.status == 1) {
                    setContactUs(res.data.value);
                    setloading(false);
                }
                setloading(false);
            } catch (error) {
                setloading(false)
            }
        }
        fetchMyAPI();
    }, []);

    if (loading) {
        return (
            <div className="container">
                <div className="d-block text-center">
                    <div className="spinner-grow" role="status">
                        <span className="sr-only">Loading...</span>
                    </div>
                </div>
            </div>
        )
    }

    return (
        <Fragment>
            <div className="container mx-auto p-0 m-0 mt-5">
                <div className="row w-100 p-0 m-0 mx-auto">
                    <div className="col-md-10 col-8 text-right"><h3><b> تماس با ما</b></h3></div>
                </div>
                <div className="row w-100 mx-auto">
                    <img src={"/ReactPages/" + borderbig} className="img-fluid mx-auto" />
                </div>
               
                <div className="row  p-2 m-0  mt-3">
                        {ReactHtmlParser(ContactUs || "")}
                        </div>
                
            </div>
        </Fragment>
    );
}



ReactDOM.render(
    <HoemContactUsView />
    ,
    document.getElementById('root')
);

