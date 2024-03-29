import { z } from "zod";

export const SignupValidation = z
  .object({
    firstName: z.string().min(2, { message: "Too short" }),
    lastName: z.string().min(2, { message: "Too short" }),
    gender: z.string().min(2, { message: "Too short" }),
    username: z.string().min(2, { message: "Too short" }),
    email: z.string().email(),
    password: z
      .string()
      .min(8, { message: "Password must be at least 8 characters." }),
    confirmPassword: z
      .string()
      .min(8, { message: "Password must be at least 8 characters." }),
  })
  .refine((data) => data.password === data.confirmPassword, {
    message: "Passwords does not match",
    path: ["confirmPassword"],
  });

export const SigninValidation = z.object({
  email: z.string().email(),
  password: z.string(),
});

export const EditUserValidation = z.object({
  email: z.string().email(),
  firstName: z.string().min(2, { message: "Too short" }),
  lastName: z.string().min(2, { message: "Too short" }),
  username: z.string().min(2, { message: "Too short" }),
});
