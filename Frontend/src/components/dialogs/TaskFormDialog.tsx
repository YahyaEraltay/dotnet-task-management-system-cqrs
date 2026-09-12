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
import { toDoTaskApi } from "../../api/toDoTaskApi";
import { userApi } from "../../api/userApi";
import type { UserListItem, ToDoTaskListItem } from "../../api/types";

interface TaskFormValues {
  toDoTaskName: string;
  toDoTaskDescription: string;
  assignedUserId: string;
}

interface Props {
  open: boolean;
  onClose: () => void;
  onSuccess: () => void;
  editingTask?: ToDoTaskListItem | null;
}

export function TaskFormDialog({ open, onClose, onSuccess, editingTask }: Props) {
  const [users, setUsers] = useState<UserListItem[]>([]);
  const [serverError, setServerError] = useState<string | null>(null);

  const {
    control,
    register,
    handleSubmit,
    reset,
    formState: { errors, isSubmitting },
  } = useForm<TaskFormValues>({
    defaultValues: { toDoTaskName: "", toDoTaskDescription: "", assignedUserId: "" },
  });

  useEffect(() => {
    if (open) {
      userApi.getAll().then(setUsers);
    }
  }, [open]);

  useEffect(() => {
    if (editingTask) {
      reset({
        toDoTaskName: editingTask.toDoTaskName,
        toDoTaskDescription: editingTask.toDoTaskDescription,
        assignedUserId: editingTask.assignedUserId,
      });
    } else {
      reset({ toDoTaskName: "", toDoTaskDescription: "", assignedUserId: "" });
    }
  }, [editingTask, reset]);

  async function onSubmit(values: TaskFormValues) {
    setServerError(null);
    try {
      if (editingTask) {
        await toDoTaskApi.update({ id: editingTask.id, ...values });
      } else {
        await toDoTaskApi.create(values);
      }
      reset({ toDoTaskName: "", toDoTaskDescription: "", assignedUserId: "" });
      onSuccess();
      onClose();
    } catch {
      setServerError("İşlem sırasında bir hata oluştu.");
    }
  }

  return (
    <Dialog open={open} onClose={onClose} fullWidth maxWidth="sm">
      <DialogTitle>{editingTask ? "Görevi Düzenle" : "Yeni Görev"}</DialogTitle>

      <DialogContent>
        <Box
          component="form"
          onSubmit={handleSubmit(onSubmit)}
          id="task-form"
          sx={{ display: "flex", flexDirection: "column", gap: 2, mt: 1 }}
        >
          {serverError && <Alert severity="error">{serverError}</Alert>}

          <TextField
            label="Görev Adı"
            {...register("toDoTaskName", { required: "Görev adı zorunlu" })}
            error={!!errors.toDoTaskName}
            helperText={errors.toDoTaskName?.message}
          />

          <TextField
            label="Açıklama"
            multiline
            rows={3}
            {...register("toDoTaskDescription", { required: "Açıklama zorunlu" })}
            error={!!errors.toDoTaskDescription}
            helperText={errors.toDoTaskDescription?.message}
          />

          <Controller
            name="assignedUserId"
            control={control}
            rules={{ required: "Atanacak kişi seçmelisin" }}
            render={({ field }) => (
              <TextField
                {...field}
                select
                label="Atanacak Kişi"
                error={!!errors.assignedUserId}
                helperText={errors.assignedUserId?.message}
              >
                {users.map((u) => (
                  <MenuItem key={u.id} value={u.id}>
                    {u.userName} ({u.departmentName})
                  </MenuItem>
                ))}
              </TextField>
            )}
          />
        </Box>
      </DialogContent>

      <DialogActions>
        <Button onClick={onClose}>İptal</Button>
        <Button type="submit" form="task-form" variant="contained" disabled={isSubmitting}>
          {isSubmitting ? "Kaydediliyor..." : "Kaydet"}
        </Button>
      </DialogActions>
    </Dialog>
  );
}