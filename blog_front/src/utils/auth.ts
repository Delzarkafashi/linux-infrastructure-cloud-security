import { jwtDecode } from "jwt-decode";

type TokenPayload = {
  "http://schemas.microsoft.com/ws/2008/06/identity/claims/role": string;
};

export function getUserRole() {
  const token = localStorage.getItem("token");

  if (!token) return null;

  try {
    const decoded = jwtDecode<TokenPayload>(token);

    return decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
  } catch {
    return null;
  }
}
