import Banner from "@/assets/img/1.jpg";
import { Link } from "react-router-dom";
const OurServices = () => {
  return (
    <div
      className="wt-bnr-inr overlay-wraper bg-center"
      style={{ backgroundImage: `url(${Banner})` }}
    >
      <div className="overlay-main site-bg-sky opacity-08"></div>
      <div className="container">
        <div className="wt-bnr-inr-entry">
          <div className="banner-title-outer">
            <div className="banner-title-name">
              <h2 className="wt-title">Our Services</h2>
            </div>
          </div>

          <div>
            <ul className="wt-breadcrumb breadcrumb-style-2">
              <li>
                <Link to={"/"}>Home</Link>
              </li>
              <li>Our Services</li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  );
};

export default OurServices;
