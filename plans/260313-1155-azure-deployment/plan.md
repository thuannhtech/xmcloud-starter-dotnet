# Plan: Azure Deployment CI/CD
Created: 2026-03-13 11:55
Status: 🟡 In Progress

## Overview
Thiết lập hệ thống tự động build và deploy dự án ASP.NET Core (.NET 8) lên Azure Web Apps thông qua GitHub Actions, chia làm 2 luồng: Rendering Host và Editing Host.

## Tech Stack
- **Framework:** .NET 8.0 (Windows)
- **CI/CD:** GitHub Actions
- **Cloud:** Azure App Service (Windows Plan)

## Phases

| Phase | Name | Status | Progress |
|-------|------|--------|----------|
| 01 | Setup GitHub Secrets | ✅ Complete | 100% |
| 02 | Rendering Host Workflow | ✅ Complete | 100% |
| 03 | Editing Host Workflow | ✅ Complete | 100% |
| 04 | Testing & Verification | 🟡 In Progress | 50% |

## Quick Commands
- Start Phase 1: `/code phase-01`
- Check progress: `/next`
- Save context: `/save-brain`
