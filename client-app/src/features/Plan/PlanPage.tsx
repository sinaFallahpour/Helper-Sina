import React, { useState, FormEvent, useContext, useEffect } from 'react'
import { observer } from 'mobx-react-lite';
import { RouteComponentProps } from 'react-router-dom';
import { RootStoreContext } from '../../app/stores/rootStore';
import LoadingTransparent from '../../app/common/Loading/LoadingTransparent';
import { toShortString, getPriceFormat } from '../../app/common/util/util';


const PlanPage: React.FC = () => {

    const rootStore = useContext(RootStoreContext);
    const { plansesList, loadPlanses, loadingPlanses } = rootStore.planStore;


    const [startrLoading, setStartrLoading] = useState(true)



    setTimeout(() => {
        setStartrLoading(false)
    }, 2000);


    useEffect(() => {

        loadPlanses();
    }, [loadPlanses]);


   
    



    if (startrLoading || loadingPlanses) return <LoadingTransparent />

    return (
        <>
            <div className="container">
                <div className="row mt-md-5 pt-md-5">
                    <div className="col-md-5 col-12 ml-lg-5 order-md-0 order-1 hj-intro-h">
                        <div className="row mx-auto">
                            <span className="text-justify size-33">
                                <b>
                                    ایجاد خدمت
                                </b>
                            </span>
                        </div>
                        <div className="row w-100 mx-auto pt-3 pt-md-2">
                            <img src={window.location.origin + "/hj/img/border-bottom.png"} className="img-fluid" alt="Responsive images" />


                        </div>
                        <div className="row mt-3 mx-auto">
                            <span className="text-justify hj-intro-text">لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</span>
                        </div>

                    </div>
                    <div className="col-md-6 col-12 mr-lg-4 order-md-1 order-0">
                        <img src={window.location.origin + "/hj/img/Group 2678.svg"} className="img-fluid" alt="Responsive images" />

                    </div>

                </div>
                {/* ...................end intro.....................*/}
            </div>
            {/* -----card----- */}
            <div className="container p-0 mt-3">
                <div className="row w-100 mx-auto">


                    {plansesList?.map((plan, index) => {


                        return (
                            <div className="col-lg-3 col-md-6 col-12 py-3 " >

                                <div

                                    className={plan.isSelected ? 'card card3' : 'card card1'}
                                    style={{ height: '500px' }}>
                                    <div className="row mx-auto w-100 pr-3 pt-2  pt-3">

                                        <h4 className={plan.isSelected ? 'text-card3 text-right' : ' text-right'} >
                                            {plan.name}
                                        </h4>

                                    </div>
                                    <div className="row w-100 mx-auto pt-3 pt-md-2 text-right">
                                        <img src={window.location.origin + "/hj/img/border-bottom.png"} className="img-fluid w-75 pr-3" alt="Responsive images" />
                                    </div>
                                    <div className="card-body">

                                        <p className={plan.isSelected ? 'text-card3 card-text text-justify' : 'card-text text-justify'} style={{ height: '210px' }}>{toShortString(plan.description, 220)} </p>
                                        <h4 className={plan.isSelected ? 'text-card3 card-title text-center hj-text-service py-3' : 'text-dark card-title text-center hj-text-service py-3 '}>{getPriceFormat(plan.planMonyUnitDTO[0].price.toString())}
                                            <br />
                                            <div className="row w-75 mx-auto text-center">
                                                <span className="size-15 mx-auto">
                                                    <select
                                                     
                                                        className="form-control text-left currency  "
                                                    >
                                                        {plan.planMonyUnitDTO.map((el, index) => {
                                                            return (
                                                                <option
                                                                    value={el.price}
                                                                    key={index} >{el!.monyName}
                                                                </option>
                                                            )

                                                        })}

                                                    </select>
                                                </span>
                                            </div>

                                        </h4>
                                        <button
                                            className={plan.isSelected ? 'btn-card3 btn btn-helper w-75 mx-auto d-block py-2' : 'btn btn-helper w-75 mx-auto d-block py-2'}

                                        >  {plan.isSelected ? 'انتخاب شده' : 'انتخاب'}</button>
                                    </div>
                                </div>
                            </div>
                        )
                    })}





                    <div className="col-lg-3 col-md-6 col-12 py-3">
                        <div className="card card1">
                            <div className="row mx-auto w-100 pr-3 pt-2  pt-3">

                                <h4 className="text-right">

                                    ایجاد خدمت

                                </h4>

                            </div>
                            <div className="row w-100 mx-auto pt-3 pt-md-2 text-right">
                                <img src={window.location.origin + "/hj/img/border-bottom.png"} className="img-fluid w-75 pr-3" alt="Responsive images" />
                            </div>
                            <div className="card-body">

                                <p className="card-text text-justify">لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه </p>
                                <h4 className="card-title text-center hj-text-service py-3">150.000<br /><span className="size-15">ریال</span> </h4>
                                <a href="#" className="btn btn-helper w-75 mx-auto d-block py-2"> نوع دیفالت</a>
                            </div>
                        </div>
                    </div>
                    <div className="col-lg-3 col-md-6 col-12 py-3">
                        <div className="card card4">
                            <div className="row mx-auto w-100 pr-3 pt-2  pt-3">

                                <h4 className="text-right">

                                    ایجاد خدمت

                                </h4>

                            </div>
                            <div className="row w-100 mx-auto pt-3 pt-md-2 text-right">
                                <img src={window.location.origin + "/hj/img/border-bottom.png"} className="img-fluid w-75 pr-3" alt="Responsive images" />

                            </div>
                            <div className="card-body">

                                <p className="card-text text-justify">لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه </p>
                                <h4 className="card-title text-center hj-text-service py-3 text-dark">150.000<br /><span className="size-15">ریال</span> </h4>
                                <a href="#" className="btn btn-helper w-75 mx-auto d-block py-2 bg-dark"> نوع دیفالت</a>
                            </div>
                        </div>
                    </div>
                    <div className="col-lg-3 col-md-6 col-12 py-3">
                        <div className="card card3">
                            <div className="row mx-auto w-100 pr-3 pt-2  pt-3">

                                <h4 className="text-right text-card3">

                                    ایجاد خدمت

                               </h4>

                            </div>
                            <div className="row w-100 mx-auto pt-3 pt-md-2 text-right">
                                <img src={window.location.origin + "/hj/img/border-bottom.png"} className="img-fluid w-75 pr-3" alt="Responsive images" />
                            </div>
                            <div className="card-body">

                                <p className="card-text text-justify text-card3">لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه </p>
                                <h4 className="card-title text-center hj-text-service py-3 text-card3">150.000<br /><span className="size-15">ریال</span> </h4>
                                <a href="#" className="btn btn-helper btn-card3 w-75 mx-auto d-block py-2"> نوع دیفالت</a>
                            </div>
                        </div>
                    </div>
                    <div className="col-lg-3 col-md-6 col-12 py-3">
                        <div className="card card4">
                            <div className="row mx-auto w-100 pr-3 pt-2  pt-3">

                                <h4 className="text-right">

                                    ایجاد خدمت

                                </h4>

                            </div>
                            <div className="row w-100 mx-auto pt-3 pt-md-2 text-right">
                                <img src={window.location.origin + "/hj/img/border-bottom.png"} className="img-fluid w-75 pr-3" alt="Responsive images" />
                            </div>
                            <div className="card-body">

                                <p className="card-text text-justify">لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه </p>
                                <h4 className="card-title text-center hj-text-service py-3 text-dark">150.000<br /><span className="size-15">ریال</span> </h4>
                                <a href="#" className="btn btn-helper w-75 mx-auto d-block py-2 bg-dark"> نوع دیفالت</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </>
    )
}



export default observer(PlanPage) 