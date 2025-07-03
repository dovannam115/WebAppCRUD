Below is an updated **Model-Driven CRUD App** specification that strips out charts/dashboards and focuses solely on metadata-driven CRUD (Create, Read, Update, Delete)—just like a Power Apps model-driven app, but running locally in ASP .NET Core.

---

## 1. Purpose

Build a “Control Center” web app on `https://localhost:8080` that:

* Dynamically scaffolds **list views** and **forms** from metadata
* Provides out-of-the-box **CRUD** operations
* Enforces **business rules** (required fields, conditional visibility)
* Uses **Azure AD SSO** for authentication and **role-based security**

---

## 2. Goals & Scope

| Goal                          | In-Scope                                            | Out-of-Scope                |
| ----------------------------- | --------------------------------------------------- | --------------------------- |
| Metadata-driven CRUD UI       | Razor Pages (or Blazor) auto-generated grids/forms  | Reports, Charts, Dashboards |
| Consistent UX across entities | Paging, sorting, filtering, search, export          | Mobile/offline support      |
| Enforce business logic        | Required fields, conditional show/hide, simple calc | Complex workflows/flows     |

---

## 3. Functional Requirements

### 3.1 Metadata-Driven Data Model

* **Metadata tables**:

  * `App_Entity` (logical name, display name)
  * `App_Field` (type, label, required, visibility rule, lookup target)
  * `App_View` (which fields show in the list + default sort)
  * `App_Form` (tabs/sections + field order)
* **Core entities** (e.g. `Customer`, `Order`, `Issue`) each map to an `App_Entity`.
* All tables have a **GUID** PK + audit fields (`CreatedOn`, `CreatedBy`, `ModifiedOn`, `ModifiedBy`).

### 3.2 List Views (Grid)

* For each entity, render a **grid** based on its `App_View` metadata.
* Features:

  * **Server-side paging**, **sorting**, **filtering**
  * **Quick search** across text fields
  * **Export to CSV/Excel**
* **Command bar** above the grid with buttons:

  * **New** → opens Create Form
  * **Edit** → opens Edit Form for selected row
  * **Delete** → deletes selected row(s) with confirmation

### 3.3 Forms (Create / Edit)

* Auto-rendered from `App_Form` metadata: sections, fields, labels.
* Field types supported: text, number, date/time, boolean, option-set, lookup (drop-down).
* **Validation**:

  * **Required** fields
  * **Data type** enforcement (e.g. numeric ranges)
  * **Custom regex** or simple client/server rules
* **Submission** posts back to a generic CRUD endpoint that uses EF Core to persist changes.

### 3.4 Business Rules & Calculations

* **Conditional visibility**: show/hide fields based on other field values (e.g. only show “Reason” if Status = “Rejected”).
* **Calculated fields**: simple server-side formulas (e.g. `Total = Quantity * UnitPrice`) evaluated on save.
* **Error messages** surfaced inline on the form.

### 3.5 Command Bar & Custom Actions

* Beyond CRUD, support metadata-defined **actions** (e.g. “Approve”, “Close Issue”).
* Actions appear as buttons on the form or grid toolbar and invoke a custom server endpoint.

### 3.6 Security & Roles

* **Azure AD SSO** (OIDC via Microsoft.Identity.Web) for authentication.
* **Role-based access** defined in `App_SecurityRole` + `App_UserRole`:

  * **Entity-level**: who can view/create/edit/delete each entity
  * **Field-level**: read-only vs editable per role
* Unauthorized users redirected to login or “Access Denied” page.

---

## 4. Non-Functional Requirements

| Category     | Requirement                                           |
| ------------ | ----------------------------------------------------- |
| Performance  | List views render ≤ 1 s for 5 k records (with paging) |
| Scalability  | Support \~20 concurrent users                         |
| Maintainable | All UI driven by metadata—minimal hand-coding         |
| Secure       | HTTPS enforced, Azure AD for auth                     |
| Responsive   | Mobile-friendly layouts                               |

---

## 5. Technical Architecture

```
Browser
  │
  └──> ASP .NET Core (Razor Pages / Blazor)
         ├── Metadata APIs  ← App_Entity/etc.
         ├── CRUD APIs      ← generic controllers
         └── EF Core        ← SQL Server
```

* **UI layer** reads metadata, builds grid/forms dynamically.
* **API layer** exposes generic endpoints (`/api/{entity}`) for CRUD.
* **ORM**: EF Core code-first with migrations.
* **Auth**: Microsoft.Identity.Web for Azure AD OIDC.

---

## 6. Deployment & Environment

* **Local dev**: Kestrel on `https://localhost:8080`
* **Database**: Local SQL Server (Express or dev)
* **Secrets**: store Azure AD client secret & DB connection in user-secrets
* **Startup**: one `Program.cs` + generic CRUD controllers + metadata seed

---

## 7. Acceptance Criteria

1. **CRUD list view**: you can list, sort, filter and export records for any entity defined in metadata.
2. **CRUD form**: you can create, edit and delete records; required/visibility rules enforced.
3. **Security**:

   * Anonymous users redirected to Azure AD sign-in.
   * Users in “Reader” role cannot see “New/Edit/Delete” buttons.
4. **Metadata update**: adding a new field or view column in metadata makes it appear in the UI after app restart—no code changes.
5. **Logout**: clicking the logout icon signs the user out of the app and Azure AD.

---

This trimmed-down spec should guide you to build a pure-CRUD, metadata-driven “Control Center” in ASP .NET Core that behaves just like a Power Apps model-driven app.
