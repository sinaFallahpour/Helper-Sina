import React from 'react'

import { observer } from 'mobx-react-lite';






import EditProfile from './EditProfile'
import MyNotification from './MyNotification'
import MyChat from './MyChat'
import MyGiverService from './MyGiverService'
import MyGetterService from './MyGetterService'
import MyAmar from './MyAmar'
import MyGetService2 from './MyGetService2'
import MyProfileSeen from './MyProfileSeen'
import Mydifferences from './Mydifferences'
import { RouteComponentProps } from 'react-router-dom'

interface RouteParams {
    id: string;
}

interface IProps extends RouteComponentProps<RouteParams> { }
const MyProfilePage: React.FC<IProps> = (props) => {


    
    return (
        <>
         <div className="container-fluid w-75 mx-auto mt-5 p-0 m-0">
                <div className="row w-100 mx-auto text-center">
                    <div className="col-12">
                        <img src={window.location.origin + "/hj/img/img profile.png"} className="img-fluid mx-auto text-center" />
                    </div>
                    <div className="col-12 pt-4">
                        <h3>نیما کفش آرا</h3>
                        <span>مشاور املاک</span>
                    </div>
                </div>
                {/* <!-- Tabs --> */}
                <section id="tabs">
                    <div className="container p-0 m-0 mx-auto">

                        <div className="row w-100 mx-auto">
                            <div className="col-xs-12 p-0 m-0 ">

                                <nav>
                                    <div className="nav nav-tabs nav-fill p-0 m-0 w-100" id="nav-tab" role="tablist">
                                        <a className="nav-item nav-link active w-50" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">ویرایش پروفایل</a>
                                        <a className="nav-item nav-link w-50" id="nav-profile-tab" data-toggle="tab" href="#nav-profile" role="tab" aria-controls="nav-profile" aria-selected="false">دشبورد</a>
                                    </div>
                                </nav>
                                <div className="tab-content py-3 px-sm-0 mt-5" id="nav-tabContent">

                                    {/*   EditProfile */}
                                    <EditProfile {...props} />


                                    
                                    {/* ------dashbord----- */}


                                    <div className="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">

                                        {/* ------- MyGiverService   ------- */}
                                        <MyGiverService />
                                        {/* -------End MyGiverService   ------- */}

                                        <br />
                                        <br />

                                        {/* ------- MyGetterService   ------- */}
                                        <MyGetterService />
                                        {/* -------End MyGetterService   ------- */}

                                        <br />
                                        <br />



                                        {/* ------- MyAmar   ------- */}
                                        <MyAmar />
                                        {/* -------End MyAmar   ------- */}


                                        {/* ------- MyGEtSerice2   ------- */}
                                        <MyGetService2 />
                                        {/* -------End MyGEtSerice2   ------- */}


                                        {/* --------- MyProfileSeen---------- */}
                                        <MyProfileSeen />
                                        {/* ---------end  MyProfileSeen---------- */}


                                        <div className="row w-100 mx-auto text-center mt-5">
                                            <div className="col-12 text-md-right text-center">
                                                <h3>فعالیت های خدماتی من</h3>
                                            </div>
                                            <div className="col-12 p-0">
                                                <img src={window.location.origin + "/hj/img/borderbig green.png"} className="img-fluid" />
                                            </div>
                                        </div>
                                        <div className="row w-100 mx-auto mt-5 mb-3">


                                            {/* -- Actual search box -- */}
                                            <div className="form-group has-search w-100">
                                                <i className="fas fa-search form-control-feedback pl-3"></i>
                                                <input type="text" className="form-control searchbox text-center" placeholder="جستجو" />
                                            </div>



                                        </div>
                                        <div className="table-responsive text-nowrap">
                                            <table className="table text-center p-0 m-0  ">
                                                <thead>
                                                    <tr className="titr-table">
                                                        <th scope="col" className="text-center">نام پروژه</th>
                                                        <th scope="col" className="text-center">مبلغ</th>
                                                        <th scope="col" className="text-center">واحد</th>
                                                        <th scope="col" className="text-center">نام کارفرما</th>
                                                        <th scope="col" className="text-center">نام خدمات دهنده</th>
                                                        <th scope="col" className="text-center"></th>
                                                    </tr>
                                                </thead>
                                                <tbody className="table-content">
                                                    <tr>
                                                        <td scope="row">نام پروژه</td>
                                                        <td>250.000</td>
                                                        <td>ریال </td>
                                                        <td>نام کارفرما</td>
                                                        <td>نام خدمات دهنده</td>
                                                        <td><a href="#" className="color-helper">مشاهده</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td scope="row">نام پروژه</td>
                                                        <td>250.000</td>
                                                        <td>ریال </td>
                                                        <td>نام کارفرما</td>
                                                        <td>نام خدمات دهنده</td>
                                                        <td><a href="#" className="color-helper">مشاهده</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td scope="row">نام پروژه</td>
                                                        <td>250.000</td>
                                                        <td>ریال </td>
                                                        <td>نام کارفرما</td>
                                                        <td>نام خدمات دهنده</td>
                                                        <td><a href="#" className="color-helper">مشاهده</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td scope="row">نام پروژه</td>
                                                        <td>250.000</td>
                                                        <td>ریال </td>
                                                        <td>نام کارفرما</td>
                                                        <td>نام خدمات دهنده</td>
                                                        <td><a href="#" className="color-helper">مشاهده</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td scope="row">نام پروژه</td>
                                                        <td>250.000</td>
                                                        <td>ریال </td>
                                                        <td>نام کارفرما</td>
                                                        <td>نام خدمات دهنده</td>
                                                        <td><a href="#" className="color-helper">مشاهده</a></td>
                                                    </tr>
                                                </tbody>
                                            </table>

                                        </div>
                                        <div className="row w-100 mx-auto mt-5">
                                            <nav aria-label="Page navigation example " className="mx-auto">
                                                <ul className="pagination">
                                                    <li className="page-item mx-1"><a className="page-link color-helper bg-helper" href="#">قبلی</a></li>
                                                    <li className="page-item mx-1"><a className="page-link color-helper" href="#">1</a></li>
                                                    <li className="page-item mx-1"><a className="page-link color-helper" href="#">2</a></li>
                                                    <li className="page-item mx-1"><a className="page-link color-helper" href="#">3</a></li>
                                                    <li className="page-item mx-1"><a className="page-link color-helper bg-helper" href="#">بعدی</a></li>
                                                </ul>
                                            </nav>
                                        </div>
                                        {/* -------- */}
                                        <div className="row w-100 mx-auto text-center mt-5">
                                            <div className="col-12 text-md-right text-center">
                                                <h3>فعالیت های درخواستی  من</h3>
                                            </div>
                                            <div className="col-12 p-0">
                                                <img src={window.location.origin + "/hj/img/borderbig green.png"} className="img-fluid" />
                                            </div>
                                        </div>
                                        <div className="row w-100 mx-auto mt-5 mb-3">


                                            {/* -- Actual search box -- */}
                                            <div className="form-group has-search w-100">
                                                <i className="fas fa-search form-control-feedback pl-3"></i>
                                                <input type="text" className="form-control searchbox text-center" placeholder="جستجو" />
                                            </div>



                                        </div>
                                        <div className="table-responsive text-nowrap">
                                            <table className="table text-center p-0 m-0  ">
                                                <thead>
                                                    <tr className="titr-table">
                                                        <th scope="col" className="text-center">نام پروژه</th>
                                                        <th scope="col" className="text-center">مبلغ</th>
                                                        <th scope="col" className="text-center">واحد</th>
                                                        <th scope="col" className="text-center">نام کارفرما</th>
                                                        <th scope="col" className="text-center">نام خدمات دهنده</th>
                                                        <th scope="col" className="text-center"></th>
                                                    </tr>
                                                </thead>
                                                <tbody className="table-content">
                                                    <tr>
                                                        <td scope="row">نام پروژه</td>
                                                        <td>250.000</td>
                                                        <td>ریال </td>
                                                        <td>نام کارفرما</td>
                                                        <td>نام خدمات دهنده</td>
                                                        <td><a href="#" className="color-helper">مشاهده</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td scope="row">نام پروژه</td>
                                                        <td>250.000</td>
                                                        <td>ریال </td>
                                                        <td>نام کارفرما</td>
                                                        <td>نام خدمات دهنده</td>
                                                        <td><a href="#" className="color-helper">مشاهده</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td scope="row">نام پروژه</td>
                                                        <td>250.000</td>
                                                        <td>ریال </td>
                                                        <td>نام کارفرما</td>
                                                        <td>نام خدمات دهنده</td>
                                                        <td><a href="#" className="color-helper">مشاهده</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td scope="row">نام پروژه</td>
                                                        <td>250.000</td>
                                                        <td>ریال </td>
                                                        <td>نام کارفرما</td>
                                                        <td>نام خدمات دهنده</td>
                                                        <td><a href="#" className="color-helper">مشاهده</a></td>
                                                    </tr>
                                                    <tr>
                                                        <td scope="row">نام پروژه</td>
                                                        <td>250.000</td>
                                                        <td>ریال </td>
                                                        <td>نام کارفرما</td>
                                                        <td>نام خدمات دهنده</td>
                                                        <td><a href="#" className="color-helper">مشاهده</a></td>
                                                    </tr>
                                                </tbody>
                                            </table>

                                        </div>
                                        <div className="row w-100 mx-auto mt-5">
                                            <nav aria-label="Page navigation example " className="mx-auto">
                                                <ul className="pagination">
                                                    <li className="page-item mx-1"><a className="page-link color-helper bg-helper" href="#">قبلی</a></li>
                                                    <li className="page-item mx-1"><a className="page-link color-helper" href="#">1</a></li>
                                                    <li className="page-item mx-1"><a className="page-link color-helper" href="#">2</a></li>
                                                    <li className="page-item mx-1"><a className="page-link color-helper" href="#">3</a></li>
                                                    <li className="page-item mx-1"><a className="page-link color-helper bg-helper" href="#">بعدی</a></li>
                                                </ul>
                                            </nav>
                                        </div>
                                        <div className="row w-100 mx-auto text-center mt-5 mb-4 hj-hiden">
                                            <div className="col-12 text-md-right text-center">
                                                <h3> پیامهای من   </h3>
                                            </div>
                                            <div className="col-12 p-0">
                                                <img src={window.location.origin + "/hj/img/borderbig green.png"} className="img-fluid" />
                                            </div>
                                        </div>


                                        {/* --chat-- */}
                                        <MyChat />
                                        {/* ---end chat-- */}



                                        {/* ----MyNotification---- */}
                                        <MyNotification />
                                        {/* ----end MyNotification---- */}


                                        {/* ---Mydifferences-- */}
                                        <Mydifferences />
                                        {/* -----end Mydifferences -- */}


                                    </div>

                                </div>

                            </div>
                        </div>
                    </div>
                </section>
                {/* -- ./Tabs -- */}
            </div>

        </>
    )
}



export default observer(MyProfilePage)