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
  shipment: any; // Thay thế `any` nếu bạn có kiểu chính xác cho `shipment`
}
interface ButtonDetailProps {
  shipmentId: number;
}
const ButtonDetail : React.FC<ButtonDetailProps> = ({ shipmentId }) => {
  const [routes, setRoutes] = useState<RouteData[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchRoutes = async () => {
      try {
        const response = await axios.get<RouteData[]>(`http://localhost:7184/api/Route/byShipmentId?sid=${shipmentId}`);
        setRoutes(response.data);
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
            className={`flex items-center ${route.status ? "text-white dark:text-blue-500" : ""}`}
          >
            <span className="flex items-center justify-center w-5 h-5 me-2 text-xs border border-white rounded-full shrink-0 dark:border-blue-500">
              {index + 1}
            </span>
            <span className="hidden sm:inline-flex sm:ms-2">
              {route.notice}
            </span>
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
          </li>
        ))}
              {/* <li className="flex items-center text-white dark:text-blue-500">
                <span className="flex items-center justify-center w-5 h-5 me-2 text-xs border border-white rounded-full shrink-0 dark:border-blue-500">
                  1
                </span>

                <span className="hidden sm:inline-flex sm:ms-2">
                  {" "}
                 Notice
                </span>
                <svg
                  className="w-3 h-3 ms-2 sm:ms-4 rtl:rotate-180"
                  aria-hidden="true"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 12 10"
                >
                  <path
                    stroke="currentColor"
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="m7 9 4-4-4-4M1 9l4-4-4-4"
                  />
                </svg>
              </li>


              <li className="flex items-center">
                <span className="flex items-center justify-center w-5 h-5 me-2 text-xs border border-gray-500 rounded-full shrink-0 dark:border-gray-400">
                  2
                </span>
                Account{" "}
                <span className="hidden sm:inline-flex sm:ms-2">
                  Đang lấy hàng
                </span>
                <svg
                  className="w-3 h-3 ms-2 sm:ms-4 rtl:rotate-180"
                  aria-hidden="true"
                  xmlns="http://www.w3.org/2000/svg"
                  fill="none"
                  viewBox="0 0 12 10"
                >
                  <path
                    stroke="currentColor"
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="m7 9 4-4-4-4M1 9l4-4-4-4"
                  />
                </svg>
              </li> */}
              {/* <li className="flex items-center">
                <span className="flex items-center justify-center w-5 h-5 me-2 text-xs border border-gray-500 rounded-full shrink-0 dark:border-gray-400">
                  3
                </span>
                Giao hàng
              </li> */}
            </ol>
          </div>
          <div className="grid gap-4 py-4 bg-slate-900 pr-10 rounded-md">
            <div className="grid grid-cols-4 items-center gap-4">
              <Label htmlFor="name" className="text-right">
                Order Id
              </Label>
              <Input id="name" defaultValue="#1234" className="col-span-3" />
            </div>
            <div className="grid grid-cols-4 items-center gap-4">
              <Label htmlFor="username" className="text-right">
                Status
              </Label>
              <div className="me-2 mt-1.5 inline-flex items-center rounded bg-green-100 px-2.5 py-0.5 text-xs font-medium text-green-800 dark:bg-green-900 dark:text-green-300">
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
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M5 11.917 9.724 16.5 19 7.5"
                  />
                </svg>
                Confirmed
              </div>
            </div>
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
