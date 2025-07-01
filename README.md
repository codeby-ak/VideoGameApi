# .NET Core VideoGame API Documentation

This example demonstrates the .NET Core Web API for managing video games.

# 🐳 Docker Commands for Running VideoGame API

This guide explains how to build and run the `VideoGame` Web API using Docker.

---

## 🔨 Step 1: Build the Docker Image

```bash
docker build -t videogameapi-image .
```

### 📘 Explanation:
- `docker build`: Builds a Docker image from the Dockerfile in the current directory (`.`).
- `-t videogameapi-image`: Tags the image with the name `videogameapi-image`.

---

## 🚀 Step 2: Run the Docker Container

```bash
docker run -it --rm -p 3000:8080 --name Videogame-cont videogameapi-image
```

### 📘 Explanation:
- `docker run`: Runs a container from the built image.
- `-it`: Enables interactive mode with a terminal.
- `--rm`: Automatically removes the container when it exits.
- `-p 3000:8080`: Maps port `8080` in the container to port `3000` on the host.
- `--name Videogame-cont`: Assigns the name `Videogame-cont` to the container.
- `videogameapi-image`: The image to run.

---

## ✅ Result

After running these commands:

- The `VideoGame` Web API will be accessible at:  
  **http://localhost:3000**

- Once the container stops, it will be automatically removed (due to `--rm`).

---
