// src/components/KhachHangList.js
import React, { useEffect, useState } from 'react';
import axios from 'axios';

function KhachHangList() {
    const [data, setData] = useState([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        axios.get('http://localhost:5148/api/KhachHang')
            .then(response => {
                setData(response.data);
                setLoading(false);
            })
            .catch(error => {
                console.error("Lỗi khi lấy dữ liệu:", error);
                setLoading(false);
            });
    }, []);

    if (loading) return <p>Đang tải dữ liệu...</p>;

    return (
        <div>
            <h2>Danh sách khách hàng</h2>
            <table border="1" cellPadding="10">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Tài khoản</th>
                        <th>Email</th>
                        <th>SĐT</th>
                        <th>Họ tên</th>
                        <th>Địa chỉ</th>
                        <th>Ngày tạo</th>
                        <th>Ngày cập nhật</th>
                        <th>Trạng thái</th>
                    </tr>
                </thead>
                <tbody>
                    {data.map(kh => (
                        <tr key={kh.id}>
                            <td>{kh.id}</td>
                            <td>{kh.tenTaiKhoan}</td>
                            <td>{kh.email}</td>
                            <td>{kh.sdt}</td>
                            <td>{kh.hoTen}</td>
                            <td>{kh.diaChi}</td>
                            <td>{new Date(kh.ngayTao).toLocaleDateString()}</td>
                            <td>{new Date(kh.ngayCapNhat).toLocaleDateString()}</td>
                            <td>{kh.trangThai}</td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
}

export default KhachHangList;
