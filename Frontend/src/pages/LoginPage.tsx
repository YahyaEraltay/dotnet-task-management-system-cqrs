import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { useForm } from "react-hook-form";
import {
  Box,
  Button,
  Paper,
  TextField,
  Typography,
  Alert,
} from "@mui/material";
import { useAuth } from "../auth/AuthContext";
import type { LoginRequest } from "../api/types";

export function LoginPage() {
  const { login } = useAuth();
  const navigate = useNavigate();
  const [serverError, setServerError] = useState<string | null>(null);

  
  const {
    register,       
    handleSubmit,    
    formState: { errors, isSubmitting }, 
  } = useForm<LoginRequest>();

  async function onSubmit(data: LoginRequest) {
    setServerError(null);
    try {
      await login(data); 
      navigate("/"); 
    } catch {
      setServerError("E-posta veya şifre hatalı.");
    }
  }

  return (
    <Box
      sx={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        minHeight: "100vh",
        bgcolor: "grey.100",
      }}
    >
      <Paper elevation={3} sx={{ p: 4, width: 360 }}>
        <Typography variant="h5" sx={{ mb: 3, textAlign: "center" }}>
          Giriş Yap
        </Typography>

        {serverError && (
          <Alert severity="error" sx={{ mb: 2 }}>
            {serverError}
          </Alert>
        )}

       
        <Box component="form" onSubmit={handleSubmit(onSubmit)}>
          <TextField
            label="E-posta"
            fullWidth
            margin="normal"
            
            {...register("userEmail", { required: "E-posta zorunlu" })}
            error={!!errors.userEmail}
            helperText={errors.userEmail?.message}
          />
          <TextField
            label="Şifre"
            type="password"
            fullWidth
            margin="normal"
            {...register("userPassword", { required: "Şifre zorunlu" })}
            error={!!errors.userPassword}
            helperText={errors.userPassword?.message}
          />
          <Button
            type="submit"
            variant="contained"
            fullWidth
            sx={{ mt: 2 }}
            disabled={isSubmitting} // istek devam ederken butona tekrar tıklanamasın
          >
            {isSubmitting ? "Giriş yapılıyor..." : "Giriş Yap"}
          </Button>
        </Box>
      </Paper>
    </Box>
  );
}