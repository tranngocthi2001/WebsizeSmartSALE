import React from "react";

const ProductForm = ({
  form,
  onchange,
  onsubmit,
  isEditing,
  onCancel,
  onFileChange
}) => {
  return (
    <div style={{ display: 'flex', gap: 8, marginBottom: 16, flexWrap: 'wrap', justifyContent: 'center' }}>
      <input name="tenSanPham" placeholder="Tên sản phẩm" value={form.tenSanPham} onChange={onchange} />
      <input name="gia" placeholder="Giá" value={form.gia} onChange={onchange} />
      <input name="soLuong" placeholder="Số lượng" value={form.soLuong} onChange={onchange} />
      <select name="trangThai" value={form.trangThai} onChange={onchange}>
        <option value="">Trạng thái</option>
        <option value="0">Đang hoạt động</option>
        <option value="1">Không hoạt động</option>
      </select>
      <input name="danhmucId" placeholder="Danh mục ID" value={form.danhmucId} onChange={onchange} />
      {/* Cho phép chọn nhiều file */}
      <input type="file" accept="image/*" multiple onChange={onFileChange} />
      {isEditing ? (
        <>
          <button onClick={onsubmit}>Cập nhật</button>
          <button onClick={onCancel}>Hủy</button>
        </>
      ) : (
        <button onClick={onsubmit}>Thêm</button>
      )}
    </div>
  );
};

export default ProductForm;
