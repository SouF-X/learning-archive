# Frontend Blueprint

## Goal

Build the MechanicShop frontend as a premium modern Blazor product UI that is easy to read, easy to explain, and strong enough for a junior .NET developer portfolio demo.

The first phase is design-first. We will build static screens with clear HTML/Razor structure and CSS before connecting real API calls.

## Technology Decision

- **Framework:** Blazor WebAssembly
- **View syntax:** Razor components (`.razor`)
- **Styling:** Scoped CSS (`.razor.css`) plus shared design tokens
- **Language:** C# for UI behavior and API calls
- **Markup:** HTML inside Razor
- **JavaScript:** Avoid custom JavaScript unless a browser feature truly requires it
- **Icons:** Bootstrap Icons for now, because the project already uses them
- **API calls:** Existing `ServiceApi` pattern, improved gradually when needed
- **Authentication:** Existing Blazor auth state, bearer token handler, and local storage setup

## Design Direction

Follow `PRODUCT.md` and `DESIGN.md`.

The UI should feel like a workshop command center:

- premium and modern
- clean professional structure
- garage-tech character without childish visuals
- restrained color
- readable data tables and forms
- strong workflow screens
- no cheap default Bootstrap look
- no noisy gradients or decorative animation

## Users And Roles

### Manager/Admin

Needs control over:

- dashboard stats
- customers
- vehicles
- work orders
- labor assignment
- schedules
- repair tasks
- invoices
- operating settings

### Labor/Employee

Needs focused access to:

- assigned work
- work order details
- current state
- schedule context
- task progress

## Main Navigation

The app should use a consistent shell:

- sidebar on desktop
- top bar with current user and session actions
- collapsed menu on smaller screens
- active page indicator
- role-aware navigation

Recommended navigation order:

1. Dashboard
2. Schedule
3. Work Orders
4. Customers
5. Repair Tasks
6. Invoices
7. Labors/Technicians
8. Settings

Note: the current API exposes labor selection through `GET /api/v1/labors`. It does not currently expose full employee CRUD for the frontend.

## Build Order

### Phase 1: Static Design

No API calls yet. Use fake data directly in the page/component.

1. App shell
2. Login page
3. Dashboard
4. Work orders list
5. Work order details
6. Schedule board
7. Customers list/details
8. Invoice details

### Phase 2: Razor Basics

Add simple C# only where it teaches the UI:

- fields
- lists
- loops
- conditions
- button clicks
- local page state
- simple component parameters

### Phase 3: Manual API Connection

Connect one screen at a time:

1. Login
2. Dashboard stats
3. Work orders list
4. Work order details
5. Customers
6. Schedule
7. Invoices

Each API connection must be explained with:

1. what endpoint it calls
2. what data model it expects
3. what loading state appears
4. what error state appears
5. what the user can do next

### Phase 4: Workflow Polish

After the core data works:

- empty states
- validation messages
- loading skeletons
- error banners
- confirmation dialogs
- responsive layout
- accessibility pass

## Screen Plan

### Login

Purpose: authenticate the user and enter the app.

Needs:

- email/username input
- password input
- remember me checkbox
- error message area
- clear login button
- premium but simple layout

Learning focus:

- form structure
- input binding
- submit action
- auth response

### Dashboard

Purpose: show the current health of the workshop.

Needs:

- today work orders
- scheduled/in-progress/completed/cancelled counts
- revenue/cost/profit summary if available
- quick links to schedule and work orders
- compact activity/status area

Learning focus:

- cards as data summaries
- fake data first
- API data later
- simple loading state

### Work Orders List

Purpose: search, filter, and open work orders.

Needs:

- table/list view
- state chips
- customer/vehicle summary
- labor assignment summary
- date/time
- filters
- pagination

Learning focus:

- lists
- tables
- query filters
- reusable status chip component

### Work Order Details

Purpose: manage one work order.

Needs:

- customer and vehicle block
- current state
- assigned labor
- repair tasks
- schedule timing
- invoice action when allowed
- manager-only actions

Learning focus:

- route parameter
- loading one item
- conditional UI by state/role
- update actions

### Schedule Board

Purpose: understand daily workshop capacity.

Needs:

- date selector
- labor filter
- operating hours
- spots/slots
- work order blocks
- clear empty slots

Learning focus:

- nested data
- responsive grids
- time display
- refresh/update after action

### Customers

Purpose: manage customer and vehicle records.

Needs:

- customers list
- search
- details panel/page
- vehicles under customer
- create/edit actions later

Learning focus:

- parent/child data
- simple CRUD screens
- forms

### Repair Tasks

Purpose: manage reusable repair task definitions.

Needs:

- task list
- estimated duration
- price/cost if available
- create/edit/delete for manager

Learning focus:

- simple admin table
- validation messages

### Invoices

Purpose: show billing output from completed work.

Needs:

- invoice details
- line items
- totals
- status
- download PDF action
- settle payment action if available

Note: the current API supports issuing an invoice from a work order, viewing one invoice, downloading PDF, and marking paid. No invoice list route was found, so the frontend should open invoices from work order/detail flows unless the backend adds a list later.

Learning focus:

- detail layout
- money formatting
- file download concept later

## Reusable Components

Build these as small readable components:

- `AppShell`
- `PageHeader`
- `StatTile`
- `StatusChip`
- `DataTableToolbar`
- `EmptyState`
- `ErrorBanner`
- `LoadingSkeleton`
- `ConfirmDialog`
- `FormField`
- `WorkOrderCard`
- `ScheduleSlot`

Each reusable component should have one clear job.

## Readability Rules

- Keep component names obvious.
- Keep page code simple before extracting abstractions.
- Do not hide beginner-important logic behind clever helpers too early.
- Repeat simple patterns until they are understood.
- Move only repeated API calls into services.
- Use comments only when the code teaches a non-obvious idea.
- Keep CSS class names meaningful and connected to the design system.

## API Coverage

The frontend should eventually cover these active controller-based backend areas:

- `identity/token/generate`
- `identity/token/refresh-token`
- `identity/current-user/claims`
- `api/v1/dashboard/stats`
- `api/v1/customers`
- `api/v1/labors`
- `api/v1/repair-tasks`
- `api/v1/workorders`
- `api/v1/workorders/schedule/{date}`
- `api/v1/invoices`
- `api/settings/operating-hours`

Important API notes:

- Vehicles are nested under customers, not a standalone frontend area.
- Parts are nested under repair tasks, not a standalone frontend area.
- Schedule is part of work orders and needs the `X-TimeZone` header.
- SignalR work order updates are available at `/hubs/workorders`.
- The controller routes are the active API surface; old minimal endpoint files should not guide the frontend unless they are wired into startup later.

## Definition Of Ready Before Coding

Before coding a screen, we should know:

1. who uses the screen
2. what the main action is
3. what fake data appears first
4. what API endpoint replaces the fake data later
5. what loading, empty, and error states look like
6. what concept the screen teaches

## First Build Target

Start with:

1. App shell
2. Login page
3. Dashboard

These give the project a professional first impression and teach the basic frontend pattern before the more complex screens.
