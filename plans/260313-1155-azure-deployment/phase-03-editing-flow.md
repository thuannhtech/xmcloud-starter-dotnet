# Phase 03: Editing Host Workflow

## Objective
Tạo file automation cho Editing Host trên branch `dev-editing-host`.

## Implementation Steps
1. [ ] Tạo file `.github/workflows/deploy-editing-host.yml`.
2. [ ] Định cấu hình trigger: `on: push: branches: [ dev-editing-host ]`.
3. [ ] Các bước Build & Publish tương tự Rendering Host.
4. [ ] Action deploy trỏ tới App Name `sai-editing-host`.
5. [ ] Sử dụng secret `AZURE_WEBAPP_PUBLISH_PROFILE_EDITING`.

## Test Criteria
- [ ] Push code lên branch `dev-editing-host`.
- [ ] Kiểm tra deployment trên Azure Portal.

---
Next Phase: [Phase 04: Testing & Verification](phase-04-testing.md)
