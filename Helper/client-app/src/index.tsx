import React from 'react';
import ReactDOM from 'react-dom';
import * as serviceWorker from './serviceWorker';
import { Router } from 'react-router-dom';
import App from './app/layout/App';

import { createBrowserHistory } from 'history';



export const history = createBrowserHistory();


ReactDOM.render(
  <React.StrictMode>
    <Router history={history}>
      <App />
    </Router>
  </React.StrictMode>,
  document.getElementById('root')
);



serviceWorker.unregister();
