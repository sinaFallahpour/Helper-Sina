import React, { useContext } from 'react'
import { Route, Redirect } from "react-router-dom";
import { RootStoreContext } from '../../stores/rootStore';


interface IProps {
    path: string,
    targetPath: string,
    exact: boolean,
    component: React.FC,
}


const ProtectedRout: React.FC<IProps> = ({ path, targetPath, exact, component: Component, ...rest }) => {

    const rootStore = useContext(RootStoreContext);
    const { isLoggedIn } = rootStore.userStore;

    return (
        isLoggedIn ?

            (<Route path={path} exact={exact} component={Component} {...rest}/>)
            :
            (<Redirect to={{
                pathname: "/login",
                state: { from: targetPath }
            }}
            />)
        )

}

export default ProtectedRout;