♿ Disability Support System – Backend API
 
The Disability Support System is an accessible web-based platform designed to connect patients with disabilities and Providers (helpers) who are willing to provide essential services.
This repository contains the ASP.NET Core Web API that serves as the backend for the system, fully integrated with an Angular frontend.
The system enables:

Patients: To request various services and manage their requests.
Helpers (Providers): To offer services or apply to fulfill patient requests.
Payment Tracking: To handle secure payments between patients and Helpers.

🚀 Features
👤 User Management
Secure registration and login.
Role-based authentication for:
Patients
Helpers

📝 Patient Features
Create direct Patient Requests to specific helpers.
Create public Patient Offers for any helper to apply.
Manage profile, service requests, and payments.

🧑‍🔧 Helper Features
Create and manage Helper Service Offers.
Apply for public Patient Offers.
Accept or reject direct Patient Requests.
Receive and manage payments.

💳 Payment Features
Track payments related to completed services.
Store amount, status, payment method, and linked service/request.

📚 Service Management
Centralized Service Categories.
Flexible scheduling and budgeting.
🔮Additional Features
 Real Payment Gateways: ( Stripe)
 Real-time Notifications: (using SignalR)

🏗 Technologies Used
Layer	Technology
Backend	ASP.NET Core Web API (.NET 7)
Database	SQL Server (EF Core Code-First)
Authentication	ASP.NET Identity + JWT Tokens
Frontend	Angular 17+ (Separate Repository)
API Docs	Swagger (Swashbuckle)
Security	Role-based Authorization, Data Validation

🗄 Main Database Entities
Table	Description
User	Core identity: shared by both Helpers and Patients
Patient	Patient-specific profile and medical data
Helper	Helper-specific profile and bio
ServiceCategories	Service category lookup (e.g., transportation)
PatientRequest	Direct requests from patients to helpers
patient_Offers	Public patient requests for any helper to apply
HelperServices	Services posted by helpers
HelperReques	Applications by helpers to public patient requests
Payment	Payment transactions between users

🔗 API Documentation
Swagger UI available at:
https://localhost:{port}/swagger/index.html
Allows interactive testing of all available endpoints.

⚙ Setup & Running the Project
1️⃣ Clone this repository:
git clone https://github.com/AlaaElsisy/DisabilitySupport.git
cd DisabilitySupport
2️⃣ Update appsettings.json:
Configure SQL Server connection string.
Add JWT settings.

3️⃣ Apply EF Core Migrations:
dotnet ef database update
4️⃣ Run the API:
dotnet run
🌐 Frontend (Angular) Repository
The frontend for this system is available at:
👉 https://github.com/shiiim5/DisabilityPlatformUI.git

👥 Contributors
Ahmed Abu-elmagd
Ahmed Hatem	
Aya Elzoghby
Alaa Elsisy	 
Shimaa Aglan

📌 Future Improvements
Multi-language support (Arabic/English toggle for better accessibility).
Automated Email & SMS Notifications for service updates and payment confirmations.
Advanced Search & Filtering for services, helpers, and patient requests.
Rating & Review System for patients to rate helpers after service completion.
Admin Dashboard for:
  Managing users and services.
  Viewing system-wide statistics and reports.
