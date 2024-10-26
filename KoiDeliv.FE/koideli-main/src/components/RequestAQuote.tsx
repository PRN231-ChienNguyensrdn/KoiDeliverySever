import bg from "@/assets/img/booking/bg-map.png";
import pic1 from "@/assets/img/booking/pic1.png";
import icon1 from "@/assets/img/booking/icon1.png";

import { Input } from "./ui/input";
import { Label } from "./ui/label";
import { DateTimePicker } from "./ui/date-picker";
import {
  Select,
  SelectContent,
  SelectGroup,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "./ui/select";
const RequestAQuote = () => {
  return (
    <div
      className="section-full p-t120 p-b90 site-bg-gray tw-booking-area"
      style={{
        backgroundImage: `url(${bg})`,
      }}
    >
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
                      <form>
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
                                placeholder="Tên người nhận"
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

                          <div className="w-full md:w-1/2 lg:w-1/2">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Phone
                              </Label>
                              <Input
                                className="bg-white text-black"
                                placeholder="Phone"
                              />
                            </div>
                          </div>
                          <div className="w-full md:w-1/2 lg:w-1/2">
                            <div className="mb-3"></div>
                          </div>

                          <div className="w-full md:w-1/2 lg:w-1/2">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Nơi lấy cá
                              </Label>
                              <Input
                                className="bg-white text-black"
                                placeholder="Nơi lấy cá"
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
                                placeholder="Nơi nhận cá"
                              />
                            </div>
                          </div>

                          <div className="w-full md:w-1/4 lg:w-1/4">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Khối lượng
                              </Label>
                              <Input
                                className="bg-white text-black"
                                placeholder="Khối lượng đơn hàng"
                              />
                            </div>
                          </div>
                          <div className="w-full md:w-1/4 lg:w-1/4">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Loại cá
                              </Label>
                              <Input
                                className="bg-white text-black"
                                placeholder="Loại cá"
                              />
                            </div>
                          </div>
                          <div className="w-full md:w-1/2 lg:w-1/2">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Ngày và giờ lấy hàng
                              </Label>
                              <DateTimePicker />
                            </div>
                          </div>
                          <div className="w-full md:w-1/2 lg:w-1/2">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Ngày và giờ giao hàng
                              </Label>
                              <DateTimePicker />
                            </div>
                          </div>
                          <div className="w-full md:w-1/2 lg:w-1/2">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Hướng dẫn đặc biệt
                              </Label>
                              <Input
                                className="bg-white text-black"
                                placeholder="Hướng dẫn đặc biệt"
                              />
                            </div>
                          </div>
                          <div className="w-full md:w-1/2 lg:w-1/2">
                            <div className="mb-3 px-2">
                              <Label className="text-black" htmlFor="email">
                                Phương thức thanh toán
                              </Label>
                              <Select>
                                <SelectTrigger className="w-full bg-white text-black">
                                  <SelectValue placeholder="Chọn phương thức" />
                                </SelectTrigger>
                                <SelectContent>
                                  <SelectGroup>
                                    <SelectItem value="apple">
                                      Thanh toán online
                                    </SelectItem>
                                    <SelectItem value="banana">
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
                                Ghi chú
                              </Label>
                              <Input
                                className="bg-white text-black"
                                placeholder="Ghi chú"
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
