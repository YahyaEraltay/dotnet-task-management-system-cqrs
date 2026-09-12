import axiosClient from "./axiosClient";
import type { UserListItem } from "./types";

export const userApi = {
  getAll: () =>
    axiosClient.get<UserListItem[]>("/User/All").then((res) => res.data),
};