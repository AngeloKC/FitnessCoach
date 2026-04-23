# Project Instructions: AI Fitness Coach App
## Aligned with AI-103T00 — Develop AI Apps and Agents on Azure

---

## 1. Project Overview

We are building an **AI-powered fitness coaching web app** that serves as the hands-on vehicle for working through the [AI-103T00 course](https://learn.microsoft.com/en-us/training/courses/ai-103t00). Every feature we build maps directly to a course module. The app is real, functional, and production-minded — not a toy.

**Tech stack:** Azure AI Foundry (Microsoft Foundry), .NET 10 / C#, Blazor Server.

---

## 2. The App — What We're Building

### User Profile
The end-user can enter and manage:
- **Name, age, height, weight**

### Goals
The user can define fitness goals:
- **Goal name** (e.g., "Run a 5K", "Deadlift 225 lbs")
- **Description**
- **Target date**
- **Exercise sessions** that constitute progress toward the goal
  - Examples: "5-mile run in under 60 min", "Deadlift 225 lbs × 5 reps × 3 sets"

### AI Capabilities
The app has two AI modes:

**1. Conversational Chat (AI Apps)**
- Built-in chat interface anchored to the user's profile and goals
- User can ask about: next session planning, exercise form, recovery, nutrition, motivation, etc.
- Context-aware: the AI knows who the user is and what they're working toward

**2. Agentic Progress Evaluation (AI Agents)**
- Agents run on an interval (e.g., daily/weekly)
- They evaluate logged progress against goals
- They surface proactive recommendations (e.g., "You're behind pace — here's an adjusted plan")
- They can use tools: calendar awareness, goal math, session history analysis

---

## 3. Course Mapping & Build Plan

### Phase 1 — AI Apps (Aggressive Pace) ✦ Priority 1
**Course Module 1: Develop generative AI apps in Azure**

| Course Concept | App Feature |
|---|---|
| Deploy & configure models via Azure AI Foundry | Wire up the LLM backend; select and deploy a chat model |
| Prompt engineering & system prompts | Build the fitness coach persona; inject user profile + goals into system prompt |
| Chat completions API | Implement the in-app chat UI and backend endpoint |
| RAG (Retrieval-Augmented Generation) | Connect user's goal/session history as a knowledge source |
| Responsible AI / content safety | Add content filters appropriate for health/fitness context |

**Deliverable:** A working web app where a user can set up their profile, define a goal, and have a contextual fitness coaching conversation.

---

### Phase 2 — AI Agents (Aggressive Pace) ✦ Priority 2
**Course Module 2: Develop AI agents on Azure**

| Course Concept | App Feature |
|---|---|
| Agent fundamentals (what, when, why) | Design the "Progress Evaluator" agent architecture |
| Azure AI Foundry Agent Service | Implement the agent using Foundry Agent Service |
| Tool integration | Give the agent tools: goal calculator, session log reader, date/schedule awareness |
| Multi-step reasoning / agentic workflows | Agent evaluates progress, reasons about gaps, generates a recommendation plan |
| Multi-agent orchestration | Optional: separate agents for "progress analysis" vs. "plan generation" |
| Agent scheduling / interval execution | Hook agent to a scheduler (e.g., Azure Function timer trigger) |

**Deliverable:** Agents that periodically evaluate the user's logged sessions vs. their goals and surface recommendations in the app UI.

---

### Phase 3 — Natural Language Solutions
**Course Module 3: Natural language in Azure**

| Course Concept | App Feature |
|---|---|
| Text analysis | Analyze session notes for sentiment, effort, and keywords |
| Speech transcription | Voice input for logging sessions or chatting |
| Speech synthesis | Read coach responses aloud |
| Language translation | Multi-language support for the coaching interface |

---

### Phase 4 — Visual Data & Multimodal
**Course Module 4: Extract insights from visual data**

| Course Concept | App Feature |
|---|---|
| Computer vision | Analyze a photo of a lift for form feedback |
| Generative AI + vision | Upload a video still; coach comments on posture |
| Content Understanding | Parse fitness documents / PDFs (e.g., training plans) |

---

## 4. Working Conventions

### Cost Mindfulness — Standing Rule
Azure billing is a first-class concern at every step. This applies to architecture decisions, code reviews, and any "vibe coding" sessions where we're moving fast.

- **Provision on demand, tear down when done.** No cloud resource should sit idle. Scripts or IaC (Bicep/CLI) that create resources must have a paired teardown.
- **Prefer serverless and consumption-based tiers** (Azure Container Apps, Functions consumption plan, etc.) over always-on compute.
- **Local-first development.** Run everything locally (SQLite, local model endpoints or mocks) until a cloud resource is actually required to test a specific Azure capability.
- **Before provisioning anything in Azure, ask:** does this need to be in the cloud right now, or can we fake it locally?
- **"Vibe coding" rule:** when moving fast and iterating freely, cost discipline does not relax. If a shortcut would leave a billable resource running unattended, it's not an acceptable shortcut.

### Pace
- **Modules 1 & 2 (AI Apps + AI Agents):** Aggressive. We move fast, make pragmatic decisions, and iterate. Don't over-engineer early.
- **Modules 3 & 4:** Steady. We'll integrate features thoughtfully as we reach them.

### Architecture — N-Tier
The solution is layered. Each layer has one job. Blazor is a thin shell.

```
FitnessCoach.sln
FitnessCoach.App\          # Blazor Server — UI only
FitnessCoach.Services\     # Business logic, AI orchestration, agent coordination
FitnessCoach.DAL\          # EF Core DbContext, repositories, SQLite
FitnessCoach.Data\         # Shared models, DTOs, interfaces — no dependencies
```

**Rules:**
- **Blazor pages/components** call services, bind to models, render state. No business logic, no EF, no AI SDK calls.
- **Services** own all logic — chat orchestration, prompt building, agent evaluation, goal math. They depend on repositories and AI clients via interfaces.
- **Repositories** are the only things that touch EF Core. Services never call `DbContext` directly.
- **Data** is the shared contract layer — models, DTOs, and interfaces live here. Nothing in Data depends on anything else in the solution.
- Dependency injection wires everything together in `Program.cs`.

This keeps Blazor approachable and the logic testable.

### Stack
- **Backend:** .NET 10 / C#
- **Frontend:** Blazor Server
- **Data persistence:** SQLite via EF Core — simple, file-based, no infrastructure overhead for now
- **Auth:** Anonymous — no login/identity for MVP
- **Agent scheduling:** .NET `BackgroundService` with a daily timer
- Secrets in `appsettings.json` locally; environment variables in production

### Session Format
Each working session should:
1. Reference the course section being covered
2. Build the mapped app feature
3. End with a working, committed increment

### AI Assistance (Meta)
Claude is a working partner in this project. It can:
- Explain course concepts in context of the app
- Generate and review code
- Suggest architecture decisions
- Flag when we're diverging from course intent

---

## 5. Resolved Decisions

| Decision | Choice | Notes |
|---|---|---|
| Language | .NET 10 / C# | Python only if a .NET SDK gap forces it |
| Frontend | Blazor Server — `FitnessCoach.App` | |
| Data persistence | SQLite via EF Core — `FitnessCoach.DAL` | File-based, zero infrastructure; migrate later if needed |
| Models & interfaces | `FitnessCoach.Data` | No dependencies on other projects |
| Business logic & AI | `FitnessCoach.Services` | No direct EF or Blazor references |
| Auth | Anonymous | No login/identity for MVP |
| Session logging | EF Core models + SQLite | User logs completed sessions via UI; same persistence layer as profile/goals |
| Agent cadence | Daily digest | Background service runs once per day, evaluates progress, stores recommendations |

---

## 6. Reference Links

- Course: https://learn.microsoft.com/en-us/training/courses/ai-103t00
- Azure AI Foundry docs: https://learn.microsoft.com/en-us/azure/ai-foundry/
- Azure AI Foundry Agent Service: https://learn.microsoft.com/en-us/azure/ai-services/agents/
- Target certification: Microsoft Certified: Azure AI App and Agent Developer Associate
