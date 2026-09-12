import axiosClient from "./axiosClient";
import type {
  Department,
  DeleteDepartmentResponse,
  CreateDepartmentRequest,
  UpdateDepartmentRequest,
} from "./types";

export const departmentApi = {
  getAll: () =>
    axiosClient.get<Department[]>("/Department/All").then((res) => res.data),

  getDetail: (id: string) =>
    axiosClient.get<Department>(`/Department/Detail/${id}`).then((res) => res.data),

  create: (data: CreateDepartmentRequest) =>
    axiosClient
      .post<Department>("/Department/Create", data)
      .then((res) => res.data),

  update: (data: UpdateDepartmentRequest) =>
    axiosClient
      .put<Department>("/Department/Update", data)
      .then((res) => res.data),

  delete: (id: string) =>
    axiosClient
      .delete<DeleteDepartmentResponse>("/Department/Delete", { data: { id } })
      .then((res) => res.data),
};