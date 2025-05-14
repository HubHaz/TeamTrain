# TeamTrain

**TeamTrain** is a web-based training management system for sports teams and coaches. It provides tools for managing training schedules, participant sign-ups, membership payments, and administrative oversight.

## ✨ Features

- 👥 Role-based access: Admin, Coach, Participant
- 📅 Training calendar with recurring events
- ✅ Sign-up and cancellation with rules (e.g., cancel before 12:00)
- 💸 Membership tracking and penalty system
- 🧾 Membership types and entry deductions from pass
- 🔐 Registration, login, JWT authentication with role claims
- ⚙️ Admin dashboard for managing users, roles, and reports
- 📊 API-first architecture (backend focus)

## 🛠 Tech Stack

- **.NET 9 / ASP.NET Core Web API**
- **Entity Framework Core + PostgreSQL**
- **CQRS + MediatR**
- **JWT authentication**
- **FluentValidation**
- **Docker-ready**
- **Unit & Integration Tests**

## 📁 Project Structure

TeamTrain/
- **├── Application # Commands, Queries, DTOs, Interfaces**
- **├── Domain # Core entities and enums**
- **├── Infrastructure # Repositories, services, DbContext**
- **├── WebApi # Controllers, middleware, auth**
- **├── Tests # Application and infrastructure tests**

## 🚀 Getting Started

## Clone the repository
- **```git clone https://github.com/yourusername/TeamTrain.git```**
- **```cd TeamTrain```**

## Run migrations and start the app
- **```dotnet ef database update```**
- **```dotnet run --project WebApi```**


## ✅ Roadmap
 - **Role-based authentication**
 - **Create/join/cancel trainings**
 - **Membership fee tracking**
 - **Notifications (email/SMS)**
 - **Frontend (Vue.js client)**
 - **Docker Compose setup**


##📄 License
This project is licensed under the MIT License.
