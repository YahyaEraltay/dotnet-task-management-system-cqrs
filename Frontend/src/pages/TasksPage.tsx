import { useEffect, useState } from "react";
import {
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Paper,
  Chip,
  Typography,
  CircularProgress,
  Alert,
  Box,
} from "@mui/material";
import { toDoTaskApi } from "../api/toDoTaskApi";
import type { ToDoTaskListItem, TaskStatus } from "../api/types";

const statusConfig: Record<TaskStatus, { label: string; color: "warning" | "success" | "error" }> = {
  pending: { label: "Beklemede", color: "warning" },
  approved: { label: "Onaylandı", color: "success" },
  denied: { label: "Reddedildi", color: "error" },
};

export function TasksPage() {
  const [tasks, setTasks] = useState<ToDoTaskListItem[]>([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    toDoTaskApi
      .getAll()
      .then(setTasks)
      .catch(() => setError("Görevler yüklenirken bir hata oluştu."))
      .finally(() => setIsLoading(false));
  }, []); 

  if (isLoading) {
    return (
      <Box sx={{ display: "flex", justifyContent: "center", mt: 4 }}>
        <CircularProgress />
      </Box>
    );
  }

  if (error) {
    return <Alert severity="error">{error}</Alert>;
  }

  return (
    <Box>
      <Typography variant="h5" sx={{ mb: 2 }}>
        Görevler
      </Typography>

      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Görev Adı</TableCell>
              <TableCell>Oluşturan</TableCell>
              <TableCell>Atanan Kişi</TableCell>
              <TableCell>Departman</TableCell>
              <TableCell>Durum</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {tasks.length === 0 ? (
              <TableRow>
                <TableCell colSpan={5} align="center">
                  Henüz görev yok.
                </TableCell>
              </TableRow>
            ) : (
              tasks.map((task) => (
                <TableRow key={task.id}>
                  <TableCell>{task.toDoTaskName}</TableCell>
                  <TableCell>{task.creatorUserName}</TableCell>
                  <TableCell>{task.assignedUserName}</TableCell>
                  <TableCell>{task.assignedDepartmentName}</TableCell>
                  <TableCell>
                    <Chip
                      label={statusConfig[task.status].label}
                      color={statusConfig[task.status].color}
                      size="small"
                    />
                  </TableCell>
                </TableRow>
              ))
            )}
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
}