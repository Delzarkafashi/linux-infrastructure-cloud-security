import { useEffect, useState } from "react";
import { getPosts } from "../api/postsApi";
import type { Post } from "../types/post";

type HomePageProps = {
  onGoToLogin: () => void;
};

function HomePage({ onGoToLogin }: HomePageProps) {
  const [posts, setPosts] = useState<Post[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    async function loadPosts() {
      try {
        const data = await getPosts();
        setPosts(data);
      } catch (err) {
        setError("Kunde inte ladda blogginlägg.");
      } finally {
        setLoading(false);
      }
    }

    loadPosts();
  }, []);

  return (
    <main>
      <h1>Blog Front</h1>
      <p>Här ska alla kunna läsa blogginlägg.</p>

      <button onClick={onGoToLogin}>Logga in</button>

      <section>
        <h2>Blogginlägg</h2>

        {loading && <p>Laddar blogginlägg...</p>}
        {error && <p>{error}</p>}

        {!loading && !error && posts.length === 0 && (
          <p>Det finns inga blogginlägg ännu.</p>
        )}

        {posts.map((post) => (
          <article key={post.id}>
            <h3>{post.title}</h3>
            <p>{post.content}</p>
          </article>
        ))}
      </section>
    </main>
  );
}

export default HomePage;
