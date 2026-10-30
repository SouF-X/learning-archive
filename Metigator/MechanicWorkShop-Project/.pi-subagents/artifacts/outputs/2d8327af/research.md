# Research: Free-forever hosting for a Dockerized ASP.NET Core 9 + persistent SQL Server demo (2026)

## Summary
There is no credible no-cost managed *SQL Server engine* paired with a conventional free Docker host. The closest genuine ongoing zero-cost, no-provider-migration option is **Azure Container Apps (scale-to-zero) + Azure SQL Database Free Offer**: Azure SQL is a SQL Server–compatible PaaS database, free for the life of the subscription within its monthly quota, while Container Apps has recurring monthly grants. It is suitable only if traffic is sparse and overage behavior is explicitly set to pause.

For a simple hobby/demo deployment willing to move to PostgreSQL, **Render Free Web Service + Neon Free Postgres** is the easiest operational combination, but both layers cold-start (Render after 15 minutes; Neon after five). **Koyeb Free Web + Neon** avoids a documented Render-style app spin-down, but its 512 MB/0.1-vCPU web limit and required payment card make it less forgiving.

## Findings
1. **Keeping SQL Server: Azure is the only practical ongoing-free path found.** Azure SQL Database's Free Offer gives each database 100,000 serverless vCore-seconds, 32 GB data, and 32 GB backup *per month for the lifetime of the subscription*, up to ten databases. At the quota, it can be configured to auto-pause until the next month; selecting continued use permits billable overage. Azure Container Apps Consumption includes 180,000 vCPU-seconds, 360,000 GiB-seconds, and two million requests/month; replicas scale to zero by default, so a low-traffic demo can remain inside the grant. This is Azure SQL Database PaaS, not a customer-run SQL Server Docker container; test any SQL Server-specific features. [Azure SQL Free Offer](https://learn.microsoft.com/en-us/azure/azure-sql/database/free-offer?view=azuresql) · [Container Apps pricing](https://azure.microsoft.com/en-us/pricing/details/container-apps/)

