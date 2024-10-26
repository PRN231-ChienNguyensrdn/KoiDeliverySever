import AllServices from "@/components/AllServices";
import OurBlogs from "@/components/OurBlogs";
import Projects from "@/components/Projects";
import { Slider } from "@/components/Slide";
import WhyChooseUs from "@/components/WhyChooseUs";

const HomePage = () => {
  return (
    <div className="w-full h-full">
      <Slider />
      <WhyChooseUs />
      <AllServices />
      <Projects />
      <OurBlogs />
    </div>
  );
};

export default HomePage;
