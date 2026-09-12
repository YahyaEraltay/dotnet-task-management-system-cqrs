import { Routes, Route, Navigate } from "react-router-dom";
import { LoginPage } from "./pages/LoginPage";
import { TasksPage } from "./pages/TasksPage";
import { DepartmentsPage } from "./pages/DepartmentsPage"; 
import { AssignedTasksPage } from "./pages/AssignedTasksPage"; 
import { ProtectedRoute } from "./auth/ProtectedRoute";
import { AppLayout } from "./components/layouts/AppLayout";

function App() {
  return (
    <Routes>
      <Route path="/login" element={<LoginPage />} />

      <Route
        path="/"
        element={
          <ProtectedRoute>
            <AppLayout>
              <TasksPage />
            </AppLayout>
          </ProtectedRoute>
        }
      />

      <Route
        path="/assigned"
        element={
          <ProtectedRoute>
            <AppLayout>
              <AssignedTasksPage /> 
            </AppLayout>
          </ProtectedRoute>
        }
      />

      <Route
        path="/departments"
        element={
          <ProtectedRoute>
            <AppLayout>
              <DepartmentsPage /> 
            </AppLayout>
          </ProtectedRoute>
        }
      />

      <Route path="*" element={<Navigate to="/" replace />} />
    </Routes>
  );
}

export default App;