import React, { useEffect, useState } from "react";
import { useParams, useSearchParams } from "react-router-dom";

const ProductDetails = () => {
  const { id } = useParams();
  const [searchParams] = useSearchParams();
  const danhmucId = searchParams.get("danhmucId");
  const [product, setProduct] = useState(null);

  useEffect(() => {
    if (id && danhmucId) {
      fetch(`http://localhost:5148/api/SanPham/${id}`)
        .then(res => res.json())
        .then(data => setProduct(data));
    }
  }, [id, danhmucId]);

  if (!product) return <div>Đang tải...</div>;

  return (
    <div style={{ maxWidth: 1000, margin: "40px auto", background: "#fff", borderRadius: 8, boxShadow: "0 2px 8px #eee", padding: 24 }}>
      <h4>Chi tiết sản phẩm</h4>
      <p><b>ID:</b> {product.id}</p>
      <p><b>Tên sản phẩm:</b> {product.tenSanPham}</p>
      <p style={{ textAlign: 'justify' }}><b>Mô tả:</b> {product.moTa}</p>
      <p><b>Giá:</b> {product.gia}</p>
      <p><b>Số lượng:</b> {product.soLuong}</p>
      <p><b>Trạng thái:</b> {product.trangThai}</p>
      <p><b>Danh mục ID:</b> {product.danhmucId}</p>
      <div>
        <b>Hình ảnh:</b>
        <div style={{ display: "flex", flexWrap: "wrap", gap: 8, marginTop: 8 }}>
          {Array.isArray(product.hinhAnhs) && product.hinhAnhs.map((img, idx) => (
            <img
              key={idx}
              src={`http://localhost:5148${img}`}
              alt={product.tenSanPham}
              style={{ width: 120, height: 120, objectFit: "cover", borderRadius: 6, border: "1px solid #eee" }}
            />
          ))}
        </div>
      </div>
    </div>
  );
};

export default ProductDetails;