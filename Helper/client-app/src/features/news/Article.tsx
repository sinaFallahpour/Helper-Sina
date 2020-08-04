import React, { useEffect, useContext } from 'react'
import { Swiper, SwiperSlide } from 'swiper/react';
import { observer } from 'mobx-react-lite';

import MiniLoading from '../../app/common/Loading/MiniLoading'

import { toShortString } from '../../app/common/util/util'
import { siteUrl } from '../../config.json'

import { RootStoreContext } from '../../app/stores/rootStore';

const Articles = () => {
    const rootStore = useContext(RootStoreContext);
    const { loadArticles, loadingArticle, articlesList } = rootStore.newsStore;

    useEffect(() => {
        loadArticles();
    }, [loadArticles]);

    if (loadingArticle)
        return <>
            <MiniLoading />
        </>

    return (
        <>
            <div className="swiper-container swiper-container3 swiper-container-initialized swiper-container-horizontal swiper-container-rtl">
                <div
                    className="swiper-wrapper"
                    style={{
                        transform: 'translate3d(1170px, 0px, 0px)',
                        transitionDuration: '0ms'
                    }}
                >
                    {articlesList?.map((article, index) => {
                        return (
                            <div
                                key={article.id}
                                className="swiper-slide"
                            >
                                <div className=" col-12 mx-auto  my-3 p-0">
                                    <div className="card w-100 hj-card-news">
                                        <img
                                            className="card-img-top"
                                            src={siteUrl + article.articlePhotoAddress}
                                            // src={window.location.origin + "/hj/img/articles.png"}
                                            // src="/hj/img/articles.png"
                                            alt="new"
                                        />

                                        <div className="card-body">
                                            <div className="row w-100 p-0 m-0 hj-option-card text-center">
                                                <div className="col-4 p-0 m-0">
                                                    <i
                                                        // onclick="myFunction(this)"
                                                        className="far fa-heart pl-2"
                                                    ></i>
                                                    <span className="hj-like">{article.likesCount}</span>
                                                </div>
                                                <div className="col-4 p-0 m-0">
                                                    <i className="fa fa-comments  pl-2"></i>
                                                    <span className="hj-like">{article.commentsCount}</span>
                                                </div>
                                                <div className="col-4 p-0 m-0">
                                                    <i className="fa fa-eye  pl-2"></i>
                                                    <span className="hj-like">{article.seenCount}</span>
                                                </div>
                                            </div>
                                            <h5 className="card-title text-right pt-4"> {article.title}</h5>
                                            <p className="card-text text-justify size-14">
                                                {toShortString(article.description, 160)}
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        )
                    })}


                </div>
            {/* <!-- Add Pagination --> */}
            <div className="swiper-pagination swiper-pagination-clickable swiper-pagination-bullets">
                <span
                    className="swiper-pagination-bullet"
                    tabIndex={0}
                    role="button"
                    aria-label="Go to slide 1"
                ></span>
                <span
                    className="swiper-pagination-bullet"
                    tabIndex={1}
                    role="button"
                    aria-label="Go to slide 2"
                ></span>
                <span
                    className="swiper-pagination-bullet"
                    tabIndex={2}
                    // tabindex="0"
                    role="button"
                    aria-label="Go to slide 3"
                ></span>
                <span
                    className="swiper-pagination-bullet swiper-pagination-bullet-active"
                    tabIndex={3}
                    // tabindex="0"
                    role="button"
                    aria-label="Go to slide 4"
                ></span>
            </div>
            {/* <!-- Add Arrows --> */}
            <span
                className="swiper-notification"
                aria-live="assertive"
                aria-atomic="true"
            ></span>
        </div>

        </>



    )
}


export default observer(Articles)































