import React, { useState, useContext } from 'react'
import { NavLink, Redirect } from 'react-router-dom'
import { Form, Button } from 'semantic-ui-react';
import { history } from '../..';

import { IUserFormValues } from '../../app/models/user';


//tyhese are for formValidation
import { Form as FinalForm, Field } from 'react-final-form';
import { FORM_ERROR } from 'final-form';


import {
    combineValidators,
    isRequired,
    composeValidators,
    hasLengthGreaterThan,
    matchesPattern,
    hasLengthLessThan,
} from 'revalidate';

import { RootStoreContext } from '../../app/stores/rootStore';
import TextInput from '../../app/common/form/TextInput';
import ErrorMessage from '../../app/common/form/ErrorMessage';





//register validation
const registervalidate = combineValidators({
    email: composeValidators(
        isRequired({ message: 'ایمیل الزامیست' }),
        matchesPattern(/^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?$/
        )({ message: 'به فرمت ایمیل وارد کنید' }),
        hasLengthLessThan(31)({ message: "حداکثر 30 کاراکتر وارد کنید" })
    )('email'),

    password: composeValidators(
        isRequired({ message: 'پسورد الزامیست' }),
        hasLengthGreaterThan(5)({ message: "حداقل 6 کاراکتر وارد کنید" }),
        hasLengthLessThan(21)({ message: "حداکثر 20 کاراکتر وارد کنید" })

    )('password'),

    username: composeValidators(
        isRequired({ message: ' نام کاربری الزامیست ' }),
        hasLengthGreaterThan(3)({ message: "حداقل4  کاراکتر وارد کنید" }),
        hasLengthLessThan(21)({ message: " حداکثر 20 کاراکتر وارد کنید " })
    )('username'),
});


//login validate
const loginvalidate = combineValidators({

    password: composeValidators(
        isRequired({ message: 'پسورد الزامیست' }),
        hasLengthGreaterThan(5)({ message: "حداقل 6 کاراکتر" }),
        hasLengthLessThan(20)({ message: "حداکثر 20 کاراکتر وارد کنید" }),
    )('password'),

    username: composeValidators(
        isRequired({ message: ' نام کاربری الزامیست ' }),
        hasLengthGreaterThan(3)({ message: "حداقل 4 کاراکتر وارد کنید" }),
        hasLengthLessThan(20)({ message: " حداکثر 20 کاراکتر وارد کنید " })
    )('username'),
})

const getReturnURL = (loc: any) => {
    const { state } = loc;
    return state ? state.from.pathname : "/profile";
}


