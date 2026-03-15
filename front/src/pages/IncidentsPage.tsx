import { useEffect, useState } from "react";
import { getAllIncidents, createIncident } from "../services/incidentService";
import { useAuth } from "../hooks/useAuth";

function IncidentsPage() {
  const [incidents, setIncidents] = useState<any[]>([]);
  const [error, setError] = useState("");
  const [title, setTitle] = useState("");
  const [description, setDescription] = useState("");
  const { role } = useAuth();

  useEffect(() => {
    getAllIncidents()
      .then((data) => setIncidents(data))
      .catch((err) => setError(err.message));
  }, []);

  const handleCreate = async (e: React.FormEvent) => {
    e.preventDefault();
    try {
      const newIncident = await createIncident(title, description);
      setIncidents([...incidents, newIncident]);
      setTitle("");
      setDescription("");
    } catch (err: any) {
      setError(err.message);
    }
  };

  if (error) return <p>{error}</p>;

  return (
    <div>
      <h1>Incidents</h1>

      {/* Skapa-formulär: bara staff/admin */}
      {(role === "staff" || role === "admin") && (
        <form onSubmit={handleCreate}>
          <input
            type="text"
            placeholder="Titel"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
            required
          />
          <input
            type="text"
            placeholder="Beskrivning"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
            required
          />
          <button type="submit">Skapa avvikelse</button>
        </form>
      )}

      <ul>
        {incidents.map((i) => (
          <li key={i.id}>
            <strong>{i.title}</strong>: {i.description} (skapad av {i.created_by})
          </li>
        ))}
      </ul>
    </div>
  );
}

export default IncidentsPage;
