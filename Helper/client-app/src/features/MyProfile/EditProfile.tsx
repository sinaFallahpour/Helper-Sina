import React, { useState, useContext, useEffect } from 'react'
import { observer } from 'mobx-react-lite';



import { RouteComponentProps } from 'react-router-dom';
import LoadingTransparent from '../../app/common/Loading/LoadingTransparent';


import { IProfileRE } from '../../app/models/profile';
import { Form as FinalForm, Field } from 'react-final-form';

import '../../style/sina.css';
// import '../../style/datePicker.css'
// import 'react-persian-datepicker/lib/styles/basic.css'




import {
    combineValidators,
    isRequired,
    composeValidators,
    hasLengthGreaterThan,
    hasLengthLessThan,
    hasLengthBetween,
    isNumeric,
    matchesPattern,


} from 'revalidate';

// import { Calendar, DatePicker } from 'react-persian-datepicker';



import { Form, Button, Input } from 'semantic-ui-react';
import { FORM_ERROR } from 'final-form';
import { RootStoreContext } from '../../app/stores/rootStore';


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


    nickname: composeValidators(
        hasLengthGreaterThan(3)({ message: "حداقل 4 کاراکتر وارد کنید" }),
        hasLengthLessThan(201)({ message: " حداکثر 200 کاراکتر وارد کنید " })
    )('nickname'),


    descriptions: composeValidators(
        hasLengthGreaterThan(10)({ message: "حداقل 10 کاراکتر وارد کنید" }),
        hasLengthLessThan(201)({ message: " حداکثر 200 کاراکتر وارد کنید " })
    )('descriptions'),


    birthdate: composeValidators(
        // isNumeric({ message: 'به فرمت  موبایل وارد کنید' }),
        hasLengthLessThan(51)({ message: " حداکثر 50 کاراکتر وارد کنید " })
    )('birthdate'),

    city: composeValidators(
        // hasLengthGreaterThan(1)({ message: "حداقل 3 کاراکتر وارد کنید" }),
        hasLengthLessThan(50)({ message: " حداکثر 51 کاراکتر وارد کنید " })
    )('city'),

    // isMarid: composeValidators(
    //     isNumeric({ message: 'به فرمت  موبایل وارد کنید' }),
    //     hasLengthBetween(11, 11)({ message: '11 کاراکتر وارد کنید' })
    // )('isMarid'),


    phone: composeValidators(
        isNumeric({ message: 'به فرمت  موبایل وارد کنید' }),
        hasLengthBetween(11, 11)({ message: '11 کاراکتر وارد کنید' })
    )('phone'),


})




interface RouteParams {
    id: string;
}


interface IProps extends RouteComponentProps<RouteParams> { }


