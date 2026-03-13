# Phase 01: Setup GitHub Secrets

## Objective
Chuẩn bị các thông tin định danh (Publish Profile) để GitHub Actions có quyền đẩy code lên Azure Web App.

## Implementation Steps
1. [ ] Truy cập [Azure Portal](https://portal.azure.com).
2. [ ] Vào Web App `sai-rendering-host` > Overview > **Get publish profile**.
3. [ ] Vào Web App `sai-editing-host` > Overview > **Get publish profile**.
4. [ ] Vào GitHub Repo > Settings > Secrets and variables > Actions.
5. [ ] Tạo secret: `AZURE_WEBAPP_PUBLISH_PROFILE_RENDERING` (Paste nội dung file 1).
6. [ ] Tạo secret: `AZURE_WEBAPP_PUBLISH_PROFILE_EDITING` (Paste nội dung file 2).

## Test Criteria
- [ ] Secrets đã được lưu thành công trên GitHub.
- [ ] Có thể gọi được Secrets trong file YAML (sẽ check ở Phase 2).

---
Next Phase: [Phase 02: Rendering Host Workflow](phase-02-rendering-flow.md)
