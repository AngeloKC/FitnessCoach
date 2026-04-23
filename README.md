# FitnessCoach

An AI-powered fitness coaching web app built as a hands-on learning vehicle for the [AI-103T00: Develop AI Apps and Agents on Azure](https://learn.microsoft.com/en-us/training/courses/ai-103t00) course.

## What It Does

- Users manage a fitness profile (name, age, height, weight) and define goals with target dates and exercise sessions
- **Conversational coaching:** context-aware chat powered by Azure AI Foundry — the AI knows your profile and goals
- **Agentic progress evaluation:** a background agent evaluates logged sessions against goals and surfaces proactive recommendations

## Tech Stack

| Layer | Technology |
|---|---|
| Frontend | Blazor Server (.NET 10) |
| Business Logic / AI | C# services, Azure AI Foundry |
| Data Access | EF Core + SQLite |
| Agent Scheduling | .NET BackgroundService |

## Solution Structure

```
FitnessCoach.App        # Blazor Server — UI only
FitnessCoach.Services   # Business logic, AI orchestration, agent coordination
FitnessCoach.DAL        # EF Core DbContext and repositories
FitnessCoach.Data       # Shared models, DTOs, interfaces
```

## Getting Started

```bash
git clone https://github.com/AngeloKC/FitnessCoach.git
cd FitnessCoach
dotnet run --project src/FitnessCoach.App
```

## Course Alignment

| Phase | Course Module | Status |
|---|---|---|
| 1 | Develop generative AI apps in Azure | In progress |
| 2 | Develop AI agents on Azure | Planned |
| 3 | Natural language solutions | Planned |
| 4 | Extract insights from visual data | Planned |
