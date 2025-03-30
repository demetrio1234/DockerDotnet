# How to run the application in a docker container

1. **Build the Docker image**:
    Run the following command in the terminal from the directory containing your `Dockerfile`:

    ```bash
    docker build -t jsonreader . --load
    ```

2. **Run the container**:
    Use the following command to start the application in a container:

    ```bash
    docker run --rm -p 5000:5000 jsonreader
    ```

    - The `--rm` flag automatically removes the container when it stops.
    - The `-p 5000:5000` flag maps port 5000 on your host to port 5000 in the container (adjust the port if your application uses a different one).

    Make sure your application is configured to listen on all network interfaces (e.g., `http://0.0.0.0:5000`) for it to be accessible outside the container.
