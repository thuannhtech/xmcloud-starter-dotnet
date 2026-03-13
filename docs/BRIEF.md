# 💡 BRIEF: Azure Web App Deployment for Sitecore Hosts

**Ngày tạo:** 2026-03-13
**Trạng thái:** Confirmed

---

## 1. VẤN ĐỀ CẦN GIẢI QUYẾT
Tự động hóa việc triển khai (CI/CD) ứng dụng ASP.NET Core lên Azure Web Apps (Windows) thay vì chạy local qua Docker.

## 2. GIẢI PHÁP ĐỀ XUẤT
Sử dụng GitHub Actions để build code .NET 8 và deploy trực tiếp (Code publish) lên Azure App Service.

## 3. ĐỐI TƯỢNG & MÔI TRƯỜNG
- **Target OS:** Windows (Azure Web App)
- **Runtime:** .NET 8.0
- **Project:** `headapps/aspnet-core-starter/aspnet-core-starter.csproj`

## 4. LUỒNG TRIỂN KHAI (CI/CD)
| Nhánh (Branch) | Target App Service | Secret (Publish Profile) |
|---------------|-------------------|--------------------------|
| `dev-rendering-host` | `sai-rendering-host` | `AZURE_WEBAPP_PUBLISH_PROFILE_RENDERING` |
| `dev-editing-host` | `sai-editing-host` | `AZURE_WEBAPP_PUBLISH_PROFILE_EDITING` |

## 5. TÍNH NĂNG (PLANNING)
### 🚀 MVP (Giai đoạn 1):
- [ ] Cấu hình Workflow cho Rendering Host.
- [ ] Cấu hình Workflow cho Editing Host.
- [ ] Tối ưu build process (Caching, Publish).

### 🎁 Phase 2 (Làm sau):
- [ ] Thông báo kết quả deploy qua Teams/Slack (nếu cần).
- [ ] Rollback strategy.

## 6. ƯỚC TÍNH SƠ BỘ
- **Độ phức tạp:** Trung bình (cần setup Secret chuẩn).
- **Rủi ro:** Sai lệch path project hoặc thiếu file cấu hình (`appsettings.json`, `Directory.Packages.props`).

## 7. BƯỚC TIẾP THEO
→ Thực hiện `/plan` để tạo file workflow chi tiết.
