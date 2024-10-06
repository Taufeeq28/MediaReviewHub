# Media Review Hub

Media Review Hub is a simple web application designed to allow users to review and track various forms of media (e.g., movies, books, games, etc.). This project demonstrates proficiency in C#, ASP.NET Core Razor Pages, PostgreSQL, and basic web development skills. The project also features personal reviews to showcase media preferences.

## Table of Contents
1. [Project Structure](#project-structure)
2. [Technology Stack](#technology-stack)
3. [Application Features](#application-features)
4. [Setup and Installation](#setup-and-installation)
5. [Database Schema](#database-schema)
6. [Assumptions and Design Decisions](#assumptions-and-design-decisions)
7. [Personal Reviews](#personal-reviews)

---

## Project Structure

The solution is organized into the following projects:

MediaReviewHub/
│
├── MediaReviewHub.DataAccess/
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   ├── Migrations/
│   │   ├── 20241003181932_addReviewsToDb.cs
│   │   ├── 20241003185320_SeedReviewsToDb.cs
│   │   └── ApplicationDbContextModelSnapshot.cs
│   ├── Repository/
│       ├── IRepository/
│       │   ├── IRepository.cs
│       │   ├── IReviewRepository.cs
│       │   └── IUnitOfWork.cs
│       ├── Repository.cs
│       ├── ReviewRepository.cs
│       └── UnitOfWork.cs
│
├── MediaReviewHub.Models/
│   ├── Review.cs
│
└── MediaReviewHubWeb/
    ├── wwwroot/
    │   ├── css/
    │   ├── images/
    │   └── js/
    ├── Pages/
    │   ├── Reviews/
    │   │   ├── CreateReview.cshtml
    │   │   ├── Delete.cshtml
    │   │   ├── Edit.cshtml
    │   │   ├── Index.cshtml
    │   ├── Shared/
    │   ├── Error.cshtml
    │   └── Index.cshtml
    ├── appsettings.json
    └── Program.cs

### Key Files and Their Purpose:
- **ApplicationDbContext.cs**: Handles the connection to the PostgreSQL database and defines the `DbSet<Review>` to interact with the `Reviews` table.
- **Review.cs**: The model representing a review entity with properties such as `Title`, `Category`, `ReviewText`, `Rating`, and `DateReviewed`.
- **Repository Pattern**: Follows a clean separation of concerns with interfaces and implementations for the review repository and unit of work.
- **Razor Pages**: Contains Razor Pages (Views) for CRUD operations on reviews. Pages like `CreateReview.cshtml`, `Edit.cshtml`, and `Index.cshtml` provide user interaction.
- **wwwroot**: Contains static assets like CSS files and images used in the application.

---

## Technology Stack

The project utilizes the following technologies:

- **Language**: C# with .NET 8
- **Framework**: ASP.NET Core Razor Pages
- **Database**: PostgreSQL with Entity Framework Core (EFC) as the ORM
- **Front-end**: Razor Pages with HTML and CSS for UI
- **Version Control**: GitHub for source code management

---

## Application Features

1. **Home Page**: 
   - Displays a welcome message and includes navigation links to view, add, and manage reviews.
   
2. **View Reviews**:
   - Displays a list of all reviews with details like title, category, review text, rating, and date reviewed.
   - Allows filtering and sorting by category or rating.
   - Implements pagination to manage large lists of reviews.

3. **Add Review**:
   - Form to create a new review with fields for title, category, review text, rating, and date.
   
4. **Edit Review**:
   - Allows users to update existing reviews.

5. **Delete Review**:
   - Provides an option to delete a review with a confirmation prompt for the user.

6. **User Interface**:
   - Basic and clean UI implemented using HTML and CSS. Focuses on ease of navigation and simplicity.

---

## Setup and Installation

### Prerequisites:
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)

### Steps to Run Locally:

1. **Clone the Repository**:
    ```
    git clone https://github.com/YourUsername/MediaReviewHub.git
    cd MediaReviewHub
    ```

2. **Database Setup**:
    - Ensure PostgreSQL is installed and running locally.
    - Update the connection string in the `appsettings.json` file located in the `MediaReviewHubWeb` project.
      ```json
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Database=MediaReviewHub;Username=your_username;Password=your_password"
      }
      ```
      then select the solution file i.e MediaReviewHub.sln and run build

3. **Apply Migrations**:
    Run the following commands to apply database migrations:
    Go to package manager console and select MediaReviewHub.DataAccess as Default project 
    ```Package manager console
    add-migration addReviewToDb
    update-database
    ```

5. **Run the Application**:
    
6. **Database Seed**:
    The application seeds some initial review data using migrations.

---

## Database Schema

**Reviews Table**:
- `ReviewID` (Primary Key) - Auto-increment integer.
- `Title` (string) - Title of the media being reviewed.
- `Category` (string) - Category of media (e.g., Movie, Book, Game).
- `ReviewText` (text) - Detailed review of the media.
- `Rating` (integer) - A rating out of 5.
- `DateReviewed` (date) - The date the media was reviewed.

---

## Assumptions and Design Decisions

- **Repository Pattern**: Used to abstract data access, allowing the code to be more maintainable and testable.
- **EF Core**: Chosen as the ORM for ease of integration with PostgreSQL and to streamline database interactions.
- **Basic HTML/CSS**: The UI focuses on simplicity and clarity, as the primary goal is to demonstrate back-end and data-handling capabilities.
- **Data Seeding**: Initial reviews are seeded to the database through migrations for demonstration purposes.
- **DataTables for Filtering and Sorting**: We have implemented **DataTables** in the front-end to dynamically filter reviews based on selected categories using checkboxes. The filtered data updates in real-time, improving the user experience.

---



