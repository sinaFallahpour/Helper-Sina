import React from 'react';
const MyAmar: React.FC = () => {
    return (
        <>

            <div className="row w-100 mx-auto text-center">
                <div className="col-12 text-md-right text-center">
                    <h3>آمـــــــــــــار</h3>
                </div>
                <div className="col-12 p-0">
                    <img
                        src={window.location.origin + "/hj/img/borderbig green.png"}
                        className="img-fluid" />
                </div>
            </div>
            <div className="row w-100 mx-auto mt-5">
                <div className="col-lg-6 col-12 p-0">
                    <div className="row w-100 mx-auto">
                        <div className="col-3 py-3 p-0 mx-auto text-center hj-number-amar">
                            <div className="row w-100 mx-auto"><h6 className="text-center hj-size text-helper timer mx-auto" data-to="3556" data-speed="8000"></h6></div>
                            <div className="row w-100 mx-auto"><h6 className="text-center hj-size text-helper mx-auto pt-3"> پسندیده شده ها</h6></div>
                        </div>

                        <div className="col-3 py-3 p-0 mx-auto text-center hj-number-amar">
                            <div className="row w-100 mx-auto"><h6 className="text-center hj-size text-helper timer mx-auto" data-to="3556" data-speed="8000"></h6></div>
                            <div className="row w-100 mx-auto"><h6 className="text-center  hj-size text-helper mx-auto pt-3"> پسندیده شده ها</h6></div>
                        </div>
                        <div className="col-3 py-3 p-0  mx-auto text-center hj-number-amar">
                            <div className="row w-100 mx-auto"><h6 className="text-center hj-size text-helper timer mx-auto" data-to="3556" data-speed="8000"></h6></div>
                            <div className="row w-100 mx-auto"><h6 className="text-center hj-size text-helper mx-auto pt-3"> پسندیده شده ها</h6></div>
                        </div>
                    </div>
                    <div className="row w-100 mx-auto sum-amar mt-5 py-4">
                        <div className="col-6 text-center amar-daramad">
                            <div className="col-12 py-3 py-md-0"><h6>درآمد کسب شده</h6></div>
                            <div className="col-12"><h6>در سه ماه گذشته</h6></div>
                        </div>
                        <div className="col-6 text-center"><div className="col-12 py-4 py-md-0"><h6>150.000.000</h6></div><div className="col-12 py-4 py-md-0"><h6>ریال</h6></div></div>
                    </div>
                </div>
                <div className="col-lg-6 col-12 hj-charts mt-lg-0 mt-5">     <canvas id="myChart"></canvas></div>

            </div>



            <div className="row w-100 mx-auto mt-5 text-center">
                <div className="col-md-4 col-12 py-3 mx-auto">
                    <img
                        src={window.location.origin + "/hj/img/111.png"}
                        className="img-fluid " alt="Responsive image" />
                    <br></br>
                    <br></br>
                    <span className=" hj-text-service pt-4 text-center"> تعداد خدمات دهندگان</span><br />
                    <span className="timer text-helper" data-to="3556" data-speed="8000">3556</span>
                </div>
                <div className="col-md-4 col-12 py-3 mx-auto">
                    <img
                        src={window.location.origin + "/hj/img/222.png"}
                        className="img-fluid " alt="Responsive image" />
                    <br></br>
                    <br></br>
                    <span className=" hj-text-service pt-4 text-center"> خدمات انجام شده</span><br />
                    <span className="timer text-helper" data-to="3556" data-speed="8000">3556</span>
                </div>
                <div className="col-md-4 col-12 py-3 mx-auto">
                    <img
                        src={window.location.origin + "/hj/img/333.png"}
                        className="img-fluid " alt="Responsive image" />
                    <br></br>
                    <br></br>
                    <span className=" hj-text-service pt-4 text-center"> شهر های تحت پوشش</span><br />
                    <span className="timer text-helper" data-to="3556" data-speed="8000">3556</span>
                </div>
            </div>


        </>


    )
}



export default MyAmar