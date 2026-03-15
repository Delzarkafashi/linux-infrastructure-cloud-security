import API_BASE_URL from "./api";
import { getToken } from "../utils/storage";

export async function getAllIncidents() {
  const token = getToken();
  if (!token) throw new Error("Not authenticated");

  const response = await fetch(`${API_BASE_URL}/avvikelser`, {
    headers: {
      "Content-Type": "application/json",
      "Authorization": `Bearer ${token}`,
    },
  });

  if (!response.ok) {
    throw new Error(`Could not fetch incidents (${response.status})`);
  }

  return response.json();
}

export async function createIncident(title: string, description: string) {
  const token = getToken();
  if (!token) throw new Error("Not authenticated");

  // Viktigt: fältnamnen matchar exakt vad backend förväntar sig
  const body = {
    title: title,
    description: description,
    created_by: localStorage.getItem("username") || "frontend", // skickar inloggad user
  };

  const response = await fetch(`${API_BASE_URL}/avvikelser`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
      "Authorization": `Bearer ${token}`,
    },
    body: JSON.stringify(body),
  });

  if (!response.ok) {
    const text = await response.text();
    throw new Error(`Could not create incident (${response.status}): ${text}`);
  }

  return response.json();
}
