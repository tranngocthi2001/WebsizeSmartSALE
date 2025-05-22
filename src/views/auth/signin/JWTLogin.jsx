import React from 'react';
import { Row, Col, Alert, Button } from 'react-bootstrap';
import * as Yup from 'yup';
import { Formik } from 'formik';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '../../../contexts/AuthContext';
// import { c } from 'vite/dist/node/moduleRunnerTransport.d-DJ_mE5sf';

const JWTLogin = () => {
  // const { login } = useAuth();
  const auth = useAuth() || {};
  const { login } = auth;

  const navigate = useNavigate();

  return (
    <Formik
      initialValues={{
        tenTaiKhoan: '',
        matKhau: '',
        submit: null
      }}
      validationSchema={Yup.object().shape({
        tenTaiKhoan: Yup.string().required('Tên tài khoản là bắt buộc'),
        matKhau: Yup.string().required('Mật khẩu là bắt buộc')
      })}
      onSubmit={async (values, { setErrors, setSubmitting }) => {
        try {
          const response = await fetch('http://localhost:5148/api/Auth/login', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify({
              tenTaiKhoan: values.tenTaiKhoan,
              matKhau: values.matKhau
            })
            
          });
// console.log('values', values);
// console.log('response', response);
          if (!response.ok) {
            throw new Error('Sai thông tin đăng nhập');
          }

          const data = await response.json();
          // console.log('data', data);
          if (data.vaiTro !== 'admin') {
            throw new Error('Bạn không có quyền truy cập vào trang này');
          }
          login(data); // Cập nhật context và localStorage
          navigate('/app/dashboard/default'); // ✅ KHỚP với route đã định nghĩa
          } catch (error) {
          setErrors({ submit: error.message });
        } finally {
          setSubmitting(false);
        }
      }
      }
    >
      {({ errors, handleBlur, handleChange, handleSubmit, isSubmitting, touched, values }) => (
        <form noValidate onSubmit={handleSubmit}>
          <div className="form-group mb-3">
            <input
              className="form-control"
              placeholder="Tên tài khoản"
              name="tenTaiKhoan"
              onBlur={handleBlur}
              onChange={handleChange}
              value={values.tenTaiKhoan}
            />
            {touched.tenTaiKhoan && errors.tenTaiKhoan && (
              <small className="text-danger form-text">{errors.tenTaiKhoan}</small>
            )}
          </div>

          <div className="form-group mb-4">
            <input
              className="form-control"
              placeholder="Mật khẩu"
              name="matKhau"
              type="password"
              onBlur={handleBlur}
              onChange={handleChange}
              value={values.matKhau}
            />
            {touched.matKhau && errors.matKhau && (
              <small className="text-danger form-text">{errors.matKhau}</small>
            )}
          </div>

          <div className="custom-control custom-checkbox text-start mb-4 mt-2">
            <input type="checkbox" className="custom-control-input mx-2" id="customCheck1" />
            <label className="custom-control-label" htmlFor="customCheck1">
              Ghi nhớ tài khoản
            </label>
          </div>

          {errors.submit && (
            <Col sm={12}>
              <Alert variant="danger">{errors.submit}</Alert>
            </Col>
          )}

          <Row>
            <Col>
              <Button className="btn-block mb-4" type="submit" variant="primary" disabled={isSubmitting}>
                Đăng nhập
              </Button>
            </Col>
          </Row>
        </form>
      )}
    </Formik>
  );
};

export default JWTLogin;
