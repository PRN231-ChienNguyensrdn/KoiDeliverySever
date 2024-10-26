import { ChevronRight } from "lucide-react";
import AB1 from "@/assets/img/abt-1.jpg";
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
                      <h2>295+</h2>
                      <h3>Branches</h3>
                      <span>Since 1996</span>
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
                      We Are Professional Logistics & cargo Agency
                    </h2>
                  </div>

                  <strong>
                    Sed ut perspiciatis unde omnis iste natus error volup tatem
                    accusantium dolorem que laudantium, totam inventore.
                  </strong>

                  <ul className="description-list text-slate-800">
                    <li className="flex items-center">
                      <ChevronRight className="text-[#ff8a00]" /> Go beyond
                      logistics, make the world go round and revolutionize
                      business.
                    </li>
                    <li className="flex items-center">
                      <ChevronRight className="text-[#ff8a00]" /> Logistics
                      through innovation, dedication, and technology. ready,
                      set, done.
                    </li>
                    <li className="flex items-center">
                      <ChevronRight className="text-[#ff8a00]" /> We take pride
                      in serving our customers safely. together with passion.
                    </li>
                    <li className="flex items-center">
                      <ChevronRight className="text-[#ff8a00]" /> Imagination
                      what we can easily see is only a small percentage.
                    </li>
                    <li className="flex items-center">
                      <ChevronRight className="text-[#ff8a00]" /> Quality never
                      goes out of style. safety, quality, professionalism.
                    </li>

                    <li className="flex items-center">
                      <ChevronRight className="text-[#ff8a00]" /> The quality
                      shows in every move we make where business lives.
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
