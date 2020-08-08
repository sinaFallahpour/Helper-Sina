import React, { useState, FormEvent, useContext } from 'react'
import { observer } from 'mobx-react-lite';

import { IProfile } from '../../app/models/profile';

import { Form as FinalForm, Field } from 'react-final-form';

import {
    combineValidators,
    isRequired,
    composeValidators,
    hasLengthGreaterThan,
    hasLengthLessThan,
    hasLengthBetween,
    isNumeric,
    matchesPattern
} from 'revalidate';
import { Form, Button, Input } from 'semantic-ui-react';
import { FORM_ERROR } from 'final-form';
import { RootStoreContext } from '../../app/stores/rootStore';
import { profile } from 'console';



//validate BankAccount 
const validate = combineValidators({
    userName: composeValidators(
        isRequired({ message: ' نام کاربری الزامیست ' }),
        hasLengthGreaterThan(3)({ message: "حداقل 4 کاراکتر وارد کنید" }),
        hasLengthLessThan(21)({ message: " حداکثر 20 کاراکتر وارد کنید " })
    )('userName'),

    email: composeValidators(
        matchesPattern(/^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?$/
        )({ message: 'به فرمت ایمیل وارد کنید' }),
        hasLengthLessThan(31)({ message: "حداکثر 30 کاراکتر وارد کنید" })
    )('email'),

    phone: composeValidators(
        isNumeric({ message: 'به فرمت  موبایل وارد کنید' }),
        hasLengthBetween(11, 11)({ message: '11 کاراکتر وارد کنید' })
    )('phone'),

})


interface IProps {
    profile: IProfile
}


