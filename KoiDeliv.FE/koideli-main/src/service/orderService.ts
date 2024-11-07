// orderService.ts
import axios from "axios";

export const getOrders = async (filters: Record<string, any>) => {
  try {
    const response = await axios.get("/api/Order/Orders", {
      
    });
    return response.data; // Return the data (e.g., orders)
  } catch (error) {
    throw new Error("Failed to fetch orders");
  }
};
