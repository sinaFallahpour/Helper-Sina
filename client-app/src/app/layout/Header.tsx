import React, { useContext } from 'react'
import { NavLink } from 'react-router-dom'
import { RootStoreContext } from '../stores/rootStore';
const Header: React.FC = () => {

    const rootStore = useContext(RootStoreContext);
    const { isLoggedIn } = rootStore.userStore;
    const { user } = rootStore.userStore;
    return (
        // @*...........header............*@
        <div className="container p-0 mx-auto">
            {/* @*........navbar.......*@ */}
            <div className="row hj-header mt-5 m-0">
                <div className="col-12 p-md-0 m-md-0">
                    <div className="row">

                        <div className="col-md-4 col-5 d-flex justify-content-center align-items-center">
                            <form action="/action_page.php" className="hj-language text-right">

                                <select name="language" id="language">
                                    <option value="volvo">Ln فارسی</option>
                                    <option value="saab">Ln EN</option>

                                </select>
                            </form>
                        </div>

                        <div className="col-md-4 col-2 text-center p-2">
                            <img
                                src={window.location.origin + "/hj/img/logo.png"}
                                className="img-fluid" alt="Responsive image1" />
                        </div>
                        <div className="col-md-4  col-5 d-flex justify-content-center align-items-center">
                            {
                                isLoggedIn ?
                                    <>
                                        <NavLink to="/LogOut" className="btn btn-link hj-index-login">خروج </NavLink>/
                                        <NavLink to={`/profile/${user?.id}`} className="btn btn-link hj-index-login">پروفایل </NavLink>
                                    </>
                                    :
                                    <NavLink to="/login" className="btn btn-link hj-index-login">ورود / ثبت نام</NavLink>
                            }
                        </div>
                    </div>
                    {/* @*......navbarbootsrap.....*@ */}
                    <nav className="navbar navbar-expand-lg navbar-light bg-light hj-navbarbootstrap p-md-0 m-md-0 ">

                        <button className="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                            <span className="navbar-toggler-icon"></span>
                        </button>
                        <div className="collapse navbar-collapse" id="navbarNav">
                            <ul className="navbar-nav w-100 text-md-center text-right mt-3">
                                <div className="col-md-3">
                                    <li className='@Html.IsSelected("Home", "Index","") nav-item'>
                                        {/* <a className="nav-link ">صفحه اصلی </a> */}
                                        <NavLink className="nav-link " to='/' > صفحه اصلی </NavLink>
                                    </li>
                                </div>
                                <div className="col-md-2">
                                    <li className='@Html.IsSelected("News", "Index","") nav-item'>
                                        {/* <a  className="nav-link">اخبار</a> */}
                                        <NavLink className="nav-link " to='/newses'  >  اخبار </NavLink>
                                    </li>
                                </div>
                                <div className="col-md-2">
                                    <li className='@Html.IsSelected("Contactus", "Index","") nav-item'>
                                        {/* <a className="nav-link">تماس با ما</a> */}
                                        <NavLink className="nav-link " to='/contactUs'  >  تماس با ما </NavLink>
                                    </li>
                                </div>
                                <div className="col-md-2">
                                    <li className='@Html.IsSelected("Aboutus", "Index","") nav-item'>
                                        {/* <a className="nav-link">درباره ما</a> */}
                                        <NavLink className="nav-link " to='/aboutUs'>   درباره ما  </NavLink>
                                    </li>
                                </div>
                                <div className="col-md-3">
                                    <li className="nav-item">
                                        <a className="nav-link" href="#">کارشناسان</a>
                                    </li>
                                </div>

                            </ul>
                        </div>
                    </nav>

                    {/* @*.....End navbarboottrap.....*@ */}

                </div>
            </div>
        </div>
        /* @*........end navbar.......*@ */


    )
}


export default Header;
