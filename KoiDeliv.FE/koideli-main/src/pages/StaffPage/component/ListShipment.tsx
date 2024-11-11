import ButtonDetail from "./ButtonDetail";
import React, { useEffect, useState } from 'react';
import axios from 'axios';
import OrderUser from "@/pages/OrderPage/OrderUser";
import { jwtDecode } from "jwt-decode";
import { Modal, Input, Form, Button,Select } from "antd";

interface ListShip {
  shipmentId: number;
  orderId: number;
  salesStaffId: number;
  deliveringStaffId: number;
  healthCheckStatus: string;
  packingStatus: string;
  shippingStatus: string;
  foreignImportStatus: string;
  certificateIssued: string;
  deliveryDate: string;
  deliveringStaff: any; // Adjust type as needed
  order: any; // Adjust type as needed
  salesStaff: any; // Adjust type as needed
  routes: any[]; // Adjust array item type as needed
}


interface ApiResponse {
  status: number;
  message: string;
  data: ListShip[];
  success: boolean;
}
interface CustomJwtPayload {
  UserId: string;
  UserName: string;
  Email: string;
  Role: string; 
  exp: number;
  iss: string;
  aud: string;
}
const ListShipment : React.FC= () => {
  
  const [selectedOrder, setSelectedOrder] = useState<ListShip | null>(null);
  const [isModalVisible, setIsModalVisible] = useState(false);
  const [Ship, setShip] = useState<ListShip[]>([]);
  const getAuthToken = (): string | null => {
    const authData = localStorage.getItem("authToken");
    if (authData) {
      const parsedData = JSON.parse(authData);
      return parsedData.accessToken;
    }
    return null; // Return null if there's no token stored
  };  
  let userData: CustomJwtPayload;

  const token = getAuthToken();
  if (token) {
    userData = jwtDecode<CustomJwtPayload>(token);
  } else {
    console.error("No token found, cannot decode");
    // Handle the case where there's no token, e.g., redirect to login or show a message
  }
  const fetchOrders = async () => {
    try {
      const response = await axios.get<ApiResponse>(`http://localhost:7184/api/Shipment/byDeliId?deliId=${userData.UserId}`);
      setShip(response.data.data || []);
    } catch (error) {
      console.error("Error fetching orders:", error);
    }
  };
  useEffect(() => {
    // Fetch orders from API
    

    fetchOrders();
  }, []);

  const handleCheckKoi = (shipmentId: number) => {
    const selectedShipment = Ship.find(s => s.shipmentId === shipmentId);
    if (selectedShipment) {
      setSelectedOrder(selectedShipment);
      setIsModalVisible(true);
    }
  };

  const handleCloseModal = () => {
    setIsModalVisible(false);
    setSelectedOrder(null);
  };
  const handleUpdateShipment = async (values: ListShip) => {

    console.log("check id ",selectedOrder)
    console.log("check value ",values)

    try {
      const response = await axios.put(
        `http://localhost:7184/api/Shipment/${selectedOrder?.shipmentId}`,
        values
      );
      console.log("check log ",response)
     if(values?.healthCheckStatus === "Pass"){
      const responseSec = await axios.put(
        `http://localhost:7184/api/Order/UpdateOrderStatus?id=${selectedOrder?.orderId}&status=Accept`         
      );
      console.log("check up2", responseSec)
     }
      if (response.data.success) {
        // Update local state with updated shipment data
        const updatedShipments = Ship.map((item) =>
          item.shipmentId === selectedOrder?.shipmentId ? { ...item, ...values } : item
        );
        setShip(updatedShipments);
        setIsModalVisible(false);
        setSelectedOrder(null);
      }
      //handleCloseModal();
      fetchOrders();
    } catch (error) {
      console.error('Error updating shipment:', error);
    }
  };
  return (
    <section className=" py-8 antialiased bg-[#1e8fd0] md:py-16">
      <div className="mx-auto max-w-screen-xl px-4 2xl:px-0 bg-white py-10 rounded-md">
        <div className="mx-auto max-w-5xl">
          <div className="gap-4 sm:flex sm:items-center sm:justify-between">
            <h2 className="text-xl font-semibold text-gray-900 dark:text-white sm:text-2xl">
             Your Ship
            </h2>

            <div className="mt-6 gap-4 space-y-4 sm:mt-0 sm:flex sm:items-center sm:justify-end sm:space-y-0">
              <div>
                <label
                  htmlFor="order-type"
                  className="sr-only mb-2 block text-sm font-medium text-gray-900 dark:text-white"
                >
                  Select order type
                </label>
                <select
                  id="order-type"
                  className="block w-full min-w-[8rem] rounded-lg border border-gray-300 bg-gray-50 p-2.5 text-sm text-gray-900 focus:border-primary-500 focus:ring-primary-500 dark:border-gray-600 dark:bg-gray-700 dark:text-white dark:placeholder:text-gray-400 dark:focus:border-primary-500 dark:focus:ring-primary-500"
                >
                  <option selected>All orders</option>
                  <option value="pre-order">Pre-order</option>
                  <option value="transit">In transit</option>
                  <option value="confirmed">Confirmed</option>
                  <option value="cancelled">Cancelled</option>
                </select>
              </div>

              <span className="inline-block text-gray-500 dark:text-gray-400">
                {" "}
                from{" "}
              </span>

              <div>
                <label
                  htmlFor="duration"
                  className="sr-only mb-2 block text-sm font-medium text-gray-900 dark:text-white"
                >
                  Select duration
                </label>
                <select
                  id="duration"
                  className="block w-full rounded-lg border border-gray-300 bg-gray-50 p-2.5 text-sm text-gray-900 focus:border-primary-500 focus:ring-primary-500 dark:border-gray-600 dark:bg-gray-700 dark:text-white dark:placeholder:text-gray-400 dark:focus:border-primary-500 dark:focus:ring-primary-500"
                >
                  <option selected>this week</option>
                  <option value="this month">this month</option>
                  <option value="last 3 months">the last 3 months</option>
                  <option value="lats 6 months">the last 6 months</option>
                  <option value="this year">this year</option>
                </select>
              </div>
            </div>
          </div>

          <div className="mt-6 flow-root sm:mt-8">
            <div className="divide-y divide-gray-200 dark:divide-gray-700">            
              <div>
      {Ship.map((Ship) => (
       <div key={Ship.shipmentId} className="flex flex-wrap items-center gap-y-4 py-6">
     <dl className="w-1/2 sm:w-1/6 lg:w-auto lg:flex-1">
  <dt className="text-base font-medium text-gray-500 dark:text-gray-400">Health Check</dt>
  <dd
    className={`mt-1.5 text-base font-semibold ${
      Ship.healthCheckStatus === 'Pass'
        ? 'text-green-500 dark:text-green-400'
        : Ship.healthCheckStatus === 'Fail'
        ? 'text-red-500 dark:text-red-400'
        : 'text-yellow-500 dark:text-yellow-400'
    }`}
  >
    <a href="#" className="hover:underline">{Ship.healthCheckStatus}</a>
  </dd>
</dl>  
<dl className="w-1/2 sm:w-1/6 lg:w-auto lg:flex-1">
  <dt className="text-base font-medium text-gray-500 dark:text-gray-400">Pakages status:</dt>
  <dd
    className={`mt-1.5 text-base font-semibold ${
      Ship.packingStatus === 'Finish'
        ? 'text-green-500 dark:text-green-400'
        : Ship.packingStatus === 'Not Finish'
        ? 'text-yellow-500 dark:text-yellow-400'
        : Ship.packingStatus === 'Not Accept'
        ? 'text-red-500 dark:text-red-400'
        : 'text-gray-900 dark:text-white'
    }`}
  >
    <a href="#" className="hover:underline">{Ship.packingStatus}</a>
  </dd>
</dl>
   
       <dl className="w-1/2 sm:w-1/6 lg:w-auto lg:flex-1">
         <dt className="text-base font-medium text-gray-500 dark:text-gray-400">Shiping method:</dt>
         <dd className="mt-1.5 text-base font-semibold text-gray-900 dark:text-white">{Ship.shippingStatus}</dd>
       </dl>
   
       <dl className="w-1/2 sm:w-1/6 lg:w-auto lg:flex-1">
         <dt className="text-base font-medium text-gray-500 dark:text-gray-400">Date:</dt>
         <dd className="mt-1.5 text-base font-semibold text-gray-900 dark:text-white">
           {new Date(Ship.deliveryDate).toLocaleDateString()}
         </dd>
       </dl>
   
       <dl className="w-1/2 sm:w-1/6 lg:w-auto lg:flex-1">
         <dt className="text-base font-medium text-gray-500 dark:text-gray-400">Price:</dt>
         <dd className="mt-1.5 text-base font-semibold text-gray-900 dark:text-white">${Ship.deliveryDate}</dd>
       </dl>
       <div className="w-full grid sm:grid-cols-2 lg:flex lg:w-64 lg:items-center lg:justify-end gap-4">
         <ButtonDetail shipmentId={Ship.shipmentId}/>
         <Button onClick={() => handleCheckKoi(Ship.shipmentId)} type="primary">Check Koi</Button>
       </div>     
     </div>
      ))}
    </div>           
            </div>
          </div>
        </div>
      </div>


      {selectedOrder && (
  <Modal
    title={`Update Order Details - ID: ${selectedOrder.orderId}`}
    visible={isModalVisible}
    onCancel={handleCloseModal}
    footer={null}
  >
    <Form
      layout="vertical"
      initialValues={{
        shipmentId: selectedOrder.shipmentId,
        healthCheckStatus: selectedOrder.healthCheckStatus,
        packingStatus: selectedOrder.packingStatus,
        shippingStatus: selectedOrder.shippingStatus,
        foreignImportStatus: selectedOrder.foreignImportStatus,
      }}
      onFinish={handleUpdateShipment}
    >
      <Form.Item label="Shipment ID" name="shipmentId">
        <Input disabled value={selectedOrder.shipmentId} />
      </Form.Item>

      <Form.Item label="Health Check Status" name="healthCheckStatus">
    <Select>
      <Select.Option value="Pass">Pass</Select.Option>
      <Select.Option value="Fail">Fail</Select.Option>
      <Select.Option value="Check Again">Check Again</Select.Option>
    </Select>
  </Form.Item>

  <Form.Item label="Packing Status" name="packingStatus">
    <Select>
      <Select.Option value="Finish">Finish</Select.Option>
      <Select.Option value="Not Finish">Not Finish</Select.Option>
      <Select.Option value="Not Accept">Not Accept</Select.Option>
    </Select>
  </Form.Item>

  <Form.Item label="Foreign Import Status" name="foreignImportStatus">
    <Select>
      <Select.Option value="true">True</Select.Option>
      <Select.Option value="false">False</Select.Option>
      <Select.Option value="waiting">Waiting</Select.Option>
    </Select>
  </Form.Item>

      <Form.Item label="Shipping Status" name="shippingStatus">
        <Input />
      </Form.Item>

      

      <div className="flex justify-end">
        <Button onClick={handleCloseModal} className="mr-2">
          Cancel
        </Button>
        <Button type="primary" htmlType="submit">
          Update
        </Button>
      </div>
    </Form>
  </Modal>
)}

    </section>





  );
};

export default ListShipment;
