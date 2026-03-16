import { useEffect, useState } from "react";
import { getPosts, createPost, updatePost, deletePost } from "../api/postsApi";
import type { Post } from "../types/post";

type DashboardPageProps = {
  onLogout: () => void;
};

function DashboardPage({ onLogout }: DashboardPageProps) {
  const [posts, setPosts] = useState<Post[]>([]);
  const [title, setTitle] = useState("");
  const [content, setContent] = useState("");
  const [message, setMessage] = useState("");
  const [editingPostId, setEditingPostId] = useState<number | null>(null);
  const [editTitle, setEditTitle] = useState("");
  const [editContent, setEditContent] = useState("");

  async function loadPosts() {
    const data = await getPosts();
    setPosts(data);
  }

  useEffect(() => {
    loadPosts();
  }, []);

  async function handleCreatePost(event: React.FormEvent<HTMLFormElement>) {
    event.preventDefault();
    setMessage("");

    try {
      await createPost(title, content, 1);
      setTitle("");
      setContent("");
      setMessage("Post skapades.");
      loadPosts();
    } catch {
      setMessage("Kunde inte skapa post.");
    }
  }

  function handleStartEdit(post: Post) {
    setEditingPostId(post.id);
    setEditTitle(post.title);
    setEditContent(post.content);
    setMessage("");
  }

  function handleCancelEdit() {
    setEditingPostId(null);
    setEditTitle("");
    setEditContent("");
  }

  async function handleUpdatePost(id: number) {
    setMessage("");

    try {
      await updatePost(id, editTitle, editContent);
      setEditingPostId(null);
      setEditTitle("");
      setEditContent("");
      setMessage("Post uppdaterades.");
      loadPosts();
    } catch {
      setMessage("Kunde inte uppdatera post.");
    }
  }

  async function handleDeletePost(id: number) {
    setMessage("");

    try {
      await deletePost(id);
      setMessage("Post togs bort.");
      loadPosts();
    } catch {
      setMessage("Kunde inte ta bort post.");
    }
  }

  return (
    <main>
      <h1>Dashboard</h1>

      <button onClick={onLogout}>Logga ut</button>

      <h2>Skapa blogginlägg</h2>

      <form onSubmit={handleCreatePost}>
        <div>
          <input
            placeholder="Titel"
            value={title}
            onChange={(event) => setTitle(event.target.value)}
          />
        </div>

        <div>
          <textarea
            placeholder="Innehåll"
            value={content}
            onChange={(event) => setContent(event.target.value)}
          />
        </div>

        <button type="submit">Skapa post</button>
      </form>

      {message && <p>{message}</p>}

      <h2>Alla blogginlägg</h2>

      {posts.map((post) => (
        <article key={post.id}>
          {editingPostId === post.id ? (
            <>
              <div>
                <input
                  value={editTitle}
                  onChange={(event) => setEditTitle(event.target.value)}
                />
              </div>

              <div>
                <textarea
                  value={editContent}
                  onChange={(event) => setEditContent(event.target.value)}
                />
              </div>

              <button onClick={() => handleUpdatePost(post.id)}>Spara</button>
              <button onClick={handleCancelEdit}>Avbryt</button>
            </>
          ) : (
            <>
              <h3>{post.title}</h3>
              <p>{post.content}</p>

              <button onClick={() => handleStartEdit(post)}>Uppdatera</button>
              <button onClick={() => handleDeletePost(post.id)}>Delete</button>
            </>
          )}
        </article>
      ))}
    </main>
  );
}

export default DashboardPage;
