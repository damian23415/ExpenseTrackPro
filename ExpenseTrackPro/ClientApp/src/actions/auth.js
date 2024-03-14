import * as api from "@/_auth/api/Helper.js";

export const login = (formData) => (dispatch) => {
  return api.SignIn(formData).then();
};
