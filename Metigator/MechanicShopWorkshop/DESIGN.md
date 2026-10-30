---
name: MechanicShop
description: Premium workshop management dashboard for admins and employees.
colors:
  primary: "#155E63"
  primary-deep: "#0B383C"
  accent: "#D99A2B"
  danger: "#B42318"
  success: "#287A4B"
  warning: "#B76E00"
  info: "#2563A8"
  ink: "#172023"
  muted-ink: "#526064"
  canvas: "#F5F7F8"
  surface: "#FFFFFF"
  surface-raised: "#EEF3F4"
  border: "#D8E0E2"
typography:
  display:
    fontFamily: "Inter, Segoe UI, system-ui, sans-serif"
    fontSize: "2.25rem"
    fontWeight: 700
    lineHeight: 1.12
    letterSpacing: "0"
  headline:
    fontFamily: "Inter, Segoe UI, system-ui, sans-serif"
    fontSize: "1.5rem"
    fontWeight: 700
    lineHeight: 1.2
    letterSpacing: "0"
  title:
    fontFamily: "Inter, Segoe UI, system-ui, sans-serif"
    fontSize: "1.125rem"
    fontWeight: 650
    lineHeight: 1.3
    letterSpacing: "0"
  body:
    fontFamily: "Inter, Segoe UI, system-ui, sans-serif"
    fontSize: "1rem"
    fontWeight: 400
    lineHeight: 1.55
    letterSpacing: "0"
  label:
    fontFamily: "Inter, Segoe UI, system-ui, sans-serif"
    fontSize: "0.875rem"
    fontWeight: 600
    lineHeight: 1.25
    letterSpacing: "0"
rounded:
  sm: "4px"
  md: "6px"
  lg: "8px"
spacing:
  xs: "4px"
  sm: "8px"
  md: "16px"
  lg: "24px"
  xl: "32px"
components:
  button-primary:
    backgroundColor: "{colors.primary}"
    textColor: "{colors.surface}"
    rounded: "{rounded.md}"
    padding: "10px 16px"
  button-secondary:
    backgroundColor: "{colors.surface}"
    textColor: "{colors.ink}"
    rounded: "{rounded.md}"
    padding: "10px 16px"
  input-default:
    backgroundColor: "{colors.surface}"
    textColor: "{colors.ink}"
    rounded: "{rounded.md}"
    padding: "10px 12px"
---

# Design System: MechanicShop

## 1. Overview

**Creative North Star: "The Workshop Command Center"**

MechanicShop should feel like a premium operational dashboard for a real workshop: calm enough for daily use, sharp enough to demo confidently, and practical enough that admins and employees can move through work without hesitation. The visual direction blends clean professional structure, modern product UI, and a restrained garage-tech character.

This is a product interface, not a marketing site. It should avoid cheap default Bootstrap styling, childish visuals, excessive colors, overly dark screens, noisy gradients, complicated layouts, and decorative animation. The interface earns its premium feeling through spacing, hierarchy, component consistency, and clear state design.

**Key Characteristics:**
- Dense but readable screens for real workshop work.
- Restrained color with a mechanical teal primary and amber operational accent.
- Strong tables, forms, schedules, and status indicators.
- Functional motion only: feedback, loading, state changes.
- Consistent admin and employee UI vocabulary.

## 2. Colors

The palette is restrained and professional, with deep mechanical teal as the main identity color and amber as a limited operational accent.

### Primary
- **Mechanical Teal**: The primary action, active navigation, selected states, and key focus color.
- **Deep Bay Teal**: Used for sidebar depth, high-emphasis headers, and hover states where stronger contrast is needed.

### Secondary
- **Workshop Amber**: Used sparingly for schedule attention, pending work, warnings, highlights, and small operational cues. It should never dominate an entire screen.

### Tertiary
- **Service Blue**: Used for informational states, links, and neutral workflow guidance.
- **Repair Green**: Used for success, completion, active status, and positive state changes.
- **Fault Red**: Used only for destructive actions, errors, blocked states, and inactive status.

### Neutral
- **Graphite Ink**: Main text and high-contrast UI labels.
- **Muted Steel Ink**: Secondary text, helper labels, timestamps, and low-emphasis metadata.
- **Clean Workshop Canvas**: Main page background.
- **Lifted White Surface**: Cards, panels, forms, and tables.
- **Cool Raised Surface**: Sidebars, toolbar strips, table headers, and grouped controls.
- **Fine Steel Border**: Dividers, input borders, table lines, and subtle separation.

### Named Rules

**The Ten Percent Accent Rule.** Amber is an accent, not decoration. It should stay below roughly 10% of any screen.

