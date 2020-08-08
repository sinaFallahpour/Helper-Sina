import React, { Fragment, useEffect } from 'react';

import CountUp from 'react-countup';
// import { Swiper, SwiperSlide } from 'swiper/react';
import Slides from './Slides'
const HomePage: React.FC = () => {


    useEffect(() => {
    }, []);


    return (
        <Fragment>

            {/*  // @*...............intro..................*@*/}
            <div className="container">
                <div className="row mt-md-5 pt-md-5">
                    <div className="col-md-5 col-12 ml-lg-5 order-md-0 order-1 hj-intro-h">
                        <div className="row mx-auto">
                            <span className="text-justify size-33"> </span>
                            <b>
                                هلپر ، بستری مناسب برای
                                دسترسی  آسان
                    </b>
                        </div>
                        <div className="row w-100 mx-auto pt-3 pt-md-2">
                            <img
                                src={window.location.origin + "/hj/img/border-bottom.png"}
                                alt="img1"
                                className="img-fluid" />
                        </div>
                        <div className="row mt-3 mx-auto">
                            <span className="text-justify hj-intro-text">لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</span>
                        </div>
                        <div className="row mt-5 ">
                            <div className="col-6">
                                <button type="button" className="btn btn-primary w-100 hj-intro-button">همین حالا شروع کن</button>
                            </div>
                            <div className="col-6">
                                <button type="button" className="btn btn-primary w-100 hj-intro-button">مشاهده دسته بندی ها</button>
                            </div>
                        </div>
                    </div>
                    <div className="col-md-6 col-12 mr-lg-4 order-md-1 order-0">
                        <img
                            src={window.location.origin + "/hj/img/intro.svg"}
                            className="img-fluid" alt="Responsive image112" />
                    </div>

                </div>
                {/* @*...................end intro.....................*@*/}
            </div>
            {/*  //            @*...........end header..........*@*/}

            {/* // @*..............contect...............*@  */}
            <div className="container-fluid mt-md-5">
                <div className="row hj-content hj-content">
                    <div className="container mt-md-5 pt-md-5">
                        <div className="row text-center mt-5">
                            <div className="col-md-4  mb-5">
                                {/* src={window.location.origin + "/ReactPages/" + one}  */}
                                <img src={window.location.origin + "/hj/img/1.png"}
                                    className="img-fluid "
                                    alt="Responsive imag3" />
                                <h4 className="pt-4">تعداد خدمات دهندگان</h4>
                                <span className="timer" data-to="3556" data-speed="8000"></span>
                                <CountUp className="timer" start={0} end={3556} duration={4} />

                            </div>
                            <div className="col-md-4  mb-5">
                                {/* src={window.location.origin + "/ReactPages/" + two} */}
                                <img src={window.location.origin + "/hj/img/2.png"}
                                    className="img-fluid"
                                    alt="Responsive image114" />

                                <h4 className="pt-4">خدمات انجام شده</h4>
                                <span className="timer" data-to="3556" data-speed="8000"></span>
                                <CountUp className="timer" start={0} end={3556} duration={4} />

                            </div>
                            <div className="col-md-4  mb-5">
                                {/* src={window.location.origin + "/ReactPages/" + tree} */}
                                <img src={window.location.origin + "/hj/img/3.png"}
                                    className="img-fluid"
                                    alt="Responsive image115" />
                                <h4 className="pt-4">شهر های تحت پوشش</h4>
                                <span className="timer" data-to="3556" data-speed="8000"></span>
                                <CountUp className="timer" start={0} end={3556} duration={4} />
                            </div>
                        </div>
                        {/*  //@*........................service....................*@  */}
                        <div className="row mt-md-5 pt-md-5">
                            <div className="row w-100 p-0 m-0 pt-md-5 mt-md-5 mx-auto hj-work-header">
                                {/* src={"/ReactPages/" + Rectangle} */}
                                <div className="col-4 text-left pt-3"><img src={window.location.origin + "/hj/img/Rectangle 2886.png"} className="img-fluid" alt="imm" /></div>
                                <div className="col-4 text-center pt-3  pt-md-2 pt-lg-0 mx-auto"> <span className="text-center size-33  hj-work"> خدمات </span></div>

                                {/* src={"/ReactPages/" + Rectangle} */}
                                <div className="col-4 text-right pt-3"><img src={window.location.origin + "/hj/img/Rectangle 2886.png"} className="img-fluid" alt="img" /></div>
                            </div>
                        </div>
                        <div className="row text-center mt-5 ">
                            <div className="col-md-3 col-6 py-3">
                                {/* src={window.location.origin + "/ReactPages/" + service1} */}
                                <img src={window.location.origin + "/hj/img/service1.png"} className="img-fluid " alt="Responsive image116" />
                                <br />
                                <br />
                                <span className=" hj-text-service pt-4">ماشین</span>
                            </div>
                            <div className="col-md-3 col-6 py-3">
                                {/* src={window.location.origin + "/ReactPages/" + service2} */}
                                <img src={window.location.origin + "/hj/img/service2.png"}
                                    className="img-fluid " alt="Responsive image11" />
                                <br />
                                <br />
                                <span className=" hj-text-service pt-4">شارژ و قبض</span>
                            </div>
                            <div className="col-md-3 col-6 py-3">

                                {/* src={window.location.origin + "/ReactPages/" + service3} */}
                                <img
                                    src={window.location.origin + "/hj/img/service3.png"}
                                    className="img-fluid " alt="Responsive image11" />
                                <br />
                                <br />
                                <span className=" hj-text-service pt-4">بلیط</span>
                            </div>
                            <div className="col-md-3 col-6 py-3">
                                {/* src={window.location.origin + "/ReactPages/" + service4} */}
                                <img
                                    src={window.location.origin + "/hj/img/service4.png"}
                                    className="img-fluid " alt="Responsive image119" />
                                <br />
                                <br />
                                <span className=" hj-text-service pt-4"> مسکن</span>
                            </div>
                        </div>
                        <div className="row text-center  ">
                            <div className="col-md-3 col-6 py-3 pt-5 order-md-0 order-3">
                                <span className=" hj-text-service pt-4">مشاهده همه</span>
                                <div className="load-wrapp ">
                                    <div className="load-3 pt-3">

                                        <div className="line"></div>
                                        <div className="line"></div>
                                        <div className="line"></div>
                                    </div>
                                </div>
                            </div>
                            <div className="col-md-3 col-6  py-3 order-md-1 order-2">
                                {/* src={window.location.origin + "/ReactPages/" + service7} */}
                                <img
                                    src={window.location.origin + "/hj/img/service7.png"}
                                    className="img-fluid " alt="Responsive image119" />
                                <br />
                                <br />
                                <span className=" hj-text-service pt-4">مترجم</span>
                            </div>
                            <div className="col-md-3 col-6  py-3  order-md-2 order-1 ">
                                {/* src={window.location.origin + "/hj/img/service7.png"} */}
                                <img
                                    src={window.location.origin + "/hj/img/service6.png"}
                                    className="img-fluid " alt="Responsive image1110" />
                                <br />
                                <br />
                                <span className=" hj-text-service pt-4">خدمات شهروندی</span>
                            </div>
                            <div className="col-md-3 col-6 py-3  order-md-3 order-0">
                                {/* src={window.location.origin + "/ReactPages/" + service5} */}
                                <img
                                    src={window.location.origin + "/hj/img/service5.png"}
                                    className="img-fluid " alt="Responsive image1111" />
                                <br />
                                <br />
                                <span className=" hj-text-service pt-4  "> صرافی</span>
                            </div>
                        </div>
                        <div className="row text-center mt-5">
                            <div className="col-12">
                                <button type="button" className="btn btn-success hj-service-index-button  ">همین حالا شروع کن</button>
                            </div>
                        </div>
                        {/*  // @*........................End service....................*@ */}
                    </div>

                </div>
                {/*  //@*..........work...........*@    */}
                <div className="row hj-work-index pt-md-5">
                    <div className="container pt-md-5 mt-5">

                        <div className="row w-100 p-0 m-0 pt-md-5 mx-auto hj-work-header">
                            <div className="col-md-4 col-3 text-left pt-3">
                                {/* src={"/ReactPages/" + Rectangle} */}
                                <img
                                    src={window.location.origin + "/hj/img/Rectangle 2886.png"}
                                    className="img-fluid"
                                    alt="im" />

                            </div>
                            <div className="col-md-4 col-6 text-center mx-auto mt-md-0 mt-3"> <span className="text-center size-33 hj-work">چطور کار میکنه</span></div>
                            <div className="col-md-4 col-3 text-right pt-3">
                                {/* src={"/ReactPages/" + Rectangle}  */}
                                <img
                                    src={window.location.origin + "/hj/img/Rectangle 2886.png"}
                                    className="img-fluid" alt="img8" />
                            </div>
                        </div>

                        <div className="row mt-5 pl-md-5">
                            <div className="col-md-6 col-12 order-1 order-md-0 mt-md-0 mt-4">

                                <div className="row mx-auto ">
                                    <span className="text-justify hj-intro-titr pb-1">
                                        برای کاربران
                        </span>
                                </div>
                                <div className="row w-100 pt-md-1 pt-3 mx-auto">
                                    {/* src={window.location.origin + "/ReactPages/" + borderBottom} */}
                                    <img
                                        src={window.location.origin + "/hj/img/border-bottom.png"}
                                        className="img-fluid" alt="img11" />
                                </div>

                                <div className="row pt-3 mx-auto">
                                    <span className="text-justify hj-intro-text pl-md-5">لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</span>
                                </div>
                                <div className="row text-right mt-5 ">
                                    <div className="col-12 text-md-right text-center">
                                        <button type="button" className="btn btn-success hj-service-index-button ">همین حالا شروع کن</button>
                                    </div>
                                </div>
                            </div>
                            <div className="col-md-6 col-12 order-0 order-md-1 mt-md-0 mt-4">
                                {/* src={window.location.origin + "/ReactPages/" + workIndex} */}
                                <img
                                    src={window.location.origin + "/hj/img/work index.svg"}
                                    className="img-fluid " alt="Responsive image1" />
                            </div>
                        </div>
                        <div className="row mt-5 pl-md-5">

                            <div className="col-md-6 col-12 ">
                                {/* src={window.location.origin + "/ReactPages/" + workIndex} */}
                                <img
                                    src={window.location.origin + "/hj/img/work index.svg"}
                                    className="img-fluid " alt="Responsive image1" />
                            </div>
                            <div className="col-md-6 col-12  mt-3 pr-md-5">
                                <div className="row  position-relative">
                                    <span className="text-justify hj-intro-titr pb-1">
                                        برای متخصصین
                        </span>
                                </div>
                                <div className="row w-100 pt-md-1 pt-3 mx-auto">
                                    {/* src={window.location.origin + "/ReactPages/" + borderBottom} */}
                                    <img
                                        src={window.location.origin + "/hj/img/border-bottom.png"}
                                        className="img-fluid" alt="img12" />
                                </div>
                                <div className="row pt-3">
                                    <span className="text-justify hj-intro-text">لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</span>
                                </div>
                                <div className="row text-right mt-5">
                                    <div className="col-12 text-md-right text-center">
                                        <button type="button" className="btn btn-success hj-service-index-button ">همین حالا شروع کن</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
                {/*  //@*..........end work...........*@*/}
                {/* //@*...........Why Helper?........*@  */}
                <div className="row hj-WhyHelper-index ">
                    <div className="container pt-5">
                        <div className="row w-100 mx-auto">
                            <div className="col-md-8  col-12  mb-5 hj-WhyHelper mx-auto">
                                <span className=" bg-slider px-md-5 px-2">چرا هلپر</span>
                            </div>
                        </div>
                        <div className="row w-100  mx-auto">
                            <div className="col-12">
                                {/*   //---- Swiper -------*/}
                                {/*                                 
                                <div className="swiper-container swiper-container1">
                                    <div className="swiper-wrapper">
                                        <div className="swiper-slide">
                                            <img
                                                src={window.location.origin + "/hj/img/slider1 (1).png"}

                                                className="img-fluid" alt="Responsive image11" />
                                            <div className="row w-100 text-justify Text-blue mx-auto">
                                                <div className="col-8 text-center py-2 mx-auto  hj-TilteSliderIndex "><span><b>تایتل</b></span></div>
                                                <div className="col-12 text-cener mx-auto py-2"><span>لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</span></div>
                                            </div>
                                        </div>
                                        <div className="swiper-slide">
                                            <img
                                                src={window.location.origin + "/hj/img/slider1 (3).png"}
                                                className="img-fluid" alt="Responsive image11" />
                                            <div className="row w-100 text-justify Text-blue mx-auto">
                                                <div className="col-8 text-center py-2 mx-auto  hj-TilteSliderIndex "><span><b>تایتل</b></span></div>
                                                <div className="col-12 text-cener mx-auto py-2"><span>لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</span></div>
                                            </div>
                                        </div>
                                        <div className="swiper-slide">
                                            <img
                                                src={window.location.origin + "/hj/img/slider1 (1).png"}
                                                className="img-fluid" alt="Responsive image11" />
                                            <div className="row w-100 text-justify Text-blue mx-auto">
                                                <div className="col-8 text-center py-2 mx-auto  hj-TilteSliderIndex "><span><b>تایتل</b></span></div>
                                                <div className="col-12 text-cener mx-auto py-2"><span>لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</span></div>
                                            </div>
                                        </div>
                                        <div className="swiper-slide">
                                            <img
                                                src={window.location.origin + "/hj/img/slider1 (3).png"}
                                                className="img-fluid" alt="Responsive image11" />
                                            <div className="row w-100 text-justify Text-blue mx-auto">
                                                <div className="col-8 text-center py-2 mx-auto  hj-TilteSliderIndex "><span><b>تایتل</b></span></div>
                                                <div className="col-12 text-cener mx-auto py-2"><span>لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</span></div>
                                            </div>
                                        </div>
                                        <div className="swiper-slide">
                                            <img
                                                src={window.location.origin + "/hj/img/slider1 (1).png"}
                                                className="img-fluid" alt="Responsive image11" />
                                            <div className="row w-100 text-justify Text-blue mx-auto">
                                                <div className="col-8 text-center py-2 mx-auto  hj-TilteSliderIndex "><span><b>تایتل</b></span></div>
                                                <div className="col-12 text-cener mx-auto py-2"><span>لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</span></div>
                                            </div>
                                        </div>


                                    </div>
                                      -- Add Pagination --  
                                    <div className="swiper-pagination"></div>
                                </div>
                            */}


                                {/*   //-- Swiper JS --*/}


                                <Slides />


                                {/*   //---- Swiper -------*/}
                                {/* 
                                <Swiper
                                    className="swiper-container swiper-container1"
                                    effect="coverflow"
                                    grabCursor={true}
                                    centeredSlides={false}
                                    slidesPerView="auto"

                                    pagination={{ clickable: true }}

                                    coverflowEffect={{
                                        rotate: 50,
                                        stretch: 0,
                                        depth: 100,
                                        modifier: 1,
                                        slideShadows: true,
                                    }}

                                    spaceBetween={10}
                                    onSwiper={(swiper) => console.log(swiper)}
                                    onSlideChange={() => console.log('slide change')}

                                >
                                    <div className="swiper-wrapper">

                                        <SwiperSlide
                                            className="swiper-slide"
                                        >
                                            <img
                                                src={window.location.origin + "/hj/img/slider1 (1).png"}

                                                className="img-fluid" alt="Responsive image11" />
                                            <div className="row w-100 text-justify Text-blue mx-auto">
                                                <div className="col-8 text-center py-2 mx-auto  hj-TilteSliderIndex "><span><b>تایتل1</b></span></div>
                                                <div className="col-12 text-cener mx-auto py-2"><span>لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</span></div>
                                            </div>
                                        </SwiperSlide>
                                        <SwiperSlide className="swiper-slide">
                                            <img
                                                src={window.location.origin + "/hj/img/slider1 (1).png"}
                                                className="img-fluid" 
                                                alt="Responsive image11" />
                                            <div className="row w-100 text-justify Text-blue mx-auto">
                                                <div className="col-8 text-center py-2 mx-auto  hj-TilteSliderIndex "><span><b>تایتل2</b></span></div>
                                                <div className="col-12 text-cener mx-auto py-2"><span>لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</span></div>
                                            </div>
                                        </SwiperSlide>
                                        <SwiperSlide className="swiper-slide">
                                            <img
                                                src={window.location.origin + "/hj/img/slider1 (1).png"}
                                                className="img-fluid" 
                                                alt="Responsive image11" />
                                            <div className="row w-100 text-justify Text-blue mx-auto">
                                                <div className="col-8 text-center py-2 mx-auto  hj-TilteSliderIndex "><span><b>تایتل3</b></span></div>
                                                <div className="col-12 text-cener mx-auto py-2"><span>لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</span></div>
                                            </div>
                                        </SwiperSlide>

                                        <SwiperSlide className="swiper-slide">
                                            <img
                                                src={window.location.origin + "/hj/img/slider1 (1).png"}
                                                className="img-fluid" 
                                                alt="Responsive image11" />
                                            <div className="row w-100 text-justify Text-blue mx-auto">
                                                <div className="col-8 text-center py-2 mx-auto  hj-TilteSliderIndex "><span><b>تایتل4</b></span></div>
                                                <div className="col-12 text-cener mx-auto py-2"><span>لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</span></div>
                                            </div>
                                        </SwiperSlide>
                                        <SwiperSlide className="swiper-slide">
                                            <img
                                                src={window.location.origin + "/hj/img/slider1 (1).png"}
                                                className="img-fluid" 
                                                alt="Responsive image11" />
                                            <div className="row w-100 text-justify Text-blue mx-auto">
                                                <div className="col-8 text-center py-2 mx-auto  hj-TilteSliderIndex "><span><b>تایتل</b></span></div>
                                                <div className="col-12 text-cener mx-auto py-2"><span>لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</span></div>
                                            </div>
                                        </SwiperSlide>
                                    </div>
                                    <div className="swiper-pagination"></div>
                                </Swiper>
 */}

                                {/*   //-- Swiper JS --*/}

                            </div>
                        </div>
                    </div>

                </div>

                {/* //@...........end Why Helper?........*@  */}

            </div>

            {/* //@*..............end contect...............*@ */}

        </Fragment>


    );
};


export default HomePage;