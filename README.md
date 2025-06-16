# Student-Management-WebForms
ASP.NET Web Forms project for managing student records using SQL Server stored procedures. Includes functionality to add, edit, and delete records through a GridView interface.

## 🔧 Technologies Used

- ASP.NET Web Forms (C#)
- SQL Server
- Stored Procedures
- ADO.NET

## 📌 Features

- Insert new student records (Name and Age)
- Edit existing records directly from GridView
- Delete records with confirmation
- Displays all records in a tabular format using GridView
- Backend logic uses stored procedures for data operations

## 📁 File Structure

- `Default.aspx` – Frontend UI with input form and GridView
- `Default.aspx.cs` – Code-behind logic (insert, update, delete, bind data)
- `SQL Scripts` – Stored procedures:
  - `InsertStudents`
  - `UpdateStudent`
  - `DeleteStudent`
  - `GetAllStudents`
