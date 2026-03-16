const API_URL = "http://localhost:5039";

type LoginRequest = {
  username: string;
  password: string;
};

type LoginResponse = {
  token: string;
};

export async function loginUser(loginData: LoginRequest): Promise<LoginResponse> {
  const response = await fetch(`${API_URL}/login`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(loginData)
  });

  if (!response.ok) {
    throw new Error("Fel användarnamn eller lösenord.");
  }

  const data = await response.json();
  return data;
}
