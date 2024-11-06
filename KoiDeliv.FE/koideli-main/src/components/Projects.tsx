import { Search } from "lucide-react";

import {
  Carousel,
  CarouselContent,
  CarouselItem,
  CarouselNext,
  CarouselPrevious,
} from "./ui/carousel";

// Bổ sung thêm hình ảnh
import img1 from "@/assets/img/project/cakoi2.png";
import img2 from "@/assets/img/project/cakoi5.png";
import img3 from "@/assets/img/project/cakoi6.png";
import img4 from "@/assets/img/project/cakoi7.png";  // Thêm hình ảnh mới ở đây

const Projects = () => {
  return (
    <div className="section-full section-full p-t120 p-b90 tw-project-2-wrap site-bg-gray">
      <div className="section-content">
        <div className="container">
          <div className="section-head center wt-small-separator-outer">
            <div className="wt-small-separator site-text-primary">
              <div>Projects</div>
            </div>
            <h2 className="wt-title">Featured Projects</h2>
            <p className="section-head-text">
              Lorem Ipsum is simply dummy text of the printing and typesetting
              industry the standard dummy text ever since the when an printer
              took.
            </p>
          </div>
        </div>

        <div className="tw-project-2-content m-b30">
          <div className="w-full px-20 bg-white py-10">
            <Carousel
              opts={{
                align: "start",
                loop: true,
              }}
              className="w-full"
            >
              <CarouselContent>
                {/* Bổ sung thêm các CarouselItem với hình ảnh khác nhau */}
                <CarouselItem className="md:basis-1/2 lg:basis-1/4">
                  <div className="p-1">
                    <div className="item">
                      <div className="project-new-2">
                        <div className="wt-img-effect">
                          <img src={img1} alt="Koi Fish Delivery 1" className="w-full" />
                          <div className="project-view">
                            <div
                              className="elem pic-long project-view-btn"
                              title="Koi Fish Delivery 1"
                            >
                              <Search className="absolute z-10 top-[30%] left-[30%]" />
                            </div>
                          </div>
                        </div>
                        <div className="project-new-content">
                          <span className="project-new-category">
                            Delivery Koi Fish
                          </span>
                          <h4 className="wt-title">
                            <a href="services-detail.html">Fast, Safe, Affordable</a>
                          </h4>
                          <a href="services-detail.html" className="site-button-h-align">
                            Read More
                          </a>
                        </div>
                      </div>
                    </div>
                  </div>
                </CarouselItem>
                
                <CarouselItem className="md:basis-1/2 lg:basis-1/4">
                  <div className="p-1">
                    <div className="item">
                      <div className="project-new-2">
                        <div className="wt-img-effect">
                          <img src={img2} alt="Koi Fish Delivery 2" className="w-full" />
                          <div className="project-view">
                            <div
                              className="elem pic-long project-view-btn"
                              title="Koi Fish Delivery 2"
                            >
                              <Search className="absolute z-10 top-[30%] left-[30%]" />
                            </div>
                          </div>
                        </div>
                        <div className="project-new-content">
                          <span className="project-new-category">
                            Delivery Koi Fish
                          </span>
                          <h4 className="wt-title">
                            <a href="services-detail.html">Fast, Safe, Affordable</a>
                          </h4>
                          <a href="services-detail.html" className="site-button-h-align">
                            Read More
                          </a>
                        </div>
                      </div>
                    </div>
                  </div>
                </CarouselItem>

                {/* Bổ sung thêm item với các hình ảnh khác */}
                <CarouselItem className="md:basis-1/2 lg:basis-1/4">
                  <div className="p-1">
                    <div className="item">
                      <div className="project-new-2">
                        <div className="wt-img-effect">
                          <img src={img3} alt="Koi Fish Delivery 3" className="w-full" />
                          <div className="project-view">
                            <div
                              className="elem pic-long project-view-btn"
                              title="Koi Fish Delivery 3"
                            >
                              <Search className="absolute z-10 top-[30%] left-[30%]" />
                            </div>
                          </div>
                        </div>
                        <div className="project-new-content">
                          <span className="project-new-category">
                            Delivery Koi Fish
                          </span>
                          <h4 className="wt-title">
                            <a href="services-detail.html">Fast, Safe, Affordable</a>
                          </h4>
                          <a href="services-detail.html" className="site-button-h-align">
                            Read More
                          </a>
                        </div>
                      </div>
                    </div>
                  </div>
                </CarouselItem>

                <CarouselItem className="md:basis-1/2 lg:basis-1/4">
                  <div className="p-1">
                    <div className="item">
                      <div className="project-new-2">
                        <div className="wt-img-effect">
                          <img src={img4} alt="Koi Fish Delivery 4" className="w-full" />
                          <div className="project-view">
                            <div
                              className="elem pic-long project-view-btn"
                              title="Koi Fish Delivery 4"
                            >
                              <Search className="absolute z-10 top-[30%] left-[30%]" />
                            </div>
                          </div>
                        </div>
                        <div className="project-new-content">
                          <span className="project-new-category">
                            Delivery Koi Fish
                          </span>
                          <h4 className="wt-title">
                            <a href="services-detail.html">Fast, Safe, Affordable</a>
                          </h4>
                          <a href="services-detail.html" className="site-button-h-align">
                            Read More
                          </a>
                        </div>
                      </div>
                    </div>
                  </div>
                </CarouselItem>
              </CarouselContent>
              <CarouselPrevious />
              <CarouselNext />
            </Carousel>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Projects;
