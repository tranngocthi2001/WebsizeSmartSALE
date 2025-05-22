import React, { createContext, useContext, useState, useEffect } from 'react';

const AuthContext = createContext(null);

export const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);

  // Kiểm tra token đã lưu trong localStorage
  useEffect(() => {
    const token = localStorage.getItem('token');
    const hoTen = localStorage.getItem('hoTen');
    const vaiTro = localStorage.getItem('vaiTro');

    if (token && vaiTro === 'admin') {
      setUser({ hoTen, vaiTro, token });
    }
  }, []);

  const login = (data) => {
    localStorage.setItem('token', data.token);
    localStorage.setItem('hoTen', data.hoTen);
    localStorage.setItem('vaiTro', data.vaiTro);
    setUser({ hoTen: data.hoTen, vaiTro: data.vaiTro, token: data.token });
    console.log('data', data);
    console.log('user', user);
  };

  const logout = () => {
    localStorage.clear();
    setUser(null);
  };

  return (
    <AuthContext.Provider value={{ user, login, logout, isAuthenticated: !!user }}>
      {children}
    </AuthContext.Provider>
  );
};

// Hook dùng để truy cập context
export const useAuth = () => useContext(AuthContext);
