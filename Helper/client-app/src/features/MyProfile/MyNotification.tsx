import React from 'react'


const MyNotification: React.FC = () => {
    return (
        <>
            <div className="row w-100 mx-auto text-center mt-5 mb-4">
                <div className="col-12 text-md-right text-center">
                    <h3>اطلاعیه های من</h3>
                </div>
                <div className="col-12 p-0">
                    <img src={window.location.origin + "/hj/img/borderbig green.png"} className="img-fluid" />
                </div>
            </div>
            <div className="row w-75 mx-auto hj-serachW-100 ">
                <div className="form-group has-search w-100 position-relative">
                    <i className="fas fa-search form-control-feedback pl-3"></i>
                    <input type="text" className="form-control searchbox text-center" placeholder="جستجو" />
                </div>

            </div>
            <div className="row w-100 mx-auto mt-2">
                <div className="col-md-2 col-12 text-center">
                    <img src={window.location.origin + "/hj/img/h.png"} className="img-fluid" />
                </div>
                <div className="col-md-10 col-12">
                    <div className="row w-100 py-3">
                        <div className="col-10 text-right">نیما کفش آرا</div>
                        <div className="col-2 text-helper">27/2/1396</div>
                    </div>
                    <div className="row w-100">
                        <h6 className="text-helper text-md-right text-center pr-md-3">نام پروژه</h6>
                    </div>
                    <div className="col-12 p-0">
                        <h6 className="text-justify">مختصری از آخرین پیام  لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</h6>
                    </div>
                </div>
            </div>

            <hr />
            <div className="row w-100 mx-auto mt-2">
                <div className="col-md-2 col-12 text-center">
                    <img src={window.location.origin + "/hj/img/h.png"} className="img-fluid" />
                </div>
                <div className="col-md-10 col-12">
                    <div className="row w-100 py-3">
                        <div className="col-10 text-right">نیما کفش آرا</div>
                        <div className="col-2 text-helper">27/2/1396</div>
                    </div>
                    <div className="row w-100">
                        <h6 className="text-helper text-md-right text-center pr-md-3">نام پروژه</h6>
                    </div>
                    <div className="col-12 p-0">
                        <h6 className="text-justify">مختصری از آخرین پیام  لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف</h6>
                    </div>
                </div>
            </div>

            <hr />
        </>
    )
}



export default MyNotification