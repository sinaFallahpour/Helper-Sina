import React from 'react';
// import { AxiosResponse } from 'axios';
// import { Message } from 'semantic-ui-react';

interface IProps {
    error: any;
    text?: string;
}

const ErrorMessage: React.FC<IProps> = ({ error, text }) => {

    // const handle40Error = () => {

    //     if (error && error?.data?.errors) {

    //         error.data.errors.map((prop: any, ind: any) => {

    //             prop.map((val:any,index:any)=>{
    //                     alert(val)

    //                 })

    //         })
    //     }

    // }
    return (

        <>
            {error?.status === 0 ?
                <div className="alert alert-danger text-danger" role="alert">{error?.message}</div>
                :
                null
            }
        </>

        // <Message error>

        //   <Message.Header>{error?.statusText}</Message.Header>
        //   {error?.data && Object.keys(error?.data?.errors).length > 0 && (
        //     <Message.List>
        //       {Object.values(error.data.errors).flat().map((err, i) => (
        //         <Message.Item key={i}>{err}</Message.Item>
        //       ))}
        //     </Message.List>
        //   )}
        //   {text && <Message.Content content={text} />}
        // </Message>
    );
};

export default ErrorMessage;
