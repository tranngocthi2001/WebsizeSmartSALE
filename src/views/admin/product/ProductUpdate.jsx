import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { useParams, useNavigate } from 'react-router-dom';

const ProductUpdate = () => {
  const { id } = useParams();
  const navigate = useNavigate();
  const [product, setProduct] = useState(null);
  const [oldImages, setOldImages] = useState([]);
  const [removedImages, setRemovedImages] = useState([]);
  const [newImages, setNewImages] = useState([]);

  // Lấy thông tin sản phẩm
  useEffect(() => {
    axios.get(`http://localhost:5148/api/SanPham/${id}`)
      .then(res => {
        setProduct(res.data);
        // Parse hinhAnh nếu là chuỗi JSON
        let imgs = [];
        try {
          imgs = JSON.parse(res.data.hinhAnh);
        } catch {
          imgs = [];
        }
        setOldImages(imgs);
      });
  }, [id]);

  const handleRemoveOldImage = (img) => {
    setRemovedImages([...removedImages, img]);
    setOldImages(oldImages.filter(i => i !== img));
  };

  const handleAddNewImages = (e) => {
    setNewImages([...newImages, ...Array.from(e.target.files)]);
  };

  const handleRemoveNewImage = (idx) => {
    setNewImages(newImages.filter((_, i) => i !== idx));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    const form = e.target;
    const formData = new FormData();

    formData.append('Id', product.id);
    formData.append('TenSanPham', form.TenSanPham.value);
    formData.append('MoTa', form.MoTa.value);
    formData.append('Gia', form.Gia.value);
    formData.append('SoLuong', form.SoLuong.value);
    formData.append('TrangThai', form.TrangThai.value);
    formData.append('DanhmucId', form.DanhmucId.value);
    formData.append('NgayCapNhat', new Date().toISOString());

    // Ảnh cũ giữ lại (không bị xóa)
    const keptOldImages = oldImages;
    formData.append('OldImages', JSON.stringify(keptOldImages));

    // Ảnh mới
    newImages.forEach(img => {
      formData.append('NewImages', img);
    });

    try {
      await axios.post('http://localhost:5148/api/SanPham/Update', formData, {
        headers: { 'Content-Type': 'multipart/form-data' }
      });
      alert('Cập nhật thành công!');
      navigate('/admin/product');
    } catch (err) {
      alert('Có lỗi xảy ra!');
    }
  };

  if (!product) return <div>Đang tải...</div>;

  return (
    <form onSubmit={handleSubmit}>
      <h2>Cập nhật sản phẩm</h2>
      <div>
        <label>Tên sản phẩm</label>
        <input name="TenSanPham" defaultValue={product.tenSanPham} required />
      </div>
      <div>
        <label>Mô tả</label>
        <textarea name="MoTa" defaultValue={product.moTa} required />
      </div>
      <div>
        <label>Giá</label>
        <input name="Gia" type="number" defaultValue={product.gia} required />
      </div>
      <div>
        <label>Số lượng</label>
        <input name="SoLuong" type="number" defaultValue={product.soLuong} required />
      </div>
      <div>
        <label>Trạng thái</label>
        <select name="TrangThai" defaultValue={product.trangThai}>
          <option value={0}>Ẩn</option>
          <option value={1}>Hiện</option>
        </select>
      </div>
      <div>
        <label>Danh mục ID</label>
        <input name="DanhmucId" type="number" defaultValue={product.danhmucId} required />
      </div>
      <div>
        <label>Ảnh cũ:</label>
        <div style={{ display: 'flex', gap: 8, flexWrap: 'wrap' }}>
          {oldImages.map(img => (
            <div key={img} style={{ position: 'relative' }}>
              <img
                src={`http://localhost:5148/Uploads/Images/${img}`}
                alt=""
                style={{ width: 80, height: 80, objectFit: 'cover', borderRadius: 6 }}
              />
              <button type="button" onClick={() => handleRemoveOldImage(img)}
                style={{
                  position: 'absolute', top: 0, right: 0, background: 'red', color: 'white', border: 'none', borderRadius: '50%'
                }}>x</button>
            </div>
          ))}
        </div>
      </div>
      <div>
        <label>Thêm ảnh mới:</label>
        <input type="file" multiple accept="image/*" onChange={handleAddNewImages} />
        <div style={{ display: 'flex', gap: 8, flexWrap: 'wrap' }}>
          {newImages.map((img, idx) => (
            <div key={idx} style={{ position: 'relative' }}>
              <img
                src={URL.createObjectURL(img)}
                alt=""
                style={{ width: 80, height: 80, objectFit: 'cover', borderRadius: 6 }}
              />
              <button type="button" onClick={() => handleRemoveNewImage(idx)}
                style={{
                  position: 'absolute', top: 0, right: 0, background: 'red', color: 'white', border: 'none', borderRadius: '50%'
                }}>x</button>
            </div>
          ))}
        </div>
      </div>
      <button type="submit">Cập nhật</button>
    </form>
  );
};

export default ProductUpdate;