**The State Color Rule.** Red, green, amber, and blue are reserved for meaning. Do not use them as random decoration.

## 3. Typography

**Display Font:** Inter, Segoe UI, system-ui, sans-serif  
**Body Font:** Inter, Segoe UI, system-ui, sans-serif  
**Label/Mono Font:** Use the same family unless code, invoice references, or technical IDs require a monospace style.

**Character:** The type should feel modern, direct, and work-focused. This system does not need decorative fonts; it needs clean hierarchy and reliable scanning.

### Hierarchy
- **Display** (700, 2.25rem, 1.12): Main dashboard or page-level titles only.
- **Headline** (700, 1.5rem, 1.2): Section headers and major panel titles.
- **Title** (650, 1.125rem, 1.3): Card titles, form groups, table toolbars, and modal headings.
- **Body** (400, 1rem, 1.55): Normal text, descriptions, empty states, and form help.
- **Label** (600, 0.875rem, 1.25): Field labels, table column labels, chips, tabs, buttons, and metadata.

### Named Rules

**The No Shouting Rule.** Product screens should not use giant landing-page type. Keep headings compact and useful.

## 4. Elevation

MechanicShop uses tonal layering first and shadows second. Panels and cards should feel placed on a clear work surface, but not float like marketing cards. Depth comes from background changes, borders, and small state shadows.

### Shadow Vocabulary
- **Resting Surface** (`0 1px 2px rgba(15, 23, 42, 0.06)`): Subtle card or panel separation.
- **Interactive Hover** (`0 8px 20px rgba(15, 23, 42, 0.10)`): Used only when a surface is clickable.
- **Modal Lift** (`0 20px 48px rgba(15, 23, 42, 0.18)`): Dialogs, popovers, and high-priority overlays.

### Named Rules

**The Flat By Default Rule.** Surfaces are mostly flat at rest. Shadows appear when they clarify interaction or hierarchy.

## 5. Components

### Buttons
- **Shape:** Gently squared product controls (6px radius).
- **Primary:** Mechanical Teal background with white text, used for the main action on a screen.
- **Hover / Focus:** Darken the background slightly and show a clear focus ring. Do not use glow effects.
- **Secondary / Ghost:** White or transparent background with Fine Steel Border and Graphite Ink text.

### Chips
- **Style:** Compact rounded labels for role, status, schedule state, invoice state, and work order state.
- **State:** Each chip color must map to meaning: green for completed/active, amber for pending/scheduled, blue for information, red for blocked/inactive/error.

### Cards / Containers
- **Corner Style:** 8px maximum radius.
- **Background:** Lifted White Surface on Clean Workshop Canvas.
- **Shadow Strategy:** Resting Surface only by default.
- **Border:** Fine Steel Border when the panel contains forms, tables, or dense data.
- **Internal Padding:** 16px for compact panels, 24px for major sections.

### Inputs / Fields
- **Style:** White background, Fine Steel Border, 6px radius, compact padding.
- **Focus:** Mechanical Teal border and visible focus ring.
- **Error / Disabled:** Fault Red for validation, muted raised surface for disabled controls.

### Navigation
- **Style:** Sidebar or top navigation should use Deep Bay Teal or Cool Raised Surface, with strong active states and simple icons.
- **Typography:** Labels use the Label role, never display typography.
- **Mobile Treatment:** Collapse navigation into a predictable menu, not hidden custom gestures.

### Schedule Board
- **Style:** Time slots, labor assignments, and work order states need strong scanning. Use restrained grid lines, status chips, and clear empty slots.
- **Interaction:** Hover and selected states should be visible but quiet. Avoid blur effects that make operational data hard to read.

## 6. Do's and Don'ts

### Do:
- **Do** design screens as working tools first: dashboard, forms, schedules, tables, and details pages.
- **Do** keep actions, filters, and statuses visually consistent across modules.
- **Do** use the Mechanical Teal primary color for important actions and selected navigation.
- **Do** use amber, red, green, and blue only when they communicate real state.
- **Do** keep cards at 8px radius or less.
- **Do** provide visible loading, empty, error, disabled, hover, and focus states.

### Don't:
- **Don't** create a cheap default Bootstrap look.
- **Don't** make the app too colorful, childish, overly dark, or complicated.
- **Don't** use noisy gradients, glassmorphism, gradient text, or decorative motion.
- **Don't** build identical card grids as the main pattern for every page.
- **Don't** use modal dialogs as the first answer for every workflow.
- **Don't** use large landing-page hero typography inside dashboards or forms.
