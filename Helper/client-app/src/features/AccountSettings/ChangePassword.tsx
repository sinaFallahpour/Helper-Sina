import React, { useState, FormEvent, useContext } from 'react'
import { observer } from 'mobx-react-lite';
import { IProfile, IChangePasswordRQ } from '../../app/models/profile';
import { Form as FinalForm, Field } from 'react-final-form';
import {
    combineValidators,
    isRequired,
    composeValidators,
    hasLengthGreaterThan,
    hasLengthLessThan,
    matchesField
} from 'revalidate';

import { Form, Button, Input } from 'semantic-ui-react';
import { RootStoreContext } from '../../app/stores/rootStore';
import { FORM_ERROR } from 'final-form';


//validate change password 
const validate = combineValidators({
    oldPassword: composeValidators(
        isRequired({ message: 'پسورد الزامیست' }),
        hasLengthGreaterThan(5)({ message: "حداقل 6 کاراکتر" }),
        hasLengthLessThan(20)({ message: "حداکثر 20 کاراکتر وارد کنید" }),
    )('oldPassword'),

    newPassword: composeValidators(
        isRequired({ message: 'پسورد الزامیست' }),
        hasLengthGreaterThan(5)({ message: "حداقل 6 کاراکتر" }),
        hasLengthLessThan(20)({ message: "حداکثر 20 کاراکتر وارد کنید" }),
    )('newPassword'),

    newPasswordConfirm: composeValidators(
        isRequired({ message: 'پسورد الزامیست' }),
        hasLengthGreaterThan(5)({ message: "حداقل 6 کاراکتر" }),
        hasLengthLessThan(20)({ message: "حداکثر 20 کاراکتر وارد کنید" }),
        matchesField('newPassword', 'newPassword')({ message: 'تکرار پسورد صحیح نمباشد' })
    )('newPasswordConfirm'),

})


interface IProps {
    profile: IProfile,
    // changePassword: (profile: IChangePasswordRQ) => void;
}






