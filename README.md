# Banking Management System

## Overview
This project was my TASK for GRIP @ The Sparks Foundation. #GRIPSEPTEMBER23

## Features
- **Admin Functionality:**
  - Roles, Permissions & Users Management.
  - Deactivate user accounts.
  - View Customers' accounts & transactions.
  - Activate & Deactivate Account (Bulk Actions are available) 

- **User Functionality:**
  - create multiple accounts (account per type whether it's active or not).
  - Make transactions (deposit, Withdrawal, Transfer) between accounts.
  - View History

- **Authentication & Security:**
  - **Identity** module is integrated to enhance security.
  - Registration, login, change password, forget password, two-factor authentication aka 2FA, mail verification

- **Transaction History:**
  - SQL view alike 
  - Users can review their transaction history.
  - Admin has access to review all transactions and accounts.

- **Caching Layer:**
  - Implemented a caching layer to load dynamic lookup scripts on the browser to improve system performance.

- **Filtering and Searching:**
  - Users & Admin have the ability to filter and search transactions based on various criteria.
- Responsive Design
  
## Technologies & Frameworks
### Backend Technologies
- **ASP.NET Core MVC** using **C#**
- **SQL Server**
- **Dapper (ORM)**

### Frontend Technologies
- **Serenity.is Framework**
- **TypeScript**
- **JavaScript**
- **JQuery**
- **HTML**
- **CSS**

## Want to give it a try?
To run this project locally, follow these steps:

- Clone the repo (ssh)

```bash
git clone git@github.com:yassa-alqess/cyberbanking.git
```

- Set up the required dependencies including .NET Core, SQL Server, NodeJS

  => since it's core project, all pkgs are handled by the project manager (no need for pkgs dir thanks to Microsoft)
  
- install serenity dependencies using npm

```bash
npm install
```

- Configure your database connection in the project settings (for me I set up a local database with Windows authentication).
  
- Build and run the application. (VS shipped with dotnet tools is recommended for coming steps)

```bash
dotnet run --project cyberbanking.Web.csproj
```
- Transform T4 templets (serene pkg is a must)

```bash
dotnet sergen t
```

## Usage
- on the sidebar, hover over EBanking section to mange customer's Accounts & Transactions [anynonomous user]
- on the sidebar, hover over Administration section to manage users, Roles & permissions [Admin]


**Notes**: 

- I'm using Fluent Migrations to Seed data for the application, make sure u double check `Initialization\DataMigration.cs` before u run the application
as all migrations will be applied when the application starts.
- u can check that those migrations have been applied by viewing `versionInfo` table to see the keys of those migrations there.
- Dashboard is irrelevant, it's just a demo landing page.
- there is alot of design issues related to this project, but I don't want to be over engineering and duo to short time I followed those steps and maybe later I will follow some coherent patterns.



## Acknowledgments
- Thanks to [Sparks Foundation](https://www.thesparksfoundationsingapore.org/) for the inspiration and support.
