import React, { useState, useContext, useEffect } from 'react'
import { observer } from 'mobx-react-lite';



import { RouteComponentProps } from 'react-router-dom';
import LoadingTransparent from '../../app/common/Loading/LoadingTransparent';


import { FormFieldProps, Form as as } from 'semantic-ui-react';

import { IProfileRE } from '../../app/models/profile';
import { Form as FinalForm, Field, FieldRenderProps } from 'react-final-form';

import { TextInput, SelectInput } from './form/Inputs'
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


    city: composeValidators(
        // hasLengthGreaterThan(1)({ message: "حداقل 3 کاراکتر وارد کنید" }),
        hasLengthLessThan(50)({ message: " حداکثر 51 کاراکتر وارد کنید " })
    )('city'),


    phone: composeValidators(
        isNumeric({ message: 'به فرمت  موبایل وارد کنید' }),
        hasLengthBetween(11, 11)({ message: '11 کاراکتر وارد کنید' })
    )('phone'),







    /*  اطلاعات شخصی */
    birthdate: composeValidators(
        hasLengthLessThan(51)({ message: " حداکثر 50 کاراکتر وارد کنید " })
    )('birthdate'),


    gender: composeValidators(
        isRequired({ message: ' الزامیست ' }),
    )('gender'),

    marriedType: composeValidators(
        isRequired({ message: ' الزامیست ' }),
    )('marriedType'),

    // languageKnowing: composeValidators(
    //     hasLengthLessThan(51)({ message: " حداکثر 50 کاراکتر وارد کنید " })
    // )('languageKnowing'),


    /*  سوابق کاری  */
    maghTa: composeValidators(
        hasLengthGreaterThan(3)({ message: "حداقل 4 کاراکتر وارد کنید" }),
        hasLengthLessThan(51)({ message: " حداکثر 50 کاراکتر وارد کنید " })
    )('maghTa'),

    univercityName: composeValidators(
        hasLengthGreaterThan(3)({ message: "حداقل 4 کاراکتر وارد کنید" }),
        hasLengthLessThan(51)({ message: " حداکثر 50 کاراکتر وارد کنید " })
    )('univercityName'),

    eduEnterDate: composeValidators(
        hasLengthLessThan(51)({ message: " حداکثر 50 کاراکتر وارد کنید " })
    )('eduEnterDate'),

    eduExitDate: composeValidators(
        hasLengthLessThan(51)({ message: " حداکثر 50 کاراکتر وارد کنید " })
    )('eduExitDate'),


    /* company */

    companyName: composeValidators(
        hasLengthGreaterThan(3)({ message: "حداقل 4 کاراکتر وارد کنید" }),
        hasLengthLessThan(51)({ message: " حداکثر 50 کاراکتر وارد کنید " })
    )('companyName'),

    semat: composeValidators(
        hasLengthGreaterThan(3)({ message: "حداقل 4 کاراکتر وارد کنید" }),
        hasLengthLessThan(51)({ message: " حداکثر 50 کاراکتر وارد کنید " })
    )('semat'),

    workEnterDate: composeValidators(
        hasLengthLessThan(51)({ message: " حداکثر 50 کاراکتر وارد کنید " })
    )('workEnterDate'),

    workExitDate: composeValidators(
        hasLengthLessThan(51)({ message: " حداکثر 50 کاراکتر وارد کنید " })
    )('workExitDate'),

    descriptions: composeValidators(
        hasLengthGreaterThan(10)({ message: "حداقل 10 کاراکتر وارد کنید" }),
        hasLengthLessThan(299)({ message: " حداکثر 298 کاراکتر وارد کنید " })
    )('descriptions'),

})




interface RouteParams {
    id: string;
}


interface IProps extends RouteComponentProps<RouteParams> { }


