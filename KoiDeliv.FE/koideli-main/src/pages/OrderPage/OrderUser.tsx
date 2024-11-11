import React from 'react'
import ButtonDetail from './ButtonDetail'
import { Button } from 'antd';
import axios from 'axios';
type Order = {
    orderId: number;
  customerId: number;
  origin: string;
  destination: string;
  totalWeight: number;
  totalQuantity: number;
  shippingMethod: string;
  additionalServices: string;
  status: string;
  createdAt: string;
  dateShip: string;
  paymentMethod: string;
  phoneContact: string;
  fishType: string;
  nameUserGet: string;
  customer: any; // Adjust type as needed
  ratingsFeedbacks: any[];
  shipments: any[];
  transactions: any[];
  };
  
  interface OrderUserProps {
    order: Order;
  }
  interface ApiResponse {
    status: number;
    message: string;
    data: string;
    success: boolean;
  }
const OrderUser: React.FC<OrderUserProps> = ({order}) => {

  const  handleReturn = async() => {
    try {
      const response = 
      await axios.get<ApiResponse>(`http://localhost:7184/api/Order/CreatePaymentLink?oid=${order.orderId}`);

      console.log("check",response.data)
      window.location.href = response.data.data;
    } catch (error) {
      console.error("Error fetching orders:", error);
    }
  }
  return (
    <div key={order.orderId} className="flex flex-wrap items-center gap-y-4 py-6">
    <dl className="w-1/2 sm:w-1/6 lg:w-auto lg:flex-1">
      <dt className="text-base font-medium text-gray-500 dark:text-gray-400">Method Ship</dt>
      <dd className="mt-1.5 text-base font-semibold text-gray-900 dark:text-white">
        <a href="#" className="hover:underline">{order.shippingMethod}</a>
      </dd>
    </dl>

    <dl className="w-1/2 sm:w-1/6 lg:w-auto lg:flex-1">
      <dt className="text-base font-medium text-gray-500 dark:text-gray-400">Origin:</dt>
      <dd className="mt-1.5 text-base font-semibold text-gray-900 dark:text-white">{order.origin}</dd>
    </dl>

    <dl className="w-1/2 sm:w-1/6 lg:w-auto lg:flex-1">
      <dt className="text-base font-medium text-gray-500 dark:text-gray-400">Destination:</dt>
      <dd className="mt-1.5 text-base font-semibold text-gray-900 dark:text-white">{order.destination}</dd>
    </dl>

    <dl className="w-1/2 sm:w-1/6 lg:w-auto lg:flex-1">
      <dt className="text-base font-medium text-gray-500 dark:text-gray-400">Date:</dt>
      <dd className="mt-1.5 text-base font-semibold text-gray-900 dark:text-white">
        {new Date(order.dateShip).toLocaleDateString()}
      </dd>
    </dl>

    <dl className="w-1/2 sm:w-1/6 lg:w-auto lg:flex-1">
      <dt className="text-base font-medium text-gray-500 dark:text-gray-400">Price:</dt>
      <dd className="mt-1.5 text-base font-semibold text-gray-900 dark:text-white">${order.totalQuantity}</dd>
    </dl>

    <dl className="w-1/2 sm:w-1/6 lg:w-auto lg:flex-1">
      <dt className="text-base font-medium text-gray-500 dark:text-gray-400">Status:</dt>
      <dd className={`me-2 mt-1.5 inline-flex items-center rounded ${
          order.status === "Pending" ? "bg-blue-100 text-blue-800" :
          order.status === "In transit" ? "bg-yellow-100 text-yellow-800" : "bg-green-100 text-green-800"
        } px-2.5 py-0.5 text-xs font-medium`}>
        <svg
          className="me-1 h-3 w-3"
          aria-hidden="true"
          xmlns="http://www.w3.org/2000/svg"
          width="24"
          height="24"
          fill="none"
          viewBox="0 0 24 24"
        >
          <path
            stroke="currentColor"
            strokeLinecap="round"
            strokeLinejoin="round"
            strokeWidth="2"
            d="M13 7h6l2 4m-8-4v8m0-8V6a1 1 0 0 0-1-1H4a1 1 0 0 0-1 1v9h2m8 0H9m4 0h2m4 0h2v-4m0 0h-5m3.5 5.5a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0Zm-10 0a2.5 2.5 0 1 1-5 0 2.5 2.5 0 0 1 5 0Z"
          />
        </svg>
        {order.status}
      </dd>
    </dl>

    <div className="w-full grid sm:grid-cols-2 lg:flex lg:w-64 lg:items-center lg:justify-end gap-4">
      <ButtonDetail orderID={order.orderId} />
    </div>

    {order.status === "Accept" && (
    <Button type="primary" onClick={handleReturn}>Thanh toan</Button>
    )}
  </div>
  )
}

export default OrderUser