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
awesome-azure-microservices/
│
├── user-service/                  # Centralized User Info (general only)
│   ├── src/                      # Core logic, app, infrastructure
│   ├── tests/                    # Unit and Integration Tests
│   ├── Dockerfile                # Containerization setup
│   └── azure-pipelines.yml       # CI/CD for User Service
│
├── auth-service/                 # Authentication logic (login, tokens)
│   ├── src/
│   ├── tests/
│   ├── Dockerfile
│   └── azure-pipelines.yml
│
├── admin-portal/                 # Optional admin frontend (Angular, etc.)
│   ├── frontend/                 # Could use Angular/React
│   ├── Dockerfile
│   └── azure-pipelines.yml
│
├── docker-compose.yml            # Local development orchestration
├── README.md
├── docs/                         # Architecture and documentation
│   ├── architecture-diagram.png
│   └── sequence-diagram.png