const ChangePassword: React.FC<IProps> = ({ profile }) => {

    const rootStore = useContext(RootStoreContext);
    const {
        changePassword
    } = rootStore.profileStore;


    // const rootStore = useContext(RootStoreContext);
    // const {
    //     profile,
    // } = rootStore.profileStore;

    const [passwordType, setPasswordType] = useState({
        oldpass: 'password',
        newpass: 'password',
        newpassconfirm: 'password'
    })


    const handleChangePassubmit = async (values: any) => {

        try {
            let res = await changePassword(values);
            if (res && res.status === 0 && res.statusCode === 400) {
                return { [FORM_ERROR]: 'پسورد اشتباست ' }

            }
            else if (res && res.status == 0)
                return { [FORM_ERROR]: 'پسورد اشتباست ' }
        } catch (error) {
            return { [FORM_ERROR]: 'خطایی رخداده' }
        }



        //    else if (res && status === 0 && statusCode === 400) {
        // return { [FORM_ERROR]: 'پسورد اشتباست ' }
        // err.then((res) => {
        //     return { [FORM_ERROR]: res }


        // })
        // try{
        //     err.then((res)=>{
        //         console.log(res)
        //     })
        // }

    };



    const handlePasswordType = (event: React.MouseEvent, selector: number) => {
        let res = ''
        if (selector == 0) {
            res = passwordType.oldpass === 'text' ? 'password' : 'text';
            setPasswordType(prevstate => ({ ...passwordType, oldpass: res }))
        }
        if (selector == 1) {
            res = passwordType.newpass === 'text' ? 'password' : 'text';
            setPasswordType(prevstate => ({ ...passwordType, newpass: res }))
        } if (selector == 2) {
            res = passwordType.newpassconfirm === 'text' ? 'password' : 'text'
            setPasswordType(prevstate => ({ ...passwordType, newpassconfirm: res }))
        }
    }



    return (
        <>
            <div className="tab-pane fade " id="nav-password" role="tabpanel" aria-labelledby="nav-password-tab">
                <div className="row w-100 mx-auto">
                    <div className="col-md-8 col-12 mx-auto">
                        <FinalForm
                            onSubmit={handleChangePassubmit}


                            // onSubmit={(values) =>
                            //   alert('submittes')
                            // }


                            validate={validate}
                            initialValues={{
                                oldPassword: '',
                                newPassword: '',
                                newPasswordConfirm: ''
                            }}

                            render={({
                                handleSubmit,
                                invalid,
                                pristine,
                                submitError,
                                submitting,
                                dirtySinceLastSubmit,
                                errors,
                                form
                            }) => (
                                    <Form onSubmit={handleSubmit} error >


                                        {submitError && !dirtySinceLastSubmit && (
                                            <div className="alert alert-danger text-center text-danger" role="alert">
                                                {submitError}
                                            </div>

                                        )}

                                        {/* {console.log(submitError)} */}
                                        <div className="form-group w-100 position-relative">
                                            <label className="text-right w-100 pr-3" htmlFor="password1"> رمز عبور فعلی</label>
                                            <Field
                                                name='oldPassword'
                                                placeholder=" ***************"
                                                type={passwordType.oldpass}
                                                className='form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark password'
                                                value=''
                                            >
                                                {props => (
                                                    <>
                                                        <input
                                                            {...props}
                                                            {...props.input}
                                                        />
                                                        <img src={window.location.origin + "/hj/img/View - Alt 1.svg"} className="img-fluid hj-pen" onClick={(e) => { handlePasswordType(e, 0) }} />
                                                        {props.meta.touched && props.meta.error && (
                                                            <label className='text-center d-block text-danger'> {props.meta.error}</label>
                                                        )}
                                                    </>
                                                )}
                                            </Field>
                                        </div>


                                        <div className="form-group w-100 position-relative">
                                            <label className="text-right w-100 pr-3" htmlFor="password2">رمز عبور جدید </label>
                                            <Field
                                                name='newPassword'
                                                placeholder=" ***************"
                                                type={passwordType.newpass}
                                                className='form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark password'
                                                value=''
                                            >
                                                {props => (
                                                    <>
                                                        <input
                                                            {...props}
                                                            {...props.input}
                                                        />
                                                        <img src={window.location.origin + "/hj/img/View - Alt 1.svg"} className="img-fluid hj-pen" onClick={(e) => { handlePasswordType(e, 1) }} />
                                                        {props.meta.touched && props.meta.error && (
                                                            <label className='text-center d-block text-danger'> {props.meta.error}</label>
                                                        )}
                                                    </>
                                                )}
                                            </Field>
                                        </div>



                                        <div className="form-group w-100 position-relative">
                                            <label className="text-right w-100 pr-3" htmlFor="password3"> تکرار رمز عبور جدید</label>


                                            <Field
                                                name='newPasswordConfirm'
                                                placeholder=" ***************"
                                                type={passwordType.newpassconfirm}
                                                className='form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark password'
                                                value=''
                                            >
                                                {props => (
                                                    <>
                                                        <input
                                                            {...props}
                                                            {...props.input}
                                                        />
                                                        <img src={window.location.origin + "/hj/img/View - Alt 1.svg"} className="img-fluid hj-pen" onClick={(e) => { handlePasswordType(e, 2) }} />
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
                                                    // disabled={(invalid && !dirtySinceLastSubmit) || pristine}
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








                        {/* <div className="form-group w-100 position-relative">
                            <label className="text-right w-100 pr-3" htmlFor="password1"> رمز عبور فعلی</label>

                            <input type={passwordType.oldpass} name='oldpass' className="form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark password" id="password1" placeholder=" ***************" />
                            <img src={window.location.origin + "/hj/img/View - Alt 1.svg"} className="img-fluid hj-pen" onClick={(e) => { handlePasswordType(e, 0) }} />
                        </div>
                        <div className="form-group w-100 position-relative">
                            <label className="text-right w-100 pr-3" htmlFor="password2">رمز عبور جدید </label>

                            <input type={passwordType.newpass} name='newpass' className="form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark password" id="password2" placeholder=" ***************" />
                            <img src={window.location.origin + "/hj/img/View - Alt 1.svg"} className="img-fluid hj-pen" onClick={(e) => { handlePasswordType(e, 1) }} />
                            <label className='text-center   d-block  text-danger'> error</label>
                        </div>
                        <div className="form-group w-100 position-relative">
                            <label className="text-right w-100 pr-3" htmlFor="password3"> تکرار رمز عبور جدید</label>
                            <input type={passwordType.newpassconfirm} name='newpassConfirm' className="form-control text-center hj-form-profile w-100 py-3 pr-3 text-dark password" id="password3" placeholder=" ***************" />
                            <img src={window.location.origin + "/hj/img/View - Alt 1.svg"} className="img-fluid hj-pen" onClick={(e) => { handlePasswordType(e, 2) }} />
                        </div>

                        <div className="row w-100 mx-auto mt-4 pt-4">
                            <button type="button" className="btn btn-success w-25 mx-auto Confirmation">ذخیره تنظیمات</button>
                        </div> */}

                    </div>
                </div>
            </div>


        </>
    )
}



export default observer(ChangePassword) 