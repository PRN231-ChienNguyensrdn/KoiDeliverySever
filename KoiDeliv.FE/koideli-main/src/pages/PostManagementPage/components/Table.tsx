import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Table, Modal, Button } from 'antd';
import { EyeOutlined } from '@ant-design/icons'; // Import the icon
import dayjs from 'dayjs';

interface Order {
  orderId: number;
  customerId: number;
  origin: string;
  destination: string;
  totalWeight: number;
  totalQuantity: number;
  shippingMethod: string;
  additionalServices: string | null;
  status: string;
  createdAt: string;
  dateShip: string;
  paymentMethod: string;
  phoneContact: string;
  fishType: string;
  nameUserGet: string;
}

const OrderTable: React.FC = () => {
  const [orders, setOrders] = useState<Order[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [isModalVisible, setIsModalVisible] = useState<boolean>(false);
  const [selectedOrder, setSelectedOrder] = useState<Order | null>(null);

  useEffect(() => {
    // Fetch data from the local API endpoint
    axios.get('https://localhost:7184/api/Order/Orders', {
      headers: {
        'Content-Type': 'application/json',
      },
    })
      .then(response => {
        setOrders(response.data.data);
        setLoading(false);
      })
      .catch(error => {
        console.error("There was an error fetching the data!", error);
        setLoading(false);
      });
  }, []);

  const handleRowClick = (record: Order) => {
    setSelectedOrder(record);
    setIsModalVisible(true); // Show the modal when a row is clicked
  };

  const handleCloseModal = () => {
    setIsModalVisible(false);
    setSelectedOrder(null);
  };

  const columns = [
    {
      title: 'Order ID',
      dataIndex: 'orderId',
      key: 'orderId',
    },
    {
      title: 'Customer ID',
      dataIndex: 'customerId',
      key: 'customerId',
    },
    {
      title: 'Shipping Method',
      dataIndex: 'shippingMethod',
      key: 'shippingMethod',
    },
    {
      title: 'Status',
      dataIndex: 'status',
      key: 'status',
    },
    {
      title: 'Payment Method',
      dataIndex: 'paymentMethod',
      key: 'paymentMethod',
    },
    {
      title: 'Name of Recipient',
      dataIndex: 'nameUserGet',
      key: 'nameUserGet',
    },
    {
      title: 'Action',
      key: 'action',
      render: (text: any, record: Order) => (
          <EyeOutlined onClick={() => handleRowClick(record)} />
      ),
    },
  ];

  return (
    <>
      <Table
        columns={columns}
        dataSource={orders}
        rowKey="orderId"
        loading={loading}
      />

      {selectedOrder && (
        <Modal
          title={`Order Details - ID: ${selectedOrder.orderId}`}
          visible={isModalVisible}
          onCancel={handleCloseModal}
          footer={null}
        >
          <p><strong>Order ID:</strong> {selectedOrder.orderId}</p>
          <p><strong>Customer ID:</strong> {selectedOrder.customerId}</p>
          <p><strong>Origin:</strong> {selectedOrder.origin}</p>
          <p><strong>Destination:</strong> {selectedOrder.destination}</p>
          <p><strong>Total Weight:</strong> {selectedOrder.totalWeight} kg</p>
          <p><strong>Total Quantity:</strong> {selectedOrder.totalQuantity}</p>
          <p><strong>Shipping Method:</strong> {selectedOrder.shippingMethod}</p>
          <p><strong>Additional Services:</strong> {selectedOrder.additionalServices}</p>
          <p><strong>Status:</strong> {selectedOrder.status}</p>
          <p><strong>Created At:</strong> {dayjs(selectedOrder.createdAt).format('YYYY-MM-DD HH:mm:ss')}</p>
          <p><strong>Date to Ship:</strong> {dayjs(selectedOrder.dateShip).format('YYYY-MM-DD')}</p>
          <p><strong>Payment Method:</strong> {selectedOrder.paymentMethod}</p>
          <p><strong>Phone Contact:</strong> {selectedOrder.phoneContact}</p>
          <p><strong>Fish Type:</strong> {selectedOrder.fishType}</p>
          <p><strong>Name of Recipient:</strong> {selectedOrder.nameUserGet}</p>
        </Modal>
      )}
    </>
  );
};

export default OrderTable;
