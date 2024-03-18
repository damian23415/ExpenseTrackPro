import { Button } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Input } from "@/components/ui/input";
import { EditUserValidation } from "@/lib/validation";
import { zodResolver } from "@hookform/resolvers/zod";
import { AxiosResponse } from "axios";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { EditUser } from "@/_auth/api/Helper.js";
import { useState } from "react";

const GetUser = () => {
  let user = localStorage.getItem("user");
  console.log(user);
  if (user) {
    user = JSON.parse(user);
  } else {
    user = null;
  }

  return user;
};

const EditUserForm = () => {
  const form = useForm<z.infer<typeof EditUserValidation>>({
    resolver: zodResolver(EditUserValidation),
    defaultValues: {
      firstName: "",
      lastName: "",
      username: "",
      email: "",
    },
  });

  async function onSubmit(values: z.infer<typeof EditUserValidation>) {
    console.log(values);
    let jwtToken = localStorage.getItem("jwtToken");
    console.log(jwtToken);
    await EditUser(values, jwtToken);
  }

  return (
    <Form {...form}>
      <div className="sm:w-420 flex-center flex-col">
        <h2 className="h3-bold md:h2-bold pt-5 sm:pt-12">
          Edit an account data
        </h2>
        <p className="text-light-3 small-medium md:base-regular mt-2">
          To edit ExpenseTrackPro account insert valid data
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

          <Button type="submit" className="shad-button_primary">
            Edit user data
          </Button>
        </form>
      </div>
    </Form>
  );
};

export default EditUserForm;
