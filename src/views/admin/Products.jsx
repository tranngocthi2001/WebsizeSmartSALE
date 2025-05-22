import React, { useEffect, useState } from 'react';

const API_URL = 'http://localhost:5148/api/SanPham';

const Products = () => {
  const [products, setProducts] = useState([]);
  const [sortField, setSortField] = useState('id');
  const [sortOrder, setSortOrder] = useState('asc');
  const [editing, setEditing] = useState(null);
  const [form, setForm] = useState({
    tenSanPham: '',
    gia: '',
    soLuong: '',
    trangThai: '',
    danhmucId: ''
  });

  useEffect(() => {
    fetchProducts();
  }, []);

  const fetchProducts = async () => {
    const res = await fetch(API_URL);
    const data = await res.json();
    setProducts(data);
  };

  const handleSort = (field) => {
    const order = sortField === field && sortOrder === 'asc' ? 'desc' : 'asc';
    setSortField(field);
    setSortOrder(order);
    setProducts([...products].sort((a, b) => {
      if (a[field] < b[field]) return order === 'asc' ? -1 : 1;
      if (a[field] > b[field]) return order === 'asc' ? 1 : -1;
      return 0;
    }));
  };

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleAdd = async () => {
    await fetch(API_URL, {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(form),
    });
    setForm({ tenSanPham: '', gia: '', soLuong: '', trangThai: '', danhmucId: '' });
    fetchProducts();
  };

  const handleEdit = (product) => {
    setEditing(product.id);
    setForm({
      tenSanPham: product.tenSanPham,
      gia: product.gia,
      soLuong: product.soLuong,
      trangThai: product.trangThai,
      danhmucId: product.danhmucId
    });
  };

  const handleUpdate = async (id) => {
    await fetch(`${API_URL}/${id}`, {
      method: 'PUT',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(form),
    });
    setEditing(null);
    setForm({ tenSanPham: '', gia: '', soLuong: '', trangThai: '', danhmucId: '' });
    fetchProducts();
  };

  const handleDelete = async (id) => {
    await fetch(`${API_URL}/${id}`, { method: 'DELETE' });
    fetchProducts();
  };

  return (
    <div style={{ maxWidth: 900, margin: '40px auto', background: '#fff', borderRadius: 8, boxShadow: '0 2px 8px #eee', padding: 24 }}>
      <div style={{ display: 'flex', gap: 8, marginBottom: 16, flexWrap: 'wrap', justifyContent: 'center' }}>
        <input
          name="tenSanPham"
          placeholder="Tên sản phẩm"
          value={form.tenSanPham}
          onChange={handleChange}
          style={{ padding: 8, borderRadius: 4, border: '1px solid #ccc', minWidth: 120 }}
        />
        <input
          name="gia"
          placeholder="Giá"
          value={form.gia}
          onChange={handleChange}
          style={{ padding: 8, borderRadius: 4, border: '1px solid #ccc', minWidth: 80 }}
        />
        <input
          name="soLuong"
          placeholder="Số lượng"
          value={form.soLuong}
          onChange={handleChange}
          style={{ padding: 8, borderRadius: 4, border: '1px solid #ccc', minWidth: 80 }}
        />
        <select
          name="trangThai"
          value={form.trangThai}
          onChange={handleChange}
          style={{ padding: 8, borderRadius: 4, border: '1px solid #ccc', minWidth: 100 }}
        >
          <option value="">Trạng thái</option>
          <option value="0">Đang hoạt động</option>
          <option value="1">Không hoạt động</option>
        </select>
        <input
          name="danhmucId"
          placeholder="Danh mục ID"
          value={form.danhmucId}
          onChange={handleChange}
          style={{ padding: 8, borderRadius: 4, border: '1px solid #ccc', minWidth: 80 }}
        />
        {editing ? (
          <button onClick={() => handleUpdate(editing)} style={{ background: '#1976d2', color: '#fff', border: 'none', borderRadius: 4, padding: '8px 16px' }}>Cập nhật</button>
        ) : (
          <button onClick={handleAdd} style={{ background: '#43a047', color: '#fff', border: 'none', borderRadius: 4, padding: '8px 16px' }}>Thêm</button>
        )}
        {editing && <button onClick={() => setEditing(null)} style={{ background: '#e53935', color: '#fff', border: 'none', borderRadius: 4, padding: '8px 16px' }}>Hủy</button>}
      </div>
      <table style={{ width: '100%', borderCollapse: 'collapse', background: '#fafafa' }}>
        <thead>
          <tr style={{ background: '#1976d2', color: '#fff' }}>
            <th style={{ padding: 10, cursor: 'pointer' }} onClick={() => handleSort('id')}>ID</th>
            <th style={{ padding: 10, cursor: 'pointer' }} onClick={() => handleSort('tenSanPham')}>Tên sản phẩm</th>
            <th style={{ padding: 10 }}>Hình ảnh</th> {/* New column */}
            <th style={{ padding: 10, cursor: 'pointer' }} onClick={() => handleSort('gia')}>Giá</th>
            <th style={{ padding: 10, cursor: 'pointer' }} onClick={() => handleSort('soLuong')}>Số lượng</th>
            <th style={{ padding: 10, cursor: 'pointer' }} onClick={() => handleSort('trangThai')}>Trạng thái</th>
            <th style={{ padding: 10, cursor: 'pointer' }} onClick={() => handleSort('danhmucId')}>Danh mục ID</th>
            <th style={{ padding: 10 }}>Hành động</th>
          </tr>
        </thead>
        <tbody>
          {products.map((sp, idx) => (
            <tr key={sp.id} style={{ background: idx % 2 === 0 ? '#fff' : '#f5f5f5' }}>
              <td style={{ padding: 8, textAlign: 'center' }}>{sp.id}</td>
              <td style={{ padding: 8 }}>{sp.tenSanPham}</td>
              <td style={{ padding: 8 }}>
                {sp.hinhAnh ? (
                  <img
                    src={sp.hinhAnh}
                    alt={sp.tenSanPham}
                    style={{ width: 60, height: 60, objectFit: 'cover', borderRadius: 6, border: '1px solid #eee' }}
                  />
                ) : (
                  <span style={{ color: '#aaa' }}>Không có ảnh</span>
                )}
              </td>
              <td style={{ padding: 8 }}>{sp.gia}</td>
              <td style={{ padding: 8 }}>{sp.soLuong}</td>
              <td style={{ padding: 8 }}>{sp.trangThai}</td>
              <td style={{ padding: 8 }}>{sp.danhmucId}</td>
              <td style={{ padding: 8 }}>
                <button onClick={() => handleEdit(sp)} style={{ marginRight: 8, background: '#ffb300', color: '#fff', border: 'none', borderRadius: 4, padding: '4px 12px' }}>Sửa</button>
                <button onClick={() => handleDelete(sp.id)} style={{ background: '#e53935', color: '#fff', border: 'none', borderRadius: 4, padding: '4px 12px' }}>Xóa</button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default Products;
