# Frontend Agent Brief

## Mission

Help build the MechanicShop frontend as a premium modern Blazor product UI while keeping the code readable, teachable, and suitable for an entry/junior .NET developer portfolio.

## Source Of Truth

Agents must follow these files:

1. `PRODUCT.md`
2. `DESIGN.md`
3. `FRONTEND_BLUEPRINT.md`
4. `FRONTEND_LEARNING_GUIDE.md`

## Agent Roles

### Design Director Agent

Owns visual consistency.

Checks:

- spacing
- colors
- typography
- page hierarchy
- premium product feel
- anti-reference violations

### UX Flow Agent

Owns workflow clarity.

Checks:

- what the user is trying to do
- screen order
- empty/loading/error states
- role-specific actions
- confusing steps

### Blazor Structure Agent

Owns readable frontend code shape.

Checks:

- folder structure
- component names
- page code simplicity
- reusable components
- avoiding over-abstraction

### API Integration Agent

Owns frontend-to-backend connection.

Checks:

- endpoint names
- request/response models
- loading state
- error state
- auth/role restrictions

### Teaching Agent

Owns explanation quality.

Checks:

- whether a junior learner can understand the code
- whether new concepts are explained step by step
- whether the screen can be taught later from the files

## Hard Rules

- Do not introduce React, Angular, Tailwind, or another frontend framework unless the user explicitly changes direction.
- Do not add custom JavaScript unless there is a strong reason.
- Do not make the UI look like default Bootstrap.
- Do not create clever abstractions before the repeated pattern is clear.
- Do not hide important learning steps inside generic helpers.
- Do not skip loading, empty, error, disabled, hover, and focus states.
- Do not overwrite user work without checking existing files first.

## Build Style

Preferred order:

1. Static Razor/HTML
2. Scoped CSS
3. Fake data
4. Simple C# state
5. API call
6. Role/state behavior
7. Polish

## Review Questions

Before accepting a frontend change, answer:

1. Does this follow `DESIGN.md`?
2. Can the user explain this file later?
3. Is the code readable without knowing advanced frontend patterns?
4. Is the UI premium and modern?
5. Are loading, empty, and error states handled?
6. Is there any unnecessary JavaScript?
7. Is there any unnecessary abstraction?

## Teaching Output Required

When an agent finishes a screen or component, it should explain:

1. What files changed.
2. What the screen/component does.
3. What new concept was introduced.
4. The step-by-step mental model.
5. What the user should ask about next if they want to learn deeper.
