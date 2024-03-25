import React from "react";
import { Outlet } from "react-router-dom";

const RootLayout = () => {
  return (
    <section className="flex flex-1 h-full justify-center w-full">
      <Outlet />
    </section>
  );
};

export default RootLayout;
