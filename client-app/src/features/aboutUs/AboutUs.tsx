import React, { Fragment, useEffect, useState } from 'react';
import ReactHtmlParser from 'react-html-parser';

import agent from '../../app/api/agent'


const AboutUs: React.FC = () => {

    const [aboutUs, setAboutUs] = useState(undefined);
    const [loading, setloading] = useState(false);

    useEffect(() => {
        async function fetchMyAPI() {
            setloading(true);
            try {
                let res = await agent.AboutUs.aboutUs();
                if (res.status === 1) {
                    setAboutUs(res.data.value);
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
                    <div className="col-md-10 col-8 text-right"><h3><b>  درباره ما</b></h3></div>
                </div>
                <div className="row w-100 mx-auto">
                    <img
                        src={window.location.origin + "/hj/img/borderbig green.png"}
                        alt="img1"
                        className="img-fluid mx-auto" />
                </div>

                <div className="row  p-2 m-0  mt-3">
                    {ReactHtmlParser(aboutUs || "")}
                </div>

            </div>
        </Fragment>


    );
}

export default AboutUs;

