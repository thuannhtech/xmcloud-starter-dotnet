# Phase 02: Rendering Host Workflow

## Objective
Tạo file automation cho Rendering Host trên branch `dev-rendering-host`.

## Implementation Steps
1. [ ] Tạo file `.github/workflows/deploy-rendering-host.yml`.
2. [ ] Định cấu hình trigger: `on: push: branches: [ dev-rendering-host ]`.
3. [ ] Setup .NET 8 SDK.
4. [ ] Lệnh build: `dotnet build --configuration Release`.
5. [ ] Lệnh publish: `dotnet publish -c Release -o ./publish`.
6. [ ] Action deploy: `azure/webapps-deploy@v2` với App Name `sai-rendering-host`.

## Test Criteria
- [ ] Push code lên branch `dev-rendering-host`.
- [ ] Kiểm tra tab **Actions** trên GitHub xem job có chạy thành công không.

---
Next Phase: [Phase 03: Editing Host Workflow](phase-03-editing-flow.md)
