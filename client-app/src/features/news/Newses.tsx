import React, { useEffect, useContext, useState } from 'react'
import { RootStoreContext } from '../../app/stores/rootStore';
import { Swiper, SwiperSlide } from 'swiper/react';
import SwiperCore, { Navigation, Pagination, Autoplay } from 'swiper'

import { siteUrl } from '../../config.json'
import { observer } from 'mobx-react-lite';

import MiniLoading from '../../app/common/Loading/MiniLoading'
import { toShortString } from '../../app/common/util/util';


import 'swiper/swiper-bundle.css'
import './../../style/sina.css'

SwiperCore.use([Navigation, Pagination, Autoplay])
const Newses = () => {
    const rootStore = useContext(RootStoreContext);
    const { loadingNews, loadNews, newsesList,loadingLike,Like } = rootStore.newsStore;

    const [likeTarget, setLikeTarget] = useState<string | undefined>(
        undefined
    );


    useEffect(() => {
        loadNews();
    }, [loadNews]);

    if (loadingNews)
        return (<>
            <MiniLoading />
        </>)
    return (
        <>
            <Swiper
                className="swiper-container swiper-container2"
                slidesPerView={3}
                spaceBetween={30}
                navigation={Navigation}

                autoplay={{
                    delay: 5000,
                    disableOnInteraction: false,
                    stopOnLastSlide: false,
                }}


                pagination={{
                    el: '.swiper-pagination',
                    clickable: true,
                }}
                breakpoints={{
                    // when window width is <= 499px
                    0: {
                        slidesPerView: 1,
                        spaceBetween: 30
                    },
                    // when window width is <= 999px
                    999: {
                        slidesPerView: 3,
                        spaceBetween: 40
                    }
                }}
            >

                <div className="swiper-wrapper">
                    {newsesList?.map((news, index) => {
                        return (
                            <div key={news.id}
                                className="swiper-slide _swiper-slider"
                                style={{ width: '360px', marginLeft: '30px' }}
                            >
                                <div className=" col-12 mx-auto  my-3">
                                    <div className="card w-100 hj-card-news">

                                        <video width="400" controls preload="metadata" className="card-img-top img-fluid _swiper-image">
                                            <source src={siteUrl + news.videoAddress + "#t=0.7"} id="video_here" />
                                            <source src="mov_bbb.ogg" id="video_here" />
                                        Your browser does not support HTML5 video.
                                         </video>

                                        {/* <img
                                            className="card-img-top img-fluid"
                                            // src={siteUrl + news.videoAddress}

                                            src={window.location.origin + "/hj/img/imgNews.png"}
                                            // src="~/hj/img/imgNews.png"
                                            alt="new"
                                        /> */}
                                        {/* <a href="#" data-toggle="modal" data-target="#centralPlay">
                                            <i className="fa fa-play-circle hj-play-New"></i>
                                        </a> */}
                                        <div className="card-body">
                                            <div className="row w-100 p-0 m-0 hj-option-card text-center">
                                                <div className="col-4 p-0 m-0">
                                                   
                                                {loadingLike && likeTarget == news.id ?
                                                        <i
                                                            className=" fa fa-spinner fa-spin fa-2x fa-fw pl-2"
                                                        ></i>
                                                        :
                                                        <i
                                                            // onclick="myFunction(this)"
                                                            onClick={
                                                                () => {
                                                                    setLikeTarget(news.id);
                                                                    Like(news)
                                                                }}
                                                            className={
                                                                news.isLiked ?
                                                                    'far fa-heart pl-2 fas'
                                                                    :
                                                                    'far fa-heart pl-2'
                                                            }
                                                        ></i>

                                                    }
                                                    <span className="hj-like">{news.likesCount}</span>
                                                </div>
                                                <div className="col-4 p-0 m-0">
                                                    <i className="fa fa-comments  pl-2"></i>
                                                    <span className="hj-like">{news.commentsCount}</span>
                                                </div>
                                                <div className="col-4 p-0 m-0">
                                                    <i className="fa fa-eye  pl-2"></i>
                                                    <span className="hj-like">{news.seenCount}</span>
                                                </div>
                                            </div>
                                            <h5 className="card-title text-right pt-4"> {news.title}</h5>
                                            <p className="card-text text-justify size-14 _swiper-text">
                                                {toShortString(news.description, 500)}
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        )
                    })}

                </div>
                {/* <!-- Add Pagination --> */}
                <div className="swiper-pagination"></div>
                {/* <!-- Add Arrows --> */}
                {/* @*<div className="swiper-button-next"></div>
                <div className="swiper-button-prev"></div>*@ */}





                {/* {newsesList?.map((news, index) => {
                    return (


                        <div className="swiper-wrapper">
                            {newsesList?.map((news, index) => {
                                return (<SwiperSlide key={index}
                                    className="swiper-slide"
                                >
                                    <img
                                        src={siteUrl + slide.photoAddress}
                                        className="img-fluid" alt="Responsive image11" />
                                    <div className="row w-100 text-justify Text-blue mx-auto">
                                        <div className="col-8 text-center py-2 mx-auto  hj-TilteSliderIndex "><span><b>{slide.title}</b></span></div>
                                        <div className="col-12 text-cener mx-auto py-2"><span>{slide.description} </span></div>
                                    </div>
                                </SwiperSlide>
                                )
                            })}
                        </div>
                    )
                })} */}

                {/* <div className="swiper-pagination"></div> */}
            </Swiper>


        </>





        // <div>


        //     <Swiper
        //         className="swiper-container swiper-container1"
        //         effect="coverflow"
        //         grabCursor={true}
        //         centeredSlides={false}
        //         slidesPerView="auto"
        //         pagination={{ clickable: true }}

        //         coverflowEffect={{
        //             rotate: 50,
        //             stretch: 0,
        //             depth: 100,
        //             modifier: 1,
        //             slideShadows: true,
        //         }}
        //         spaceBetween={10}
        //     >

        //         <div className="swiper-wrapper">
        //             {slidesList?.map((slide, index) => {
        //                 return (<SwiperSlide key={index}
        //                     className="swiper-slide"
        //                 >
        //                     <img
        //                         src={siteUrl + slide.photoAddress}
        //                         className="img-fluid" alt="Responsive image11" />
        //                     <div className="row w-100 text-justify Text-blue mx-auto">
        //                         <div className="col-8 text-center py-2 mx-auto  hj-TilteSliderIndex "><span><b>{slide.title}</b></span></div>
        //                         <div className="col-12 text-cener mx-auto py-2"><span>{slide.description} </span></div>
        //                     </div>
        //                 </SwiperSlide>
        //                 )
        //             })}
        //         </div>

        //         <div className="swiper-pagination"></div>
        //     </Swiper>


        // </div>
    )
}


