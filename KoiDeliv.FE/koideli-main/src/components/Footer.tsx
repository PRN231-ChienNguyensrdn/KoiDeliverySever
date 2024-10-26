import { FacebookIcon, Mail, Twitter, Youtube } from "lucide-react";
import LogoComponent from "./LogoComponent";

const Footer = () => {
  return (
    <div className="footer-dark">
      <div className="ftr-bg">
        <div className="footer-top">
          <div className="container">
            <div className="flex flex-wrap">
              <div className="w-full md:w-1/2 lg:w-1/4">
                <div className="widget widget_about">
                  <LogoComponent />
                  <p>
                    Many desktop publishing packages and web page editors now
                    use are dolra Ipsum as their default .
                  </p>
                  <ul className="social-icons flex gap-3">
                    <li className="bg-slate-500 p-2">
                      <FacebookIcon />
                    </li>
                    <li className="bg-slate-500 p-2">
                      <Twitter />
                    </li>
                    <li className="bg-slate-500 p-2">
                      <Mail />
                    </li>
                    <li className="bg-slate-500 p-2">
                      <Youtube />
                    </li>
                  </ul>
                </div>
              </div>

              <div className="w-full md:w-1/2 lg:w-1/4">
                <div className="widget widget_services ftr-list-center">
                  <h3 className="widget-title">Quick Links</h3>
                  <ul>
                    <li>
                      <a href="about-1.html">About</a>
                    </li>
                    <li>
                      <a href="services-1.html">Services</a>
                    </li>
                    <li>
                      <a href="blog-grid.html">Blog</a>
                    </li>
                    <li>
                      <a href="about-1.html">FAQ</a>
                    </li>
                    <li>
                      <a href="contact.html">Contact Us</a>
                    </li>
                  </ul>
                </div>
              </div>

              <div className="w-full md:w-1/2 lg:w-1/4">
                <div className="widget widget_services ftr-list-center">
                  <h3 className="widget-title">Services</h3>
                  <ul>
                    <li>
                      <a href="services-detail.html">Warehouse</a>
                    </li>
                    <li>
                      <a href="services-detail.html">Air Freight</a>
                    </li>
                    <li>
                      <a href="services-detail.html">Ocean Freight</a>
                    </li>
                    <li>
                      <a href="services-detail.html">Road Freight</a>
                    </li>
                    <li>
                      <a href="services-detail.html">Packaging</a>
                    </li>
                  </ul>
                </div>
              </div>

              <div className="w-full md:w-1/2 lg:w-1/4">
                <div className="widget widget_services ftr-list-center">
                  <h3 className="widget-title">Community</h3>
                  <ul>
                    <li>
                      <a href="about-1.html">Business Consulting</a>
                    </li>
                    <li>
                      <a href="about-1.html">Testimonials</a>
                    </li>
                    <li>
                      <a href="about-1.html">Track Your Shipment</a>
                    </li>
                    <li>
                      <a href="about-1.html">Privacy Policy</a>
                    </li>
                    <li>
                      <a href="about-1.html">Terms & Condition</a>
                    </li>
                  </ul>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div className="footer-bottom">
          <div className="container">
            <div className="footer-bottom-info">
              <div className="footer-copy-right">
                <span className="copyrights-text">
                  Copyright © 2022 by thewebmax All Rights Reserved.
                </span>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Footer;
