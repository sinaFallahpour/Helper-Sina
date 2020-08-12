import React from 'react';
import { FieldRenderProps } from 'react-final-form';
import { FormFieldProps, Form } from 'semantic-ui-react';

interface IProps
    extends FieldRenderProps<string, HTMLInputElement>,
    FormFieldProps { }


const TextInput: React.FC<IProps> = ({
    input,
    meta: { touched, error },
    placeholder,
    className,
    width
}) => {
    return (
        < >
          {/* <Form.Field error={touched && !!error} type={type} width={width}> */}
            <input {...input}
                placeholder={placeholder}
                className={className + ' d-block'}
                autoComplete="off"
               
            />

            {touched && error && (

                <label className="text-danger w-10 d-block">
                    {error}
                </label>

            )}
            {/* </Form.Field> */}
        </>
    );
};

export default TextInput;
