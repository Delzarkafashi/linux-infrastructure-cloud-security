import API_BASE_URL from "./api";
import type { LoginRequest, LoginResponse } from "../types/auth";

export async function loginUser(data: LoginRequest): Promise<LoginResponse> {
  const response = await fetch(`${API_BASE_URL}/login`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(data),
  });

  if (!response.ok) {
    throw new Error("Login failed");
  }

  const result: LoginResponse = await response.json();
  return result;
}
