import React, { useRef, createRef, useState } from 'react'
import { NavLink } from 'react-router-dom'


// jQuery(document).ready(function ($) {
//     tab = $('.tabs h3 a');

//     tab.on('click', function (event) {
//         event.preventDefault();
//         tab.removeClass('active');
//         $(this).addClass('active');

//         tab_content = $(this).attr('href');
//         $('div[id$="tab-content"]').removeClass('active');
//         $(tab_content).addClass('active');
//     });
// });


const Login = () => {


    const [showLogin, setShowLogin] = useState(false)

    const handleTabChange = (showRegister: boolean) => {
        if (showLogin != showRegister)
            setShowLogin(showRegister)
          

    }


    return (
        <>
            <div className="container w-100 mx-auto">
                <div className="row w-100 mx-auto">
                    <div className="form-wrap">
                        <div className="tabs">
                            <h3 className="signup-tab">
                                <a
                                    className={!showLogin ? 'active' : ''}
                                    onClick={() => handleTabChange(false)}
                                >
                                    ثبت نام
                                    </a>
                            </h3>
                            <h3 className="login-tab">
                                <a
                                    className={showLogin ? 'active' : ''}
                                    onClick={() => setShowLogin(true)}
                                >
                                    ورود
                                </a>

                            </h3>
                        </div>
                        {/* <!--.tabs--> */}

                        <div className="tabs-content mt-4">






                            {!showLogin ?


                                <div id="signup-tab-content" className="active text-center">
                                    <form className="signup-form" action="" method="post">
                                        <input autoComplete="off" type="text" className="input text-center  py-3 my-2" id="user_name" placeholder="نام کاربری" />
                                        <input type="email" className="input text-center  py-3 my-2" id="user_email" autoComplete="off" placeholder="ایمیل" />

                                        <input type="password" className="input text-center  py-3 my-2" id="user_pass" autoComplete="off" placeholder="رمز عبور" />
                                        <input type="checkbox" className="checkbox" id="rules" />


                                        <label className="pr-4 my-3 mr-2 rules"><a href="#">قوانین</a> را میپذیرم   </label>
                                        <input type="submit" className="button" value="ثبت نام " />
                                    </form>

                                    <div className="help-text">

                                        <p><NavLink to="/r">  قبلا ثبت نام کرده ام !</NavLink></p>
                                    </div>
                                    <hr />
                                    <div className="row w-100 mx-auto text-center">
                                        <p className="w-100 text-center">می توانید از سرویس گوگل برای ثبت نام استفاده کنید </p>
                                    </div>
                                    <div className="row w-100 mx-auto text-center">
                                        <a href="#" className="mx-auto">
                                            <img src= {window.location.origin +"/hj/img/google-icon.png"}
                                                className="text-center mx-auto img-fluid"
                                                alt="img" /><br />
                                            <span className="text-center w-100">ثبت نام با گوگل</span>
                                        </a> </div>
                                </div>

                                :

                                <div id="login-tab-content active">
                                    <form className=" login-form text-center" action="" method="post">
                                        <input type="text" className="input text-center  py-3 my-2" id="user_login" autoComplete="off" placeholder="نام کاربری " />
                                        <input type="password" className="input text-center  py-3 my-2" id="user_pass" autoComplete="off" placeholder="رمز عبور" />

                                        <input type="checkbox" className="checkbox" id="remember_me" />

                                        <label className="pr-4 my-3 "> مرا به خاطر بسپار</label>

                                        <input type="submit" className="button" value="ورود" />
                                    </form>

                                    <div className="help-text mt-4">
                                        <p><a href="#">رمز عبور را فراموش کردید ؟  </a></p>
                                    </div>

                                </div>


                            }





                            {/* <!--.login-tab-content--> */}
                        </div>
                        {/* <!--.tabs-content--> */}
                    </div>
                </div>
            </div>

            {/* @*-------*@ */}
        </>
    )
}


export default Login 