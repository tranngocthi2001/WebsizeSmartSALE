import React, { useEffect, useState } from 'react';
import ProductForm from './components/ProductForm';
import ProductTable from './components/ProductTable';

const API_URL = 'http://localhost:5148/api/SanPham';

const Products = () => {
  const [products, setProducts] = useState([]);
  const [sortField, setSortField] = useState('id');
  const [sortOrder, setSortOrder] = useState('asc');
  const[isEditing, setIsEditing] = useState(null);
  const [form, setForm] = useState({
    tenSanPham: '',
    gia: '',
    soLuong: '',
    trangThai: '',
    danhMucId: '',
  });
  useEffect(() => {
    fetchProducts();
  }, []);
  const fetchProducts = async () => {
    try {
      const response = await fetch(`${API_URL}?sortField=${sortField}&sortOrder=${sortOrder}`);
      const data = await response.json();
      setProducts(data);
    } catch (error) {
      console.error('Error fetching products:', error);
    }
  };

  const handleSort = (field) => {
    if (sortField === field) {
      setSortOrder(sortOrder === 'asc' ? 'desc' : 'asc');
    } else {
      setSortField(field);
      setSortOrder('asc');
    }
  };

  const handleEdit = (product) => {
    setForm(product);
    setIsEditing(product.id);
  };

  const handleCancel = () => {
    setIsEditing(null);
    setForm({
      tenSanPham: '',
      gia: '',
      soLuong: '',
      trangThai: '',
      danhMucId: '',
    });
  };

  const handleDelete = async (id) => {
    try {
      await fetch(`${API_URL}/${id}`, {
        method: 'DELETE',
      });
      fetchProducts();
    } catch (error) {
      console.error('Error deleting product:', error);
    }
  };

  const handleFormChange = (e) => {
    setForm({
      ...form,
      [e.target.name]: e.target.value,
    });
  };

  const handleFormSubmit = async (e) => {
    e.preventDefault();
    try {
      if (isEditing) {
        await fetch(`${API_URL}/${isEditing}`, {
          method: 'PUT',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(form),
        });
      } else {
        await fetch(API_URL, {
          method: 'POST',
          headers: {
            'Content-Type': 'application/json',
          },
          body: JSON.stringify(form),
        });
      }
      fetchProducts();
      handleCancel();
    } catch (error) {
      console.error('Error submitting form:', error);
    }
  };

  return (
    <div>
      <ProductForm
        form={form}
        onchange={handleFormChange}
        onsubmit={handleFormSubmit}
        isEditing={isEditing}
        onCancel={handleCancel}
      />
      <ProductTable
        products={products}
        onEdit={handleEdit}
        onDelete={handleDelete}
        onSort={handleSort}
      />
    </div>
  );
}

export default Products;
