import pic1 from "@/assets/img/pic3.png";
import pic2 from "@/assets/img/pic1.png";
import pic3 from "@/assets/img/pic2.png";
import pic4 from "@/assets/img/pic4.png";
import pic5 from "@/assets/img/pic5.png";
import pic6 from "@/assets/img/pic6.png";
const AllServices = () => {
  return (
    <div className="section-full p-t120 p-b90 site-bg-gray tw-service-gallery-style3-area">
      <div className="services-gallery-block-outer3">
        <div className="container">
          <div className="section-head center wt-small-separator-outer">
            <div className="wt-small-separator site-text-primary">
              <div>All services</div>
            </div>
            <h2 className="wt-title">Trusted For Our Services</h2>
            <p className="section-head-text">
            </p>
          </div>

          <div className="section-content">
            <div className="services-gallery-style3">
              <div className="flex flex-wrap">
                <div className="w-full md:w-1/2 lg:w-1/3 mb-4">
                  <div className="service-box-style3">
                    <div className="service-media">
                      <img src={pic1} alt="" />
                    </div>
                    <div className="service-content">
                      <h3 className="service-title-large">
                        <span className="service-title-large-number">01</span>
                        <button>Air Freight</button>
                      </h3>
                      <p>
                        Our aim is to optimize and improve your supply chain so
                        that we can give you the best service.
                      </p>
                      <button className="site-button-100">View Detail</button>
                    </div>
                  </div>
                </div>

                <div className="w-full md:w-1/2 lg:w-1/3 mb-4">
                  <div className="service-box-style3">
                    <div className="service-media">
                      <img src={pic2} alt="" />
                    </div>
                    <div className="service-content">
                      <h3 className="service-title-large">
                        <span className="service-title-large-number">02</span>
                        <button>Road Freight</button>
                      </h3>
                      <p>
                        Our aim is to optimize and improve your supply chain so
                        that we can give you the best service.
                      </p>
                      <button className="site-button-100">View Detail</button>
                    </div>
                  </div>
                </div>

                <div className="w-full md:w-1/2 lg:w-1/3 mb-4">
                  <div className="service-box-style3">
                    <div className="service-media">
                      <img src={pic3} alt="" />
                    </div>
                    <div className="service-content">
                      <h3 className="service-title-large">
                        <span className="service-title-large-number">03</span>
                        <button>Ocean Freight</button>
                      </h3>
                      <p>
                        Our aim is to optimize and improve your supply chain so
                        that we can give you the best service.
                      </p>
                      <button className="site-button-100">View Detail</button>
                    </div>
                  </div>
                </div>

                <div className="w-full md:w-1/2 lg:w-1/3 mb-4">
                  <div className="service-box-style3">
                    <div className="service-media">
                      <img src={pic4} alt="" />
                    </div>
                    <div className="service-content">
                      <h3 className="service-title-large">
                        <span className="service-title-large-number">04</span>
                        <button>Rail Freight</button>
                      </h3>
                      <p>
                        Our aim is to optimize and improve your supply chain so
                        that we can give you the best service.
                      </p>
                      <button className="site-button-100">View Detail</button>
                    </div>
                  </div>
                </div>

                <div className="w-full md:w-1/2 lg:w-1/3 mb-4">
                  <div className="service-box-style3">
                    <div className="service-media">
                      <img src={pic5} alt="" />
                    </div>
                    <div className="service-content">
                      <h3 className="service-title-large">
                        <span className="service-title-large-number">05</span>
                        <button>Warehousing</button>
                      </h3>
                      <p>
                        Our aim is to optimize and improve your supply chain so
                        that we can give you the best service.
                      </p>
                      <button className="site-button-100">View Detail</button>
                    </div>
                  </div>
                </div>

                <div className="w-full md:w-1/2 lg:w-1/3 mb-4">
                  <div className="service-box-style3">
                    <div className="service-media">
                      <img src={pic6} alt="" />
                    </div>
                    <div className="service-content">
                      <h3 className="service-title-large">
                        <span className="service-title-large-number">06</span>
                        <button>Project Cargo</button>
                      </h3>
                      <p>
                        Our aim is to optimize and improve your supply chain so
                        that we can give you the best service.
                      </p>
                      <button className="site-button-100">View Detail</button>
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

export default AllServices;
