# ♿ Disability Support System – Backend API

The **Disability Support System** is an accessible web-based platform designed to connect **patients with disabilities** and **providers (helpers)** who are willing to offer essential services.

This repository contains the **ASP.NET Core Web API** that serves as the backend for the system, fully integrated with an **Angular frontend**.

---

## 🚀 Features

### 👤 User Management

* Secure registration and login.
* Role-based authentication for:

  * Patients
  * Helpers (Providers)

---

### 📜 Patient Features

* Create direct **Patient Requests** to specific helpers.
* Create public **Patient Offers** for any helper to apply.
* Manage profile, service requests, and payments.

---

### 🧑‍🔧 Helper (Provider) Features

* Create and manage **Helper Service Offers**.
* Apply for public **Patient Offers**.
* Accept or reject direct **Patient Requests**.
* Receive and manage payments.

---

### 💳 Payment Features

* Track payments related to completed services.
* Store amount, status, payment method, and linked service/request.

---

### 📚 Service Management

* Centralized **Service Categories**.
* Flexible scheduling and budgeting.

---

### 🔮 Additional Features

* ✅ Real Payment Gateways (Stripe).
* ✅ Real-time Notifications (using SignalR).

---

## 🏗 Technologies Used

| Layer              | Technology                                |
| ------------------ | ----------------------------------------- |
| **Backend**        | ASP.NET Core Web API (.NET 7)             |
| **Database**       | SQL Server (EF Core Code-First)           |
| **Authentication** | ASP.NET Identity + JWT Tokens             |
| **Frontend**       | Angular 17+ (Separate Repository)         |
| **API Docs**       | Swagger (Swashbuckle)                     |
| **Security**       | Role-based Authorization, Data Validation |

---

## 🔗 API Documentation

Swagger UI available at:

```
https://localhost:{port}/swagger/index.html
```

Use this to interactively test and explore all available endpoints.

---

## ⚙ Setup & Running the Project

1️⃣ Clone this repository:

```bash
git clone https://github.com/AlaaElsisy/DisabilitySupport.git
cd DisabilitySupport
```

2️⃣ Update `appsettings.json`:

* Configure your **SQL Server** connection string.
* Add your **JWT** authentication settings.

3️⃣ Apply EF Core Migrations:

```bash
Update-Database
```

4️⃣ Run the API:

```bash
dotnet run
```

---

## 🌐 Frontend (Angular) Repository

👉 The frontend of the system is available here:
[https://github.com/shiiim5/DisabilityPlatformUI.git](https://github.com/shiiim5/DisabilityPlatformUI.git)

---

## 👥 Contributors

* Ahmed Abu-elmagd
* Ahmed Hatem
* Aya Elzoghby
* Alaa Elsisy
* Shimaa Aglan

---

## 📌 Future Improvements

* 🌍 Multi-language support (Arabic/English toggle for accessibility).
* ✉ Automated **Email & SMS Notifications** for service updates and payment confirmations.
* 🔍 Advanced **Search & Filtering** for services, helpers, and patient requests.
* ⭐ **Rating & Review System** for patients to rate helpers after service completion.
* 📊 **Admin Dashboard** for:

  * Managing users and services.
  * Viewing system-wide statistics and reports.



