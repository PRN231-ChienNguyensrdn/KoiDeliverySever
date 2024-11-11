import React, { useEffect, useState } from 'react';
import axios from 'axios';
import { Table, Modal, Button,Input,Select  } from 'antd';
import { EyeOutlined } from '@ant-design/icons'; 
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
interface ShipmentData {
  orderID: number;
  salesStaffId: number;
  deliveringStaffId: number;
  healthCheckStatus: string;
  packingStatus: string;
  shippingStatus: string;
  foreignImportStatus: string;
  certificateIssued: boolean;
  deliveryDate: Date;
}
interface Staff {
  userId: number;
  fullName: string;
}
const OrderTable: React.FC = () => {
  const [orders, setOrders] = useState<Order[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [isModalVisible, setIsModalVisible] = useState<boolean>(false);
  const [isModalVisibleCreate, setisModalVisibleCreate] = useState<boolean>(false);

  const [selectedOrder, setSelectedOrder] = useState<Order | null>(null);
  const [staffList, setStaffList] = useState<Staff[]>([]);

  const [shipmentData, setShipmentData] = useState<ShipmentData>({
    orderID: 0,
    salesStaffId: 0,
    deliveringStaffId: 0,
    healthCheckStatus: '',
    packingStatus: '',
    shippingStatus: '',
    foreignImportStatus: '',
    certificateIssued: true,
    deliveryDate: new Date,
  });
  useEffect(() => {
    // Fetch data from the local API endpoint
    axios.get('http://localhost:7184/api/Order/Orders', {
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


      axios.get('http://localhost:7184/api/User/Staff', {
      headers: { 'Content-Type': 'application/json' },
    })
      .then(response => {
        setStaffList(response.data.data);
      })
      .catch(error => {
        console.error("There was an error fetching the staff data!", error);
      });
  }, []);

  const handleRowClick = (record: Order) => {
    setSelectedOrder(record);
    setIsModalVisible(true); // Show the modal when a row is clicked
  };
  const [salesStaffId, setSalesStaffId] = useState<number | null>(null);
  const [deliveringStaffId, setDeliveringStaffId] = useState<number | null>(null);
  const handleRowClickCreate = (record: Order) => {
    setSelectedOrder(record);
    setisModalVisibleCreate(true); // Show the modal when a row is clicked
  };

  const handleCloseModal = () => {
    setIsModalVisible(false);
    setSelectedOrder(null);
  };

  const handleShipmentSubmit = async () => {
    try {
      const shipmentData = {
        orderId: selectedOrder?.orderId,
        salesStaffId: salesStaffId,
        deliveringStaffId: deliveringStaffId,
        healthCheckStatus: 'Not checked',
        packingStatus: 'Not checked',
        shippingStatus: 'Air',
        foreignImportStatus: 'Not checked',
        certificateIssued: "Not checked",
        // deliveryDate: dayjs().format('YYYY-MM-DD HH:mm:ss'),
      };
      
      console.log(shipmentData);

      // Uncomment to send data to the API
     const respone = await axios.post('http://localhost:7184/api/Shipment', shipmentData);
console.log("check respone :",respone)
      handleCloseModal();
    } catch (error) {
      console.error("There was an error submitting the shipment data!", error);
    }
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
    {
      title: 'Create Shipment',
      key: 'createShipment',
      render: (text: any, record: Order) => (
        <Button onClick={() => handleRowClickCreate(record)}>Create Shipment</Button>
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
        {selectedOrder && (
    <Modal
    title={`Create Shipment - Order ID: ${selectedOrder.orderId}`}
    visible={isModalVisibleCreate}
    onCancel={handleCloseModal}
    onOk={handleShipmentSubmit}
  >
    <p><strong>Order ID:</strong></p>
    <Input placeholder="Order ID" value={selectedOrder.orderId} readOnly />

    <p><strong>Sales Staff ID:</strong></p>
    <Select 
      placeholder="Select Sales Staff" 
      style={{ width: '100%' }} 
      onChange={(value) => setSalesStaffId(value)}
    >
      {staffList.map(staff => (
        <Select.Option key={staff.userId} value={staff.userId}>
          {staff.fullName}
        </Select.Option>
      ))}
    </Select>

    <p><strong>Delivering Staff ID:</strong></p>
    <Select 
      placeholder="Select Delivering Staff" 
      style={{ width: '100%' }} 
      onChange={(value) => setDeliveringStaffId(value)}
    >
      {staffList.map(staff => (
        <Select.Option key={staff.userId} value={staff.userId}>
          {staff.fullName}
        </Select.Option>
      ))}
    </Select>
  </Modal>
      )}
    </>

    
  );
};

export default OrderTable;
