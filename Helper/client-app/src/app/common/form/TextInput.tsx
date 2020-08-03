import React from 'react';
import { FieldRenderProps } from 'react-final-form';
import { FormFieldProps } from 'semantic-ui-react';

interface IProps
    extends FieldRenderProps<string, HTMLInputElement>,
    FormFieldProps { }


const TextInput: React.FC<IProps> = ({
    input,
    meta: { touched, error },
    type,
    placeholder,
    className,
    width
}) => {
    return (
        < >
            <input {...input}
                placeholder={placeholder}
                className={className}
                autoComplete="off"
            />

            {touched && error && (
               
                    <label className="text-danger">
                        {error}
                    </label>
                
            )}
        </>
    );
};

export default TextInput;
