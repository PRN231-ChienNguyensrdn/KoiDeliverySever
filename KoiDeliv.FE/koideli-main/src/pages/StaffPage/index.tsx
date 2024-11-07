import Header from "@/components/HeaderDashBoard";
import Sidebar from "@/components/Sidebar";

import ListOrder from "./component/ListOrder";
import ListShipment from "./component/ListShipment";

const StaffPage = () => {
  return (
    <div className="grid grid-cols-11 ">
      <div className="2xl:block  sm:hidden xs:hidden col-span-2   min-h-screen px-3 py-4 border-r">
        <Sidebar isAdmin={false} />
      </div>

      <div className="2xl:col-span-9 sm:col-span-11 xs:col-span-11">
        <Header />
        {/* <ListOrder /> */}

        <ListShipment/>
        {/* <div>{children}</div> */}
      </div>
    </div>
  );
};

export default StaffPage;
