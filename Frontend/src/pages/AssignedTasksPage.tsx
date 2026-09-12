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
  Snackbar,
} from "@mui/material";
import { toDoTaskApi } from "../api/toDoTaskApi";
import type { AssignedToDoTask, TaskStatus } from "../api/types";

const statusConfig: Record<TaskStatus, { label: string; color: "warning" | "success" | "error" }> = {
  pending: { label: "Beklemede", color: "warning" },
  approved: { label: "Onaylandı", color: "success" },
  denied: { label: "Reddedildi", color: "error" },
};

export function AssignedTasksPage() {
  const [tasks, setTasks] = useState<AssignedToDoTask[]>([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [snackbar, setSnackbar] = useState<string | null>(null);

  // Backend'de AssignedToDoTaskHandler, ICurrentUserService üzerinden
  // "bana atanmış görevler" filtresini sunucu tarafında uyguluyor —
  // frontend'de ayrıca bir filtreleme yapmamıza gerek yok, endpoint zaten
  // sadece bu kullanıcıya ait kayıtları döndürüyor.
  function loadTasks() {
    setIsLoading(true);
    toDoTaskApi
      .getAssigned()
      .then(setTasks)
      .catch(() => setError("Görevler yüklenirken bir hata oluştu."))
      .finally(() => setIsLoading(false));
  }

  useEffect(() => {
    loadTasks();
  }, []);

  // Onay/Red işlemi. "newStatus" parametresini iki farklı butondan
  // (Onayla/Reddet) aynı fonksiyona geçirerek kod tekrarını önlüyoruz.
  async function handleStatusChange(taskId: string, newStatus: TaskStatus) {
    try {
      await toDoTaskApi.updateStatus({ id: taskId, status: newStatus });
      setSnackbar(newStatus === "approved" ? "Görev onaylandı." : "Görev reddedildi.");
      loadTasks(); // listeyi tazele, Chip rengi/etiketi güncellensin
    } catch {
      // StatusToDoTaskHandler'daki iki olası hata:
      // 1) "You can only approve/reject the task assigned to you" — bu sayfada
      //    zaten sadece kendine atanan görevler listelendiği için normalde oluşmaz.
      // 2) "This task has already been approved or denied" — biri aynı görevi
      //    iki farklı sekmede/anda tekrar onaylamaya çalışırsa (race condition) oluşabilir.
      setSnackbar("Bu işlem gerçekleştirilemedi. Görev zaten sonuçlandırılmış olabilir.");
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
      <Typography variant="h5" sx={{ mb: 2, fontWeight: 700, letterSpacing: 0.2 }}>
        Bana Atanan Görevler
      </Typography>

      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Görev Adı</TableCell>
              <TableCell>Oluşturan</TableCell>
              <TableCell>Departman</TableCell>
              <TableCell>Tarih</TableCell>
              <TableCell>Durum</TableCell>
              <TableCell align="right">İşlemler</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {tasks.length === 0 ? (
              <TableRow>
                <TableCell colSpan={6} align="center">
                  Sana atanmış görev yok.
                </TableCell>
              </TableRow>
            ) : (
              tasks.map((task) => (
                <TableRow key={task.id}>
                  <TableCell>{task.toDoTaskName}</TableCell>
                  <TableCell>{task.creatorUserName}</TableCell>
                  <TableCell>{task.assignedDepartmentName}</TableCell>
                  {/* Backend DateTime'ı ISO string olarak gönderiyor, tarayıcının
                      yerel tarih formatına çevirmek için toLocaleDateString kullanıyoruz.
                      new Date(...) burada bir JS Date nesnesine parse ediyor. */}
                  <TableCell>{new Date(task.toDoTaskDate).toLocaleDateString("tr-TR")}</TableCell>
                  <TableCell>
                    <Chip
                      label={statusConfig[task.status].label}
                      color={statusConfig[task.status].color}
                      size="small"
                    />
                  </TableCell>
                  <TableCell align="right">
                    {/* Onay/Red butonları SADECE görev "pending" durumundayken gösterilsin —
                        backend zaten "already approved/denied" hatası fırlatıyordu ama
                        kullanıcıya zaten yapılmış bir işlem için buton göstermek kötü UX,
                        bu yüzden frontend'de de görsel olarak engelliyoruz. */}
                    {task.status === "pending" ? (
                      <>
                        <Button
                          size="small"
                          color="success"
                          variant="outlined"
                          onClick={() => handleStatusChange(task.id, "approved")}
                          sx={{ mr: 1 }}
                        >
                          Onayla
                        </Button>
                        <Button
                          size="small"
                          color="error"
                          variant="outlined"
                          onClick={() => handleStatusChange(task.id, "denied")}
                        >
                          Reddet
                        </Button>
                      </>
                    ) : (
                      // pending değilse zaten sonuçlanmış, tekrar işlem yapılamaz
                      <Typography variant="body2" color="text.secondary">
                        —
                      </Typography>
                    )}
                  </TableCell>
                </TableRow>
              ))
            )}
          </TableBody>
        </Table>
      </TableContainer>

      <Snackbar
        open={!!snackbar}
        autoHideDuration={3000}
        onClose={() => setSnackbar(null)}
        message={snackbar}
      />
    </Box>
  );
}