import React from 'react'

export const Mydifferences = () => {
    return (
        <>
                 <div className="row w-100 mx-auto text-center mt-5">
                                            <div className="col-12 text-md-right text-center">
                                                <h3>اختلافات من</h3>
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
        </>
    )
}


export default Mydifferences