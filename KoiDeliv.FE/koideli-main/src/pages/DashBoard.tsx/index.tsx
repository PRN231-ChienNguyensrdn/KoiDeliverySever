import { useState, useEffect } from "react";
import axios from "axios";
import CardDashBoard from "@/components/CardDashBoard";
import ChartDashBoard from "@/components/ChartDashBoard";

const Dashboard = () => {
  const [userCount, setUserCount] = useState(0);
  const [blogCount, setBlogCount] = useState(0); // Thêm biến trạng thái cho số lượng blogs

  useEffect(() => {
    const fetchUserCount = async () => {
      try {
        const response = await axios.get("https://localhost:7184/api/User/Users");
        console.log("User API response data:", response);
        setUserCount(response.data.data.length);
      } catch (error) {
        console.error("Error fetching user count:", error);
      }
    };

    const fetchBlogCount = async () => {
      try {
        const response = await axios.get("https://localhost:7184/api/Blog/Blogs");
        console.log("Blog API response data:", response);
        setBlogCount(response.data.length);  
      } catch (error) {
        console.error("Error fetching blog count:", error);
      }
    };

    fetchUserCount();
    fetchBlogCount(); // Gọi hàm lấy số lượng blogs
  }, []); // [] để chỉ gọi API một lần khi component được render

  return (
    <div className="my-5 flex flex-col gap-4 px-10">
      <h3 className="text-3xl font-bold tracking-tight text-start text-white">
        Dashboard
      </h3>
     
      <div className="grid auto-rows-min gap-4 md:grid-cols-3">
        <CardDashBoard
          title="Total user"
          desc="Displays the current total number of users in the system."
          total={userCount}  
        />
        <CardDashBoard
          title="Total Blogs"
          desc="Displays the current total number of blogs in the system."
          total={blogCount} // Truyền blogCount vào total để hiển thị số lượng blogs
        />
        <CardDashBoard
          title="Total user"
          desc="Displays the current total number of users in the system."
          total={userCount} // Thay đổi tên hoặc nội dung nếu cần
        />
      </div>
      
      <ChartDashBoard />
    </div>
  );
};

export default Dashboard;
