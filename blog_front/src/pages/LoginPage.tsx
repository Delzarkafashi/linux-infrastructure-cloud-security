import { useState } from "react";
import { loginUser } from "../api/authApi";

type LoginPageProps = {
  onLoginSuccess: (token: string) => void;
  onBackToHome: () => void;
};

function LoginPage({ onLoginSuccess, onBackToHome }: LoginPageProps) {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [message, setMessage] = useState("");
  const [loading, setLoading] = useState(false);

  async function handleSubmit(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();
    setMessage("");
    setLoading(true);

    try {
      const data = await loginUser({ username, password });

      localStorage.setItem("token", data.token);
      setMessage("Inloggning lyckades.");
      onLoginSuccess(data.token);
    } catch {
      setMessage("Fel användarnamn eller lösenord.");
    } finally {
      setLoading(false);
    }
  }

  return (
    <main>
      <h1>Logga in</h1>

      <form onSubmit={handleSubmit}>
        <div>
          <label htmlFor="username">Användarnamn</label>
          <br />
          <input
            id="username"
            type="text"
            value={username}
            onChange={(event) => setUsername(event.target.value)}
          />
        </div>

        <div>
          <label htmlFor="password">Lösenord</label>
          <br />
          <input
            id="password"
            type="password"
            value={password}
            onChange={(event) => setPassword(event.target.value)}
          />
        </div>

        <br />

        <button type="submit" disabled={loading}>
          {loading ? "Loggar in..." : "Logga in"}
        </button>

        <button type="button" onClick={onBackToHome}>
          Tillbaka
        </button>

        {message && <p>{message}</p>}
      </form>
    </main>
  );
}

export default LoginPage;
