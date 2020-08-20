import React, { useState, useContext, useEffect } from 'react'

import { observer } from 'mobx-react-lite';






// import { IProfileRE } from '../../app/models/profile';
import { Form as FinalForm, Field, FieldRenderProps } from 'react-final-form';
import { TextInput, SelectInput, TextAreaInput } from './form/Inputs'
import { FORM_ERROR } from 'final-form';
import { Form, Button, Input } from 'semantic-ui-react';

import { WithContext as ReactTags } from 'react-tag-input';


import {
    combineValidators,
    isRequired,
    composeValidators,
    hasLengthGreaterThan,
    hasLengthLessThan,
    hasLengthBetween,
    isNumeric,
    matchesPattern,
    createValidator,

} from 'revalidate';
import { RootStoreContext } from '../../app/stores/rootStore';
import { ISelectInfo } from '../../app/models/service';



//validate BankAccount 
const validate = combineValidators({


    title: composeValidators(
        isRequired({ message: '  عنوان خدمت الزامیست ' }),
        hasLengthGreaterThan(2)({ message: "حداقل 3 کاراکتر وارد کنید" }),
        hasLengthLessThan(49)({ message: " حداکثر 48 کاراکتر وارد کنید " })
    )('title'),



    description: composeValidators(
        isRequired({ message: '  توضیحات خدمت الزامیست ' }),
        hasLengthGreaterThan(2)({ message: "حداقل 3 کاراکتر وارد کنید" }),
        hasLengthLessThan(299)({ message: " حداکثر 298 کاراکتر وارد کنید " })
    )('description'),


    price: composeValidators(
        isRequired({ message: '  قیمت خدمت الزامیست ' }),
        hasLengthLessThan(17)({ message: 'قیمت را درست وارد کنید' }),
        isNumeric({ message: " عدد وارد کنید" })

    )('price'),


    isSendByEmail: composeValidators(
        isRequired({ message: ' وضعیت ارسال  الزامیست ' }),
    )('isSendByEmail'),


    isSendByNOtification: composeValidators(
        isRequired({ message: ' وضعیت ارسال  الزامیست ' }),

    )('isSendByNOtification'),

    isSendBySms: composeValidators(
        isRequired({ message: ' وضعیت ارسال  الزامیست ' }),
    )('isSendBySms'),

    isAgreement: composeValidators(
        isRequired({ message: ' وضعیت توافق  الزامیست ' }),
    )('isAgreement'),

    cityId: composeValidators(
        isRequired({ message: ' شهر   الزامیست ' }),
        // isNumeric({ message: 'به فرمت  موبایل وارد کنید' }),
    )('cityId'),

    categoryId: composeValidators(
        isRequired({ message: '  دسته بندی  الزامیست ' }),
        // isNumeric({ message: 'به فرمت  موبایل وارد کنید' }),
    )('categoryId'),

    monyUnitId: composeValidators(
        isRequired({ message: '  واحد پول  الزامیست ' }),
        // isNumeric({ message: 'به فرمت  موبایل وارد کنید' }),
    )('monyUnitId'),

})






const KeyCodes = {
    comma: 188,
    enter: 13,
};

const delimiters = [KeyCodes.comma, KeyCodes.enter];


interface IProps {

    selectList: ISelectInfo
}

