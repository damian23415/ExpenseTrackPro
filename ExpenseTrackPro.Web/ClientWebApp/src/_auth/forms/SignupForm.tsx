import { z } from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { Link } from "react-router-dom";

import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";

import { Button } from "@/components/ui/button";
import { useForm } from "react-hook-form";
import { SignupValidation } from "@/lib/validation";
import { Loader } from "lucide-react";
import { SignUp } from "../api/Helper.js";
import { useToast } from "@/components/ui/use-toast";
import { AxiosError, AxiosResponse } from "axios";
import { ErrorTypes } from "@/constants/errorTypes.js";

const SignupForm = () => {
  const { toast } = useToast();
  const isLoading = false;

  const form = useForm<z.infer<typeof SignupValidation>>({
    resolver: zodResolver(SignupValidation),
    defaultValues: {
      firstName: "",
      lastName: "",
      gender: "",
      username: "",
      email: "",
      password: "",
      confirmPassword: "",
    },
  });

  async function onSubmit(values: z.infer<typeof SignupValidation>) {
    await SignUp(values)
      .then((response: AxiosResponse) => {
        console.log(response);
        let errorMessage: any;

        if (
          response.data.errorCode === ErrorTypes.AccountWithEmailAlreadyExist
        ) {
          errorMessage = "Account with given email address already exists";
          console.log(errorMessage);
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
          {
            errorMessage = "Account created";
            console.log(errorMessage);
            return toast({
              title: response.data.statusCode,
              description: errorMessage,
              toastContainerStyles:
                "absolute bottom-4 right-4 gap-2 bg-lime-600 p-1.5 rounded-lg shadow-lg",
              toastTitleStyles: "text-xs mb-2",
              toastDescriptionStyles: "text-base",
              toastCloseStyles: "absolute bottom-8 right-1",
            });
          }
        }
      })
      .catch((err: AxiosError) => {
        console.log(err.response);
        return toast({
          description: "Something went wrong",
          toastContainerStyles:
            "absolute bottom-4 right-4 gap-2 bg-red p-2 rounded-lg shadow-lg",
          toastTitleStyles: "text-xs mb-2",
          toastDescriptionStyles: "text-base",
          toastCloseStyles: "none",
        });
      });
  }

  return (
    <Form {...form}>
      <div className="sm:w-420 flex-center flex-col">
        <img src="/assets/images/logo.svg" alt="logo" />

        <h2 className="h3-bold md:h2-bold pt-5 sm:pt-12">
          Create a new Account
        </h2>
        <p className="text-light-3 small-medium md:base-regular mt-2">
          To use ExpenseTrackPro enter your account details
        </p>

        <form
          onSubmit={form.handleSubmit(onSubmit)}
          className="flex flex-col gap-5 w-full mt-4"
        >
          <FormField
            control={form.control}
            name="firstName"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>First Name</FormLabel>
                <FormControl>
                  <Input type="text" className="shad-input" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="lastName"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>Last Name</FormLabel>
                <FormControl>
                  <Input type="text" className="shad-input" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="username"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>Username</FormLabel>
                <FormControl>
                  <Input type="text" className="shad-input" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="gender"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>Gender</FormLabel>
                <FormControl>
                  <Input type="text" className="shad-input" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="email"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>Email</FormLabel>
                <FormControl>
                  <Input type="email" className="shad-input" {...field} />
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
                  <Input type="password" className="shad-input" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="confirmPassword"
            render={({ field }) => (
              <FormItem className="flex flex-col">
                <FormLabel>Confirm Password</FormLabel>
                <FormControl>
                  <Input type="password" className="shad-input" {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <Button type="submit" className="shad-button_primary">
            {isLoading ? (
              <div className="flex-center gap-2">
                <Loader /> Loading...
              </div>
            ) : (
              "Sign up"
            )}
          </Button>

          <p className="text-small-regular text-light-3 text-center mt-2">
            Already have an account?
            <Link
              to="/sign-in"
              className="text-primary-500 text-small-semibold ml-1"
            >
              Log in
            </Link>
          </p>
        </form>
      </div>
    </Form>
  );
};

export default SignupForm;
