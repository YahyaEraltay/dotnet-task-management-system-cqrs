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
import { departmentApi } from "../api/departmentApi";
import type { Department } from "../api/types";
import { DepartmentFormDialog } from "../components/dialogs/DepartmentFormDialog";

export function DepartmentsPage() {
  const [departments, setDepartments] = useState<Department[]>([]);
  const [isLoading, setIsLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const [isDepartmentDialogOpen, setIsDepartmentDialogOpen] = useState(false);

  const [editingDepartment, setEditingDepartment] = useState<Department | null>(null);
  
  const [snackbar, setSnackbar] = useState<string | null>(null);

  function loadDepartments() {
    departmentApi
      .getAll()
      .then(setDepartments)
      .catch(() => setError("Departmanlar yüklenirken bir hata oluştu."))
      .finally(() => setIsLoading(false));
  }

  useEffect(() => {
    loadDepartments();
  }, []);

  function handleCreateClick() {
    setEditingDepartment(null);
    setIsDepartmentDialogOpen(true);
  }

  function handleEditClick(department: Department) {
    setEditingDepartment(department);
    setIsDepartmentDialogOpen(true);
  }

  async function handleDeleteClick(department: Department) {
    if (!window.confirm(`"${department.departmentName}" departmanını silmek istediğine emin misin?`)) {
      return;
    }
      await departmentApi.delete(department.id);
      setSnackbar("Departman silindi.");
      loadDepartments();
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
        Departmanlar
      </Typography>
        <Button variant="contained" onClick={handleCreateClick}>
          Yeni Departman
        </Button>
      </Box>

      <TableContainer component={Paper}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>Departman Adı</TableCell>
              <TableCell align="right">İşlemler</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {departments.length === 0 ? (
              <TableRow>
                <TableCell colSpan={6} align="center">
                  Henüz departman yok.
                </TableCell>
              </TableRow>
            ) : (
              departments.map((department) => (
                <TableRow key={department.id}>
                  <TableCell>{department.departmentName}</TableCell>
                  {/* YENİ */}
                  <TableCell align="right">
                    <IconButton size="small" onClick={() => handleEditClick(department)}>
                      <EditIcon fontSize="small" />
                    </IconButton>
                    <IconButton size="small" onClick={() => handleDeleteClick(department)}>
                      <DeleteIcon fontSize="small" />
                    </IconButton>
                  </TableCell>
                </TableRow>
              ))
            )}
          </TableBody>
        </Table>
      </TableContainer>

      <DepartmentFormDialog
        open={isDepartmentDialogOpen}
        onClose={() => setIsDepartmentDialogOpen(false)}
        onSuccess={loadDepartments}
        editingDepartment={editingDepartment}
      />

      <Snackbar
        open={!!snackbar}
        autoHideDuration={3000}
        onClose={() => setSnackbar(null)}
        message={snackbar}
      />
    </Box>
  );
}