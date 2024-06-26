# เริ่มต้น ASP.NET Core MVC

- ติดตั้ง (.NET Core)
  https://dotnet.microsoft.com/en-us/download

- ติดตั้ง (VS Code)
  https://code.visualstudio.com/

- ติดตั้ง (SQL Server)
  https://www.microsoft.com/th-th/sql-server/sql-server-downloads

- ติดตั้ง (SQL Server Management Studio)
  https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16#download-ssms

```sh
dotnet new webapi --use-controllers -o myFirstProject
cd myFirstProject

dotnet tool install --global dotnet-ef --version 8.*
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

dotnet add package Microsoft.EntityFrameworkCore.Tools
code .
```

- ติดตั้ง Extension C# Dev Kit
- เริ่มต้นที่ไฟล์ Program.cs กด F5 เพื่อทดสอบ

# MVC (Model-View-Controller)

- Model
- View -> UI โดย Controller จะนำข้อมูลจาก Model ที่ส่งมาให้ View และทำหน้าที่ในการส่งข้อมูลกลับมาที่ Controller
- Controller -> ควบคุมลำดับการทำงาน และ รับ-ส่ง (req,res) จาก View

# REST API

# SQL Server Management Studio (Connection)

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost; Database=Inventory; Trusted_Connection=False; TrustServerCertificate=True; User ID=sa; Password=Password "
  }
}
```

```sh
dotnet ef dbcontext scaffold "Server=localhost;Database=Inventory;Trusted_Connection=False;TrustServerCertificate=True;User ID=sa; Password=Password " Microsoft.EntityFrameworkCore.SqlServer -o Models -c InventoryContext -f --context-dir Data
```

# Metadata (\*remark\*)

- สิ่งที่เก็บข้อมูลเพิ่มเติมของ Model ต่างๆ เช่น class, method, attribute
- ไฟล์ EmployeeMetadata.cs , EmployeeController.cs

# CRUD

- Create
- Read
- Update
- Delete (Soft Delete)
- Set Route Path

# Validation

- Response
- Return Error Message
- Data Validation

# ติดตั้ง Postman

# Sorting, Searching, Paging

- เรียงข้อมูล Salary
- OrderBy() น้อย ไป มาก
- OrderByDescending() มาก ไป น้อย
- ตัวอักษรหลักการเดียวกัน

# One-to-many Relation API

- เพิ่มตารางใหม่ แล้วผูก ID เข้าเป็น FK ให้ Employee
- Scaffold ใหม่
- สร้างไฟล์ DepartmentMetadata.cs , DepartmentController.cs และ action
- ใช้รูปแบบเดียวกับ Employee

# Default 0

```sql
DBCC CHECKIDENT ('Products', RESEED, 0)

TRUNCATE TABLE 'Products'
```
