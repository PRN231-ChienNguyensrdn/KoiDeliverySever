import bg from "@/assets/img/booking/bg-map.png";
import pic1 from "@/assets/img/booking/pic1.png";
import icon1 from "@/assets/img/booking/icon1.png";
import React, { FormEvent, useState } from "react";
import axios from "axios";
import { Input } from "./ui/input";
import { Label } from "./ui/label";
//  import { DateTimePicker } from "./ui/date-picker";
import { DatePicker, Space,notification } from "antd";
import {
  Select,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "./ui/select";
interface OrderFormData {
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
import dayjs, { Dayjs } from "dayjs";
import { parseISO } from "date-fns";
const RequestAQuote: React.FC = () => {
  const onChange = (date: Dayjs | null, dateString: string | string[]) => {
    console.log(date, dateString);
  };

  const [formData, setFormData] = useState<OrderFormData>({
    orderId: 0,
    customerId: 2,
    origin: "",
    destination: "",
    totalWeight: 0,
    totalQuantity: 0,
    shippingMethod: "test",
    additionalServices: "",
    status: "test",
    createdAt: new Date().toISOString(),
    dateShip: new Date().toISOString(),
    paymentMethod: "test",
    phoneContact: "",
    fishType: "",
    nameUserGet: "",
  });

  const handleChange = (
    e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement>
  ) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleChangeMethod = (value: string, option: string) => {
    setFormData((prevData) => ({
      ...prevData,
      [option]: value,
    }));
  };

  const handleDateChange = (newDate: Date) => {
    if (newDate) {
      setFormData((prevData) => ({
        ...prevData,
        dateShip: newDate.toISOString(), // Update dateShip when date changes
      }));
    }
  };
  const [api, contextHolder] = notification.useNotification();

  // Update openNotification to accept a message and type dynamically
  const openNotification = (message: string, description: string, pauseOnHover: boolean) => {
    api.open({
      message,
      description,
      showProgress: true,
      pauseOnHover,
    });
  };


  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      console.log("Order check:", formData);

      const response = await axios.post(
        "https://localhost:7184/api/Order",
        formData
      );
      console.log("Order submitted:", response.data, formData);
      openNotification("Order Submitted", "Your order was submitted successfully!", true);

    } catch (error) {
      openNotification("Order Error", "Your order was submitted fail!", true);

      console.error("Error submitting order:", error);
    }
  };

  return (
    <div
      className="section-full p-t120 p-b90 site-bg-gray tw-booking-area"
      style={{
        //backgroundImage: url(${bg}),
        backgroundImage: `url(${bg})`,

      }}
    >
      {contextHolder}
      <div className="container">
        <div className="section-head center wt-small-separator-outer">
          <div className="wt-small-separator site-text-primary">
            <div>Request A Quote</div>
          </div>
          <h2 className="wt-title">Booking For Product Transformation</h2>
          <p className="section-head-text">
            Lorem Ipsum is simply dummy text of the printing and typesetting
            industry the standard dummy text ever since the when an printer
            took.
          </p>
        </div>
      </div>

      <div className="container">
        <div className="tw-booking-section">
          <div className="flex flex-wrap">
            <div className="w-full md:w-full lg:w-1/4 xl:w-1/4">
              <div className="tw-booking-media">
                <div className="media">
                  <img src={pic1} alt="#" />
                </div>
              </div>
            </div>

            <div className="w-full md:w-full lg:w-3/4 xl:w-3/4">
              <div className="tw-booking-form">
                <div className="flex flex-wrap booking-tab-container">
                  <div className="w-full md:w-full lg:w-1/6 booking-tab-menu">
                    <div className=" bg-white py-5 px-10 mr-10 ml-[-50px]  shadow-[0px_0px_30px_rgba(30,143,208,0.7)]">
                      <div className=" bg-white flex flex-col items-center">
                        <div className=" ">
                          <img src={icon1} alt="" />
                        </div>
                        <span className="text-black">Request</span>
                      </div>
                    </div>
                  </div>
                  <div className="w-full md:w-full lg:w-5/6 booking-tab">
                    <div className="booking-tab-content active">
                      <form onSubmit={handleSubmit}>
                        <div className="flex flex-wrap items-center">
                          <div className="w-full md:w-1/3 lg:w-1/3">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Tên người gửi
                              </Label>
                              <Input
                                className="bg-white text-black"
                                placeholder="Tên người gửi"
                              />
                            </div>
                          </div>
                          <div className="w-full md:w-1/3 lg:w-1/3">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Tên người nhận
                              </Label>
                              <Input
                                className="bg-white text-black"
                                name="nameUserGet"
                                placeholder="Tên người nhận"
                                value={formData.nameUserGet}
                                onChange={handleChange}
                              />
                            </div>
                          </div>
                          <div className="w-full md:w-1/3 lg:w-1/3">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Email
                              </Label>
                              <Input
                                className="bg-white text-black"
                                placeholder="Email"
                              />
                            </div>
                          </div>

                          <div className="w-full md:w-1/2 lg:w-full">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Phone
                              </Label>
                              <Input
                                className="bg-white text-black"
                                name="phoneContact"
                                placeholder="Phone"
                                value={formData.phoneContact}
                                onChange={handleChange}
                              />
                            </div>
                          </div>

                          <div className="w-full md:w-1/2 lg:w-1/2">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Nơi lấy cá
                              </Label>
                              <Input
                                className="bg-white text-black"
                                name="origin"
                                placeholder="Nơi lấy cá"
                                value={formData.origin}
                                onChange={handleChange}
                              />
                            </div>
                          </div>

                          <div className="w-full md:w-1/2 lg:w-1/2">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Nơi nhận cá
                              </Label>
                              <Input
                                className="bg-white text-black"
                                name="destination"
                                placeholder="Nơi nhận cá"
                                value={formData.destination}
                                onChange={handleChange}
                              />
                            </div>
                          </div>

                          <div className="w-full md:w-1/6 lg:w-1/6">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Khối lượng
                              </Label>
                              <Input
                                className="bg-white text-black"
                                name="totalWeight"
                                type="number"
                                placeholder="Khối lượng đơn hàng"
                                value={formData.totalWeight}
                                onChange={handleChange}
                              />
                            </div>
                          </div>
                          <div className="w-full md:w-1/6 lg:w-1/6">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Số lượng
                              </Label>
                              <Input
                                className="bg-white text-black"
                                name="totalQuantity"
                                type="number"
                                placeholder="Số lượng"
                                value={formData.totalQuantity}
                                onChange={handleChange}
                              />
                            </div>
                          </div>
                          <div className="w-full md:w-1/6 lg:w-1/6">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Loại cá
                              </Label>
                              <Input
                                className="bg-white text-black"
                                name="fishType"
                                placeholder="Loại cá"
                                value={formData.fishType}
                                onChange={handleChange}
                              />
                            </div>
                          </div>

                          <div className="w-full md:w-1/2 lg:w-1/2">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Ngày và giờ lấy hàng
                              </Label>
                              <Space direction="vertical">
                                <DatePicker
                                  showTime
                                  value={dayjs(formData.dateShip)}
                                  onChange={(date) =>
                                    handleDateChange(
                                      date?.toDate() || new Date()
                                    )
                                  }
                                />
                              </Space>
                            </div>
                          </div>

                          <div className="w-full md:w-1/2 lg:w-1/2">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Phương thức thanh toán
                              </Label>
                              <Select
                                onValueChange={(value) => {
                                  handleChangeMethod(value, "paymentMethod");
                                }}
                              >
                                <SelectTrigger className="w-full bg-white text-black">
                                  <SelectValue placeholder="Chọn phương thức" />
                                </SelectTrigger>
                                <SelectContent>
                                  <SelectGroup>
                                    <SelectItem value="Thanh toán online">
                                      Thanh toán online
                                    </SelectItem>
                                    <SelectItem value=" Thanh toán khi nhận hàng">
                                      Thanh toán khi nhận hàng
                                    </SelectItem>
                                  </SelectGroup>
                                </SelectContent>
                              </Select>
                            </div>
                          </div>
                          <div className="w-full md:w-1/2 lg:w-1/2">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Phương thức Vận Chuyển
                              </Label>
                              <Select
                                onValueChange={(value) => {
                                  handleChangeMethod(value, "shippingMethod");
                                }}
                              >
                                <SelectTrigger className="w-full bg-white text-black">
                                  <SelectValue placeholder="Chọn phương thức" />
                                </SelectTrigger>
                                <SelectContent>
                                  <SelectGroup>
                                    <SelectItem value="Máy bay">
                                      Máy bay
                                    </SelectItem>
                                    <SelectItem value="Xe lửa">
                                      Xe lửa
                                    </SelectItem>
                                    <SelectItem value="Xe máy">
                                      Xe máy
                                    </SelectItem>
                                    <SelectItem value="Xe tải">
                                      Xe tải
                                    </SelectItem>
                                  </SelectGroup>
                                </SelectContent>
                              </Select>
                            </div>
                          </div>

                          <div className="w-full md:w-1/2 lg:w-full">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Ghi chú
                              </Label>
                              <Input
                                className="bg-white text-black"
                                name="additionalServices"
                                placeholder="Ghi chú"
                                value={formData.additionalServices}
                                onChange={handleChange}
                              />
                            </div>
                          </div>
                          <div className="w-full md:w-full lg:w-full">
                            <div className="tw-booking-footer">
                              <div className="tw-booking-footer-btn">
                                <button
                                  type="submit"
                                  className="btn-half site-button"
                                >
                                  <span>Submit Now</span>
                                  <em></em>
                                </button>
                              </div>
                              <span className="tw-booking-footer-text">
                                Quote
                              </span>
                            </div>
                          </div>
                        </div>
                      </form>
                    </div>

                    <div className="booking-tab-content">
                      <form className="track-and-trace-form">
                        <div className="flex flex-wrap">
                          <div className="w-full md:w-full lg:w-full">
                            <div className="mb-3">
                              <select
                                id="Shipment_Type"
                                className="form-select"
                              >
                                <option selected>Shipment Type</option>
                                <option>Road</option>
                                <option>Train</option>
                                <option>Air</option>
                                <option>Sea</option>
                              </select>
                            </div>
                          </div>
                          <div className="w-full md:w-full lg:w-full">
                            <div className="mb-3">
                              <textarea
                                className="form-control"
                                id="exampleFormControlTextarea1"
                                rows={3}
                              ></textarea>
                            </div>
                          </div>

                          <div className="w-full lg:w-full">
                            <div className="tw-inline-checked mt-2 mb-3">
                              <div className="mb-4 form-check">
                                <input
                                  type="checkbox"
                                  className="form-check-input"
                                  id="Fragile1"
                                />
                                <label
                                  className="form-check-label"
                                  htmlFor="Fragile1"
                                >
                                  Fragile
                                </label>
                              </div>

                              <div className="mb-4 form-check">
                                <input
                                  type="checkbox"
                                  className="form-check-input"
                                  id="Express2"
                                />
                                <label
                                  className="form-check-label"
                                  htmlFor="Express2"
                                >
                                  Express Delivery
                                </label>
                              </div>

                              <div className="mb-4 form-check">
                                <input
                                  type="checkbox"
                                  className="form-check-input"
                                  id="Insurance3"
                                />
                                <label
                                  className="form-check-label"
                                  htmlFor="Insurance3"
                                >
                                  Insurance
                                </label>
                              </div>

                              <div className="mb-4 form-check">
                                <input
                                  type="checkbox"
                                  className="form-check-input"
                                  id="packaging4"
                                />
                                <label
                                  className="form-check-label"
                                  htmlFor="packaging4"
                                >
                                  Packaging
                                </label>
                              </div>
                            </div>
                          </div>

                          <div className="w-full md:w-full lg:w-full">
                            <div className="tw-booking-footer">
                              <div className="tw-booking-footer-btn">
                                <button
                                  type="submit"
                                  className="btn-half site-button"
                                >
                                  <span>Track & Trace</span>
                                  <em></em>
                                </button>
                              </div>
                              <span className="tw-booking-footer-text">
                                Trace
                              </span>
                            </div>
                          </div>
                        </div>
                      </form>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default RequestAQuote;