import axiosClient from "./axiosClient";
import type { LoginRequest, LoginResponse, CurrentUser } from "./types";

export const authApi = {
  login: (data: LoginRequest) =>
    axiosClient.post<LoginResponse>("/User/Login", data).then((res) => res.data),

  getCurrentUser: () =>
    axiosClient.get<CurrentUser>("/User/GetCurrentUser").then((res) => res.data),
};