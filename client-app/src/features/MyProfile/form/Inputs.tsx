
import React, { useState, useContext, useEffect } from 'react'

import { FormFieldProps, Form as as, Label, Select } from 'semantic-ui-react';
import { Form as FinalForm, Field, FieldRenderProps } from 'react-final-form';
import { values } from 'mobx';







interface IProps2
    extends FieldRenderProps<string, HTMLInputElement>,
    FormFieldProps { }


export const TextInput: React.FC<IProps2> = ({
    input,
    meta: { touched, error },
    placeholder,
    className,
    label,
    width,
    value,

}) => {

    return (
        < >
            <label
                className='text-right w-100 pr-3 mt-md-3'
                htmlFor={input.name}
            >
                {label}
            </label>
            <input
                autoComplete='off'
                placeholder={placeholder}
                {...input}
                className={className}
                value={input.value}
            />
            {touched && error && (
                <label className='text-center d-block text-danger'> {error}</label>
            )}
        </>
    );
};






interface IProp3
    extends FieldRenderProps<string, HTMLSelectElement>,
    FormFieldProps { }

export const SelectInput: React.FC<IProp3> = ({
    input,
    meta: { touched, error },
    placeholder,
    className,
    label,
    width,
    value,
    options,
}) => {

    const [selectedOption, setSelectedOption] = useState(input.value);

    return (
        <>
            <label
                className='text-right w-100 pr-3 mt-md-3'
                htmlFor={input.name}
            >
                {label}
            </label>

            <select
             className={className} 
             value={selectedOption}
             placeholder={selectedOption}
                onChange={e => setSelectedOption(e.target.value)}>
                {options.map((e: any, index: any) => {
                    return (
                        <option
                            selected={input.value == e.value}
                            value={e.value}
                            key={index} >
                            {e.text}
                        </option>)
                })}
            </select>


            {/* <Select
                value={input.value}
                onChange={(e, data) => input.onChange(data.value)}
                placeholder={placeholder}
                options={options}
                className={className}
            /> */}
            {
                touched && error && (
                    <label className='text-center d-block text-danger'> {error}</label>
                )
            }


        </>
    )
}

export default SelectInput
