import React from 'react'

const Header: React.FC = () => {
    return (

        <div className="footer">
            <div className="container-fluid p-0 m-0 ">

                <div className="container mb-5 hj-wallet-img ">
                    <div className="row w-100 text-center hj-titr-wallet mt-5 mb-5">
                        <div className="col-12 ">
                            <h3 className="hj-text-wallet">کیف پول هلپر</h3>
                        </div>
                    </div>
                    <div className="row text-center w-100 mx-auto">
                        <div className="col-4 p-0 "><img src={window.location.origin + "/hj/img/bag1.png"} className="img-fluid" alt="Responsive images" /></div>
                        <div className="col-4 p-0"><img src={window.location.origin + "/hj/img/bag2.png"} className="img-fluid" alt="Responsive image2" /></div>
                        <div className="col-4 p-0"><img src={window.location.origin + "/hj/img/bag3.png"} className="img-fluid" alt="Responsive image3" /></div>
                    </div>
                    <div className="row text-center mt-5">
                        <div className="col-12">
                            <button type="button" className="btn btn-success hj-footer-wallet-button ">شارژ کیف پول  </button>
                        </div>
                    </div>
                </div>
                <div className="container">
                    <div className="row">
                        <div className="col-md-5">
                            <div className="col-12 mb-3">
                                <h3 className="text-right">
                                    هلپر ، بستری مناسب برای

                        </h3>
                            </div>
                            <div className="row w-100 pt-5">
                                <img
                                    src={window.location.origin + "/hj/img/border-bottom.png"}
                                    className="img-fluid mr-4"
                                    alt="img4" />
                            </div>
                            <div className="col-12 pt-5">
                                <p className="text-justify hj-footer-ditalis">لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</p>
                            </div>
                            <div className="col-12 text-md-right text-center mt-4">
                                <button type="button" className="btn btn-success hj-service-index-button  ">  ورود / ثبت نام</button>
                            </div>
                        </div>
                        <div className="col-md-3">

                        </div>
                        <div className="col-md-4 mt-md-0 mt-4">
                            <div className="row">
                                <div className="col-12 text-right mb-3 hj-join-news">عضویت در خبر </div>
                                <div className="col-12">

                                    <form>
                                        <input className="SubmitBox" type="email" placeholder="برای عضویت در خبرنامه ایمیل خود را وارد کنید" />
                                    </form>
                                    <button type="button" className="btn btn-success hj-Record">ثبت </button>

                                </div>
                                <div className="row w-100 mt-4  text-center">
                                    <div className="col-4"><ul className="hj-share text-left"><i className="fab fa-telegram-plane"></i> </ul></div>
                                    <div className="col-4"><ul className="hj-share text-center"> <i className="fab fa-instagram"></i></ul></div>
                                    <div className="col-4"><ul className="hj-share  text-right"> <i className="fab fa-facebook-f"></i></ul></div>

                                </div>
                            </div>
                        </div>
                    </div>



                </div>

                <div className="row w-100 justify-content text-center width-90 mx-auto mt-3 pt-4">
                    <div className="col-1"></div>
                    <div className="col-lg-2  col-12 text-right">
                        <div className="col-12 hj-titr-Footer py-2"><h6>بخش های سایت</h6></div>
                        <div className="row w-100">
                            <div className="col-md-11 mx-auto"> <img src={window.location.origin + "/hj/img/border-bottom.png"} className="img-fluid mr-2"  alt="img5"/></div>

                        </div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i>قوانین و مقررات</span></div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i> سوالات متداول </span></div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i> مقالات آموزشی </span></div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i> دوره آموزشی</span></div>




                    </div>
                    <div className="col-lg-2  col-12 text-right">
                        <div className="col-12 hj-titr-Footer py-2"><h6>بخش های سایت</h6></div>
                        <div className="row w-100">
                            <div className="col-md-11 mx-auto"> <img src={window.location.origin + "/hj/img/border-bottom.png"} className="img-fluid mr-2" alt="img6" /></div>

                        </div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i>قوانین و مقررات</span></div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i> سوالات متداول </span></div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i> مقالات آموزشی </span></div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i> دوره آموزشی</span></div>




                    </div>
                    <div className="col-lg-2  col-12 text-right">
                        <div className="col-12 hj-titr-Footer py-2"><h6>بخش های سایت</h6></div>
                        <div className="row w-100">
                            <div className="col-md-11 mx-auto"> <img     src={window.location.origin + "/hj/img/border-bottom.png"}  className="img-fluid mr-2" alt="img7"/></div>

                        </div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i>قوانین و مقررات</span></div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i> سوالات متداول </span></div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i> مقالات آموزشی </span></div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i> دوره آموزشی</span></div>




                    </div>
                    <div className="col-lg-2 col-12 text-right">
                        <div className="col-12 hj-titr-Footer py-2"><h6>بخش های سایت</h6></div>
                        <div className="row w-100">
                            <div className="col-md-11 mx-auto"> <img  src={window.location.origin + "/hj/img/border-bottom.png"} className="img-fluid mr-2" alt="img8"/></div>

                        </div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i>قوانین و مقررات</span></div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i> سوالات متداول </span></div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i> مقالات آموزشی </span></div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i> دوره آموزشی</span></div>




                    </div>
                    <div className="col-lg-2  col-12 text-right">
                        <div className="col-12 hj-titr-Footer py-2"><h6>بخش های سایت</h6></div>
                        <div className="row w-100">
                            <div className="col-md-11 mx-auto"> <img  src={window.location.origin + "/hj/img/border-bottom.png"} className="img-fluid mr-2" alt="img9"/></div>

                        </div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i>قوانین و مقررات</span></div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i> سوالات متداول </span></div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i> مقالات آموزشی </span></div>
                        <div className="col-12 py-2"><span><i className="fa fa-circle pl-2"></i> دوره آموزشی</span></div>




                    </div>
                    <div className="col-1"></div>
                </div>
                {/* @*-----Electronic symbol----*@ */}
                <div className="container mt-5">
                    <div className="row w-100 text-center mx-auto width-70">
                        <div className="col-4">
                            <img src={window.location.origin + "/hj/img/logo1.svg"}  className="img-fluid" alt="Responsive image12" />
                        </div>
                        <div className="col-4">
                            <img src={window.location.origin + "/hj/img/logo1.svg"} 
                             className="img-fluid" 
                             alt="Responsive image10" />
                        </div>
                        <div className="col-4">
                            <img src={window.location.origin + "/hj/img/logo1.svg"} 
                             className="img-fluid" 
                             alt="Responsive image11" />
                        </div>
                    </div>
                </div>
                {/* @*-----End Electronic symbol----*@ */}

                <div className="row w-100 hj-Endfooter p-0 m-0 mt-5 text-center">
                    <span className="text-center w-100 pt-2">تمامی حقوق مادی و معنوی متعلق به هلپر  میباشد</span>
                </div>


            </div>
        </div>
    )
}


export default Header;
