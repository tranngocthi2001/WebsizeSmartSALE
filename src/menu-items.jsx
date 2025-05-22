const menuItems = {
  items: [
    {
      id: 'group-management',
      title: 'Quản lý',
      type: 'group',
      children: [
        {
          id: 'product-management',
          title: 'Quản lý sản phẩm',
          type: 'item',
          url: '/admin/products',
          icon: 'feather icon-box'
        },
        {
          id: 'customer-management',
          title: 'Quản lý khách hàng',
          type: 'item',
          url: '/admin/customers',
          icon: 'feather icon-users'
        }
      ]
    }
  ]
};

export default menuItems;