const EditProfile: React.FC<IProps> = ({ match }) => {




    //ایا سلکت آپشن باز است یا نه
    const [IsOpen, setIsOpen] = useState(true);

    const handleOpenSelect = () => {
        setIsOpen(prevstate => !prevstate)
    }



    const rootStore = useContext(RootStoreContext);

    const {
        loadingProfile,
        profile,
        loadProfile,
        updateProfile
    } = rootStore.profileStore

    useEffect(() => {
        loadProfile(match.params.id);
    }, [loadProfile, match]);

    if (loadingProfile) return <LoadingTransparent />;







    const submit = async (values: any) => {
        alert()
        try {
            let res = await updateProfile(values);
            // if (res && res.status === 0 && res.statusCode === 400) {
            //     return { [FORM_ERROR]: 'پسورد اشتباست ' }
            // }
            if (res && res.status == 0)
                return { [FORM_ERROR]: res.message }
        } catch (error) {
            return { [FORM_ERROR]: 'خطایی رخ داده' }
        }
    };





    return (
        <>

            <div className="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">

                {/* <div className="row hj-form  mx-auto"> */}
                <FinalForm
                    onSubmit={submit}
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








                                <div className="row hj-form  mx-auto">

                                    <div className="form-group w-100 mb-4">

                                        <Field
                                            name='nickname'
                                            placeholder='نام ونام خانوادگی'
                                            type='text'
                                            className='form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput'
                                            value={profile?.userName}
                                            autoComplete='off'
                                            id='nickname'
                                        >
                                            {props => (
                                                <>
                                                    <label
                                                        className="text-right w-100 pr-3"
                                                        htmlFor="nickname"
                                                    >نام ونام خانوادگی
            </label>

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

                                    <div className="form-group w-100 mb-4">
                                        <Field
                                            name='userName'
                                            placeholder='نام کاربری'
                                            type='text'
                                            className='form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput'
                                            value={profile?.userName}
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

                                    <div className="form-group w-100 mb-4">

                                        <Field
                                            name='email'
                                            placeholder='ایمیل'
                                            type='text'
                                            className='form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput'
                                            value={profile?.userName}
                                            autoComplete='off'
                                            id='email'
                                        >
                                            {props => (
                                                <>
                                                    <label
                                                        className="text-right w-100 pr-3"
                                                        htmlFor="email"
                                                    >ایمیل
                                                </label>

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




                                    <div className="form-group w-100 mb-4">

                                        <Field
                                            name='phone'
                                            placeholder='شماره تماس'
                                            type='number'
                                            className='form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput'
                                            value={profile?.phone}
                                            autoComplete='off'
                                            id='phone'
                                        >
                                            {props => (
                                                <>
                                                    <label
                                                        className="text-right w-100 pr-3"
                                                        htmlFor="phone"
                                                    >شماره تماس
                                                </label>

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

                                </div>




                                <div className="container hj-form mt-5 m-0 p-0 mx-auto">
                                    <div className="row w-100 p-0 m-0">
                                        <div className="col-md-11 col-10 text-right"><h3 className="size20"> سایر اطلاعات</h3></div>


                                        <div className="col-md-1 col-2 text-left pt-2">
                                            <i
                                                className={IsOpen ? 'fa-minus-circle fa  hj-sum' : 'fa-plus-circle fa  hj-sum'}
                                                onClick={() => { handleOpenSelect() }}
                                                // className="fa fa-plus-circle hj-sum"
                                                id="plus-profile">
                                            </i>
                                        </div>
                                    </div>

                                    <div
                                        className={IsOpen ? 'toggle-Record row w-100 hj-Records hj-form mt-3  mx-auto p-0 m-0 px-2'
                                            :
                                            ' row w-100 hj-Records hj-form mt-3  mx-auto p-0 m-0 px-2'}
                                        id="Record"
                                    >

                                        <div className="form-group w-100 text-right mb-4">
                                            <div className="form-group w-100 text-right mb-4">
                                                <div className="col-md-6 p-0 m-0">
                                                    <Field
                                                        name='city'
                                                        placeholder='شهر'
                                                        type='text'
                                                        className='form-control hj-form-profile w-100 py-3 pr-3 text-dark mb-4 _formInput'
                                                        value={profile?.city}
                                                        autoComplete='off'
                                                        id='city'
                                                    >
                                                        {props => (
                                                            <>
                                                                <label
                                                                    className="text-right w-100 pr-3"
                                                                    htmlFor="city"
                                                                >شهر
                                                </label>

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
                                                <div className="col-md-6 p-0 m-0">
                                                    <Field
                                                        name='birthdate'
                                                        placeholder='تاریخ تولد'
                                                        type='text'
                                                        className='form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput'
                                                        value={profile?.birthdate}
                                                        autoComplete='off'
                                                        id='birthdate'
                                                    >
                                                        {props => (
                                                            <>
                                                                <label
                                                                    className="text-right w-100 pr-3"
                                                                    htmlFor="city"
                                                                >
                                                                    تاریخ تولد

                                                            </label>

                                                                <input
                                                                    {...props}
                                                                    {...props.input}
                                                                />

                                                                {/* <Datepicker
                                                            {...props}
                                                            {...props.input}
                                                                value={profile?.birthdate} /> */}



                                                                {props.meta.touched && props.meta.error && (
                                                                    <label className='text-center d-block text-danger'> {props.meta.error}</label>
                                                                )}
                                                            </>
                                                        )}
                                                    </Field>
                                                </div>
                                            </div>
                                        </div>

                                        <div className="form-group w-100 text-right">
                                            <Field
                                                name='descriptions'
                                                placeholder='توضیحات'
                                                type='text'
                                                className='form-control hj-form-profile _formInput'
                                                value={profile?.descriptions}
                                                autoComplete='off'
                                                id='descriptions'
                                            >
                                                {props => (
                                                    <>
                                                        <label
                                                            className="text-right w-100 pr-3 mt-md-3"
                                                            htmlFor="descriptions"
                                                        >
                                                            توضیحات
                                                     </label>
                                                        <textarea
                                                            {...props}
                                                            {...props.input}
                                                        >
                                                        </textarea>
                                                        {props.meta.touched && props.meta.error && (
                                                            <label className='text-center d-block text-danger'> {props.meta.error}</label>
                                                        )}
                                                    </>
                                                )}
                                            </Field>

                                        </div>


















                                        {/* <div className="form-group w-100 text-right">
                                        <label htmlFor="exampleInputPosition">سمت</label>
                                        <input type="text" className="form-control hj-form-profile w-100 py-3 pr-3 text-dark" id="exampleInputPosition" placeholder="سمت خود را وارد کنید " />

                                    </div> */}
                                        {/* <div className="form-group w-100 text-right">
                                        <div className="col-md-6 p-0 m-0">
                                            <label htmlFor="exampleInputOfDate">از تاریخ</label>
                                            <input type="text" className="form-control hj-form-profile w-100 py-3 pr-3 text-dark" id="exampleInputOfDate" placeholder=" شروع کار " />
                                        </div>
                                        <div className="col-md-6 p-0 m-0">
                                            <label htmlFor="exampleInputOnDate">تا تاریخ</label>
                                            <input type="text" className="form-control hj-form-profile w-100 py-3 pr-3 text-dark" id="exampleInputOnDate" placeholder=" اتمام کار" />
                                        </div>
                                    </div> */}

                                        {/* <div className="form-group w-100 text-right">
                                        <label htmlFor="exampleInputDetalis" className="mt-md-3">توضیحات </label>
                                        <textarea className="form-control hj-form-profile " id="exampleInputDetalis" rows={3} placeholder="لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف"></textarea>
                                    </div> */}

                                    </div>
                                </div>

                                <div className="container m-0 p-0 mx-auto">
                                    {submitting ?
                                        <div className="row text-center mt-5">
                                            <button className="button btn btn-success w-25 mx-auto Confirmation" type="button" disabled>
                                                <span className="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                                                <span className="sr-only">Loading...</span>
                                            </button>
                                        </div>
                                        :
                                        <div className="row text-center mt-5">

                                            <Button
                                                className='btn btn-success w-25 mx-auto Confirmation '
                                                disabled={((invalid && !dirtySinceLastSubmit) || pristine)}
                                                loading={submitting}
                                                content='ذخیره تغیرات'
                                                fluid
                                            />
                                        </div>

                                    }
                                </div>

                            </Form>
                        )}
                />


















                {/* 
                <div className="form-group w-100">

                    <input
                        name='userName'
                        type="text"
                        className="form-control hj-form-profile w-100 py-3 pr-3 text-dark"
                        id=""
                        placeholder="نام کاربری" />

                </div> */}


                {/* 
                <div className="form-group w-100">
                    <input type="text"
                        placeholder="شهر"
                        className="form-control hj-form-profile w-100 py-3 pr-3 text-dark"
                        id=""
                    />
                </div>
                <div className="form-group w-100">

                    <input
                        placeholder=" شماره موبایل"
                        type="text"
                        className="form-control hj-form-profile w-100 py-3 pr-3 text-dark" id=""
                    />

                </div> */}
                {/* <div className="form-group w-100">

                    <input type="password" className="form-control hj-form-profile w-100 py-3 pr-3 text-dark" id="" placeholder="رمز عبور" />

                </div> */}
                {/* <div className="form-group w-100">

                    <textarea className="form-control hj-form-profile " id="exampleFormControlTextarea4" rows={3} placeholder=" توضیحات..."></textarea>
                </div> */}


                {/* 
            <div className="container hj-form mt-5 m-0 p-0 mx-auto">
                <div className="row w-100 p-0 m-0">
                    <div className="col-md-11 col-10 text-right"><h3 className="size20"> سایر اطلاعات</h3></div>


                    <div className="col-md-1 col-2 text-left pt-2">
                        <i
                            className={IsOpen ? 'fa-minus-circle fa  hj-sum' : 'fa-plus-circle fa  hj-sum'}
                            onClick={() => { handleOpenSelect() }}
                            // className="fa fa-plus-circle hj-sum"
                            id="plus-profile">
                        </i>
                    </div>
                </div>

                <div
                    className={IsOpen ? 'toggle-Record row w-100 hj-Records hj-form mt-3  mx-auto p-0 m-0 px-2'
                        :
                        ' row w-100 hj-Records hj-form mt-3  mx-auto p-0 m-0 px-2'}
                    id="Record"
                >
                    <div className="form-group w-100 text-right">
                        <label htmlFor="exampleInputCompany">شرکت</label>
                        <input type="text" className="form-control hj-form-profile w-100 py-3 pr-3 text-dark" id="exampleInputCompany" placeholder="نام شرکت" />

                    </div>
                    <div className="form-group w-100 text-right">
                        <label htmlFor="exampleInputPosition">سمت</label>
                        <input type="text" className="form-control hj-form-profile w-100 py-3 pr-3 text-dark" id="exampleInputPosition" placeholder="سمت خود را وارد کنید " />

                    </div>
                    <div className="form-group w-100 text-right">
                        <div className="col-md-6 p-0 m-0">
                            <label htmlFor="exampleInputOfDate">از تاریخ</label>
                            <input type="text" className="form-control hj-form-profile w-100 py-3 pr-3 text-dark" id="exampleInputOfDate" placeholder=" شروع کار " />
                        </div>
                        <div className="col-md-6 p-0 m-0">
                            <label htmlFor="exampleInputOnDate">تا تاریخ</label>
                            <input type="text" className="form-control hj-form-profile w-100 py-3 pr-3 text-dark" id="exampleInputOnDate" placeholder=" اتمام کار" />
                        </div>
                    </div>

                    <div className="form-group w-100 text-right">
                        <label htmlFor="exampleInputDetalis" className="mt-md-3">توضیحات </label>
                        <textarea className="form-control hj-form-profile " id="exampleInputDetalis" rows={3} placeholder="لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف"></textarea>
                    </div>

                </div>
            </div>
         
          */}



                {/* <div className="container hj-form mt-5 m-0 p-0 mx-auto">
                <div className="row w-100 p-0 m-0">
                    <div className="col-md-11 col-10 text-right"><h4 className="size20">سوابق تحصیلی</h4></div>
                    <div className="col-md-1 col-2 text-left pt-2"> <i className="fa fa-plus-circle hj-sum"></i></div>
                </div>
            </div>
            <div className="container hj-form mt-5 m-0 p-0 mx-auto">
                <div className="row w-100 p-0 m-0">
                    <div className="col-md-11 col-10 text-right"><h4 className="size20">سایر اطلاعات</h4></div>
                    <div className="col-md-1 col-2 text-left pt-2"> <i className="fa fa-plus-circle hj-sum"></i></div>
                </div>
            </div> */}
                {/* <div className="container m-0 p-0 mx-auto">
                <div className="row text-center mt-5">
                    <div className="col-12 ">
                        <button type="button" className="btn btn-success hj-service-index-button px-5  "> ذخیره تغیرات </button>
                    </div>
                </div>
            </div> */}
            </div>
        </>
    )
}



export default observer(EditProfile)