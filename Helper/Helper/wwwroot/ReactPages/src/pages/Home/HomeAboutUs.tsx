import React, { Fragment, useContext, useEffect, useState } from 'react';
import ReactDOM from 'react-dom';
import { observer } from 'mobx-react-lite';
import ReactHtmlParser, { processNodes, convertNodeToElement } from 'react-html-parser';

import agent from '../../app/api/agent'

const HoemAboutUsView: React.FC = () => {

    const [aboutUs, setAboutUs] = useState(undefined);
    const [loading, setloading] = useState(false);

    useEffect(() => {
        async function fetchMyAPI() {
            setloading(true);
            try {
                let res = await agent.AboutUs.aboutUs();
                if (res.status == 1) {
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
            <div className="container">
                {ReactHtmlParser(aboutUs || "")}
            </div>
           
        </Fragment>


    );
}



ReactDOM.render(
    <HoemAboutUsView />
    ,
    document.getElementById('root')
);

