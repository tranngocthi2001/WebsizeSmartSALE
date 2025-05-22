import React from 'react';
import { createRoot } from 'react-dom/client';

import { ConfigProvider } from './contexts/ConfigContext';

import './index.scss';
import App from './App.jsx';
import reportWebVitals from './reportWebVitals';

const container = document.getElementById('root');
const root = createRoot(container);
root.render(
  <ConfigProvider>
    <App />
  </ConfigProvider>
);

reportWebVitals();
