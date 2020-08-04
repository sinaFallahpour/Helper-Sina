import React, { useEffect, useContext } from 'react'
import { RootStoreContext } from '../../app/stores/rootStore';
import { Swiper, SwiperSlide } from 'swiper/react';
import SwiperCore, { Navigation, Pagination, Scrollbar, A11y } from 'swiper';

import { siteUrl } from '../../config.json'
import { observer } from 'mobx-react-lite';

import MiniLoading from '../../app/common/Loading/MiniLoading'

const Slides = () => {
    const rootStore = useContext(RootStoreContext);
    const { slidesList, loadSlides, loadingSlides } = rootStore.slideStore;


    SwiperCore.use([Navigation, Pagination, Scrollbar, A11y]);

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
                className="swiper-container swiper-container1"
                effect="coverflow"
                grabCursor={true}
                centeredSlides={false}
                slidesPerView={3}
                pagination={{ clickable: true,
                	el: '.swiper-pagination',
                }}

                coverflowEffect={{
                    rotate: 50,
                    stretch: 0,
                    depth: 100,
                    modifier: 1,
                    slideShadows: true,
                }}
                spaceBetween={10}
            >

                <div className="swiper-wrapper">
                    {slidesList?.map((slide, index) => {
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

                <div className="swiper-pagination"></div>
            </Swiper>



        </div>
    )
}


export default observer(Slides)