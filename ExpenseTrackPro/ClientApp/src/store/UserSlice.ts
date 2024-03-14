import { createAsyncThunk, createSlice } from "@reduxjs/toolkit";
import { SignIn } from "@/_auth/api/Helper";

export const loginUser = createAsyncThunk(
  "user/loginUser",
  async (formData: { email: string; password: string }) => {
    const request = await SignIn(formData);
    const response = await request.data.data;
    localStorage.setItem("user", JSON.stringify(response));
    return response;
  }
);

const userSlice = createSlice({
  name: "user",
  initialState: {
    loading: false,
    user: null,
    error: null,
  },
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(loginUser.pending, (state) => {
        state.loading = true;
        state.user = null;
        state.error = null;
      })
      .addCase(loginUser.fulfilled, (state, action) => {
        state.loading = false;
        state.user = action.payload;
        state.error = null;
      })
      .addCase(loginUser.rejected, (state, action) => {
        state.loading = false;
        state.user = null;
        console.log(action.error.message);
      });
  },
});

export default userSlice.reducer;
