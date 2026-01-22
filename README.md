# LoanHub-bank-API

## Requirements

- Docker Desktop (or Docker Engine)
- `docker compose` (Docker Compose v2)

## Quick start (Docker Compose)

1. Create `.env` file in the repository root (do not commit it):

   - `SA_PASSWORD` must meet SQL Server policy (min 8 chars, upper/lowercase, number, special char)

   Example:

   - `SA_PASSWORD=Your_strong_Password123!`

2. Build and start:

   - `docker compose up -d --build`

3. Open Swagger:

   - `http://localhost:9999/swagger`

## Stop / reset

- Stop containers:
  - `docker compose down`

- Stop and remove data volume (drops database):
  - `docker compose down -v`
