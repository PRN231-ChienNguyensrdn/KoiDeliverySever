import img1 from "@/assets/img/s-gallery/1.jpg";
import img2 from "@/assets/img/s-gallery/2.jpg";
import img3 from "@/assets/img/s-gallery/3.jpg";
import img4 from "@/assets/img/s-gallery/z5978105931266_8639e33c5579716733b1d8507ece2fe2.jpg";
import img5 from "@/assets/img/s-gallery/z5978130195502_76611c0d48ee7b0a1243ef85afa50b2d.jpg";


const AllServices2 = () => {
  return (
    <div className="section-full p-t120 p-b90 site-bg-gray tw-service-gallery-style1-area tyre-mark-bg">
      <div className="services-gallery-block-outer2">
        <div className="container">
          <div className="section-head center wt-small-separator-outer">
            <div className="wt-small-separator site-text-primary">
              <div>All services</div>
            </div>
            <h2 className="wt-title">Trusted For Our Services</h2>
            <p className="section-head-text">
              Lorem Ipsum is simply dummy text of the printing and typesetting
              industry the standard dummy text ever since the when an printer
              took.
            </p>
          </div>

          <div className="section-content">
            <div className="services-gallery-style1">
              <div className="flex flex-wrap ">
                <div className="w-full md:w-1/2 lg:w-1/3 mb-4 px-2">
                  <div className="service-box-style1">
                    <div className="service-content">
                      <div className="service-content-inner">
                        <div className="service-content-top">
                          <h3 className="service-title-large">
                            <div>Airplane</div>
                          </h3>
                        </div>
                        <div className="service-content-bottom">
                          <span className="service-title-large-number">01</span>
                          <p>
                          Air transport is fast, safe, and reliable, making it ideal for long-distance, especially international routes.
                          </p>
                          <div className="site-button-2">View Detail</div>
                        </div>
                      </div>
                    </div>
                    <div className="service-media">
                      <img src={img1} alt="" />
                    </div>
                  </div>
                </div>
                <div className="w-full md:w-1/2 lg:w-1/3 mb-4 px-2">
                  <div className="service-box-style1">
                    <div className="service-content">
                      <div className="service-content-inner">
                        <div className="service-content-top">
                          <h3 className="service-title-large">
                            <div>Truck</div>
                          </h3>
                        </div>
                        <div className="service-content-bottom">
                          <span className="service-title-large-number">01</span>
                          <p>
                          Flexible in routing and cost-effective, trucks can transport a variety of goods and provide easy door-to-door delivery domestically.
                          </p>
                          <div className="site-button-2">View Detail</div>
                        </div>
                      </div>
                    </div>
                    <div className="service-media">
                      <img src={img2} alt="" />
                    </div>
                  </div>
                </div>
                <div className="w-full md:w-1/2 lg:w-1/3 mb-4 px-2">
                  <div className="service-box-style1">
                    <div className="service-content">
                      <div className="service-content-inner">
                        <div className="service-content-top">
                          <h3 className="service-title-large">
                            <div>Motorcycle</div>
                          </h3>
                        </div>
                        <div className="service-content-bottom">
                          <span className="service-title-large-number">01</span>
                          <p>
                          An optimal choice for fast, flexible, and cost-effective deliveries within cities, easily navigating narrow streets.
                          </p>
                          <div className="site-button-2">View Detail</div>
                        </div>
                      </div>
                    </div>
                    <div className="service-media">
                      <img src={img5} alt="" />
                    </div>
                  </div>
                </div>
                <div className="w-full md:w-1/2 lg:w-1/3 mb-4 px-2">
                  <div className="service-box-style1">
                    <div className="service-content">
                      <div className="service-content-inner">
                        <div className="service-content-top">
                          <h3 className="service-title-large">
                            <div>Train</div>
                          </h3>
                        </div>
                        <div className="service-content-bottom">
                          <span className="service-title-large-number">01</span>
                          <p>
                          Suitable for transporting heavy and large quantities of goods over long distances at a lower cost, with less impact from weather conditions.
                          </p>
                          <div className="site-button-2">View Detail</div>
                        </div>
                      </div>
                    </div>
                    <div className="service-media">
                      <img src={img4} alt="" />
                    </div>
                  </div>
                </div>
                <div className="w-full md:w-1/2 lg:w-1/3 mb-4 px-2">
                  <div className="service-box-style1">
                    <div className="service-content">
                      <div className="service-content-inner">
                        <div className="service-content-top">
                          <h3 className="service-title-large">
                            <div>Ship</div>
                          </h3>
                        </div>
                        <div className="service-content-bottom">
                          <span className="service-title-large-number">01</span>
                          <p>
                          Ideal for international shipping at low costs, suitable for heavy and oversized cargo, and more environmentally friendly than air transport.
                          </p>
                          <div className="site-button-2">View Detail</div>
                        </div>
                      </div>
                    </div>
                    <div className="service-media">
                      <img src={img3} alt="" />
                    </div>
                  </div>  
                </div>{" "}
              </div>
            </div>
          </div>
        </div>
      </div>

      <div className="tw-hilite-text-wrap">
        <div className="tw-hilite-text right">
          <span>Services</span>
        </div>
      </div>
    </div>
  );
};

export default AllServices2;
