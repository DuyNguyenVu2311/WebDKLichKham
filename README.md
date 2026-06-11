<p align="center">
  <img src="https://img.shields.io/badge/ASP.NET%20Core-9.0-blueviolet?style=for-the-badge&logo=dotnet" alt="ASP.NET Core 9.0"/>
  <img src="https://img.shields.io/badge/SQL%20Server-Express-red?style=for-the-badge&logo=microsoftsqlserver" alt="SQL Server"/>
  <img src="https://img.shields.io/badge/License-MIT-green?style=for-the-badge" alt="License"/>
</p>

# 🏥 Hệ thống Quản lý & Đặt lịch Khám bệnh Trực tuyến

> **WebDKLichKham** — Ứng dụng web giúp phòng khám tư nhân số hóa quy trình tiếp nhận bệnh nhân, quản lý lịch khám và đội ngũ bác sĩ một cách hiệu quả.

---

## 📋 Mục lục

- [Giới thiệu dự án](#-giới-thiệu-dự-án)
- [Công nghệ sử dụng](#-công-nghệ-sử-dụng)
- [Kiến trúc hệ thống](#-kiến-trúc-hệ-thống)
- [Các chức năng chính](#-các-chức-năng-chính)
- [Hình ảnh minh họa](#-hình-ảnh-minh-họa)
- [Cơ sở dữ liệu](#-cơ-sở-dữ-liệu)
- [Hướng dẫn cài đặt & chạy project](#-hướng-dẫn-cài-đặt--chạy-project)
- [Tài khoản mẫu](#-tài-khoản-mẫu)
- [Cấu trúc thư mục](#-cấu-trúc-thư-mục)
- [Hướng phát triển](#-hướng-phát-triển)
- [Tác giả](#-tác-giả)

---

## 📖 Giới thiệu dự án

Trong bối cảnh chuyển đổi số ngành y tế, việc quản lý lịch hẹn khám bệnh theo phương thức truyền thống (gọi điện, sổ sách) gây ra nhiều bất tiện: trùng lịch, mất thông tin, thiếu minh bạch. Hệ thống **WebDKLichKham** ra đời nhằm giải quyết các vấn đề này cho **phòng khám tư nhân quy mô vừa và nhỏ**.

### 🎯 Mục tiêu

- Cho phép bệnh nhân **đặt lịch khám trực tuyến** mọi lúc, mọi nơi
- Giúp phòng khám **quản lý lịch hẹn, bác sĩ, bệnh nhân** tập trung trên một nền tảng
- **Phân quyền** rõ ràng giữa Bệnh nhân (User) và Quản trị viên (Admin)
- Hỗ trợ phòng khám có **nhiều cơ sở** (Thủ Đức, Nhơn Trạch)
- **Ngăn chặn đặt trùng lịch** và xử lý các ngoại lệ nghiệp vụ

---

## 🛠 Công nghệ sử dụng

| Thành phần         | Công nghệ                                                |
|--------------------|-----------------------------------------------------------|
| **Backend**        | ASP.NET Core 9.0 (MVC Pattern)                           |
| **Frontend**       | Razor Views, HTML5, CSS3, JavaScript, Bootstrap           |
| **Cơ sở dữ liệu** | Microsoft SQL Server Express (LocalDB)                    |
| **ORM**            | Entity Framework Core 9.0 (Code-First + Migrations)      |
| **Xác thực**       | ASP.NET Core Identity (Cookie Authentication + RBAC)      |
| **Ngôn ngữ**       | C# 12, .NET 9                                            |
| **IDE**            | Visual Studio 2022 / JetBrains Rider                      |
| **Quản lý mã nguồn** | Git & GitHub                                           |

---

## 🏗 Kiến trúc hệ thống

```
┌─────────────────────────────────────────────────────────┐
│                    Client (Browser)                     │
│         Razor Views + Bootstrap + JavaScript            │
└──────────────────────┬──────────────────────────────────┘
                       │ HTTP/HTTPS
┌──────────────────────▼──────────────────────────────────┐
│                 ASP.NET Core MVC 9.0                    │
│  ┌──────────────┐  ┌──────────────┐  ┌──────────────┐  │
│  │  Controllers │  │    Views     │  │   Models     │  │
│  │  (3 chính +  │  │  (Razor +   │  │  (9 entity + │  │
│  │   3 Admin)   │  │   Layouts)  │  │  9 ViewModel)│  │
│  └──────┬───────┘  └──────────────┘  └──────────────┘  │
│         │                                               │
│  ┌──────▼────────────────────────────────────────────┐  │
│  │        Entity Framework Core 9.0 (ORM)            │  │
│  │   ApplicationDbContext + Identity DbContext        │  │
│  └──────┬────────────────────────────────────────────┘  │
└─────────┼───────────────────────────────────────────────┘
          │ ADO.NET / SQL
┌─────────▼───────────────────────────────────────────────┐
│            Microsoft SQL Server Express                 │
│              Database: WebDKLichKhamDb                  │
│    6 bảng chính + bảng ASP.NET Identity (5 bảng)       │
└─────────────────────────────────────────────────────────┘
```

---

## ⚙ Các chức năng chính

### 👤 Vai trò: Người dùng (User / Bệnh nhân)

| #  | Chức năng                     | Mô tả                                                                             |
|----|-------------------------------|------------------------------------------------------------------------------------|
| 1  | Đăng ký / Đăng nhập          | Tạo tài khoản bằng email, đăng nhập an toàn với ASP.NET Identity                  |
| 2  | Xem trang chủ                | Dashboard hiển thị thống kê tổng quan, bác sĩ nổi bật, chuyên khoa               |
| 3  | Xem danh sách bác sĩ         | Tra cứu đội ngũ bác sĩ theo chuyên khoa, xem hồ sơ chi tiết                      |
| 4  | Đặt lịch khám online         | Chọn chuyên khoa → Hệ thống tự phân bác sĩ trực ca → Chọn ngày giờ → Xác nhận    |
| 5  | Xem lịch hẹn của tôi         | Danh sách lịch hẹn sắp tới & lịch sử, phân loại theo trạng thái                  |
| 6  | Tra cứu lịch hẹn             | Tra cứu nhanh bằng **Số điện thoại + Mã lịch hẹn** (không cần đăng nhập)          |
| 7  | Xem kiến thức y khoa         | Tra cứu triệu chứng, bệnh liên quan và cách phòng ngừa                            |
| 8  | Xem dịch vụ phòng khám       | Thông tin các dịch vụ khám và chăm sóc sức khỏe                                   |

### 🔐 Vai trò: Quản trị viên (Admin)

| #  | Chức năng                     | Mô tả                                                                             |
|----|-------------------------------|------------------------------------------------------------------------------------|
| 1  | Dashboard tổng quan           | Thống kê số bác sĩ, bệnh nhân, lịch hẹn chờ/đã xác nhận + danh sách gần đây     |
| 2  | Quản lý lịch hẹn             | Xem toàn bộ lịch hẹn, chuyển trạng thái: Chờ → Xác nhận → Hoàn thành / Hủy       |
| 3  | Quản lý bác sĩ               | Xem danh sách bác sĩ theo chuyên khoa và cơ sở làm việc                           |

### 🛡 Bảo mật & Xử lý ngoại lệ

- **Phân quyền RBAC**: Chỉ Admin mới truy cập được khu vực `/Admin/*`
- **Chống đặt trùng lịch**: Kiểm tra trùng lặp theo SĐT + Ngày + Khung giờ
- **AntiForgeryToken**: Bảo vệ tất cả form POST chống tấn công CSRF
- **Xác thực dữ liệu**: Data Annotations trên tất cả Model entities

---

## 📸 Hình ảnh minh họa

> ⚠️ *Thay thế các đường dẫn bên dưới bằng ảnh chụp màn hình thực tế của bạn.*

### Trang chủ
![Trang chủ](./report-assets/screenshots/home-page.png)

### Trang đặt lịch khám
![Đặt lịch khám](./report-assets/screenshots/booking-page.png)

### Xác nhận lịch hẹn
![Xác nhận](./report-assets/screenshots/confirmation-page.png)

### Trang quản lý Admin
![Admin Dashboard](./report-assets/screenshots/admin-dashboard.png)

### Quản lý lịch hẹn (Admin)
![Quản lý lịch hẹn](./report-assets/screenshots/admin-appointments.png)

---

## 🗄 Cơ sở dữ liệu

### Sơ đồ ERD (Entity Relationship Diagram)

```mermaid
erDiagram
    AspNetUsers ||--o| PatientProfiles : "1-1"
    PatientProfiles ||--o{ Appointments : "1-N"
    Doctors ||--o{ Appointments : "1-N"
    Doctors ||--o{ DoctorSchedules : "1-N"
    Specialties ||--o{ Doctors : "1-N"

    Specialties {
        int Id PK
        string Name UK
        string Description
        string IconClass
        bool IsActive
    }

    Doctors {
        int Id PK
        int SpecialtyId FK
        string FullName
        string Specialty
        string PhoneNumber
        string Email
        string Qualification
        int ExperienceYears
        decimal Fee
        string Biography
        string Workplace
        string AvatarUrl
        bool IsFeatured
        bool IsActive
    }

    DoctorSchedules {
        int Id PK
        int DoctorId FK
        date WorkDate
        enum Shift
        time StartTime
        time EndTime
        int MaxAppointments
        string Notes
    }

    PatientProfiles {
        int Id PK
        string UserId FK_UK
        string FullName
        string PhoneNumber
        string Address
        string MedicalHistory
        date DateOfBirth
    }

    Appointments {
        int Id PK
        int DoctorId FK
        int PatientProfileId FK
        string AppointmentCode UK
        string PatientName
        string PatientPhone
        string PatientEmail
        date AppointmentDate
        time StartTime
        time EndTime
        enum Status
        string ReasonForVisit
        string Notes
        datetime CreatedAt
    }
```

### Các ràng buộc toàn vẹn chính

- `Appointments.AppointmentCode`: **UNIQUE** — Mỗi lịch hẹn có mã duy nhất
- `(DoctorId, AppointmentDate, StartTime)`: **UNIQUE** — Không cho phép trùng ca khám
- `PatientProfiles.UserId`: **UNIQUE** — Mỗi tài khoản chỉ có 1 hồ sơ bệnh nhân
- `Specialties.Name`: **UNIQUE** — Tên chuyên khoa không trùng lặp
- `FK Doctors → Specialties`: ON DELETE SET NULL
- `FK DoctorSchedules → Doctors`: ON DELETE CASCADE
- `FK Appointments → Doctors`: ON DELETE RESTRICT
- `FK Appointments → PatientProfiles`: ON DELETE RESTRICT

---

## 🚀 Hướng dẫn cài đặt & chạy project

### Yêu cầu hệ thống

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) trở lên
- [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) hoặc LocalDB
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (khuyến nghị) hoặc VS Code + C# Extension
- [Git](https://git-scm.com/)

### Bước 1: Clone mã nguồn

```bash
git clone https://github.com/DuyNguyenVu2311/WebDKLichKham.git
cd WebDKLichKham
```

### Bước 2: Cấu hình Connection String

Mở file `WebDKLichKham/appsettings.json` và chỉnh sửa chuỗi kết nối phù hợp với SQL Server của bạn:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=TEN_MAY_BAN\\SQLEXPRESS;Database=WebDKLichKhamDb;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False;TrustServerCertificate=True"
  }
}
```

> 💡 Thay `TEN_MAY_BAN\\SQLEXPRESS` bằng tên instance SQL Server trên máy bạn. Ví dụ: `DESKTOP-ABC123\\SQLEXPRESS` hoặc `(localdb)\\mssqllocaldb`.

### Bước 3: Tạo cơ sở dữ liệu (Migration)

Mở **Package Manager Console** trong Visual Studio (hoặc terminal):

```bash
cd WebDKLichKham
dotnet ef database update
```

> Hệ thống sẽ tự tạo database `WebDKLichKhamDb` và các bảng cần thiết.

### Bước 4: Chạy ứng dụng

```bash
dotnet run --project WebDKLichKham
```

Hoặc nhấn **F5** trong Visual Studio.

Truy cập: **https://localhost:5001** (hoặc cổng hiển thị trong console)

### Bước 5: Dữ liệu mẫu (Seed Data)

Ứng dụng sẽ **tự động seed** dữ liệu mẫu khi khởi chạy lần đầu, bao gồm:
- 2 tài khoản (Admin + User)
- 6 chuyên khoa
- 10 bác sĩ (phân bố 2 cơ sở)
- Lịch làm việc tự động theo tuần hiện tại (Thứ 2 → Thứ 6, ca sáng + chiều)

---

## 🔑 Tài khoản mẫu

| Vai trò | Email                    | Mật khẩu     |
|---------|--------------------------|---------------|
| Admin   | `admin@phongkham.local`  | `Admin@123`   |
| User    | *(Tự đăng ký)*           | *(Tự chọn)*   |

> ⚠️ Tài khoản Admin được seed tự động. Bệnh nhân đăng ký tài khoản mới qua giao diện.

---

## 📁 Cấu trúc thư mục

```
WebDKLichKham/
├── WebDKLichKham.sln                 # Solution file
├── README.md                         # File hướng dẫn này
└── WebDKLichKham/                    # Main Project
    ├── Program.cs                    # Entry point, DI & Middleware
    ├── appsettings.json              # Cấu hình kết nối CSDL
    ├── WebDKLichKham.csproj          # NuGet packages
    │
    ├── Models/                       # Domain Models
    │   ├── Appointment.cs            # Lịch hẹn khám
    │   ├── AppointmentStatus.cs      # Enum trạng thái (Pending/Confirmed/Completed/Cancelled)
    │   ├── Doctor.cs                 # Bác sĩ
    │   ├── DoctorSchedule.cs         # Lịch làm việc bác sĩ
    │   ├── PatientProfile.cs         # Hồ sơ bệnh nhân
    │   ├── Specialty.cs              # Chuyên khoa
    │   ├── ScheduleShift.cs          # Enum ca làm việc
    │   └── ViewModels/               # View Models (9 files)
    │
    ├── Controllers/                  # Public Controllers
    │   ├── HomeController.cs         # Trang chủ, Dịch vụ, Kiến thức y khoa
    │   ├── AppointmentsController.cs # Đặt lịch, Xem lịch, Tra cứu
    │   └── DoctorsController.cs      # Danh sách bác sĩ
    │
    ├── Areas/
    │   ├── Admin/                    # Admin Area (RBAC Protected)
    │   │   ├── Controllers/
    │   │   │   ├── DashboardController.cs   # Thống kê tổng quan
    │   │   │   ├── AppointmentsController.cs # Quản lý lịch hẹn
    │   │   │   └── DoctorsController.cs      # Quản lý bác sĩ
    │   │   └── Views/                # Admin Razor Views
    │   └── Identity/                 # ASP.NET Identity scaffolded pages
    │
    ├── Data/
    │   ├── ApplicationDbContext.cs   # EF Core DbContext + Fluent API
    │   ├── AppDbSeeder.cs            # Seed data (Roles, Admin, Doctors, Schedules)
    │   └── Migrations/              # EF Core Migrations
    │
    ├── Views/                        # Public Razor Views
    │   ├── Home/                     # Index, Services, MedicalKnowledge, Login
    │   ├── Appointments/             # Create, Index, Confirmation, Lookup
    │   ├── Doctors/                  # Index (Danh sách bác sĩ)
    │   └── Shared/                   # _Layout, _LoginPartial, Error
    │
    └── wwwroot/                      # Static files (CSS, JS, images)
```

---

## 🔮 Hướng phát triển

- [ ] 📧 **Gửi email/SMS xác nhận** lịch hẹn tự động
- [ ] 📊 **Báo cáo thống kê** doanh thu, lượt khám theo thời gian (biểu đồ)
- [ ] 💬 **Tích hợp chatbot** tư vấn triệu chứng ban đầu
- [ ] 📱 **Responsive PWA** — Cài đặt như ứng dụng mobile
- [ ] 🏥 **Quản lý hồ sơ bệnh án** (EMR) cho bác sĩ
- [ ] 💳 **Thanh toán online** qua MoMo/ZaloPay/VNPAY
- [ ] 🔄 **API RESTful** cho tích hợp hệ thống bên thứ 3
- [ ] ☁️ **Triển khai cloud** lên Azure App Service

---

## 👨‍💻 Tác giả

| Thông tin       | Chi tiết                                                    |
|-----------------|-------------------------------------------------------------|
| **Họ và tên**   | Nguyễn Vũ Duy                                               |
| **MSSV**        | *(Điền mã số sinh viên của bạn)*                            |
| **Email**       | *(Điền email của bạn)*                                       |
| **GitHub**      | [DuyNguyenVu2311](https://github.com/DuyNguyenVu2311)      |
| **Trường**      | *(Điền tên trường / khoa)*                                   |
| **Môn học**     | *(Điền tên môn học / mã môn)*                                |
| **GVHD**        | *(Điền tên giảng viên hướng dẫn)*                            |

---

<p align="center">
  <b>⭐ Nếu dự án hữu ích, hãy cho một Star trên GitHub nhé! ⭐</b>
</p>

<p align="center">
  <i>© 2026 WebDKLichKham — Đồ án môn học</i>
</p>
