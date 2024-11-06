import Autoplay from "embla-carousel-autoplay";
import {
  Carousel,
  CarouselContent,
  CarouselItem,
} from "@/components/ui/carousel";
import img1 from "@/assets/img/bg-large.jpg";
import img2 from "@/assets/img/bg-large2.jpg";
import img3 from "@/assets/img/bg-large3.jpg";
export function Slider() {
  const sliders = [
    {
      id: 1,
      img: img1,
      title1: "To every",
      title2: "direction",
      desc: "",
    },
    {
      id: 2,
      img: img2,
      title1: "To every",
      title2: "direction",
      desc: "",
    },
    {
      id: 3,
      img: img3,
      title1: "To every",
      title2: "direction",
      desc: "",
    },
  ];
  return (
    <Carousel
      opts={{
        loop: true,
      }}
      plugins={[
        Autoplay({
          delay: 10000,
        }),
      ]}
      className="w-full  "
    >
      <CarouselContent className="w-[]">
        {sliders.map((item, index) => (
          <CarouselItem key={index}>
            <div
              className="relative h-[calc(100vh-80px)] bg-bottom bg-cover"
              style={{ backgroundImage: `url(${item.img})` }}
            >
              <div className="max-w-[1200px] h-full md:mx-auto pt-[100px] md:pt-[120px] md:mx-[20px] sm:mx-[30px]  xs:mx-[10px] ">
                <div className="md:w-[680px] sm:w-full h-full xs:w-full">
                  <h2 className="md:text-[120px] md:leading-[110px] text-white uppercase font-oswald font-extrabold mb-5 sm:text-[60px] xs:text-[50px]">
                    <span className="text-[#ff8a00] md:text-[140px] sm:text-[60px] xs:text-[50px]">
                      {item.title1}
                    </span>{" "}
                    {item.title2}
                  </h2>
                  <p className="text-[24px] text-[#fff]">{item.desc}</p>
                  <button className="outline-none  mt-[20px] text-white px-8 py-3 tracking-wider relative inline-table bg-transparent border border-white text-[18px] uppercase transition-all duration-500 ease-in-out hover:bg-[#ff8a00]">
                    View services
                  </button>
                </div>
              </div>
            </div>
          </CarouselItem>
        ))}
      </CarouselContent>
      {/* <CarouselPrevious className="right-[50%]" />
      <CarouselNext className="absolute" /> */}
    </Carousel>
  );
}
