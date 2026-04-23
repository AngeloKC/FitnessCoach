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
FitnessCoach.sln
FitnessCoach.App\       # Blazor Server — UI only
FitnessCoach.Services\  # Business logic, AI orchestration, agent coordination
FitnessCoach.DAL\       # EF Core DbContext and repositories
FitnessCoach.Data\      # Shared models, DTOs, interfaces
```

## Getting Started

```bash
git clone https://github.com/AngeloKC/FitnessCoach.git
cd FitnessCoach
dotnet run --project FitnessCoach.App
```

## Course Alignment

| Phase | Course Module | Status |
|---|---|---|
| 1 | [Develop generative AI apps in Azure](https://learn.microsoft.com/en-us/training/paths/develop-generative-ai-apps/) | In progress |
| 2 | [Develop AI agents on Azure](https://learn.microsoft.com/en-us/training/paths/develop-ai-agents-azure/) | Planned |
| 3 | [Develop natural language solutions in Azure](https://learn.microsoft.com/en-us/training/paths/develop-language-solutions-azure-ai/) | Planned |
| 4 | [Develop computer vision solutions with Microsoft Foundry](https://learn.microsoft.com/en-us/training/paths/develop-computer-vision-with-foundry/) | Planned |

## Real-World Scenarios

Alongside the course deliverables, this project explores three enterprise scenarios that surface in production AI work:

**Prompt management for non-technical stakeholders**
How can subject-matter experts (e.g., certified trainers) contribute to and govern the coaching persona and system prompts without requiring code access or a deployment cycle? This covers prompt versioning, external prompt storage, and approval workflows.

**LLM prompt quality evaluation**
How do we validate that a model or prompt change actually improves coaching response quality before it reaches production? This covers Azure AI Foundry's evaluation tooling, defining fitness-specific quality metrics, and regression testing across model versions.

**Migration path: Azure OpenAI Service → Microsoft Foundry**
Many existing workloads are built on the standalone Azure OpenAI Service. Foundry expands model choice and unlocks agentic capabilities. This tracks the migration delta — API surface, SDK changes, and capabilities that are Foundry-only.
