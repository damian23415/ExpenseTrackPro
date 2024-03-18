import { Routes, Route } from "react-router-dom";

import SigninForm from "./_auth/forms/SigninForm";
import SignupForm from "./_auth/forms/SignupForm";
import { Home } from "./_root/pages";

import AuthLayout from "./_auth/AuthLayout";
import RootLayout from "./_root/RootLayout";
import "./globals.css";
import { Toaster } from "@/components/ui/toaster";
import EditUserForm from "./_root/pages/UserManagement/Form/EditUserForm";

const App = () => {
  return (
    <main className="flex h-screen">
      <Routes>
        {/* public routes*/}
        <Route element={<AuthLayout />}>
          <Route path="/sign-in" element={<SigninForm />} />
          <Route path="/sign-up" element={<SignupForm />} />
        </Route>

        {/* private routes*/}
        <Route element={<RootLayout />}>
          <Route index element={<Home />} />
          <Route path="/edit-user" element={<EditUserForm />} />
        </Route>
      </Routes>

      <Toaster />
    </main>
  );
};

export default App;
