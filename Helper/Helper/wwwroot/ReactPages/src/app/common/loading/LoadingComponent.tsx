import React from 'react';


const LoadingComponent: React.FC = () => {
    return (
        <div  className="container">
            <div className="row">
                <div className="col-md-12">
                    <div className="loader">
                        <div className="loader-inner">
                            <div className="loading one"></div>
                        </div>
                        <div className="loader-inner">
                            <div className="loading two"></div>
                        </div>
                        <div className="loader-inner">
                            <div className="loading three"></div>
                        </div>
                        <div className="loader-inner">
                            <div className="loading four"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
};

export default LoadingComponent;
