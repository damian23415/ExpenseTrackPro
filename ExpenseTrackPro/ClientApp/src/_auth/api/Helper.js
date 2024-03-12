import axios from "axios";

const API = axios.create({ baseURL: "http://localhost:5237/api/Account" });

export const SignIn = (formData) => API.post("/Authentication", formData);
export const SignUp = (formData) => API.post("/RegisterUser", formData);
