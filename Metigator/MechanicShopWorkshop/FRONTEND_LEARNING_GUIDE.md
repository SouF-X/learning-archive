# Frontend Learning Guide

## Purpose

This guide exists so the frontend stays understandable. The goal is not only to build a good-looking app, but also to make every piece teachable later.

When we build a screen, the explanation should be simple enough to revisit after a break.

## Main Mental Model

Blazor is the frontend framework.

Razor is the file format that lets us write HTML and C# together.

For this project:

- HTML describes the structure.
- CSS controls the look.
- C# controls page behavior.
- Services call the API.
- The backend keeps the real business rules.

## Learning Order

### Step 1: Static Design

Build the screen with fake data.

Learn:

- page structure
- layout
- CSS classes
- spacing
- colors
- responsive design

No API calls yet.

### Step 2: Razor Basics

Add simple C# inside the page.

Learn:

- variables
- lists
- `@foreach`
- `@if`
- `@onclick`
- component parameters

### Step 3: One API Call

Connect one page to one endpoint.

Learn:

- `HttpClient` or `ServiceApi`
- loading state
- success state
- error state
- showing returned data

### Step 4: Forms

Add create/edit screens.

Learn:

- form model
- input binding
- validation messages
- submit action
- server errors

### Step 5: Workflow Logic

Add real behavior.

Learn:

- role-based UI
- state-based buttons
- refresh after update
- confirmation dialogs
- empty states

## Explanation Template For Every Screen

Every screen should be explainable in this order:

1. What is this screen for?
2. Who uses it?
3. What data does it show?
4. Where does the data come from?
5. What local state does the page keep?
6. What actions can the user do?
7. What API calls happen?
8. What happens when loading fails?
9. What reusable components are used?
10. What new concept did this screen teach?

## Code Style For Learning

Use clear names:

- `isLoading`
- `errorMessage`
- `workOrders`
- `selectedDate`
- `HandleLogin`
- `LoadCustomersAsync`
- `SaveCustomerAsync`

Avoid names that hide meaning:

- `data`
- `item`
- `manager`
- `handler`
- `DoStuff`

Use small components only when they help learning.

Good extraction:

- `StatusChip`
- `PageHeader`
- `ErrorBanner`
- `LoadingSkeleton`

Avoid early extraction:

- generic page engines
- abstract table builders
- complicated base classes
- too many helper methods before the pattern is understood

## Page Code Pattern

Most data pages should follow this readable pattern:

1. Page route and title
2. HTML/Razor layout
3. loading/empty/error UI
4. page fields
5. `OnInitializedAsync`
6. load method
7. action methods

Example shape:

```razor
@page "/customers"

<PageHeader Title="Customers" />

@if (isLoading)
{
    <LoadingSkeleton />
}
else if (!string.IsNullOrWhiteSpace(errorMessage))
{
    <ErrorBanner Message="@errorMessage" />
}
else
{
    <section class="customer-list">
        @foreach (var customer in customers)
        {
            <article>@customer.Name</article>
        }
    </section>
}

@code {
    private bool isLoading = true;
    private string? errorMessage;
    private List<CustomerModel> customers = [];

    protected override async Task OnInitializedAsync()
    {
        await LoadCustomersAsync();
    }

    private async Task LoadCustomersAsync()
    {
        // API call goes here later.
    }
}
```

## API Explanation Pattern

When we connect an API, explain it like this:

1. The page asks the service for data.
2. The service sends HTTP request to the backend.
3. The backend returns success or error.
4. The page stores the result in a field.
5. Razor re-renders the UI automatically.

Simple sentence:

> The page does not manually touch the DOM. It changes C# state, and Blazor updates the HTML.

## Agent Rules

Any agent working on this frontend must follow these rules:

1. Keep code junior-readable.
2. Explain new concepts step by step.
3. Do not add JavaScript unless clearly necessary.
4. Do not introduce a new frontend framework.
5. Follow `PRODUCT.md`, `DESIGN.md`, and `FRONTEND_BLUEPRINT.md`.
6. Prefer explicit simple code over clever abstractions.
7. Add only useful comments.
8. Keep UI premium and modern without making the code confusing.
9. When adding a screen, include static/fake-data mode first when possible.
10. Be ready to explain every file changed.

## Questions To Ask Before A New Screen

Before building a screen, ask:

1. Are we designing it static first or connecting API immediately?
2. Is this screen for manager, labor, or both?
3. What is the one main action?
4. What data do we need?
5. What should the empty state say?

## Current Learning Focus

The next learning focus is:

1. Blazor page/component structure
2. Razor basics
3. scoped CSS
4. layout and responsive design
5. fake data first
6. manual API connection later

Testing is intentionally paused for now.
