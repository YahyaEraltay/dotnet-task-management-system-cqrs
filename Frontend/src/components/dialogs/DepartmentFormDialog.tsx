import { useEffect, useState } from "react";
import { useForm, Controller } from "react-hook-form";
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  Button,
  MenuItem,
  Alert,
  Box,
} from "@mui/material";
import { departmentApi } from "../../api/departmentApi";
import type { Department } from "../../api/types";

interface DepartmentFormValues {
  departmentName: string;
}

interface Props {
  open: boolean;
  onClose: () => void;
  onSuccess: () => void;
  editingDepartment?: Department | null;
}

export function DepartmentFormDialog({ open, onClose, onSuccess, editingDepartment }: Props) {
  const [serverError, setServerError] = useState<string | null>(null);

  const {
    control,
    register,
    handleSubmit,
    reset,
    formState: { errors, isSubmitting },
  } = useForm<DepartmentFormValues>({
    defaultValues: { departmentName: "" },
  });


  useEffect(() => {
    if (editingDepartment) {
      reset({
        departmentName: editingDepartment.departmentName,
      });
    } else {
      reset({ departmentName: "" });
    }
  }, [editingDepartment, reset]);

  async function onSubmit(values: DepartmentFormValues) {
    setServerError(null);
    try {
      if (editingDepartment) {
        await departmentApi.update({ id: editingDepartment.id, ...values });
      } else {
        await departmentApi.create(values);
      }
      reset({ departmentName: "" });
      onSuccess();
      onClose();
    } catch {
      setServerError("İşlem sırasında bir hata oluştu.");
    }
  }

  return (
    <Dialog open={open} onClose={onClose} fullWidth maxWidth="sm">
      <DialogTitle>{editingDepartment ? "Departmanı Düzenle" : "Yeni Departman"}</DialogTitle>

      <DialogContent>
        <Box
          component="form"
          onSubmit={handleSubmit(onSubmit)}
          id="department-form"
          sx={{ display: "flex", flexDirection: "column", gap: 2, mt: 1 }}
        >
          {serverError && <Alert severity="error">{serverError}</Alert>}

          <TextField
            label="Departman Adı"
            {...register("departmentName", { required: "Departman adı zorunlu" })}
            error={!!errors.departmentName}
            helperText={errors.departmentName?.message}
          />
        </Box>
      </DialogContent>

      <DialogActions>
        <Button onClick={onClose}>İptal</Button>
        <Button type="submit" form="department-form" variant="contained" disabled={isSubmitting}>
          {isSubmitting ? "Kaydediliyor..." : "Kaydet"}
        </Button>
      </DialogActions>
    </Dialog>
  );
}