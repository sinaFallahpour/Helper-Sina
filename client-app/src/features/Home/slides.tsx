import React, { useEffect, useContext } from 'react'
import { RootStoreContext } from '../../app/stores/rootStore';
import { Swiper, SwiperSlide } from 'swiper/react';
import SwiperCore, { Navigation, Pagination, Scrollbar, A11y, Autoplay } from 'swiper';

import { siteUrl } from '../../config.json'
import { observer } from 'mobx-react-lite';

import MiniLoading from '../../app/common/Loading/MiniLoading'

import './../../style/sina.css'
import { toShortString } from '../../app/common/util/util';

SwiperCore.use([Navigation, Pagination, Scrollbar, A11y, Autoplay]);

const Slides = () => {
    const rootStore = useContext(RootStoreContext);
    const { slidesList, loadSlides, loadingSlides } = rootStore.slideStore;



    useEffect(() => {
        loadSlides();
    }, [loadSlides]);

    if (loadingSlides)
        return <>
            <MiniLoading />
        </>

    return (
        <div>

            <Swiper
                className="swiper-container swiper-container1 "
                effect="coverflow"
                grabCursor={true}
                centeredSlides={false}
                navigation={Navigation}
                slidesPerView={3}
                pagination={{
                    clickable: true,
                    el: '.swiper-pagination',
                }}

                coverflowEffect={{
                    rotate: 50,
                    stretch: 0,
                    depth: 100,
                    modifier: 1,
                    slideShadows: true,
                }}
                autoplay={{
                    delay: 5000,
                    disableOnInteraction: false,
                    stopOnLastSlide: false,
                }}
                spaceBetween={30}
            >

                <div className="swiper-wrapper ">
                    {slidesList?.map((slide, index) => {
                        return (<SwiperSlide key={index}
                            className="swiper-slide _swiper-slider"
                        >
                            <img
                                src={siteUrl + slide.photoAddress}
                                className="img-fluid _swiper-image" alt="Responsive image11 " />
                            <div className="row w-100 text-justify Text-blue mx-auto">
                                <div className="col-8 text-center py-2 mx-auto  hj-TilteSliderIndex "><span><b>{slide.title}</b></span></div>
                                <div className="col-12 text-cener mx-auto py-2 _swiper-text"><span>{toShortString( slide.description,300)} </span></div>
                            </div>
                        </SwiperSlide>
                        )
                    })}
                </div>

                <div className="swiper-pagination"></div>
            </Swiper>



        </div>
    )
}


export default observer(Slides)