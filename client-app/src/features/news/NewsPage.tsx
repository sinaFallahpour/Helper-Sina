import React, { Fragment, useEffect } from "react";
import Newses from './Newses';
import Videos from './Videos';
import Articles from './Article'

// import CountUp from "react-countup";
// import { Swiper, SwiperSlide } from 'swiper/react';

const NewsPage: React.FC = () => {
  useEffect(() => { }, []);

  return (
    <Fragment>
      <div className="container mx-auto p-0 m-0 mt-5">
        <div className="row w-100 p-0 m-0 mx-auto">
          <div className="col-md-10 col-8 text-right">
            <h3>
              <b>اخبار هلپر</b>
            </h3>
          </div>
          <div className="col-md-2 col-4 text-news">
            <span> جدید ترین ها</span>
          </div>
        </div>
        <div className="row w-100 mx-auto">
          <img
            src={window.location.origin + "/hj/img/borderbig green.png"}
            // src="~/hj/img/borderbig green.png"
            className="img-fluid mx-auto"
          />
        </div>

        {/* @*---SLIDER---*@ */}
        <Newses />
        {/* @*--END SLIDER---*@ */}



      </div>
      {/* @*-------*@ */}
      <div className="container mx-auto p-0 m-0 mt-5">
        <div className="row w-100 p-0 m-0 mx-auto">
          <div className="col-md-10 col-8 text-right">
            <h3>
              <b> ویدئو های آموزشی</b>
            </h3>
          </div>
          <div className="col-md-2 col-4 text-news">
            <span> جدید ترین ها</span>
          </div>
        </div>
        <div className="row w-100 mx-auto">
          <img
            src={window.location.origin + "/hj/img/borderbig green.png"}
            // src="/hj/img/borderbig green.png"
            className="img-fluid mx-auto"
          />
        </div>

        {/* @*---SLIDER for Videos---*@ */}
        <Videos />
        {/* @*--END SLIDER  for videos---*@ */}

      </div>
      {/* @*---billbord---*@ */}
      <div className="container mt-3 mx-auto">
        <div className="row w-100 mx-auto">
          <div className="col-md-6 py-2 news-billbord">
            <img
              src={window.location.origin + "/hj/img/imgNews.svg"}
              //   src="~/hj/img/imgNews.svg"
              className="img-fluid"
            />
          </div>
          <div className="col-md-6 py-2 news-billbord">
            <img
              src={window.location.origin + "/hj/img/imgNews.svg"}
              //   src="~/hj/img/imgNews.svg"
              className="img-fluid"
            />
          </div>
        </div>
      </div>

      {/* @*----articles----*@ */}
      <div className="container mx-auto p-0 m-0 mt-5">
        <div className="row w-100 p-0 m-0 mx-auto">
          <div className="col-md-10 col-8 text-right">
            <h3>
              <b>  مفالات آموزشی </b>
            </h3>
          </div>
          <div className="col-md-2 col-4 text-news">
            <span> جدید ترین ها</span>
          </div>
        </div>
        <div className="row w-100 mx-auto">
          <img
            src={window.location.origin + "/hj/img/borderbig green.png"}
            // src="/hj/img/borderbig green.png"
            className="img-fluid mx-auto"
          />
        </div>

        {/* @*---SLIDER for Articles---*@ */}
        <Articles />
        {/* @*--END SLIDER  for Articles---*@ */}

      </div>

      {/* @*--modal---*@ */}

      {/* <!-- Central Modal Small --> */}
      <div
        className="modal fade"
        id="centralPlay"
        tabIndex={-1}
        // tabindex="-1"
        role="dialog"
        aria-labelledby="myModalLabel"
        aria-hidden="true"
      >
        {/* <!-- Change className .modal-sm to change the size of the modal --> */}
        <div className="modal-dialog modal-large" role="document">
          <div className="modal-content modal-video">
            <div className="modal-header">
              <button
                type="button"
                className="close"
                data-dismiss="modal"
                aria-label="Close"
              >
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div className="modal-body ">
              <div className="embed-responsive embed-responsive-16by9">
                
                <iframe
                  className="embed-responsive-item"
                  src="https://localhost:44340/Upload/Slider/b5404152-fa74-4e28-8b06-3a7f3c5400b7_5.mp4"
                  allowFullScreen
                ></iframe>
              </div>
            </div>
          </div>
        </div>
      </div>
      {/* <!-- Central Modal Small --> */}
    </Fragment>
  );
};

export default NewsPage;
