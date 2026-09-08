import { createContext, useContext, useEffect, useState } from "react";
import type { ReactNode } from "react";
import { authApi } from "../api/authApi";
import type { CurrentUser, LoginRequest } from "../api/types";

interface AuthContextType {
  user: CurrentUser | null;
  isLoading: boolean;
  login: (data: LoginRequest) => Promise<void>;
  logout: () => void;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export function AuthProvider({ children }: { children: ReactNode }) {
  const [user, setUser] = useState<CurrentUser | null>(null);
  const [isLoading, setIsLoading] = useState(true);

  // Sayfa yenilendiğinde: token localStorage'da varsa, kullanıcıyı tekrar çek.
  // Yoksa her F5'te login sayfasına düşerdik.
  useEffect(() => {
    const token = localStorage.getItem("token");
    if (!token) {
      setIsLoading(false);
      return;
    }

    authApi
      .getCurrentUser()
      .then(setUser)
      .catch(() => {
        localStorage.removeItem("token");
      })
      .finally(() => setIsLoading(false));
  }, []);

  async function login(data: LoginRequest) {
    const { token } = await authApi.login(data);
    localStorage.setItem("token", token);
    const currentUser = await authApi.getCurrentUser();
    setUser(currentUser);
  }

  function logout() {
    localStorage.removeItem("token");
    setUser(null);
  }

  return (
    <AuthContext.Provider value={{ user, isLoading, login, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth() {
  const context = useContext(AuthContext);
  if (!context) {
    throw new Error("useAuth, AuthProvider içinde kullanılmalı");
  }
  return context;
}