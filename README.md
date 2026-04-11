# FEAA-SAD — Winery Management Application

A Windows Forms desktop application for managing and analyzing winery sales data. It connects to an Oracle database and provides data browsing, interactive analytics charts, wine recommendations, and synthetic data generation.

## Table of Contents

- [Tech Stack](#tech-stack)
- [Architecture](#architecture)
- [Database Schema](#database-schema)
- [Features](#features)
  - [Database Overview](#database-overview)
  - [Sales Graphs](#sales-graphs)
  - [Client Analysis Graphs](#client-analysis-graphs)
  - [Wine Catalog & Variety Charts](#wine-catalog--variety-charts)
  - [Data Generator](#data-generator)
- [Prerequisites](#prerequisites)
- [Setup](#setup)

---

## Tech Stack

| Component | Technology |
|---|---|
| Language / Framework | C# / .NET 4.8, Windows Forms |
| Database | Oracle (via `Oracle.ManagedDataAccess`) |
| Charts | OxyPlot 2.1 (`OxyPlot.Core`, `OxyPlot.WindowsForms`) |
| Excel Export | `Microsoft.Office.Interop.Excel` |
| ORM | Entity Framework 6 |
| Data Generation | `RandomNameGeneratorLibrary` |

---

## Architecture

The application follows the **Model-View-Presenter (MVP)** pattern:

- **Models** (`Winery/Models/`) — Plain C# objects representing domain entities (`Wine`, `Winery`, `SoldWines`, `WineCountry`, etc.).
- **Views** (`Winery/Views/`) — Windows Forms `UserControl` panels and forms for each section of the UI.
- **Presenters** (`Winery/Presenters/`) — `MainFormPresenter` coordinates navigation between views.
- **Helper** (`Winery/Helper/`) — `DatabaseCommandHelper` executes all database queries; `ExportToExcelHelper` handles Excel exports; `WinformsHelper` and `RandomGenerator` provide utilities.

Navigation is handled through the main form (`MainForm`), which swaps `UserControl` panels based on the top navigation buttons.

---

## Database Schema

Four tables store all application data:

```sql
COUNTRY_INFO  (id PK, name)

WINES         (id PK, name, price, country_id FK→COUNTRY_INFO, variety, winery)

CLIENTS       (id PK, name, country_id FK→COUNTRY_INFO, date_of_birth, sex)

SOLD_WINES    (id PK, id_wine FK→WINES, id_client FK→CLIENTS, quantity, sale_date)
```

The DDL script and sample CSV data files are in `Winery/DataBaseQuery/`.

---

## Features

### Database Overview

A tabbed data-grid view of each table in the database. Switching tabs loads the corresponding data on demand.

| Tab | Table | Filter fields |
|---|---|---|
| 1 — Wines | `WINES` | id, name, price range, country id, variety, winery |
| 2 — Clients | `CLIENTS` | id, name, country id |
| 3 — Sold Wines | `SOLD_WINES` | id, wine id, client id, quantity |
| 4 — Countries | `COUNTRY_INFO` | id, name |
| 5 — All Data | Merged join view | client name, date of birth, wine name, variety, country, price range |

The **Wines** tab also includes an **Export to Excel** button that saves the current (filtered) grid to an `.xlsx` file.

---

### Sales Graphs

Three chart types for analyzing winery sales over time. Each chart supports filtering by winery (checkbox list) and a custom date range, and can be exported to Excel.

| Chart | Type | Description |
|---|---|---|
| Daily Sales | Line chart | Revenue per day per winery; annotates the peak and lowest-sales days with colored horizontal lines |
| Weekly Sales | Bar chart | Revenue aggregated by ISO week per winery |
| Sales Share | Pie chart | Total revenue share over the selected period per winery |

A **Sold Wines Export** button on the Daily Sales tab opens a dialog for a detailed data export.

---

### Client Analysis Graphs

Three analytics views focused on client behaviour.

| View | Description |
|---|---|
| Expenses by Age | Line chart comparing average spending by age for male vs. female clients, with an automatic marketing recommendation for the least-engaged age group |
| Wine Recommendations | Given a selected wine, shows up to 9 wines of the **same variety** and up to 9 wines **also bought** by clients who bought the selected wine |
| Wine Popularity | Bar chart of the top-30 wines sold to clients of a chosen **age** and **gender** |

---

### Wine Catalog & Variety Charts

| View | Description |
|---|---|
| Wine Tree | Hierarchical tree view organised by Country → Winery → Variety → Wine. Clicking a leaf node displays a wine detail card |
| Variety by Age | Line chart showing quantities sold per wine variety across age groups, with peak/low annotations |

---

### Data Generator

Generates synthetic clients and their purchase histories directly into the database for testing and demo purposes.

**Configurable parameters:**

- Client birth-date range, gender, and country
- Wine price range and name filter (restricts which wines can be assigned)
- Total expenses range (budget per generated client)
- Maximum quantity per sale
- Sale date range
- Number of records to generate

Two generation modes are available:

- **Generate Clients** — creates new client records and their associated sales.
- **Generate Sales Only** — creates new sales for existing clients that match the specified birth-date range.

---

## Prerequisites

- Windows OS
- Visual Studio 2019 or later
- .NET Framework 4.8
- Access to an Oracle database instance
- Microsoft Excel (for Excel export functionality)

---

## Setup

1. **Clone the repository**
   ```
   git clone https://github.com/StefanStafie/FEAA-SAD.git
   ```

2. **Create the database schema** using the DDL script:
   ```
   Winery/DataBaseQuery/Create DB query.txt
   ```

3. **Populate initial data** (optional) using the CSV files in `Winery/DataBaseQuery/`:
   - `COUNTRY_INFO.csv`
   - `WINES.csv`
   - `CLIENTS.csv`
   - `SOLD_WINES.csv`

4. **Configure the connection string** in `Winery/App.config` to point to your Oracle instance.

5. **Restore NuGet packages** and build the solution in Visual Studio:
   ```
   Winery/Winery.sln
   ```

6. Run the application. On first launch a loading form will appear while the initial data is fetched from the database.

