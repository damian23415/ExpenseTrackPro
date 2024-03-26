import { useState } from "react";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import "@/styles/Dashboard.css";
import WidgetsOutlinedIcon from "@mui/icons-material/WidgetsOutlined";
import MenuOpenOutlinedIcon from "@mui/icons-material/MenuOpenOutlined";

import {
  NavigationMenu,
  NavigationMenuItem,
  NavigationMenuLink,
  NavigationMenuList,
} from "@/components/ui/navigation-menu";
import { Link } from "react-router-dom";
import Dashboard from "./Business/Dashboard";
import Transactions from "./Business/Transactions";

const Home = () => {
  const [selectedTab, setSelectedTab] = useState("dashboard");

  return (
    <div className="flex h-full w-full">
      <section className="flex w-1/4 p-4 bg-white flex flex-col">
        <div className="flex w-full mb-5">
          <div className="w-1/5">
            <Avatar>
              <AvatarImage
                className="w-10 h-10 rounded-full"
                src="https://github.com/shadcn.png"
              />
              <AvatarFallback>CN</AvatarFallback>
            </Avatar>
          </div>
          <div className="flex flex-col justify-center w-3/5 text-dark">
            ExpenseTrackPro
          </div>
        </div>

        <NavigationMenu>
          <NavigationMenuList>
            <NavigationMenuItem className="mt-2">
              <NavigationMenuLink asChild>
                <Link to="" onClick={() => setSelectedTab("dashboard")}>
                  <WidgetsOutlinedIcon />
                  <span className="ml-3">Przegląd</span>
                </Link>
              </NavigationMenuLink>
            </NavigationMenuItem>
            <NavigationMenuItem className="mt-2">
              <NavigationMenuLink asChild>
                <Link to="" onClick={() => setSelectedTab("transactions")}>
                  <MenuOpenOutlinedIcon />
                  <span className="ml-3">Transakcje</span>
                </Link>
              </NavigationMenuLink>
            </NavigationMenuItem>
          </NavigationMenuList>
        </NavigationMenu>
      </section>
      <section className="w-3/4 bg-[#F1F1F1]">
        {selectedTab === "dashboard" && <Dashboard />}
        {selectedTab === "transactions" && <Transactions />}
      </section>
    </div>
  );
};

export default Home;
