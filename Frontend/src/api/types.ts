export type TaskStatus = "pending" | "approved" | "denied";

export interface LoginRequest {
  userEmail: string;
  userPassword: string;
}

export interface LoginResponse {
  token: string; // UserController.Login sadece { token } döndürüyor
}

// UserController.GetCurrentUser -> CurrentUserDTOs.ResponseModel
export interface CurrentUser {
  id: string;
  departmentId: string;
  userName: string;
  userEmail: string;
  phoneNumber: string;
  departmentName: string;
  userTitle: string;
}

// ---- ToDoTask ----
export interface ToDoTaskListItem {
  id: string;
  toDoTaskName: string;
  assignedUserName: string;
  assignedUserEmail: string;
  creatorUserName: string;
  assignedDepartmentName: string;
  status: TaskStatus;
}

export interface ToDoTaskDetail {
  id: string;
  toDoTaskName: string;
  assignedUserName: string;
  assignedUserEmail: string;
  assignedDepartmentName: string;
  creatorUserName: string;
  status: TaskStatus;
}

export interface AssignedToDoTask {
  id: string;
  toDoTaskDate: string; // DateTime -> ISO string
  creatorUserName: string;
  assignedUserName: string;
  assignedDepartmentName: string;
  toDoTaskName: string;
  status: TaskStatus;
}

export interface CreateToDoTaskRequest {
  toDoTaskName: string;
  toDoTaskDescription: string;
  assignedUserId: string;
}

export interface CreateToDoTaskResponse {
  id: string;
  toDoTaskName: string;
  toDoTaskDescription: string;
  toDoTaskDate: string;
  departmentId: string;
  creatorUserId: string;
  assignedUserId: string;
  status: TaskStatus;
}

export interface UpdateToDoTaskRequest {
  id: string;
  toDoTaskName: string;
  toDoTaskDescription: string;
  assignedUserId: string;
}

export interface UpdateToDoTaskResponse {
  id: string;
  toDoTaskName: string;
  toDoTaskDescription: string;
  assignedDepartmentName: string;
  creatorUserName: string;
  assignedUserName: string;
  status: TaskStatus;
}

export interface StatusToDoTaskRequest {
  id: string;
  status: TaskStatus; 
}

export interface StatusToDoTaskResponse {
  status: TaskStatus;
}

export interface DeleteResponse {
  isDeleted: boolean;
  message: string;
}

// ---- User ----
export interface UserListItem {
  id: string;
  userName: string;
  userEmail: string;
  departmentName: string;
}

export interface CreateUserRequest {
  userName: string;
  userEmail: string;
  userPassword: string;
  phoneNumber: string;
  departmentId: string;
  userTitle: string;
}

export interface CreateUserResponse {
  id: string;
  userName: string;
  userEmail: string;
  phoneNumber: string;
  departmentId: string;
  userTitle: string;
}

export interface UpdateUserRequest {
  id: string;
  userName: string;
  userEmail: string;
  userPassword?: string; 
  userTitle: string;
  phoneNumber: string;
  departmentId: string;
}

export interface UpdateUserResponse {
  id: string;
  userName: string;
  userEmail: string;
  userTitle: string;
  phoneNumber: string;
  departmentName: string;
}

// ---- Department ----
export interface Department {
  id: string;
  departmentName: string;
}

export interface CreateDepartmentRequest {
  departmentName: string;
}

export interface UpdateDepartmentRequest {
  id: string;
  departmentName: string;
}