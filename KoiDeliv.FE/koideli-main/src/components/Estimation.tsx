import { Link } from "react-router-dom";

import bg from "@/assets/img/bg-2.jpg";
const Estimation = () => {
  return (
    <div className="section-full p-t120 site-bg-white  tw-estimation-area">
      <div className="container">
        <div className="wt-separator-two-part">
          <div className="flex flex-wrap wt-separator-two-part-row">
            <div className="w-full md:w-1/1 lg:w-1/2 xl:w-1/2 wt-separator-two-part-left">
              <div className="section-head left wt-small-separator-outer">
                <div className="wt-small-separator site-text-primary">
                  <div>Estimation</div>
                </div>
                <h2 className="wt-title">Has a wide range of solutions</h2>
                <p className="section-head-text text-black">
                  Lorem Ipsum is simply dummy text of the printing and
                  typesetting industry the standard dummy text ever since the
                  when an printer took.
                </p>
              </div>
            </div>
            <div className="w-full md:w-1/1 lg:w-1/2 xl:w-1/2 wt-separator-two-part-right text-right">
              <Link to={"/"} className="btn-half site-button">
                <span>Read More</span>
                <em></em>
              </Link>
            </div>
          </div>
        </div>
      </div>
      <div
        className="tw-estimation-section bg-cover bg-no-repeat"
        style={{
          backgroundImage: `url(${bg})`,
        }}
      >
        <div className="container">
          <div className="flex flex-wrap">
            <div className="w-full md:w-1/2 lg:w-1/3 xl:w-1/3">
              <div className="tw-est-section-block">
                <div className="tw-est-section-block-content">
                  <span className="tw-est-section-number">01</span>
                  <h3 className="tw-title">
                    Solutions and specialized expertise
                  </h3>
                  <p>
                    Our aim is to optimize and improve your supply chain so that
                    we can give you the best service
                  </p>
                  <a href="about-1.html" className="site-button-2-outline">
                    <i className="fa fa-angle-right"></i>
                  </a>
                </div>
              </div>
            </div>

            <div className="w-full md:w-1/2 lg:w-1/3 xl:w-1/3">
              <div className="tw-est-section-block">
                <div className="tw-est-section-block-content">
                  <span className="tw-est-section-number">02</span>
                  <h3 className="tw-title">Multiple warehouses</h3>
                  <p>
                    We provide multiple drop off and pickup locations so you
                    don't have to worry. And you should not face any kind...
                  </p>
                  <a href="about-1.html" className="site-button-2-outline">
                    <i className="fa fa-angle-right"></i>
                  </a>
                </div>
              </div>
            </div>

            <div className="w-full md:w-1/2 lg:w-1/3 xl:w-1/3">
              <div className="tw-est-section-block">
                <div className="tw-est-section-block-content">
                  <span className="tw-est-section-number">03</span>
                  <h3 className="tw-title">Tracking made easy</h3>
                  <p>
                    A tracking number for the entire process. so that you can
                    find the exact position. it will help you
                  </p>
                  <a href="about-1.html" className="site-button-2-outline">
                    <i className="fa fa-angle-right"></i>
                  </a>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Estimation;
