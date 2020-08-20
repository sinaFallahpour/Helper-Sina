
import React, { useState, useContext, useEffect } from 'react'

import { FormFieldProps, Form as as, Label, Select, Form } from 'semantic-ui-react';
import { Form as FinalForm, Field, FieldRenderProps } from 'react-final-form';




interface IProps1
    extends FieldRenderProps<string, HTMLInputElement>,
    FormFieldProps { }


export const TextInput: React.FC<IProps1> = ({
    input,
    meta: { touched, error },
    placeholder,
    className,
    label,
    width,
    value,
    inpId,

}) => {

    return (
        < >
            <input
                autoComplete='off'
                placeholder={placeholder}
                {...input}
                className={className}
                value={input.value}
                id={inpId!}
            />
            {touched && error && (
                <label className='text-center w-100 text-danger'> {error}</label>
            )}
        </>
    );
};







interface IProps2
    extends FieldRenderProps<string, HTMLTextAreaElement>,
    FormFieldProps { }

export const TextAreaInput: React.FC<IProps2> = ({
    input,
    width,
    rows,
    className,
    placeholder,

    meta: { touched, error, submitError }
}) => {
    return (
        <>
            <textarea rows={rows} className={className} autoComplete='off' {...input} placeholder={placeholder} />
            {
                touched && error && (
                    <label className='text-center w-100 text-danger'> {error}</label>
                )
            }
            {/* {
                submitError[input?.name]&&(
                    submitError[input.name]
                )
            } */}
        </>
    );
};








// interface IProps
//   extends FieldRenderProps<string, HTMLSelectElement>,
//     FormFieldProps {}

// const SelectInput: React.FC<IProps> = ({
//     input,
//     width,
//     options,
//     placeholder,
//     meta: { touched, error }
//   }) => {
//     return (
//         <Form.Field error={touched && !!error} width={width}>
//         <Select 
//             value={input.value}
//             onChange={(e, data) => input.onChange(data.value)}
//             placeholder={placeholder}
//             options={options}
//         />
//         {touched && error && (
//           <Label basic color='red'>
//             {error}
//           </Label>
//         )}
//       </Form.Field>
//     )
// }

// export default SelectInput





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
    defaultText
}) => {

    // const [selectedOption, setSelectedOption] = useState(input.value);
    return (
        <>
            <select
                className={className}
                // value={selectedOption}
                // placeholder={selectedOption}

                onChange={(e) => input.onChange(e.target.value)}>
                <option value="-1" selected>{defaultText} </option>
                {options.map((e: any, index: any) => {
                    return (
                        <option
                            // selected={input.value == e.value}
                            value={e.id}
                            key={index} >
                            {e.name}
                        </option>)
                })}

            </select>
            {
                touched && error && (
                    <label className='text-center w-100 text-danger'> {error}</label>
                )
            }
          
        </>
    )
}

export default SelectInput