const Login = () => {

    const rootStore = useContext(RootStoreContext);
    const { login, register, isLoggedIn } = rootStore.userStore;

    const [showLogin, setShowLogin] = useState(true)

    const handleTabChange = (showRegister: boolean) => {
        if (showLogin !== showRegister)
            setShowLogin(showRegister)
    }


    if (isLoggedIn) return <Redirect to="/profile" />

    return (
        <>
            <div className="container w-100 mx-auto">
                <div className="row w-100 mx-auto">
                    <div className="form-wrap w-100" >
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

                                    {/* ........register from.................s   */}
                                    <FinalForm

                                        onSubmit={(values: IUserFormValues) =>
                                            register(values, '/profile')
                                                .catch(error => ({
                                                    [FORM_ERROR]: error
                                                }))
                                        }
                                        initialValues={{
                                            email: '',
                                            acceptRules: true,
                                            password: '',
                                            rememberMe: true,
                                            username: ''
                                        }}

                                        validate={registervalidate}
                                        render={({
                                            handleSubmit,
                                            submitting,
                                            submitError,
                                            invalid,
                                            pristine,
                                            dirtySinceLastSubmit,
                                            form,
                                            touched,
                                            error
                                        }) => (


                                                <Form
                                                    onSubmit={handleSubmit} error
                                                    className="signup-form"
                                                >
                                                    {submitError && !dirtySinceLastSubmit && (
                                                        <ErrorMessage
                                                            error={submitError}
                                                        />
                                                    )}

                                                    <Field
                                                        name='username'
                                                        component={TextInput}
                                                        type="text" id="user_name"
                                                        className="input text-center py-3 my-2 mx-auto"
                                                        placeholder='نام کاربری'
                                                    />

                                                    <Field
                                                        name='email'
                                                        value='qwer1234'
                                                        component={TextInput}
                                                        type="email"
                                                        id="user_email"
                                                        className="input text-center py-3 my-2 mx-auto"
                                                        placeholder='ایمیل'
                                                    />

                                                    <Field
                                                        name='password'
                                                        type="password"
                                                        component={TextInput} id="user_pass"
                                                        className="input text-center  py-3 my-2 mx-auto"
                                                        placeholder='رمز عبور' />
                                                    <br></br>

                                                    <label className="pr-4 my-3 mr-5 d-flex align-item-center ">
                                                        قوانین را میپذیرم
                                                         <Field
                                                            name='acceptRules'
                                                            type="checkbox"
                                                            component={TextInput}
                                                            id="acceptRules"
                                                            className="checkboxss "
                                                            style={{ visibility: "unset" }}
                                                        />
                                                    </label>

                                                    {submitting ?
                                                        <button className="button" type="button" disabled>
                                                            <span className="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                                                            <span className="sr-only">Loading...</span>
                                                        </button>
                                                        :
                                                        <Button
                                                            // disabled={(invalid && !dirtySinceLastSubmit) || pristine}
                                                            className={((invalid && !dirtySinceLastSubmit) || pristine) ? 'button btn disabled' : 'button'}
                                                            disabled={((invalid && !dirtySinceLastSubmit) || pristine)}
                                                            loading={submitting}
                                                            color='teal'
                                                            content='ثبت نام'

                                                            fluid
                                                        />
                                                    }
                                                    {/* <button type="submit" className="button" value="ثبت نام" >  </button> */}
                                                </Form>
                                            )}
                                    />
                                    <div className="help-text">
                                        <p><a onClick={() => setShowLogin(true)} >  قبلا ثبت نام کرده ام !</a></p>
                                    </div>
                                    <hr />
                                    <div className="row w-100 mx-auto text-center">
                                        <p className="w-100 text-center">می توانید از سرویس گوگل برای ثبت نام استفاده کنید </p>
                                    </div>
                                    <div className="row w-100 mx-auto text-center">
                                        <a href="#" className="mx-auto">
                                            <img src={window.location.origin + "/hj/img/google-icon.png"}
                                                className="text-center mx-auto img-fluid"
                                                alt="img" /><br />
                                            <span className="text-center w-100">ثبت نام با گوگل</span>
                                        </a> </div>
                                </div>

                                :

                                <div id="login-tab-content active">
                                    {/* <form className=" login-form text-center" action="" method="post"> */}


                                    {/* ........login from.................s   */}
                                    <FinalForm
                                        onSubmit={(values: IUserFormValues) =>
                                            login(values, getReturnURL(history.location)).catch(error => ({
                                                [FORM_ERROR]: error
                                            }))
                                        }
                                        initialValues={{
                                            email: '',
                                            acceptRules: true,
                                            password: '',
                                            rememberMe: true,
                                            username: ""
                                        }}
                                        validate={loginvalidate}
                                        render={({
                                            handleSubmit,
                                            submitting,
                                            submitError,
                                            invalid,
                                            pristine,
                                            dirtySinceLastSubmit,
                                           
                                        }) => (


                                                <Form
                                                    onSubmit={handleSubmit} error

                                                    className="signup-form login-form text-center"
                                                >
                                                    {submitError && !dirtySinceLastSubmit && (
                                                        <ErrorMessage
                                                            error={submitError}
                                                        />
                                                    )}

                                                    <Field
                                                        name='username'
                                                        component={TextInput}
                                                        type="text"
                                                        id="user_name"
                                                        className="input text-center  py-3 my-2 mx-auto"
                                                        placeholder='نام کاربری'
                                                    />

                                                    <Field
                                                        name='password'
                                                        type="password"
                                                        component={TextInput}
                                                        id="user_pass"
                                                        className="input text-center py-3 my-2 mx-auto"
                                                        placeholder='رمز عبور'
                                                    />

                                                    <br></br>

                                                    <div className="row w-100 mx-auto">

                                                        {/* <input type="checkbox" className="checkbox" id="remember_me" /> */}

                                                        {/* <label className="pr-4 my-3 "> مرا به خاطر بسپار</label> */}
                                                        <label className="pr-4 my-3 mr-5 ml-5 d-flex align-item-center">
                                                            مرا به خاطر بسپار
                                                           <Field
                                                                name='rememberMe'
                                                                type="checkbox"
                                                                component={TextInput}
                                                                id="rememberMe"
                                                                className="checkboxس"
                                                                style={{ visibility: "unset" }}
                                                            />
                                                        </label>

                                                        <br></br>
                                                    </div>

                                                    {submitting ?
                                                        <button className="button" type="button" disabled>
                                                            <span className="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                                                            <span className="sr-only">Loading...</span>
                                                        </button>
                                                        :
                                                        <Button
                                                            // disabled={(invalid && !dirtySinceLastSubmit) || pristine}
                                                            className={((invalid && !dirtySinceLastSubmit) || pristine) ? 'button btn disabled' : 'button'}
                                                            disabled={((invalid && !dirtySinceLastSubmit) || pristine)}
                                                            loading={submitting}
                                                            color='teal'
                                                            content='ورود'

                                                            fluid
                                                        />
                                                    }
                                                </Form>
                                            )}
                                    />
                                    {/* </form> */}

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