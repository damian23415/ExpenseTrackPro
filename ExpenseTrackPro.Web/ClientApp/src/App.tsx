import { Routes, Route } from "react-router-dom";

import SigninForm from "./_auth/forms/SigninForm";
import SignupForm from "./_auth/forms/SignupForm";
import { Home } from "./_root/pages";

import AuthLayout from "./_auth/AuthLayout";
import RootLayout from "./_root/RootLayout";
import "./globals.css";
import { Toaster } from "@/components/ui/toaster";
import EditUserForm from "./_root/pages/UserManagement/Form/EditUserForm";
import Dashboard from "./_root/pages/Business/Dashboard";
import Transactions from "./_root/pages/Business/Transactions";

const App = () => {
  return (
    <main className="flex h-screen bg-[#F1F1F1]">
      <Routes>
        {/* public routes*/}
        <Route element={<AuthLayout />}>
          <Route path="/sign-in" element={<SigninForm />} />
          <Route path="/sign-up" element={<SignupForm />} />
        </Route>

        {/* private routes*/}
        <Route element={<RootLayout />}>
          <Route path="/home" element={<Home />} />
          <Route path="/edit-user" element={<EditUserForm />} />
          <Route path="/dashboard" element={<Dashboard />} />
          <Route path="/transactions" element={<Transactions />} />
        </Route>
      </Routes>

      <Toaster />
    </main>
  );
};

export default App;
