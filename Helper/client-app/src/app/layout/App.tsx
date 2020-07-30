import React, { Fragment, useContext, useEffect } from 'react';
import { observer } from 'mobx-react-lite';
import {
  Route,
  withRouter,
  RouteComponentProps,
  Switch
} from 'react-router-dom';

import HomePage from './../../features/Home/HomePage';
import NotFound from './NotFound';

import Header from '../layout/Header';
import Footer from '../layout/Footer'

import { ToastContainer } from 'react-toastify';
import { RootStoreContext } from '../stores/rootStore';
import LoadingComponent from './LoadingComponent';
import ModalContainer from '../common/modals/ModalContainer';

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
      <ModalContainer />
      <ToastContainer position='bottom-right' />

      
      <Header />
      < >
        <Switch>
          <Route exact path='/' component={HomePage} />

        </Switch>
      </>
      <Footer />
      
      
      {/* <Route
        path={'/(.+)'}
        render={() => (
          <Fragment>
            <Header />
            < >
              <Switch>
                <Route exact path='/activities' component={ActivityDashboard} />
                <Route path='/activities/:id' component={ActivityDetails} />
                <Route
                  key={location.key}
                  path={['/createActivity', '/manage/:id']}
                  component={ActivityForm}
                />
                <Route path='/profile/:username' component={ProfilePage} />
                <Route component={NotFound} />
              </Switch>
            </>
            <Footer />
          </Fragment>
        )}
      /> */}
    </Fragment>
  );
};

export default withRouter(observer(App));
