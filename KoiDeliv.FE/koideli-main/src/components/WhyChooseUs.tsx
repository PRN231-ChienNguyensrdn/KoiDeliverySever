import { ChevronRight } from "lucide-react";
import AB1 from "@/assets/img/cakoi1.png";
const WhyChooseUs = () => {
  return (
    <div className="section-full p-t120 p-b90 site-bg-white tw-why-choose-area2">
      <div className="tw-why-choose-area-top2">
        <div className="container">
          <div className="tw-why-choose-section2">
            <div className="flex flex-wrap">
              <div className="w-full md:w-6/12 lg:w-6/12 xl:w-6/12">
                <div className="tw-why-choose-right">
                  <div className="tw-why-choose-media1 shine-effect">
                    <div className="shine-box">
                      <img src={AB1} alt="" />
                    </div>
                  </div>
                  <div className="tw-why-choose-tag slide-top shine-effect">
                    <div className="tag-box">
                      <h2>1</h2>
                      <h3>Branch</h3>
                      <span>Since 2024</span>
                    </div>
                  </div>
                </div>
              </div>

              <div className="w-full md:w-6/12 lg:w-6/12 xl:w-6/12">
                <div className="tw-why-choose-left">
                  <div className="section-head left wt-small-separator-outer">
                    <div className="wt-small-separator site-text-primary">
                      <div>Why Choose Us</div>
                    </div>
                    <h2 className="wt-title">
                      We are a dedicated and professional logistics agency specializing in koi fish 
                      transportation. With expertise and care, we ensure the safe and efficient delivery 
                      of each order. Our commitment to quality and safety is at the heart of everything we 
                      do, providing clients peace of mind knowing their koi fish are in trusted hands.


                    </h2>
                  </div>

                  <ul className="description-list text-slate-800">
                    <li className="flex items-center">
                      <ChevronRight className="text-[#ff8a00]" /> Quality & Safety – Advanced technology 
                      ensures the health and protection of every fish.

                    </li>
                    <li className="flex items-center">
                      <ChevronRight className="text-[#ff8a00]" /> Efficiency & Accuracy – Timely, reliable, 
                      and carefully managed shipments, every time.

                    </li>
                    <li className="flex items-center">
                      <ChevronRight className="text-[#ff8a00]" /> Customer Focus – Clear communication and 
                      responsive support for every order.

                    </li>
                    <li className="flex items-center">
                      <ChevronRight className="text-[#ff8a00]" /> Trusted & Professional – Experienced and 
                      reputable, we provide dependable service.
                    </li>
                    
                  </ul>
                  <div className="tw-why-choose-left-bottom">
                    <a href="about-1.html" className="btn-half site-button">
                      <span>Learn More</span>
                      <em></em>
                    </a>
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

export default WhyChooseUs;
