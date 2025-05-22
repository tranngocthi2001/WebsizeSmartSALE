import React from 'react';
import { Navigate } from 'react-router-dom';
import { useAuth } from '../contexts/AuthContext';

const PrivateRoute = ({ children }) => {
  const { isAuthenticated, user } = useAuth();

  if (!isAuthenticated || user.vaiTro !== 'admin') {
    return <Navigate to="/login" />;
  }

  return children;
};

export default PrivateRoute;
