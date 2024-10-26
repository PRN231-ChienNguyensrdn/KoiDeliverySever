import { Input } from "./ui/input";

import { cn } from "@/lib/utils";
import SheetMenu from "./SheetMenu";

import User from "./User";

const HeaderDashBoard = () => {
  return (
    <div className="border flex items-center px-5 py-3 justify-between">
      <div className="flex items-center">
        <SheetMenu />
        <nav
          className={cn(
            "flex items-center space-x-4 lg:space-x-6 mx-6",
            "xs:hidden"
          )}
        ></nav>
      </div>
      <div className="flex gap-4 items-center">
        <div>
          <Input
            type="search"
            placeholder="Search..."
            className="md:w-[100px] lg:w-[300px]"
            disabled
          />
        </div>
        <User />
      </div>
    </div>
  );
};

export default HeaderDashBoard;
