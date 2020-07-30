import React from 'react'

const Header: React.FC = () => {
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
                            <img src="~/hj/img/logo.png" className="img-fluid" alt="Responsive image" />
                        </div>
                        <div className="col-md-4  col-5 d-flex justify-content-center align-items-center">
                            <button type="button" className="btn btn-link hj-index-login">ورود / ثبت نام</button>
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
                                        <a asp-action="Index" asp-controller="Home" className="nav-link ">صفحه اصلی </a>
                                    </li>
                                </div>
                                <div className="col-md-2">
                                    <li className='@Html.IsSelected("News", "Index","") nav-item'>
                                        <a asp-action="Index" asp-controller="News" className="nav-link">اخبار</a>
                                    </li>
                                </div>
                                <div className="col-md-2">
                                    <li className='@Html.IsSelected("Contactus", "Index","") nav-item'>
                                        <a asp-action="ContactUs" asp-controller="Home" className="nav-link">تماس با ما</a>
                                    </li>
                                </div>
                                <div className="col-md-2">
                                    <li className='@Html.IsSelected("Aboutus", "Index","") nav-item'>
                                        <a asp-action="AboutUs" asp-controller="Home" className="nav-link">درباره ما</a>
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
