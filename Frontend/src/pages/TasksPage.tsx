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
  Button,
  IconButton,
  Snackbar,
} from "@mui/material";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import { toDoTaskApi } from "../api/toDoTaskApi";
import type { ToDoTaskListItem, TaskStatus } from "../api/types";
import { TaskFormDialog } from "../components/dialogs/TaskFormDialog";

const statusConfig: Record<TaskStatus, { label: string; color: "warning" | "success" | "error" }> = {
  pending: { label: "Beklemede", color: "warning" },
  approved: { label: "Onaylandı", color: "success" },
  denied: { label: "Reddedildi", color: "error" },
};

export function TasksPage() {
  const [tasks, setTasks] = useState<ToDoTaskListItem[]>([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [isTaskDialogOpen, setIsTaskDialogOpen] = useState(false);

  // YENİ: hangi görevin düzenlendiğini tutuyoruz. null = "yeni görev" modu.
  const [editingTask, setEditingTask] = useState<ToDoTaskListItem | null>(null);

  // YENİ: silme sonrası/hata durumunda kısa bildirim
  const [snackbar, setSnackbar] = useState<string | null>(null);

  function loadTasks() {
    toDoTaskApi
      .getAll()
      .then(setTasks)
      .catch(() => setError("Görevler yüklenirken bir hata oluştu."))
      .finally(() => setIsLoading(false));
  }

  useEffect(() => {
    loadTasks();
  }, []);

  // YENİ: "Yeni Görev" butonuna basınca editingTask'i null'a çekiyoruz,
  // yoksa bir önceki düzenlemenin verisi formda kalmış olurdu.
  function handleCreateClick() {
    setEditingTask(null);
    setIsTaskDialogOpen(true);
  }

  // YENİ: kalem ikonuna basınca o satırın verisini editingTask'e koyup dialog'u açıyoruz.
  // TaskFormDialog içindeki useEffect, editingTask dolu olduğu için formu
  // bu görevin verileriyle otomatik dolduracak.
  function handleEditClick(task: ToDoTaskListItem) {
    setEditingTask(task);
    setIsTaskDialogOpen(true);
  }

  // YENİ: silme işlemi + yetki hatasını yakalama
  async function handleDeleteClick(task: ToDoTaskListItem) {
    if (!window.confirm(`"${task.toDoTaskName}" görevini silmek istediğine emin misin?`)) {
      return;
    }
    try {
      await toDoTaskApi.remove(task.id);
      setSnackbar("Görev silindi.");
      loadTasks();
    } catch {
      // DeleteToDoTaskHandler sadece görevi OLUŞTURAN kişinin silmesine izin veriyor
      setSnackbar("Bu görevi silme yetkin yok (sadece oluşturan kişi silebilir).");
    }
  }

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
      <Box sx={{ display: "flex", justifyContent: "space-between", alignItems: "center", mb: 2 }}>
        <Typography variant="h5" sx={{ mb: 2, fontWeight: 700, letterSpacing: 0.2 }}>
        Görevler
      </Typography>
        <Button variant="contained" onClick={handleCreateClick}>
          Yeni Görev
        </Button>
      </Box>

      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Görev Adı</TableCell>
              <TableCell>Oluşturan</TableCell>
              <TableCell>Atanan Kişi</TableCell>
              <TableCell>Departman</TableCell>
              <TableCell>Durum</TableCell>
              {/* YENİ */}
              <TableCell align="right">İşlemler</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {tasks.length === 0 ? (
              <TableRow>
                <TableCell colSpan={6} align="center">
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
                  {/* YENİ */}
                  <TableCell align="right">
                    <IconButton size="small" onClick={() => handleEditClick(task)}>
                      <EditIcon fontSize="small" />
                    </IconButton>
                    <IconButton size="small" onClick={() => handleDeleteClick(task)}>
                      <DeleteIcon fontSize="small" />
                    </IconButton>
                  </TableCell>
                </TableRow>
              ))
            )}
          </TableBody>
        </Table>
      </TableContainer>

      <TaskFormDialog
        open={isTaskDialogOpen}
        onClose={() => setIsTaskDialogOpen(false)}
        onSuccess={loadTasks}
        editingTask={editingTask}
      />

      {/* YENİ */}
      <Snackbar
        open={!!snackbar}
        autoHideDuration={3000}
        onClose={() => setSnackbar(null)}
        message={snackbar}
      />
    </Box>
  );
}