const EditProfile: React.FC<IProps> = ({ match }) => {


    const [startrLoading, setStartrLoading] = useState(true)

    setTimeout(() => {
        setStartrLoading(false)
    }, 2000);


    //ایا سلکت آپشن باز است یا نه
    const [IsOpen, setIsOpen] = useState(true);

    const handleOpenSelect = () => {
        setIsOpen(prevstate => !prevstate)
    }

    const [IsOpen2, setIsOpen2] = useState(true);

    const handleOpenSelect2 = () => {
        setIsOpen2(prevstate => !prevstate)
    }


    const [IsOpen3, setIsOpen3] = useState(true);

    const handleOpenSelect3 = () => {
        setIsOpen3(prevstate => !prevstate)
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



    if (loadingProfile || startrLoading) return <LoadingTransparent />;


    const submit = async (values: any) => {
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
                    initialValues={{
                        ...profile,
                        ...profile?.workExperienceDTO,
                        ...profile?.educationHistryDTO,
                        workEnterDate: profile?.educationHistryDTO?.enterDate,
                        workExitDate: profile?.educationHistryDTO?.exitDate,
                        eduEnterDate: profile?.workExperienceDTO?.enterDate,
                        eduExitDate: profile?.workExperienceDTO?.exitDate,
                    }}

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
                                            name='userName'
                                            component={TextInput}
                                            type="text"
                                            id="userName"
                                            className='form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput'
                                            placeholder='نام کاربری '
                                            value={profile?.userName}
                                            label=' نام کاربری'
                                        />
                                    </div>

                                    <div className="form-group w-100 mb-4">
                                        <Field
                                            name='email'
                                            component={TextInput}
                                            type="text"
                                            id="email"
                                            className='form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput'
                                            placeholder='ایمیل '
                                            value={profile?.email}
                                            label=' ایمیل'
                                        />
                                    </div>

                                    <div className="form-group w-100 mb-4">
                                        <Field
                                            name='city'
                                            component={TextInput}
                                            type="text"
                                            id="city"
                                            className='form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput'
                                            placeholder='شهر'
                                            value={profile?.city}
                                            label='شهر'
                                        />
                                    </div>


                                    <div className="form-group w-100 mb-4">
                                        <Field
                                            name='phone'
                                            component={TextInput}
                                            type="number"
                                            id="phone"
                                            className='form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput'
                                            placeholder='شماره تماس'
                                            value={profile?.phone}
                                            label='شماره تماس'
                                        />
                                    </div>
                                </div>



                                {/*  سوابق کاری  */}
                                <div className="container hj-form mt-5 m-0 p-0 mx-auto">
                                    <div className="row w-100 p-0 m-0">
                                        <div className="col-md-11 col-10 text-right"><h3 className="size20">  سابقه کاری</h3></div>


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

                                            <Field
                                                name='companyName'
                                                component={TextInput}
                                                type="text"
                                                id="companyName"
                                                className="form-control hj-form-profile _formInput"
                                                placeholder='نام شرکت'
                                                value='companyName'
                                                label="نام شرکت "
                                            />


                                            <Field
                                                name='semat'
                                                component={TextInput}
                                                type="text"
                                                id="semat"
                                                className="form-control hj-form-profile _formInput"
                                                placeholder='سمت'
                                                value='semat'
                                                label="سمت"
                                            />

                                            <div className="form-group w-100 text-right mb-4">
                                                <div className="form-group w-100 text-right mb-4">
                                                    <div className="col-md-6 p-0 m-0">
                                                        <Field
                                                            name='workEnterDate'
                                                            component={TextInput}
                                                            type="text"
                                                            id="workEnterDate"
                                                            className="form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput"
                                                            placeholder="از تاریخ"
                                                            value='workEnterDate'
                                                            label="از تاریخ"
                                                        />
                                                    </div>
                                                    <div className="col-md-6 p-0 m-0">
                                                        <Field
                                                            name='workExitDate'
                                                            component={TextInput}
                                                            type="text"
                                                            id='workExitDate'
                                                            className="form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput"
                                                            placeholder="تا تاریخ"
                                                            value='workExitDate'
                                                            label="تا تاریخ"
                                                        />
                                                    </div>
                                                </div>
                                            </div>

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
                                    </div>
                                </div>

                                {/*  سوابق تحصیلی  */}
                                <div className="container hj-form mt-5 m-0 p-0 mx-auto">
                                    <div className="row w-100 p-0 m-0">
                                        <div className="col-md-11 col-10 text-right"><h3 className="size20">   سابقه تحصیلی</h3></div>

                                        <div className="col-md-1 col-2 text-left pt-2">
                                            <i
                                                className={IsOpen2 ? 'fa-minus-circle fa  hj-sum' : 'fa-plus-circle fa  hj-sum'}
                                                onClick={() => { handleOpenSelect2() }}
                                                // className="fa fa-plus-circle hj-sum"
                                                id="plus-profile">
                                            </i>
                                        </div>
                                    </div>

                                    <div
                                        className={IsOpen2 ? 'toggle-Record row w-100 hj-Records hj-form mt-3  mx-auto p-0 m-0 px-2'
                                            :
                                            ' row w-100 hj-Records hj-form mt-3  mx-auto p-0 m-0 px-2'}
                                        id="Record"
                                    >

                                        <div className="form-group w-100 text-right">

                                            <Field
                                                name='maghTa'
                                                component={TextInput}
                                                type="text"
                                                id="maghTa"
                                                className="form-control hj-form-profile _formInput"
                                                placeholder='مقطع'
                                                value={profile?.educationHistryDTO?.maghTa}
                                                label='مقطع '
                                            />


                                            <Field
                                                name='univercityName'
                                                component={TextInput}
                                                type="text"
                                                id="univercityName"
                                                className="form-control hj-form-profile _formInput"
                                                placeholder="نام دانشگاه"
                                                value={profile?.educationHistryDTO?.univercityName}
                                                label="نام دانشگاه"
                                            />

                                            <div className="form-group w-100 text-right mb-4">
                                                <div className="form-group w-100 text-right mb-4">
                                                    <div className="col-md-6 p-0 m-0">
                                                        <Field
                                                            name='eduEnterDate'
                                                            component={TextInput}
                                                            type="text"
                                                            id="eduEnterDate"
                                                            className="form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput"
                                                            placeholder="از تاریخ"
                                                            value={profile?.educationHistryDTO?.enterDate}
                                                            label="از تاریخ"
                                                        />
                                                    </div>
                                                    <div className="col-md-6 p-0 m-0">
                                                        <Field
                                                            name='eduExitDate'
                                                            component={TextInput}
                                                            type="text"
                                                            id='eduExitDate'
                                                            className="form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput"
                                                            placeholder="تا تاریخ"

                                                            value={profile?.educationHistryDTO?.exitDate}
                                                            label="تا تاریخ"
                                                        />
                                                    </div>
                                                </div>
                                            </div>

                                            <label className="text-right w-100 pr-3 mt-md-3">   </label>
                                        </div>
                                    </div>
                                </div>


                                {/*  سایر اطلاعات  */}
                                <div className="container hj-form mt-5 m-0 p-0 mx-auto">
                                    <div className="row w-100 p-0 m-0">
                                        <div className="col-md-11 col-10 text-right"><h3 className="size20"> سایر اطلاعات</h3></div>

                                        <div className="col-md-1 col-2 text-left pt-2">
                                            <i
                                                className={IsOpen3 ? 'fa-minus-circle fa  hj-sum' : 'fa-plus-circle fa  hj-sum'}
                                                onClick={() => { handleOpenSelect3() }}
                                                id="plus-profile">
                                            </i>
                                        </div>
                                    </div>

                                    <div
                                        className={IsOpen3 ? 'toggle-Record row w-100 hj-Records hj-form mt-3  mx-auto p-0 m-0 px-2'
                                            :
                                            ' row w-100 hj-Records hj-form mt-3  mx-auto p-0 m-0 px-2'}
                                        id="Record"
                                    >

                                        <div className="form-group w-100 text-right">

                                            <Field
                                                name='birthdate'
                                                component={TextInput}
                                                type="text"
                                                id="birthdate"
                                                className="form-control hj-form-profile _formInput"
                                                placeholder='تاریخ تولد'
                                                value={profile?.birthdate}
                                                label='تاریخ تولد'
                                            />

                                            <div className="form-group w-100 text-right mb-4">
                                                <div className="form-group w-100 text-right mb-4">
                                                    <div className="col-md-6 p-0 m-0">
                                                        <Field
                                                            name='gender'
                                                            component={SelectInput}
                                                            options={[
                                                                { key: '0', text: 'مرد', value: '0' },
                                                                { key: '1', text: 'زن', value: '1' }]
                                                            }
                                                            id="gender"
                                                            className="form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput"

                                                            value={profile?.gender.toString()}
                                                            label="جنسیت"
                                                        />
                                                    </div>
                                                    <div className="col-md-6 p-0 m-0">
                                                        <Field
                                                            name='marriedType'
                                                            component={SelectInput}
                                                            options={[
                                                                { key: '0', text: 'مجرد', value: '0' },
                                                                { key: '1', text: 'متاهل', value: '1' }]
                                                            }
                                                            id='marriedType'
                                                            className="form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput"
                                                            value={profile?.marriedType.toString()}
                                                            label="وضعیت"
                                                        />
                                                    </div>
                                                </div>
                                            </div>

                                            <label className="text-right w-100 pr-3 mt-md-3">   </label>
                                        </div>
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
            </div>
        </>
    )
}

export default observer(EditProfile)

