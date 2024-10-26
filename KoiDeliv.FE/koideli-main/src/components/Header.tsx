import { Sheet, SheetTrigger, SheetContent } from "@/components/ui/sheet";
import { Button } from "@/components/ui/button";
import {
  NavigationMenu,
  NavigationMenuList,
  NavigationMenuLink,
} from "@/components/ui/navigation-menu";
import { Link } from "react-router-dom";

import { Menu } from "lucide-react";
import LogoComponent from "./LogoComponent";
import User from "./User";
import { useUser } from "@/context";

export function Header() {
  const { state } = useUser();
  return (
    <header className="flex h-20 w-full shrink-0 items-center px-4 md:px-6 fixed bg-white z-50">
      <Sheet>
        <SheetTrigger asChild>
          <Button variant="outline" size="icon" className="lg:hidden">
            <Menu className="h-6 w-6" />
            <span className="sr-only">Toggle navigation menu</span>
          </Button>
        </SheetTrigger>
        <SheetContent side="left">
          <div>
            <LogoComponent />
          </div>
          <div className="grid gap-2 py-6">
            <Link
              to={"/"}
              className="text-purple-950 flex w-full items-center py-2 text-lg font-semibold"
            >
              Home
            </Link>
            <Link
              to={"/"}
              className="text-purple-950 flex w-full items-center py-2 text-lg font-semibold"
            >
              About
            </Link>
            <Link
              to={"/services"}
              className="text-purple-950 flex w-full items-center py-2 text-lg font-semibold"
            >
              Services
            </Link>
            <Link
              to={"/"}
              className="text-purple-950 flex w-full items-center py-2 text-lg font-semibold"
            >
              Portfolio
            </Link>
            <Link
              to={"/"}
              className="text-purple-950 flex w-full items-center py-2 text-lg font-semibold"
            >
              Contact
            </Link>
          </div>
        </SheetContent>
      </Sheet>
      <div className="mr-6 hidden lg:flex text-black">
        <LogoComponent />
      </div>
      <NavigationMenu className="hidden lg:flex flex-1 mx-auto">
        <NavigationMenuList>
          <NavigationMenuLink asChild>
            <div className="group inline-flex h-9 w-max items-center justify-center rounded-md bg-white px-4 py-2 text-sm font-medium transition-colors cursor-pointer hover:text-gray-900 focus:bg-gray-100 focus:text-gray-900 focus:outline-none disabled:pointer-events-none disabled:opacity-50 data-[active]:bg-gray-100/50 data-[state=open]:bg-gray-100/50 dark:bg-gray-950 dark:hover:bg-gray-800 dark:hover:text-gray-50 dark:focus:bg-gray-800 dark:focus:text-gray-50 dark:data-[active]:bg-gray-800/50 dark:data-[state=open]:bg-gray-800/50 text-black">
              <Link to={"/"}>Home</Link>
            </div>
          </NavigationMenuLink>

          <NavigationMenuLink asChild>
            <div className="group inline-flex h-9 w-max items-center justify-center rounded-md bg-white px-4 py-2 text-sm font-medium transition-colors cursor-pointer hover:text-gray-900 focus:bg-gray-100 focus:text-gray-900 focus:outline-none disabled:pointer-events-none disabled:opacity-50 data-[active]:bg-gray-100/50 data-[state=open]:bg-gray-100/50 dark:bg-gray-950 dark:hover:bg-gray-800 dark:hover:text-gray-50 dark:focus:bg-gray-800 dark:focus:text-gray-50 dark:data-[active]:bg-gray-800/50 dark:data-[state=open]:bg-gray-800/50 text-black">
              <Link to={"/service"}>Services</Link>
            </div>
          </NavigationMenuLink>
          <NavigationMenuLink asChild>
            <div className="group inline-flex h-9 w-max items-center justify-center rounded-md bg-white px-4 py-2 text-sm font-medium transition-colors cursor-pointer hover:text-gray-900 focus:bg-gray-100 focus:text-gray-900 focus:outline-none disabled:pointer-events-none disabled:opacity-50 data-[active]:bg-gray-100/50 data-[state=open]:bg-gray-100/50 dark:bg-gray-950 dark:hover:bg-gray-800 dark:hover:text-gray-50 dark:focus:bg-gray-800 dark:focus:text-gray-50 dark:data-[active]:bg-gray-800/50 dark:data-[state=open]:bg-gray-800/50 text-black">
              <Link to={"/order"}>Orders</Link>
            </div>
          </NavigationMenuLink>
        </NavigationMenuList>
      </NavigationMenu>
      {state?.data?.email ? (
        <User />
      ) : (
        <div className=" flex gap-2">
          <Link to={"/login"}>
            <Button variant="outline">Sign in</Button>
          </Link>
          <Link to={"/login"}>
            <Button>Sign Up</Button>
          </Link>
        </div>
      )}
    </header>
  );
}
