import Footer from "@/components/Footer";
import { Header } from "@/components/Header";
import React, { FC } from "react";

interface MainLayoutProps {
  children: React.ReactNode;
}
const MainLayout: FC<MainLayoutProps> = ({ children }) => {
  return (
    <div>
      <Header />
      <div className="pt-[80px]">{children}</div>
      <Footer />
    </div>
  );
};

export default MainLayout;
