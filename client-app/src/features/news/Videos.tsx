import React, { useEffect, useContext, useState } from 'react'
import { RootStoreContext } from '../../app/stores/rootStore';
import { Swiper, SwiperSlide } from 'swiper/react';
import SwiperCore, { Navigation, Pagination, Autoplay } from 'swiper'

import { siteUrl } from '../../config.json'
import { observer } from 'mobx-react-lite';

import MiniLoading from '../../app/common/Loading/MiniLoading'
import { keys } from 'mobx';
import { toShortString } from '../../app/common/util/util';



import 'swiper/swiper-bundle.css'
import './../../style/sina.css'
SwiperCore.use([Navigation, Pagination, Autoplay])

const Videos = () => {
    const rootStore = useContext(RootStoreContext);
    const { loadingVideos, loadVideos, videosList, loadingLike, Like } = rootStore.newsStore;

    const [likeTarget, setLikeTarget] = useState<string | undefined>(
        undefined
    );

    useEffect(() => {
        loadVideos();
    }, [loadVideos]);

    if (loadingVideos)
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
                    delay: 3000,
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
                    {videosList?.map((video, index) => {
                        return (
                            <div key={video.id}
                                className="swiper-slide _swiper-slider"
                                style={{ width: '360px', marginLeft: '30px' }}
                            >
                                <div className=" col-12 mx-auto  my-3">
                                    <div className="card w-100 hj-card-news">

                                        <video width="400" controls preload="metadata" className="card-img-top img-fluid _swiper-image">
                                            <source src={siteUrl + video.videoAddress + "#t=0.7"} id="video_here" />
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
                                                    {loadingLike && likeTarget == video.id ?
                                                        <i
                                                            className=" fa fa-spinner fa-spin fa-2x fa-fw pl-2"
                                                        ></i>
                                                        :
                                                        <i
                                                            // onclick="myFunction(this)"
                                                            onClick={
                                                                () => {
                                                                    setLikeTarget(video.id);
                                                                    Like(video)
                                                                }}
                                                            className={
                                                                video.isLiked ?
                                                                    'far fa-heart pl-2 fas'
                                                                    :
                                                                    'far fa-heart pl-2'
                                                            }
                                                        ></i>

                                                    }
                                                    <span className="hj-like">{video.likesCount}</span>
                                                </div>
                                                <div className="col-4 p-0 m-0">
                                                    <i className="fa fa-comments  pl-2"></i>
                                                    <span className="hj-like">{video.commentsCount}</span>
                                                </div>
                                                <div className="col-4 p-0 m-0">
                                                    <i className="fa fa-eye  pl-2"></i>
                                                    <span className="hj-like">{video.seenCount}</span>
                                                </div>
                                            </div>
                                            <h5 className="card-title text-right pt-4"> {video.title}</h5>
                                            <p className="card-text text-justify size-14 _swiper-text">
                                                {toShortString(video.description, 500)}
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


    )
}


export default observer(Videos)


