import React, { Fragment, useContext, useEffect } from 'react';
import { observer } from 'mobx-react-lite';
import {
  Route,
  withRouter,
  RouteComponentProps,
  Switch,
  Redirect,
  Router,
} from 'react-router-dom';


/* Pages */
import HomePage from './../../features/Home/HomePage';

import Header from '../layout/Header';
import Footer from '../layout/Footer'
import AboutUs from '../../features/aboutUs/AboutUs'
import ContactUS from '../../features/contactUs/ContactUS'

//news
import NewsPage from '../../features/news/NewsPage'

//Account
import Login from '../../features/Account/Login'
import LogOut from '../../features/Account/LogOut'
import MyProfilePage from '../../features/MyProfile/MyProfilePage'


//account Settings
import AccountSettingsPage from '../../features/AccountSettings/AccountSettingsPage'

import NotFound from './NotFound';
/*End  Pages */



import { ToastContainer } from 'react-toastify';
import { RootStoreContext } from '../stores/rootStore';
import LoadingComponent from './LoadingComponent';
import ProtectedRout from '../common/ProtectedRout/protectedRout';
// import ModalContainer from '../common/modals/ModalContainer';

const App: React.FC<RouteComponentProps> = ({ location }) => {
  const rootStore = useContext(RootStoreContext);
  const { setAppLoaded, token, appLoaded } = rootStore.commonStore;
  const { getUser, isLoggedIn } = rootStore.userStore;

  useEffect(() => {

    if (token) {
      getUser().
        finally(() => setAppLoaded())
    } else {
      setAppLoaded();
    }
  }, [getUser, setAppLoaded, token])

  if (!appLoaded) return <LoadingComponent />

  return (
    <Fragment>
      {/* <ModalContainer /> */}
      <ToastContainer position='bottom-right' />

      <Header />
      < >
        <Switch>
          <Route exact path='/' component={HomePage} />
          <Route path='/aboutus' component={AboutUs} />
          <Route path='/newses' component={NewsPage} />
          <Route path='/contactus' component={ContactUS} />

          <Route exact path='/login' component={Login} />
          <Route path='/LogOut' component={LogOut} />






          {/* <Route path='/profile/id:string' component={MyProfilePage} /> */}


          <Route
            path='/profile/:id'
            exact={true}
            render={props => {
              if (!isLoggedIn) {
                return <Redirect to={{
                  pathname: "/login",
                  state: { from: props.location },
                }} />
              }
              else {
                return <MyProfilePage {...props} />
              }
            }}
          />



          {/* <Route path='/profile/id:string' component={MyProfilePage} /> */}

          {/* <ProtectedRout
            path="/AccountSettingsPage/:username"
            targetPath='/login'
            exact={true}
            component={AccountSettingsPage}
          /> */}

          <Route
            path='/AccountSettingsPage/:id'
            exact={true}
            render={props => {
              if (!isLoggedIn) {
                return <Redirect to={{
                  pathname: "/login",
                  state: { from: props.location },
                }} />
              }
              else {
                return <AccountSettingsPage {...props} />
              }

            }}
          />


          <Route component={NotFound} />

        </Switch>
      </>
      <Footer />



    </Fragment>
  );
};

export default withRouter(observer(App));