export default observer(Newses)



































// <div className="swiper-container swiper-container2">
// <div className="swiper-wrapper">
//     {newsesList?.map((news, index) => {
//         return (
//             <div key={news.id}
//                 className="swiper-slide"
//                 style={{ width: '360px', marginLeft: '30px' }}
//             >
//                 <div className=" col-12 mx-auto  my-3">
//                     <div className="card w-100 hj-card-news">

//                         <video width="400" controls preload="metadata" className="card-img-top img-fluid">
//                             <source src={siteUrl + news.videoAddress + "#t=0.7"} id="video_here" />
//                             <source src="mov_bbb.ogg" id="video_here" />
//                         Your browser does not support HTML5 video.
//                          </video>

//                         {/* <img
//                             className="card-img-top img-fluid"
//                             // src={siteUrl + news.videoAddress}

//                             src={window.location.origin + "/hj/img/imgNews.png"}
//                             // src="~/hj/img/imgNews.png"
//                             alt="new"
//                         /> */}
//                         {/* <a href="#" data-toggle="modal" data-target="#centralPlay">
//                             <i className="fa fa-play-circle hj-play-New"></i>
//                         </a> */}
//                         <div className="card-body">
//                             <div className="row w-100 p-0 m-0 hj-option-card text-center">
//                                 <div className="col-4 p-0 m-0">
//                                     <i
//                                         // onclick="myFunction(this)"
//                                         className="far fa-heart pl-2"
//                                     ></i>
//                                     <span className="hj-like">{news.likesCount}</span>
//                                 </div>
//                                 <div className="col-4 p-0 m-0">
//                                     <i className="fa fa-comments  pl-2"></i>
//                                     <span className="hj-like">{news.commentsCount}</span>
//                                 </div>
//                                 <div className="col-4 p-0 m-0">
//                                     <i className="fa fa-eye  pl-2"></i>
//                                     <span className="hj-like">{news.seenCount}</span>
//                                 </div>
//                             </div>
//                             <h5 className="card-title text-right pt-4"> {news.title}</h5>
//                             <p className="card-text text-justify size-14">
//                                 {toShortString(news.description, 500)}

//                             </p>
//                         </div>
//                     </div>
//                 </div>
//             </div>

//         )
//     })}


// </div>
// {/* <!-- Add Pagination --> */}
// <div className="swiper-pagination"></div>
// {/* <!-- Add Arrows --> */}
// {/* <div className="swiper-button-next"></div>
// <div className="swiper-button-prev"></div> */}
// </div>




