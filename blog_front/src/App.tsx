import { useState } from "react";
import HomePage from "./pages/HomePage";
import LoginPage from "./pages/LoginPage";
import DashboardPage from "./pages/DashboardPage";

function App() {
  const [currentPage, setCurrentPage] = useState("home");
  const [token, setToken] = useState(localStorage.getItem("token") || "");

  function handleLoginSuccess(newToken: string) {
    setToken(newToken);
    setCurrentPage("dashboard");
  }

  function handleLogout() {
    localStorage.removeItem("token");
    setToken("");
    setCurrentPage("home");
  }

  return (
    <>
      {currentPage === "home" && (
        <HomePage onGoToLogin={() => setCurrentPage("login")} />
      )}

      {currentPage === "login" && (
        <LoginPage
          onLoginSuccess={handleLoginSuccess}
          onBackToHome={() => setCurrentPage("home")}
        />
      )}

      {currentPage === "dashboard" && token && (
        <DashboardPage onLogout={handleLogout} />
      )}
    </>
  );
}

export default App;