2. **Do not try to put SQL Server in the free web container tiers.** SQL Server on Linux requires x64-compatible CPU, at least 2 GB RAM, 6 GB disk, and two cores; its container images are supported only on Intel/AMD x86-64. Render Free and Koyeb Free each provide just 512 MB RAM and 0.1 vCPU, so neither can host the SQL Server engine alongside (or instead of) the application. [SQL Server Linux requirements](https://learn.microsoft.com/en-us/sql/linux/install-upgrade/setup?view=sql-server-ver17) · [Render Free](https://render.com/docs/free) · [Koyeb pricing FAQ](https://www.koyeb.com/docs/faqs/pricing)

3. **Render is easy for a Docker demo but its own free database is not persistent forever.** Render supports Docker web services and managed TLS/custom domains. Free web services sleep after 15 idle minutes and take about a minute to return; they have 750 runtime hours/month and an ephemeral filesystem. Its free Postgres is only 1 GB and expires after 30 days (then is deleted after a 14-day upgrade grace period), so it fails the persistent/free-forever database requirement. [Render Free limits](https://render.com/docs/free) · [Render Docker](https://render.com/docs/docker)

4. **Neon is the strongest free-forever Postgres database complement for intermittent traffic.** Neon Free is $0/month with 100 CU-hours/project/month, 0.5 GB persistent storage, 5 GB monthly public egress, one manual snapshot, and six-hour restore history. It unavoidably suspends compute after five idle minutes; a request/query wakes it, and quota exhaustion suspends compute until the next billing period without deleting data. This is a good fit for a demo, not availability-sensitive production. [Neon plans and quotas](https://neon.com/docs/introduction/plans)

5. **Supabase Free is viable but worse for an infrequently visited demo.** It provides PostgreSQL, but automatically pauses low-activity projects after seven days. A paused project retains data/configuration only for a 90-day restoration window; its Free database quota is 500 MB (within 1 GB disk). A daily health/data request can prevent pausing, but that is an operational workaround rather than always available service. [Supabase project pausing](https://supabase.com/docs/guides/platform/free-project-pausing) · [Supabase database-size limits](https://supabase.com/docs/guides/platform/database-size)

6. **Koyeb is the best free app-host alternative when avoiding the Render app sleep is more important than capacity.** Its stated forever-free web service is one service in Frankfurt or Washington, DC with 512 MB RAM, 0.1 vCPU, and 2 GB SSD; Koyeb says it never charges for that instance. Public `koyeb.app` endpoints are TLS-encrypted. Its own free PostgreSQL allocation is only five hours of active time and 1 GB, so pair the web service with Neon rather than use Koyeb's database. Caveats: a credit card is required for Koyeb account validation, and the free service has very tight CPU/RAM; Koyeb does not document a forced idle timeout for the free instance in the cited limits, but it also disallows custom scaling configuration. [Koyeb pricing FAQ](https://www.koyeb.com/docs/faqs/pricing) · [Koyeb TLS](https://www.koyeb.com/docs/reference/edge-network)

### Comparison

| Combination | Docker app / public HTTPS | Persistent database and SQL Server availability | Free limits | Sleep / availability consequence | Verdict |
|---|---|---|---|---|---|
| **Azure Container Apps + Azure SQL Database Free** | Container Apps runs containers; configure public ingress. | **Azure SQL Database**, SQL Server-compatible managed PaaS; not a SQL Server container. | App: 180k vCPU-s, 360k GiB-s, 2M requests/month. DB: 100k vCore-s, 32 GB data + backups per DB/month. | App defaults to scale-to-zero. DB can auto-pause for the rest of the month at quota. | **Best/no migration**, but requires Azure subscription/billing safeguards and careful quota monitoring. |
| **Render Free Web + Neon Free** | Docker supported; `onrender.com` URL/TLS. | Neon PostgreSQL; must migrate provider/schema/data. | Render 512 MB/0.1 vCPU, 750 running hours/month; Neon 0.5 GB, 100 CU-h, 5 GB egress. | Render sleeps after 15 min (~1-min wake); Neon after 5 min. | **Recommended easiest PostgreSQL demo**; accept first-request latency. |
| **Koyeb Free Web + Neon Free** | Docker images supported; TLS `koyeb.app` URL. | Neon PostgreSQL; migration required. | Koyeb 512 MB/0.1 vCPU/2 GB SSD, one free service; Neon limits above. | No forced free-instance idle timeout is stated in Koyeb's cited limits; Neon sleeps after 5 min. | Use if Render's 15-min web sleep is unacceptable and app fits tiny compute. Card required. |
| **Render Free Web + Render Free Postgres** | Yes. | PostgreSQL only. | DB 1 GB. | DB expires at 30 days. | **Reject**: not persistent/free forever. |
| **Koyeb Free Web + Koyeb Free Postgres** | Yes. | PostgreSQL only. | DB 1 GB, only five active hours. | Active-time cap makes it unsuitable as an app database. | **Reject**. |
| **Any free web tier with self-hosted SQL Server** | Nominally Docker-capable. | SQL Server needs >=2 GB RAM, 6 GB disk, two x64 cores. | Render/Koyeb offer 512 MB/0.1 vCPU. | Would fail resource/support requirements. | **Reject**. |

## EF Core SQL Server → PostgreSQL practicality

For a conventional EF Core 9 monolith that mostly uses LINQ, normal relationships, migrations, and no handwritten T-SQL, this is a **moderate, bounded migration**, not a rewrite. Npgsql ships an EF Core provider, supports `UseNpgsql`, and documents EF 9 configuration. Replace `Microsoft.EntityFrameworkCore.SqlServer` with the matching-major `Npgsql.EntityFrameworkCore.PostgreSQL` provider, switch the configured provider/connection string, create PostgreSQL-specific migrations from the model, deploy the schema, and import/seed data. [Npgsql EF Core provider](https://www.npgsql.org/efcore/)

Do **not** apply existing SQL Server-generated migrations blindly: EF tooling scaffolds migrations for the active provider, and Microsoft documents maintaining separate migration sets when supporting more than one provider. For a one-way production/demo cutover, generate a clean PostgreSQL baseline and validate it against a copied dataset; for a codebase that must support both, retain provider-specific migration assemblies. [EF Core multiple providers](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/providers)

Review before committing to PostgreSQL:

- Raw SQL, stored procedures, SQL Server views/functions, `EF.Functions` SQL Server calls, `IDENTITY_INSERT`, `TOP`, brackets, and T-SQL date/string syntax.
- SQL Server-only column types/features (`uniqueidentifier`, `datetimeoffset`, `money`, `rowversion`, computed columns, filtered indexes, full-text/search, JSON SQL) and default SQL expressions. Map types intentionally (commonly GUID→`uuid`, binary concurrency token→`bytea`/provider-supported concurrency strategy, timestamps with a timezone policy).
- Identifier casing/quoted identifiers, case sensitivity/collation, sequence/identity behavior, decimal precision, and UTC `DateTime` semantics.
- Data conversion and validation: export/import is separate from EF migrations; run integration tests plus representative create/update/query flows against the hosted PostgreSQL service.

**Recommendation:**

1. **Lowest change/risk:** deploy the existing container to **Azure Container Apps** with **Azure SQL Database Free Offer**, configure Container Apps minimum replicas to zero, set the database's *Auto-pause when free limit reached* behavior, set free-amount alerts, and do not enable billable continuation. This is the only researched combination retaining the SQL Server provider/database family at ongoing zero cost within documented quotas.
2. **Simplest hobby hosting after accepting a provider migration:** use **Render + Neon**. Render is straightforward for a Dockerfile and HTTPS; Neon is explicitly $0/month and preserves storage without Render's 30-day database expiry. Expect a cold first request because both components suspend.
3. Choose **Koyeb + Neon** only after testing the monolith under 512 MB/0.1 vCPU. It can improve app wake behavior, but capacity and card-validation friction make it a less universally easy default.

## Sources
- **Kept:** [Azure SQL Database Free Offer](https://learn.microsoft.com/en-us/azure/azure-sql/database/free-offer?view=azuresql) — primary lifetime quota, pause, and overage behavior.
- **Kept:** [Azure Container Apps pricing](https://azure.microsoft.com/en-us/pricing/details/container-apps/) — primary recurring grants and scale-to-zero billing behavior.
- **Kept:** [Render Free limits](https://render.com/docs/free) — primary sleep, 750-hour, TLS support, and 30-day database expiration evidence.
- **Kept:** [Neon plans](https://neon.com/docs/introduction/plans) — primary $0 price, quotas, scale-to-zero, and quota suspension behavior.
- **Kept:** [Koyeb pricing FAQ](https://www.koyeb.com/docs/faqs/pricing) and [TLS docs](https://www.koyeb.com/docs/reference/edge-network) — free service limits, card requirement, and HTTPS endpoint.
- **Kept:** [Supabase project pausing](https://supabase.com/docs/guides/platform/free-project-pausing) — primary seven-day inactivity pause and 90-day restore window.
- **Kept:** [SQL Server on Linux requirements](https://learn.microsoft.com/en-us/sql/linux/install-upgrade/setup?view=sql-server-ver17) — primary architecture/resource constraints for self-hosting SQL Server.
- **Kept:** [Npgsql EF Core provider](https://www.npgsql.org/efcore/) and [EF Core multiple providers](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/providers) — primary migration/provider guidance.
- **Dropped:** Oracle Always Free documentation — offers useful always-free VMs, but it does not provide an equally simple managed SQL Server solution; evaluating self-hosted SQL Server would still require satisfying the documented x64/2-GB/two-core minimum and operational administration.
- **Dropped:** Railway/Fly.io/blog comparison pages — no stronger primary evidence of a free-forever Docker + persistent SQL Server solution than the options above.

## Gaps
- “Free forever” is a provider policy, not a contractual SLA; plans and anti-abuse rules can change. Recheck pricing immediately before deployment.
- Azure Container Apps public ingress/HTTPS configuration was not independently reproduced here; verify the current portal/CLI defaults and region availability during implementation.
- Exact EF migration effort depends on this repository's migrations, raw SQL, provider-specific types, and data size; no codebase inspection or trial migration was requested/performed.
- Azure SQL Database is highly SQL Server-compatible but is not a full boxed SQL Server instance; test SQL Agent, cross-database access, server-level features, and any vendor-specific T-SQL used by the monolith.

```acceptance-report
{
  "criteriaSatisfied": [
    {
      "id": "criterion-1",
      "status": "satisfied",
      "evidence": "Produced the requested focused hosting and EF Core migration research only; no application code or configuration was changed."
    }
  ],
  "changedFiles": [
    ".pi-subagents/artifacts/outputs/2d8327af/research.md"
  ],
  "testsAddedOrUpdated": [],
  "commandsRun": [],
  "validationOutput": [
    "Reviewed primary provider documentation for Azure, Render, Neon, Koyeb, Supabase, Microsoft SQL Server, EF Core, and Npgsql.",
    "Research artifact written to the authoritative requested path."
  ],
  "residualRisks": [
    "Free-plan policies, quotas, regions, and anti-abuse enforcement can change.",
    "Azure charges are possible if billable-overage behavior is enabled or other billable Azure resources are created.",
    "PostgreSQL migration compatibility must be validated against the actual model, migrations, raw SQL, and data."
  ],
  "noStagedFiles": true,
  "diffSummary": "Added one research artifact; no product code changes.",
  "reviewFindings": [
    "No blockers for the requested research-only scope."
  ],
  "manualNotes": "No tests were appropriate because this task requested research only."
}
```