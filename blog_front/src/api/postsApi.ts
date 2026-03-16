import type { Post } from "../types/post";

const API_URL = "http://localhost:5039";

export async function getPosts(): Promise<Post[]> {
  const response = await fetch(`${API_URL}/posts`);

  if (!response.ok) {
    throw new Error("Kunde inte hämta blogginlägg.");
  }

  const data = await response.json();
  return data;
}

export async function createPost(title: string, content: string, userId: number) {
  const token = localStorage.getItem("token");

  const query = new URLSearchParams({
    title: title,
    content: content,
    user_id: userId.toString()
  });

  const response = await fetch(`${API_URL}/posts?${query.toString()}`, {
    method: "POST",
    headers: {
      "Authorization": `Bearer ${token}`
    }
  });

  if (!response.ok) {
    throw new Error("Kunde inte skapa post.");
  }

  return await response.json();
}

export async function updatePost(id: number, title: string, content: string) {
  const token = localStorage.getItem("token");

  const query = new URLSearchParams({
    title: title,
    content: content
  });

  const response = await fetch(`${API_URL}/posts/${id}?${query.toString()}`, {
    method: "PUT",
    headers: {
      "Authorization": `Bearer ${token}`
    }
  });

  if (!response.ok) {
    throw new Error("Kunde inte uppdatera post.");
  }
}

export async function deletePost(id: number) {
  const token = localStorage.getItem("token");

  const response = await fetch(`${API_URL}/posts/${id}`, {
    method: "DELETE",
    headers: {
      "Authorization": `Bearer ${token}`
    }
  });

  if (!response.ok) {
    throw new Error("Kunde inte ta bort post.");
  }
}
