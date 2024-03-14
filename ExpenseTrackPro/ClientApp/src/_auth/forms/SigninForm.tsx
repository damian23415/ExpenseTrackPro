﻿import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { SigninValidation } from "@/lib/validation";
import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { SignIn } from "../api/Helper";
import { AxiosResponse } from "axios";
import { ErrorTypes } from "@/constants/errorTypes";
import { useToast } from "@/components/ui/use-toast";
import { useNavigate } from "react-router-dom";
import { useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { loginUser } from "@/store/UserSlice";

const SinginForm = () => {
  const { toast } = useToast();
  const navigate = useNavigate();

  //states
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  //redux state

  const dispatch = useDispatch<any>();

  const form = useForm<z.infer<typeof SigninValidation>>({
    resolver: zodResolver(SigninValidation),
    defaultValues: {
      email: "",
      password: "",
    },
  });

  let formData = { email, password };
  dispatch(loginUser(formData));

  async function onSubmit(values: z.infer<typeof SigninValidation>) {
    await SignIn(values).then((response: AxiosResponse) => {
      let errorMessage: any;
      if (response.data.errorCode === ErrorTypes.AccountWithEmailNotExist) {
        errorMessage = "Account with given email not exists in system";
        return toast({
          title: response.data.statusCode,
          description: errorMessage,
          toastContainerStyles:
            "absolute bottom-4 right-4 gap-2 bg-red p-1.5 rounded-lg shadow-lg",
          toastTitleStyles: "text-xs mb-2",
          toastDescriptionStyles: "text-base",
          toastCloseStyles: "absolute bottom-8 right-1",
        });
      } else if (
        response.data.errorCode === ErrorTypes.InvalidEmailOrPassword
      ) {
        errorMessage = "Invalid email or password";
        return toast({
          title: response.data.statusCode,
          description: errorMessage,
          toastContainerStyles:
            "absolute bottom-4 right-4 gap-2 bg-red p-1.5 rounded-lg shadow-lg",
          toastTitleStyles: "text-xs mb-2",
          toastDescriptionStyles: "text-base",
          toastCloseStyles: "absolute bottom-8 right-1",
        });
      } else {
        errorMessage = "Successfully logged in";

        toast({
          title: response.data.statusCode,
          description: errorMessage,
          toastContainerStyles:
            "absolute bottom-4 right-4 gap-2 bg-lime-600 p-1.5 rounded-lg shadow-lg",
          toastTitleStyles: "text-xs mb-2",
          toastDescriptionStyles: "text-base",
          toastCloseStyles: "absolute bottom-8 right-1",
        });

        navigate("/");
        return;
      }
    });
  }

  return (
    <Form {...form}>
      <div className="sm:w-420 flex-center flex-col">
        <h2 className="text-light-3 small-medium md:base-regular mt-2">
          Already have an account? Plase log in
        </h2>

        <form
          onSubmit={form.handleSubmit(onSubmit)}
          className="flex flex-col gap-5 w-full mt-4"
        >
          <FormField
            control={form.control}
            name="email"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>E-mail</FormLabel>
                <FormControl>
                  <Input
                    type="email"
                    className="shad-input"
                    {...field}
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="password"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>Password</FormLabel>
                <FormControl>
                  <Input
                    type="password"
                    className="shad-input"
                    {...field}
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                  />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <Button type="submit" className="shad-button_primary">
            Log in
          </Button>
        </form>
      </div>
    </Form>
  );
};

export default SinginForm;
