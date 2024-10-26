import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuGroup,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "./ui/dropdown-menu";
import { Button } from "./ui/button";
import { BadgeCheck, CircleDashed, LogOut, UserIcon } from "lucide-react";

import { useUser } from "@/context";
import { Link, useNavigate } from "react-router-dom";
import Account from "./Account";

const User = () => {
  const nav = useNavigate();
  const { state, dispatch } = useUser();
  const handleLogout = () => {
    dispatch({
      type: "UPDATE_USER",
      payload: null,
    });
    dispatch({
      type: "TOGGLE_ADMIN",
    });
    nav("/");
  };
  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button
          size="lg"
          className="data-[state=open]:bg-sidebar-accent data-[state=open]:text-sidebar-accent-foreground flex gap-4 bg-transparent hover:bg-transparent"
        >
          <Account />
        </Button>
      </DropdownMenuTrigger>
      <DropdownMenuContent
        className="w-[--radix-dropdown-menu-trigger-width] min-w-56 rounded-lg"
        // side={isMobile ? "bottom" : "right"}
        align="end"
        sideOffset={4}
      >
        <DropdownMenuLabel className="p-0 font-normal">
          <div className="flex items-center gap-2 px-1 py-1.5 text-left text-sm">
            <Account />
            <div className="grid flex-1 text-left text-sm leading-tight">
              <span className="truncate font-semibold">
                {state?.data?.name}
              </span>
              <span className="truncate text-xs">{state?.data?.email}</span>
            </div>
          </div>
        </DropdownMenuLabel>
        <DropdownMenuSeparator />

        <DropdownMenuGroup>
          <DropdownMenuItem>
            <BadgeCheck />
            Account
          </DropdownMenuItem>
        </DropdownMenuGroup>
        <DropdownMenuSeparator />
        <Link to={"/staff"}>
          <DropdownMenuItem className="cursor-pointer">
            <UserIcon />
            Staff
          </DropdownMenuItem>
        </Link>

        <DropdownMenuSeparator />
        <Link to={"/admin/dashboard"}>
          <DropdownMenuItem className="cursor-pointer">
            <CircleDashed />
            Admin
          </DropdownMenuItem>
        </Link>
        <DropdownMenuSeparator />
        <DropdownMenuItem className="cursor-pointer  " onClick={handleLogout}>
          <LogOut />
          Log out
        </DropdownMenuItem>
      </DropdownMenuContent>
    </DropdownMenu>
  );
};

export default User;
