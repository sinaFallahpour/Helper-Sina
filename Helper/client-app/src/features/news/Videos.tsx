import React, { useEffect, useContext } from 'react'
import { RootStoreContext } from '../../app/stores/rootStore';
import { Swiper, SwiperSlide } from 'swiper/react';

import { siteUrl } from '../../config.json'
import { observer } from 'mobx-react-lite';

import MiniLoading from '../../app/common/Loading/MiniLoading'
import { keys } from 'mobx';
import { toShortString } from '../../app/common/util/util';

const Videos = () => {
    const rootStore = useContext(RootStoreContext);
    const { loadingVideos, loadVideos, videosList } = rootStore.newsStore;

    useEffect(() => {
        loadVideos();
    }, [loadVideos]);

    if (loadingVideos)
        return <>
            <MiniLoading />
        </>

    return (
        <>


            <div className="swiper-container swiper-container2">
                <div className="swiper-wrapper">

                    {videosList?.map((video, index) => {
                        return (

                            <div key={video.id} className="swiper-slide"
                                style={{ width: '360px', marginLeft: '30px' }}
                            >
                                <div className=" col-12 mx-auto  my-3">
                                    <div className="card w-100 hj-card-news">

                                        <video width="400" controls preload="metadata" className="card-img-top img-fluid">
                                            <source src={siteUrl + video.videoAddress+"#t=0.6"} id="video_here" />
                                            Your browser does not support HTML5 video.
                                         </video>
                                        {/* <img
                                            className="card-img-top img-fluid"
                                            // src={siteUrl + video.videoAddress}
                                            src={window.location.origin + "/hj/img/imgNews.png"}
                                            // src="~/hj/img/imgNews.png"
                                            alt="new"
                                        /> */}
                                        {/* <a href="#" data-toggle="modal d-bock text-center" data-target="#centralPlay">
                                            <i className="fa fa-play-circle hj-play-New "></i>
                                        </a> */}
                                        <div className="card-body">
                                            <div className="row w-100 p-0 m-0 hj-option-card text-center">
                                                <div className="col-4 p-0 m-0">
                                                    <i
                                                        // onclick="myFunction(this)"
                                                        className="far fa-heart pl-2"
                                                    ></i>
                                                    <span className="hj-like">{video.commentsCount}</span>
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
                                            <h5 className="card-title text-right pt-4"> فیلم آموزشی</h5>
                                            <p className="card-text text-justify size-14">
                                                {toShortString(video.description, 160)}
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
                {/* <div className="swiper-button-next"></div>
            <div className="swiper-button-prev"></div> */}
            </div>


        </>


    )
}


export default observer(Videos)


