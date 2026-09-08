import axiosClient from "./axiosClient";
import type {
  ToDoTaskListItem,
  ToDoTaskDetail,
  AssignedToDoTask,
  CreateToDoTaskRequest,
  CreateToDoTaskResponse,
  UpdateToDoTaskRequest,
  UpdateToDoTaskResponse,
  StatusToDoTaskRequest,
  StatusToDoTaskResponse,
  DeleteResponse,
} from "./types";

export const toDoTaskApi = {
  getAll: () =>
    axiosClient.get<ToDoTaskListItem[]>("/ToDoTask/All").then((res) => res.data),

  getDetail: (id: string) =>
    axiosClient.get<ToDoTaskDetail>(`/ToDoTask/Detail/${id}`).then((res) => res.data),

  getAssigned: () =>
    axiosClient
      .get<AssignedToDoTask[]>("/ToDoTask/AssignedTasks")
      .then((res) => res.data),

  create: (data: CreateToDoTaskRequest) =>
    axiosClient
      .post<CreateToDoTaskResponse>("/ToDoTask/Create", data)
      .then((res) => res.data),

  update: (data: UpdateToDoTaskRequest) =>
    axiosClient
      .put<UpdateToDoTaskResponse>("/ToDoTask/Update", data)
      .then((res) => res.data),

  updateStatus: (data: StatusToDoTaskRequest) =>
    axiosClient
      .post<StatusToDoTaskResponse>("/ToDoTask/TaskStatus", data)
      .then((res) => res.data),

  remove: (id: string) =>
    axiosClient
      .delete<DeleteResponse>("/ToDoTask/Delete", { data: { id } })
      .then((res) => res.data),
};