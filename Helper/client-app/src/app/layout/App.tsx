import React, { Fragment, useContext, useEffect } from 'react';
import { observer } from 'mobx-react-lite';
import {
  Route,
  withRouter,
  RouteComponentProps,
  Switch,
  Redirect
} from 'react-router-dom';



/* Pages */
import HomePage from './../../features/Home/HomePage';

import Header from '../layout/Header';
import Footer from '../layout/Footer'
import AboutUs from '../../features/aboutUs/AboutUs'
import ContactUS from '../../features/contactUs/ContactUS'

//Account
import Login from '../../features/Account/Login'
import Register from '../../features/Account/Register'

import NotFound from './NotFound';
/*End  Pages */



import { ToastContainer } from 'react-toastify';
import { RootStoreContext } from '../stores/rootStore';
import LoadingComponent from './LoadingComponent';
// import ModalContainer from '../common/modals/ModalContainer';

const App: React.FC<RouteComponentProps> = ({ location }) => {
  const rootStore = useContext(RootStoreContext);
  const { setAppLoaded, token, appLoaded } = rootStore.commonStore;
  const { getUser } = rootStore.userStore;

  useEffect(() => {
    if (token) {
      getUser().finally(() => setAppLoaded())
    } else {
      setAppLoaded();
    }
  }, [getUser, setAppLoaded, token])

  if (!appLoaded) return <LoadingComponent content='Loading app...' />

  return (
    <Fragment>
      {/* <ModalContainer /> */}
      <ToastContainer position='bottom-right' />


      <Header />
      < >
        <Switch>
          <Route exact path='/' component={HomePage} />
          <Route path='/aboutus' component={AboutUs} />
          <Route path='/contactus' component={ContactUS} />
          <Route path='/login' component={Login} />
          <Route path='/register' component={Register} />
          <Route  component={NotFound} />
          
        </Switch>
      </>
      <Footer />



    </Fragment>
  );
};

export default withRouter(observer(App));
