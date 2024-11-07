import axios from "axios";

export interface OrderInput  {
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
}

// Hàm lấy toàn bộ đơn hàng
export const getOrders = async (): Promise<OrderInput[]> => {
  try {
    const response = await axios.get<OrderInput[]>("https://localhost:7184/api/Order/Orders");
    return response.data;
  } catch (error) {
    console.error("Failed to fetch orders:", error);
    throw error;
  }
};

export const createOrder = async (orderData: OrderInput): Promise<void> => {
    try {
      const response = await axios.post("https://localhost:7184/api/Order", orderData);
      console.log("Order created:", response.data);
    } catch (error) {
      console.error("Failed to create order:", error);
      throw error;
    }};
