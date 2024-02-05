# Concurrent Text File Editor

This is a C# console application that allows users to concurrently edit multiple text files. The application uses asynchronous tasks, introduces a semaphore to control access to shared resources (files), and ensures proper synchronization during concurrent editing to prevent conflicts.

## Features

- **Concurrent Editing:** Initiate concurrent editing sessions for different text files.
- **Asynchronous Tasks:** Utilizes asynchronous tasks for non-blocking file I/O operations.
- **Semaphore Synchronization:** Ensures proper synchronization using a semaphore to control access to shared resources (text files).

## How to Use

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/your-username/concurrent-text-file-editor.git
   cd concurrent-text-file-editor
