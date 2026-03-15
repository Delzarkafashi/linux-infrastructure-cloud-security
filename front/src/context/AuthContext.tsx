import { createContext, useMemo, useState, type ReactNode } from "react";
import {
  clearAuthData,
  getRole,
  getToken,
  getUsername,
  saveAuthData,
} from "../utils/storage";

type AuthContextType = {
  token: string | null;
  username: string | null;
  role: string | null;
  isAuthenticated: boolean;
  login: (token: string, username: string, role: string) => void;
  logout: () => void;
};

export const AuthContext = createContext<AuthContextType | undefined>(undefined);

type AuthProviderProps = {
  children: ReactNode;
};

export function AuthProvider({ children }: AuthProviderProps) {
  const [token, setToken] = useState<string | null>(getToken());
  const [username, setUsername] = useState<string | null>(getUsername());
  const [role, setRole] = useState<string | null>(getRole());

  const login = (newToken: string, newUsername: string, newRole: string) => {
    saveAuthData(newToken, newUsername, newRole);
    setToken(newToken);
    setUsername(newUsername);
    setRole(newRole);
  };

  const logout = () => {
    clearAuthData();
    setToken(null);
    setUsername(null);
    setRole(null);
  };

  const value = useMemo(
    () => ({
      token,
      username,
      role,
      isAuthenticated: !!token,
      login,
      logout,
    }),
    [token, username, role]
  );

  return <AuthContext.Provider value={value}>{children}</AuthContext.Provider>;
}
