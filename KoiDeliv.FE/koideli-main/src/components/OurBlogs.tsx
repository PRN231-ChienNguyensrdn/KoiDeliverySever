import img1 from "@/assets/img/blog/cakoi3.png";

import img2 from "@/assets/img/blog/cakoi4.png";
const OurBlogs = () => {
  return (
    <div className="section-full p-t120 p-b90 site-bg-white">
      <div className="container">
        <div className="section-head center wt-small-separator-outer">
          <div className="wt-small-separator site-text-primary">
            <div>Our Blogs</div>
          </div>
          <h2 className="wt-title">Recent news & events</h2>
          <p className="section-head-text">
          </p>
        </div>

        <div className="section-content">
          <div className="flex flex-wrap  d-flex justify-content-center">
            <div className="w-full sm:w-full md:w-1/2 lg:w-1/2 m-b30 px-10">
              <div className="blog-post blog-post-4-outer">
                <div className="wt-post-media wt-img-effect zoom-slow">
                  <div>
                    <img src={img1} alt="" />
                  </div>
                </div>
                <div className="wt-post-info">
                  <div className="wt-post-meta ">
                    <ul>
                      <li className="post-date">
                        <span>02</span>Aug
                      </li>
                    </ul>
                  </div>

                  <div className="wt-post-title ">
                    <h3 className="post-title">
                      <div>
                      Explore the essentials of koi fish transportation with our blog – your go-to 
                      resource for safe handling tips, expert advice, and best practices.
                      </div>
                    </h3>
                  </div>
                  <div className="wt-post-text ">
                    <p>
                    Our blog offers guidance on transporting koi fish, covering everything from 
                    preparation and handling to ensuring safe, stress-free journeys for your koi.
                    </p>
                  </div>
                  <div className="wt-post-readmore ">
                    <div className="site-button-link site-text-primary">
                      Read More
                    </div>
                  </div>
                </div>
              </div>
            </div>

            <div className="w-full sm:w-full md:w-1/2 lg:w-1/2 m-b30 px-10">
              <div className="blog-post blog-post-4-outer">
                <div className="wt-post-media wt-img-effect zoom-slow">
                  <div>
                    <img src={img2} alt="" />
                  </div>
                </div>
                <div className="wt-post-info">
                  <div className="wt-post-meta ">
                    <ul>
                      <li className="post-date">
                        <span>21</span> Aug
                      </li>
                    </ul>
                  </div>

                  <div className="wt-post-title ">
                    <h3 className="post-title">
                      <div>
                      Our blog offers guidance on transporting koi fish, covering everything from 
                      preparation and handling to ensuring safe, stress-free journeys for your koi.
                      </div>
                    </h3>
                  </div>
                  <div className="wt-post-text ">
                    <p>
                      New chip traps clusters of migrating tumor cells
                      asperiortenetur, blanditiis odit. typesetting industry the
                      standard dummy text ever since the when an printer.
                    </p>
                  </div>
                  <div className="wt-post-readmore ">
                    <div className="site-button-link site-text-primary">
                      Read More
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

export default OurBlogs;