const PersonalInformation: React.FC<IProps> = ({ profile }) => {



    const rootStore = useContext(RootStoreContext);
    const {
        changePersonalInformation
    } = rootStore.profileStore;


    const handleChangePersonalInformation = async (values: any) => {
        try {
            let res = await changePersonalInformation(values);
            // if (res && res.status === 0 && res.statusCode === 400) {
            //     return { [FORM_ERROR]: 'پسورد اشتباست ' }
            // }
            if (res && res.status == 0)
                return { [FORM_ERROR]: res.message }
        } catch (error) {
            return { [FORM_ERROR]: 'خطایی رخداده' }
        }
    };




    return (
        <>

            <div className="tab-pane fade show active" id="nav-Personal" role="tabpanel" aria-labelledby="nav-Personal-tab">

                <div className="row hj-form  mx-auto">



                    <FinalForm
                        onSubmit={handleChangePersonalInformation}
                        validate={validate}
                        initialValues={profile}

                        render={({
                            handleSubmit,
                            invalid,
                            pristine,
                            submitError,
                            submitting,
                            dirtySinceLastSubmit,
                            form
                        }) => (
                                <Form
                                    onSubmit={handleSubmit}
                                    error
                                    className='form-group w-100'

                                >
                                    {submitError && !dirtySinceLastSubmit && (
                                        <div
                                            className="alert alert-danger text-center text-danger"
                                            role="alert">
                                            {submitError}
                                        </div>

                                    )}


                                    <div className="form-group w-100">
                                        <Field
                                            name='userName'
                                            placeholder='نام کاربری'
                                            type='text'
                                            className='form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark'
                                            value={profile.userName}
                                            autoComplete='off'
                                        >
                                            {props => (
                                                <>
                                                    <label
                                                        className="text-right w-100 pr-3"
                                                        htmlFor="Owner-name"
                                                    >نام  کاربری </label>

                                                    <input
                                                        {...props}
                                                        {...props.input}
                                                    />
                                                    {props.meta.touched && props.meta.error && (
                                                        <label className='text-center d-block text-danger'> {props.meta.error}</label>
                                                    )}
                                                </>
                                            )}
                                        </Field>
                                    </div>


                                    <div className="form-group w-100">
                                        <Field
                                            name='email'
                                            placeholder=' test@gmail.com'
                                            type='email'
                                            className='form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark'
                                            value={profile.email}
                                            autoComplete='off'
                                        >
                                            {props => (
                                                <>
                                                    <label
                                                        className="text-right w-100 pr-3"
                                                        htmlFor="Owner-name"
                                                    >  ایمیل  </label>

                                                    <input
                                                        {...props}
                                                        {...props.input}
                                                    />
                                                    {props.meta.touched && props.meta.error && (
                                                        <label className='text-center d-block text-danger'> {props.meta.error}</label>
                                                    )}
                                                </>
                                            )}
                                        </Field>

                                    </div>


                                    <div className="form-group w-100 position-relative">
                                        <Field
                                            name='phone'
                                            placeholder='6037 9099 9900 9900'
                                            type='number'
                                            className='form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark'
                                            value={profile.phone}
                                            autoComplete='off'
                                        >
                                            {props => (
                                                <>
                                                    <label
                                                        className="text-right w-100 pr-3"
                                                        htmlFor="Owner-name"
                                                    >   شماره موبایل </label>
                                                    <input
                                                        {...props}
                                                        {...props.input}
                                                    />
                                                    <img src={window.location.origin + "/hj/img/Edit - Alt 2.png"} className="img-fluid hj-pen" />

                                                    {props.meta.touched && props.meta.error && (
                                                        <label className='text-center d-block text-danger'> {props.meta.error}</label>
                                                    )}
                                                </>
                                            )}
                                        </Field>

                                    </div>
                                    <pre>{JSON.stringify(form.getState(), null, 2)}</pre>



                                    <div className="row w-100 mx-auto mt-4 pt-4">
                                        {submitting ?
                                            <button className="button btn btn-success w-25 mx-auto Confirmation" type="button" disabled>
                                                <span className="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                                                <span className="sr-only">Loading...</span>
                                            </button>
                                            :
                                            <Button
                                                className='btn btn-success w-25 mx-auto Confirmation '
                                                disabled={((invalid && !dirtySinceLastSubmit) || pristine)}

                                                loading={submitting}
                                                content='ذخیره تنطیمات'
                                                fluid
                                            />
                                        }
                                    </div>

                                </Form>
                            )}
                    />







                    {/* <div className="form-group w-100">
                        <label className="text-right w-100 pr-3" htmlFor="name">نام کاربری</label>
                        <input type="text" className="form-control text-center hj-form-profile w-100 py-3  text-dark" id="name" placeholder="نام کاربری" />

                    </div> */}




                    {/* <div className="form-group w-100">
                        <label className="text-right w-100 pr-3" htmlFor="email">ایمیل</label>
                        <input type="email" className="form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark" id="email" placeholder="test.gmail.com" />

                    </div> */}




                    {/* <div className="form-group w-100 position-relative">
                        <label className="text-right w-100 pr-3" htmlFor="number-Phone">شماره موبایل</label>

                        <input type="text" className="form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark" id="number-Phone" placeholder=" 00000000_98+" />
                        <img src={window.location.origin + "/hj/img/Edit - Alt 2.png"} className="img-fluid hj-pen" />
                    </div> */}



                    <label className="text-right w-100 pr-3 mt-2" htmlFor="">زبان وبسایت و اعلامه های رسمی </label>
                    <div className="row w-100 mx-auto my-2 hj-form-profile hj-maharat ">

                        <div className="col-md-7 col-8  mx-auto text-left py-2 ">
                            <h6 className="pt-1 pl-4">فارسی</h6>
                        </div>
                        <div className="col-md-5 col-4  mx-auto">
                            <i className="fas fa-chevron-down pl-3 pt-3" id="select-down"></i>
                        </div>
                    </div>


                    <div className="row w-100 mx-auto hj-select  ">
                        <div className="col-sm-2 col-12 py-2">
                            <button type="button" className="btn  w-100 button-Service">فارسی</button>
                        </div>
                        <div className="col-sm-2 col-12  py-2">
                            <button type="button" className="btn  w-100 button-Service">انگلیسی</button>
                        </div>

                    </div>

                    <div className="row w-100 mx-auto mt-4 pt-4">
                        <button type="button" className="btn btn-success w-25 mx-auto Confirmation">ذخیره تنظیمات</button>
                    </div>


                </div>
            </div>

        </>
    )
}



export default observer(PersonalInformation) 