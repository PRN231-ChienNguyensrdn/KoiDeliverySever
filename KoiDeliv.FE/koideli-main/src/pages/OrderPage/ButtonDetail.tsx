import { Button } from "@/components/ui/button";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";
import { Eye } from "lucide-react";
import React, { useEffect, useState } from 'react';
import axios from 'axios';

interface RouteData {
  routedId: number;
  shipmentId: number;
  status: boolean | null;
  notice: string;
  dateSetting: string;
  dateUpdate: string | null;
  adress: string;
  shipment: any; 
}
interface ButtonDetailProps {
    orderID : number;
}
const ButtonDetail : React.FC<ButtonDetailProps> = ({ orderID }) => {
  const [routes, setRoutes] = useState<RouteData[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchRoutes = async () => {
      try {
        const response = await axios.get<RouteData[]>(`http://localhost:7184/api/Route/byOrderId?oid=${orderID}`);
        setRoutes(response.data);
        console.log("check a'",routes )
      } catch (err) {
        setError('Error fetching data');
        console.error(err);
      }
    };

    fetchRoutes();
  }, []);



  return (
    <Dialog>
      <DialogTrigger asChild>
        <Button size={"icon"} variant={"ghost"}>
          <Eye />
        </Button>
      </DialogTrigger>
      <DialogContent className="md:w-[800px] sm:max-w-[825px]">
        <DialogHeader>
          <DialogTitle className="text-white">Detail Order</DialogTitle>
          <DialogDescription>
            Routed for a Ship
          </DialogDescription>
        </DialogHeader>
        <div>
          <div className="mb-5 grid-cols-4 items-center gap-">           
            <ol className="flex items-center w-full p-3 space-x-2 text-sm  mx-auto font-medium text-center text-gray-500 border border-gray-200 rounded-lg shadow-sm dark:text-gray-400 sm:text-base dark:bg-gray-800 dark:border-gray-700 sm:p-4 sm:space-x-4 rtl:space-x-reverse">
            {routes.map((route, index) => (
  <li
    key={route.routedId}
    className={`flex items-center ${
      route.status ? "text-white dark:text-blue-500" : ""
    } ${index === routes.length - 1 ? "text-gray-500 dark:text-gray-400" : ""}`}
  >
    <span
      className={`flex items-center justify-center w-5 h-5 me-2 text-xs border rounded-full shrink-0 ${
        index === routes.length - 1 ? "border-gray-500 dark:border-gray-400" : "border-white dark:border-blue-500"
      }`}
    >
      {index + 1}
    </span>
    <span className="hidden sm:inline-flex sm:ms-2">
      {index === routes.length - 1 ? "Giao hàng" : route.notice}
    </span>
    {index !== routes.length - 1 && (
      <svg
        className="w-3 h-3 ms-2 sm:ms-4 rtl:rotate-180"
        aria-hidden="true"
        xmlns="http://www.w3.org/2000/svg"
        fill="none"
        viewBox="0 0 12 10"
      >
        <path
          stroke="currentColor"
          strokeLinecap="round"
          strokeLinejoin="round"
          strokeWidth="2"
          d="m7 9 4-4-4-4M1 9l4-4-4-4"
        />
      </svg>
    )}
  </li>
))}           
            </ol>
          </div>
         
        </div>
        <DialogFooter>
          <Button type="submit">Save changes</Button>
        </DialogFooter>
      </DialogContent>
    </Dialog>
  );
};

export default ButtonDetail;
