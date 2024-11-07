export interface IPost {
    userId: number;
    id: number;
    title: string;
    body: string;
  }
  
  export interface IParams {
    _page?: number;
    _limit?: number;
  }
  

export interface IOrder {
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
  customer: any; 
  ratingsFeedbacks: any[]; 
  shipments: any[]; 
  transactions: any[]; 
}
