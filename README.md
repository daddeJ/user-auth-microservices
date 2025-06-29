# user-auth-microservices
A .NET-based microservices project with separate User and Authentication services. Includes Docker setup and Azure DevOps CI/CD pipelines for easy deployment and scalability.

---

## Overview

**user-auth-microservices** is a scalable microservices-based platform built using .NET technologies, focused on centralized user management and authentication services.

This project follows clean architecture principles and standard coding practices such as SOLID, separation of concerns, and TDD. It features:

- 🔐 A dedicated **User Service** for handling general user information across multiple systems
- 🔑 A standalone **Authentication Service** to manage credentials, tokens, and identity flows
- 📦 Dockerized services for local and cloud deployments
- 🔄 CI/CD pipelines using **Azure DevOps** for streamlined testing and delivery
- 🧪 Integrated unit testing and validation logic for maintainability

It is built to be **extensible**, allowing you to plug this into systems like:
- 📚 Library Management Systems
- 🧾 Visitor/Attendance Tracking Systems
- 🏢 Admin Portals and Internal Tools

---

## Project Structure
````bash
user-auth-microservices/ 
│
├── user-service/              # ✅ Centralized user info (name, email, etc.)
│   ├── src/
│   │   ├── Domain/            # Entities, ValueObjects, Enums
│   │   ├── Application/       # Use cases (CreateUser, GetUser)
│   │   ├── Infrastructure/    # EF Core setup, DbContext, Repos
│   │   └── Api/               # Controllers, DTOs
│   ├── tests/                 # Unit + integration tests
│   ├── Dockerfile
│   └── azure-pipelines.yml
│
├── auth-service/              # 🔐 JWT-based auth (login, register, token)
│   ├── src/                   # Same DDD layout
│   ├── tests/
│   ├── Dockerfile
│   └── azure-pipelines.yml
│
├── tracking-service/          # 📊 Logs check-in, check-out, activity history
│   ├── src/
│   │   ├── Domain/            # CheckInRecord entity
│   │   ├── Application/       # Use cases: LogCheckIn, LogCheckOut
│   │   ├── Infrastructure/    # DB persistence
│   │   └── Api/               # POST /checkin, /checkout, GET /logs
│   ├── tests/
│   ├── Dockerfile
│   └── azure-pipelines.yml
│
├── admin-portal/              # 🖥 Angular frontend for staff dashboard
│   ├── frontend/              # Auth, user list, activity viewer
│   ├── Dockerfile
│   └── azure-pipelines.yml
│
├── docker-compose.yml         # Local orchestration (services + DBs)
├── README.md
├── docs/
│   ├── architecture-diagram.png
│   ├── sequence-diagram.png
│   └── user-service-contract.md