const DonnerCreateService: React.FC<IProps> = ({ selectList }) => {



    const rootStore = useContext(RootStoreContext);

    const {
        createService,
        loadingSubmitingForm
    } = rootStore.serviceStore;





    //ایا   باز است یا نه
    // const [IsOpen, setIsOpen] = useState(true);

    // const handleOpenSelect = () => {
    //     setIsOpen(prevstate => !prevstate)
    // }

    const [tags, setTags] = useState<{ id: string, text: string }[]>()


    // tags: [
    //     { id: "Thailand", text: "Thailand" },
    //     { id: "India", text: "India" }
    // ],




    const handleDeleteTags = (i: any) => {

        alert(1)
    }

    const handleAdditionTags = (tag: { id: string, text: string }) => {

        var res = [...tags!, tag]
        setTags(res)

    }

    // handleDelete(i) {
    //     const { tags } = this.state;
    //     this.setState({
    //         tags: tags.filter((tag, index) => index !== i),
    //     });
    // }

    // handleAdditionTags(tag) {
    //     this.setState(state => ({ tags: [...state.tags, tag] }));
    // }



    const submit = async (values: any) => {




        console.log(validate)
        let isValid = true;
        var errors = {
            categoryId: '',
            cityId: '',
            monyUnitId: ''
        }

        if (values.categoryId === '-1') {
            isValid = false;
            errors.categoryId = 'لطفا دسته بندی را انتخاب کنید'
        } else
            delete errors.categoryId
        if (values.cityId === '-1') {
            isValid = false;
            errors.cityId = 'لطفا شهر را انتخاب کنید'
        } else
            delete errors.cityId

        if (values.monyUnitId === '-1') {
            isValid = false;
            errors.monyUnitId = 'لطفا واحد را انتخاب کنید'
        }
        else
            delete errors.monyUnitId;
        if (!isValid)
            return errors

        // return null





        // // validate(values)
        try {
            let res = await createService(values);
            // if (res && res.status === 0 && res.statusCode === 400) {
            //     return { [FORM_ERROR]: 'پسورد اشتباست ' }
            // }
            if (res && res.status == 0)
                return { [FORM_ERROR]: res.message }
        } catch (error) {
            return { [FORM_ERROR]: 'خطایی رخ داده' }
        }
    };


    const validatSubmit = (values: any) => {


    }

    // isSendByEmail: composeValidators(
    //     isRequired({ message: ' وضعیت ارسال  الزامیست ' }),
    // )('isSendByEmail'),


    // isSendByNOtification: composeValidators(
    //     isRequired({ message: ' وضعیت ارسال  الزامیست ' }),
    // )('isSendByNOtification'),

    // isSendBySms: composeValidators(
    //     isRequired({ message: ' وضعیت ارسال  الزامیست ' }),
    // )('isSendBySms'),



    return (
        <>
            <FinalForm
                onSubmit={submit}
                validate={validate}
                initialValues={{
                    isSendByEmail: false,
                    isSendByNOtification: false,
                    isSendBySms: false,
                    isAgreement: true
                }}

                render={({
                    handleSubmit,
                    invalid,
                    pristine,
                    submitError,
                    submitting,
                    dirtySinceLastSubmit,
                    form,
                    submitErrors,
                    hasSubmitErrors
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


                            {/* {hasSubmitErrors && (
                                <div>
                                    submitErrors
                                </div>
                            )} */}
                            <pre>{JSON.stringify(form.getState(), null, 2)}</pre>
                            <div className="row w-100 mx-auto my-3  text-center ">
                                <Field
                                    name='title'
                                    component={TextInput}
                                    type="text"
                                    id="title"
                                    className='text-center form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput'
                                    placeholder='عنوان خدمت'
                                    label='عنوان خدمت'
                                />
                            </div>
                            <div className="row w-100 mx-auto my-3  text-center ">

                                <Field
                                    name='description'
                                    component={TextAreaInput}
                                    rows={3}
                                    id="description"
                                    className='text-center w-100 pt-2 pb-5 text-justify service-form-detalis service-form text-dark'
                                    placeholder='توضیحات خدمت'

                                />
                            </div>



                            <div className="form-group">


                                <Field
                                    name='cityId'
                                    component={SelectInput}
                                    options={selectList.cities}
                                    id="cityId"
                                    className="form-control my-3 service-form"
                                    defaultText="انتخاب شهر"

                                //  value="انتخاب شهر"
                                // label="جنسیت"
                                />


                                {/* <select className="form-control my-3 service-form" id="exampleFormControlSelect1">
                                    <option value="-1" >انتخاب شهر </option>
                                    {selectList?.cities?.map((city, index) => {
                                        return (
                                            <option value={city.id} key={index}> {city.name} </option>
                                        )
                                    })}

                                </select> */}
                            </div>



                            <div className="form-group">

                                <Field
                                    name='categoryId'
                                    component={SelectInput}
                                    options={selectList.categories}
                                    id="categoryId"
                                    className="form-control my-3 service-form"
                                    defaultText="انتخاب دسته بندی"
                                //  value="انتخاب شهر"
                                // label="جنسیت"
                                />


                                {/* <select className="form-control my-3 service-form" id="exampleFormControlSelect1">
                                    <option selected value="-1" >انتخاب دسته بندی </option>
                                    {selectList?.categories?.map((category, index) => {
                                        return (
                                            <option value={category.id} key={index}>{category.name}</option>
                                        )
                                    })}
                                </select> */}
                            </div>



                            <div className="row w-100 mx-auto my-3 ">

                                <ReactTags

                                    //tags={tags}
                                    //  suggestions={suggestions}
                                    handleDelete={handleDeleteTags}
                                    handleAddition={handleAdditionTags}
                                //     handleDrag={this.handleDrag}
                                    delimiters={delimiters} 

                                // classNames="col-12 service-form mx-auto text-right pt-2 pr-3"
                                />

                                <input type="text" className="col-12 service-form mx-auto text-right pt-2 pr-3" placeholder=" مهارت مورد نظر" />

                                {/* <div className="col-2  mx-auto">
                       <i className="fas fa-chevron-down pl-3 pt-3 " id="select-down"></i>
                     </div> */}
                            </div>


                            <div className="row w-100 mx-auto hj-select">
                                <div className="col-sm-2 col-12 py-2">
                                    <button type="button" className="btn  w-100 button-Service">مهارت</button>
                                </div>
                                <div className="col-sm-2 col-12  py-2">
                                    <button type="button" className="btn  w-100 button-Service">مهارت</button>
                                </div>
                                <div className="col-sm-2 col-12  py-2">
                                    <button type="button" className="btn  w-100 button-Service">مهارت</button>
                                </div>
                                <div className="col-sm-2 col-12  py-2">
                                    <button type="button" className="btn  w-100 button-Service">مهارت</button>
                                </div>
                                <div className="col-sm-2 col-12  py-2">
                                    <button type="button" className="btn  w-100 button-Service">مهارت</button>
                                </div>
                                <div className="col-sm-2 col-12  py-2">
                                    <button type="button" className="btn  w-100 button-Service">مهارت</button>
                                </div>
                            </div>




                            <div className="row w-100 mx-auto">
                                <div className="col-lg-10 col-md-8 col-6">
                                    <h5 className="text-right Pricerange ">بازه قیمت</h5>
                                </div>
                                <div className="col-lg-2 col-md-4 col-6 text-news">


                                    <Field
                                        name='monyUnitId'
                                        component={SelectInput}
                                        options={selectList?.monyUnits}
                                        id="monyUnitId"
                                        className="form-control text-left currency"
                                        defaultText=" واحد پول"

                                    //  value="انتخاب شهر"
                                    // label="جنسیت"
                                    />




                                    {/* <select className="form-control text-left currency  ">
                                        <i
                                            id='Pricerange-down'
                                            className={IsOpen ? 'fa-chevron-up fas fa-chevron-down pl-3 pt-3 mr-3' : 'fas fa-chevron-down pl-3 pt-3 mr-3'}
                                            onClick={() => { handleOpenSelect() }}
                                        >
                                        </i>
                                        <option selected value="-1">   واحد پول </option>
                                        {selectList?.monyUnits?.map((mony, index) => {
                                            return (
                                                <option value={mony.id} key={index}> {mony.name} </option>
                                            )
                                        })}

                                    </select> */}
                                </div>
                            </div>




                            <div className="row w-100 mx-auto my-3  text-center ">
                                <Field
                                    name='price'
                                    component={TextInput}
                                    type="number"
                                    id="price"
                                    className='form-control hj-form-profile w-100 py-3 pr-3 text-dark _formInput'
                                    placeholder='فیمت '
                                    label=''
                                />
                            </div>


                            {/* <div
                                className={IsOpen ? ' hj-cost-service-block row w-100 mx-auto hj-cost-service pb-5' : 'row w-100 mx-auto hj-cost-service pb-5'}

                            >
                                <div className="col-sm-6 py-2">
                                    <input type="text" className="form-control text-center hj-input-service py-3" placeholder="از قیمت" />
                                </div>
                                <div className="col-sm-6 py-2">
                                    <input type="text" className="form-control text-center hj-input-service py-3 " placeholder="تا قیمت" />
                                </div>
                            </div> */}
                            <div className="row w-100 mx-auto ">
                                <div className="col-12 text-right">
                                    <Field
                                        name='isAgreement'
                                        type="checkbox"
                                        component={TextInput}
                                        inpId="isAgreement"
                                        className="checkbox-service "
                                    />

                                    {/* <input name="TS1" value=" TS asa1, " type="checkbox" id="checkbox1" className="checkbox-service" /> */}
                                    <label htmlFor="isAgreement" className="label-chekbox"> توافقی</label>
                                </div>
                            </div>
                            <div className="row w-100 p-0 m-0 mx-auto pt-md-3 pt-5 mt-3">
                                <div className="col-12  text-right"><h5><b> نحوه ارسال به خدمات دهندگان</b></h5></div>

                            </div>
                            <div className="row w-100 mx-auto">
                                <img src={window.location.origin + "/hj/img/borderbig green.png"} className="img-fluid mx-auto" alt='Responsive images' />
                                {/* <img src="~/hj/img/borderbig green.png" className="img-fluid mx-auto" /> */}
                            </div>

                            <div className="row w-100 mx-auto text-md-center text-right mt-3">
                                <div className="col-md-4">

                                    <Field
                                        name='isSendByEmail'
                                        type="checkbox"
                                        component={TextInput}
                                        inpId="isSendByEmail"
                                        className="checkbox-service "
                                    />

                                    <label htmlFor="isSendByEmail" className="label-chekbox"> ایمیل</label>
                                    {/* <input name="TS1" value=" TS 1, " type="checkbox" id="checkbox11" className="checkbox-service" />
                                    <label htmlFor="checkbox11" className="label-chekbox"> ایمیل</label> */}
                                </div>

                                <div className="col-md-4">
                                    <Field
                                        name='isSendByNOtification'
                                        type="checkbox"
                                        component={TextInput}
                                        inpId="isSendByNOtification"
                                        className="checkbox-service "
                                    />
                                    <label htmlFor="isSendByNOtification" className="label-chekbox"> نوتیفیکیشن</label>


                                    {/* <input name="TS1" value=" TS 1, " type="checkbox" id="checkbox3" className="checkbox-service" />
                                    <label htmlFor="checkbox3" className="label-chekbox"> نوتیفیکیشن</label> */}
                                </div>
                                <div className="col-md-4">

                                    <Field
                                        name='isSendBySms'
                                        type="checkbox"
                                        component={TextInput}
                                        inpId="isSendBySms"
                                        className="checkbox-service "
                                    />
                                    <label htmlFor="isSendBySms" className="label-chekbox"> اس ام اس</label>



                                </div>
                            </div>






                            <div className="row w-100 mx-auto mt-4 pt-4">
                                {submitting || loadingSubmitingForm ?
                                    <div className="row text-center mt-5">
                                        <button className="button btn btn-success w-25 mx-auto Confirmation" type="button" disabled>
                                            <span className="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                                            <span className="sr-only">Loading...</span>
                                        </button>
                                    </div>
                                    :

                                    <Button
                                        className='btn btn-success w-25 mx-auto Confirmation '
                                        disabled={((invalid && !dirtySinceLastSubmit) || pristine)}
                                        loading={submitting}
                                        content='تایید'
                                        fluid
                                    />

                                }
                            </div>











                            {/* <div className="row w-100 mx-auto mt-4 pt-4">
                                <button type="button" className="btn btn-success w-25 mx-auto Confirmation">تایید</button>
                            </div> */}

                        </Form>
                    )}
            />


            {/* 


isSendByEmail: composeValidators(
        isRequired({ message: ' وضعیت ارسال  الزامیست ' }),
    )('isSendByEmail'),


    isSendByNOtification: composeValidators(
        isRequired({ message: ' وضعیت ارسال  الزامیست ' }),
    )('isSendByNOtification'),

    isSendBySms: composeValidators(
        isRequired({ message: ' وضعیت ارسال  الزامیست ' }),
    )('isSendBySms'),

 */}

























            {/* <div className="row w-100 mx-auto my-3  text-center ">

                <input type="text" className="text-center service-form w-100 pt-2" placeholder="تایتل خدمت" />
                <span className=" text-center w-100">sdhsyud</span>

            </div>
            <div className="row w-100 mx-auto my-3  text-center ">

                <textarea
                    className="text-center w-100 pt-2 pb-5 text-justify service-form-detalis service-form text-dark"
                    placeholder=" لورم ایکاربردهای متنوع با هدف">

                </textarea>


            </div> */}
            {/* <div className="row w-100 mx-auto my-3 service-form">
        <div className="col-10  mx-auto text-right pt-2 pr-3">
            <h5> دسته بندی</h5>
        </div>
        <div className="col-2  mx-auto">
            <i className="fas fa-chevron-down pl-3 pt-3"></i>
        </div>
        </div> 
            <div className="form-group">

                <select className="form-control my-3 service-form" id="exampleFormControlSelect1">
                    <option>استان</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                </select>
            </div>
            <div className="form-group">

                <select className="form-control my-3 service-form" id="exampleFormControlSelect1">
                    <option>شهر</option>
                    <option>2</option>
                    <option>3</option>
                    <option>4</option>
                    <option>5</option>
                </select>
            </div>

            <div className="row w-100 mx-auto my-3 ">
                <input type="text" className="col-12 service-form mx-auto text-right pt-2 pr-3" placeholder=" مهارت مورد نظر" />

              
            </div>
            <div className="row w-100 mx-auto hj-select">
                <div className="col-sm-2 col-12 py-2">
                    <button type="button" className="btn  w-100 button-Service">مهارت</button>
                </div>
                <div className="col-sm-2 col-12  py-2">
                    <button type="button" className="btn  w-100 button-Service">مهارت</button>
                </div>
                <div className="col-sm-2 col-12  py-2">
                    <button type="button" className="btn  w-100 button-Service">مهارت</button>
                </div>
                <div className="col-sm-2 col-12  py-2">
                    <button type="button" className="btn  w-100 button-Service">مهارت</button>
                </div>
                <div className="col-sm-2 col-12  py-2">
                    <button type="button" className="btn  w-100 button-Service">مهارت</button>
                </div>
                <div className="col-sm-2 col-12  py-2">
                    <button type="button" className="btn  w-100 button-Service">مهارت</button>
                </div>
            </div>

            <div className="row w-100 mx-auto">
                <div className="col-lg-10 col-md-8 col-6">
                    <h5 className="text-right Pricerange ">بازه قیمت</h5>
                </div>
                <div className="col-lg-2 col-md-4 col-6 text-news">

                    <select className="form-control text-left currency  ">
                        <i
                            id='Pricerange-down'
                            className={IsOpen ? 'fa-chevron-up fas fa-chevron-down pl-3 pt-3 mr-3' : 'fas fa-chevron-down pl-3 pt-3 mr-3'}
                            onClick={() => { handleOpenSelect() }}
                        >

                        </i>
                        <option>واحد پول</option>
                        <option>2</option>
                        <option>3</option>
                        <option>4</option>
                        <option>5</option>
                    </select>
                </div>
            </div>
            <div
                className={IsOpen ? ' hj-cost-service-block row w-100 mx-auto hj-cost-service pb-5' : 'row w-100 mx-auto hj-cost-service pb-5'}

            >
                <div className="col-sm-6 py-2">  <input type="text" className="form-control text-center hj-input-service py-3" placeholder="از قیمت" /></div>
                <div className="col-sm-6 py-2"> <input type="text" className="form-control text-center hj-input-service py-3 " placeholder="تا قیمت" /></div>
            </div>
            <div className="row w-100 mx-auto ">
                <div className="col-12 text-right">
                   

                    <input name="TS1" value=" TS asa1, " type="checkbox" id="checkbox1" className="checkbox-service" />
                    <label htmlFor="checkbox1" className="label-chekbox"> توافقی</label>
                </div>
            </div>
            <div className="row w-100 p-0 m-0 mx-auto pt-md-3 pt-5 mt-3">
                <div className="col-12  text-right"><h5><b> نحوه ارسال به خدمات دهندگان</b></h5></div>

            </div>
            <div className="row w-100 mx-auto">

                <img src={window.location.origin + "/hj/img/borderbig green.png"} className="img-fluid mx-auto" alt='Responsive images' />

               
            </div>

            <div className="row w-100 mx-auto text-md-center text-right mt-3">
                <div className="col-md-4">  <input name="TS1" value=" TS 1, " type="checkbox" id="checkbox11" className="checkbox-service" /><label htmlFor="checkbox11" className="label-chekbox"> ایمیل</label></div>

                <div className="col-md-4">  <input name="TS1" value=" TS 1, " type="checkbox" id="checkbox3" className="checkbox-service" /><label htmlFor="checkbox3" className="label-chekbox"> نوتیفیکیشن</label></div>
                <div className="col-md-4">  <input name="TS1" value=" TS 1, " type="checkbox" id="checkbox4" className="checkbox-service" /><label htmlFor="checkbox4" className="label-chekbox"> اس ام اس</label></div>
            </div>
            <div className="row w-100 mx-auto mt-4 pt-4">
                <button type="button" className="btn btn-success w-25 mx-auto Confirmation">تایید</button>
            </div>
    */}

        </>
    )
}



export default observer(DonnerCreateService)