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
} from 'revalidate';

import { Form, Button, Input } from 'semantic-ui-react';
import { FORM_ERROR } from 'final-form';
import { RootStoreContext } from '../../app/stores/rootStore';




//validate BankAccount 
const validate = combineValidators({
    accountOwner: composeValidators(
        hasLengthGreaterThan(2)({ message: "حداقل 3 کاراکتر" }),
        hasLengthLessThan(49)({ message: "حداکثر 50 کاراکتر وارد کنید" }),
    )('accountOwner'),

    bankName: composeValidators(
        hasLengthLessThan(119)({ message: "حداکثر 120 کاراکتر وارد کنید" }),
    )('bankName'),


    cardNumber: composeValidators(
        hasLengthBetween(16, 16)({ message: "16 رقم وارد کنید" }),
        isNumeric({ message: " به فرمت  شماره کارد وارد کنید " }),
    )('cardNumber'),


    shabaNumber: composeValidators(
        hasLengthBetween(16, 16)({ message: "16 رقم وارد کنید" }),
        isNumeric({ message: " به فرمت  ویزا  وارد کنید " }),

    )('shabaNumber'),

    visaNumber: composeValidators(
        hasLengthBetween(16, 16)({ message: "16 رقم وارد کنید" }),
        isNumeric({ message: " به فرمت   ویزا  وارد کنید " }),
    )('visaNumber'),

})


interface IProps {
    profile: IProfile
}


const BacnkAccount: React.FC<IProps> = ({ profile }) => {

   
    const rootStore = useContext(RootStoreContext);
    const {
        chnageBankAccount
    } = rootStore.profileStore;


    const handleChangeBankAccount = async (values: any) => {
        try {
            let res = await chnageBankAccount(values);
            if (res && res.status === 0 && res.statusCode === 400) {
                return { [FORM_ERROR]: 'پسورد اشتباست ' }
            }
            else if (res && res.status == 0)
                return { [FORM_ERROR]: 'پسورد اشتباست ' }
        } catch (error) {
            return { [FORM_ERROR]: 'خطایی رخداده' }
        }
    };


    return (
        <>
            <div className="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
                <div className="row hj-form  mx-auto">

                    <FinalForm
                        onSubmit={handleChangeBankAccount}
                        validate={validate}
                        initialValues={profile}

                        render={({
                            handleSubmit,
                            invalid,
                            pristine,
                            submitError,
                            submitting,
                            dirtySinceLastSubmit,
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
                                            name='accountOwner'
                                            placeholder='نام صاحب حساب'
                                            type='text'
                                            className='form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark'
                                            value={profile.accountOwner}
                                            autoComplete='off'
                                        >
                                            {props => (
                                                <>
                                                    <label
                                                        className="text-right w-100 pr-3"
                                                        htmlFor="Owner-name"
                                                    >نام صاحب حساب </label>

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
                                            name='bankName'
                                            placeholder='نام بانک'
                                            type='text'
                                            className='form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark'
                                            value={profile.bankName}
                                            autoComplete='off'
                                        >
                                            {props => (
                                                <>
                                                    <label
                                                        className="text-right w-100 pr-3"
                                                        htmlFor="Owner-name"
                                                    > نام بانک  </label>

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
                                            name='cardNumber'
                                            placeholder='6037 9099 9900 9900'
                                            type='number'
                                            className='form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark'
                                            value={profile.cardNumber}
                                            autoComplete='off'
                                        >
                                            {props => (
                                                <>
                                                    <label
                                                        className="text-right w-100 pr-3"
                                                        htmlFor="Owner-name"
                                                    >  شماره کارت </label>
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
                                            name='shabaNumber'
                                            placeholder='6037 9099 9900 9900'
                                            type='number'
                                            className='form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark'
                                            value={profile.shabaNumber}
                                            autoComplete='off'
                                        >
                                            {props => (
                                                <>
                                                    <label
                                                        className="text-right w-100 pr-3"
                                                        htmlFor="Owner-name"
                                                    > شماره شبا</label>

                                                    <input
                                                        {...props}
                                                        {...props.input}
                                                    />
                                                    <img src={window.location.origin + "/hj/img/visa.png"} className="img-fluid hj-visa" />

                                                    {props.meta.touched && props.meta.error && (
                                                        <label className='text-center d-block text-danger'> {props.meta.error}</label>
                                                    )}
                                                </>
                                            )}
                                        </Field>
                                    </div>


                                    <div className="form-group w-100 position-relative">
                                        <Field
                                            name='visaNumber'
                                            placeholder='6037 9099 9900 9900'
                                            type='number'
                                            className='form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark'
                                            value={profile.visaNumber}
                                            autoComplete='off'
                                            
                                        >
                                            {props => (
                                                <>
                                                    <label
                                                        className="text-right w-100 pr-3"
                                                        htmlFor="Owner-name"
                                                    >شماره ویزا یا مستر کارت</label>

                                                    <input
                                              
                                                        {...props}
                                                        {...props.input}
                                                    />
                                                    <img src={window.location.origin + "/hj/img/visa.png"} className="img-fluid hj-visa" />

                                                    {props.meta.touched && props.meta.error && (
                                                        <label className='text-center d-block text-danger'> {props.meta.error}</label>
                                                    )}
                                                </>
                                            )}
                                        </Field>
                                    </div>


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
                        <label className="text-right w-100 pr-3" htmlFor="Owner-name">نام صاحب حساب </label>
                        <input type="text" className="form-control text-center hj-form-profile w-100 py-3  text-dark" id="Owner-name" placeholder=" نیما کفش آرا" />
                    </div>

                    <div className="form-group w-100">
                        <label className="text-right w-100 pr-3" htmlFor="Bank-name">نام بانک</label>
                        <input type="text" className="form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark" id="Bank-name" placeholder="سامان" />
                    </div>

                    <div className="form-group w-100">
                        <label className="text-right w-100 pr-3" htmlFor="card-number"> شماره کارت</label>
                        <input type="text" className="form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark" id="card-number" placeholder=" 6541981656498" />
                    </div>

                    <div className="form-group w-100 position-relative">
                        <label className="text-right w-100 pr-3" htmlFor="shaba-number"> شماره شبا</label>
                        <input type="text" className="form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark" id="shaba-number" placeholder=" 6541981656498" />
                        <img src={window.location.origin + "/hj/img/ss.png"} className="img-fluid hj-shaba" />
                    </div>

                    <div className="form-group w-100 position-relative">
                        <label className="text-right w-100 pr-3" htmlFor="visa-number">  شماره ویزا یا مستر کارت</label>
                        <input type="text" className="form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark" id="visa-number" placeholder=" 6541981656498" />
                        <img src={window.location.origin + "/hj/img/visa.png"} className="img-fluid hj-visa" />
                    </div>

                    <div className="row w-100 mx-auto mt-4 pt-4">
                        <button type="button" className="btn btn-success w-25 mx-auto Confirmation">ذخیره تنظیمات</button>
                    </div> */}

                </div>
            </div>

        </>
    )
}

export default observer(BacnkAccount) 