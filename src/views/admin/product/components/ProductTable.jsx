import React from 'react';
import { useNavigate } from 'react-router-dom';

const ProductTable = ({ products, onSort, onEdit, onDelete }) => {
  const navigate = useNavigate();

  return (
    <table>
      <thead>
        <tr>
          <th onClick={() => onSort('id')}>ID</th>
          <th onClick={() => onSort('tenSanPham')}>Tên sản phẩm</th>
          <th>Hình ảnh</th>
          <th onClick={() => onSort('gia')}>Giá</th>
          <th onClick={() => onSort('soLuong')}>Số lượng</th>
          <th onClick={() => onSort('trangThai')}>Trạng thái</th>
          <th onClick={() => onSort('danhmucId')}>Danh mục ID</th>
          <th>Hành động</th>
          <th>Chi tiết</th>
        </tr>
      </thead>
      <tbody>
        {products.map((sp, idx) => {
          console.log('sp:', sp); // Xem toàn bộ object sản phẩm
          return (
            <tr key={sp.id}>
              <td>{sp.id}</td>
              <td>{sp.tenSanPham}</td>
              <td>
                {(() => {
                  let images = [];
                  if (sp.hinhAnh) {
                    try {
                      images = JSON.parse(sp.hinhAnh);
                    } catch {
                      images = [];
                    }
                  }
                  return Array.isArray(images) && images.length > 0 ? (
                    <img
                      src={`http://localhost:5148/Uploads/Images/${images[0]}`}
                      alt={sp.tenSanPham}
                      style={{ width: 60, height: 60, objectFit: 'cover', borderRadius: 6, marginRight: 4 }}
                    />
                  ) : (
                    <span>Không có ảnh</span>
                  );
                })()}
              </td>
              <td>{sp.gia}</td>
              <td>{sp.soLuong}</td>
              <td>{sp.trangThai}</td>
              <td>{sp.danhmucId}</td>
              <td>
                <button onClick={() =>navigate(`/admin/product/update/${sp.id}`)}>Sửa</button>
                <button onClick={() => onDelete(sp.id)}>Xóa</button>
              </td>
              <td>
                <button
                  onClick={() => navigate(`/admin/product/details/${sp.id}?danhmucId=${sp.danhmucId}`)}
                >
                  Chi tiết
                </button>
              </td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
};

export default ProductTable;
