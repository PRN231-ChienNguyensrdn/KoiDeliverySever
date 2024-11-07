import { createElement, FC, useMemo } from "react";
import { Gauge, Table } from "lucide-react";
import { paths } from "@/constants";
import { NavLink } from "react-router-dom";
import { cn } from "@/lib/utils";
import LogoComponent from "./LogoComponent";
import { Separator } from "./ui/separator";

interface SidebarProps {
  isAdmin?: boolean;
}
const Sidebar: FC<SidebarProps> = ({ isAdmin = true }) => {
  const menus = useMemo(
    () =>
      isAdmin
        ? [
            {
              title: "Dashboard",
              icon: Gauge,
              path: "/admin/" + paths.dashboard,
            },
            {
              title: "Orders Management",
              icon: Table,
              path: "/admin/" + paths.ordersManagement,
            },
          ]
        : [
            {
              title: "Orders Management",
              icon: Table,
              path: "/staff",
            },
            {
              title: "Shipment",
              icon: Table,
              path: "/staff/shipment",
            },
          ],
    [isAdmin]
  );
  return (
    <div className="space-y-3">
      <LogoComponent />
      <Separator />
      <div className="px-3 py-2">
        <h2 className="mb-4 px-4 text-start text-2xl text-white font-bold tracking-tight">
          {isAdmin ? "Admin" : "Staff"}
        </h2>
        <ul className="space-y-3">
          {menus.map((menu) => (
            <li key={menu.path}>
              <NavLink
                to={menu.path}
                className={({ isActive }) =>
                  cn(
                    "flex items-center  p-2 rounded-lg",
                    "w-full justify-start",
                    "hover:bg-accent hover:text-accent-foreground",
                    "text-base font-semibold text-white",
                    isActive &&
                      "bg-secondary text-secondary-foreground hover:bg-secondary/80"
                  )
                }
              >
                <div className="mr-3">
                  {createElement(menu.icon, { className: "font-bold" })}
                </div>
                {menu.title}
              </NavLink>
            </li>
          ))}
        </ul>
      </div>
    </div>
  );
};

export default Sidebar;
