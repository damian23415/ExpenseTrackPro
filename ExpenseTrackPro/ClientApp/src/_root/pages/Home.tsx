import React from "react";
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";

const currentUser = () => {
  var user = JSON.parse(localStorage.getItem("user"));
  return `${user.firstName} ${user.lastName}`;
};

const Home = () => {
  return (
    <div className="flex justify-center h-full w-3/4">
      <section className="flex w-1/3 bg-[#1a2647]">
        <div className="flex w-full">
          <div className="w-1/5">
            <Avatar>
              <AvatarImage
                className="w-10 h-10 rounded-full"
                src="https://github.com/shadcn.png"
              />
              <AvatarFallback>CN</AvatarFallback>
            </Avatar>
          </div>
          <div className="flex flex-col w-4/5">
            <p className="text-lime-100">Hey,</p>
            <p className="text-lime-100">{currentUser()}</p>
          </div>
        </div>
      </section>
      <section className="w-2/3 bg-[#203757]">
        <p>tutaj bedzie dashboard</p>
      </section>
    </div>
  );
};

export default Home;
