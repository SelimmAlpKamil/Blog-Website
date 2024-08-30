Here is the README in English with the screenshots section included:

---

# Blog Website

## Project Description

This project is a blog website application that allows users to create, edit, and delete blog posts, as well as add comments to blog posts. It also provides a comprehensive user interface for viewing and managing blog posts and comments.

## Features

- **User Management:** Users can register, log in, and update their profile information.
- **Blog Posts:** Users can create new blog posts, edit existing posts, or delete posts.
- **Comments:** Users can add comments to blog posts and view existing comments.
- **Role-Based Authorization:** Users can log in with different roles, and authorization is applied based on these roles.
- **Error Handling:** Dynamic error messages and user-friendly error pages are provided.

## Technologies Used

- **.NET Core 5:** Used as the web application development platform.
- **Entity Framework Core:** Used for database operations and data access.
- **FluentValidation:** Used for form validation.
- **Razor Pages:** Used for creating dynamic content and user interface components.
- **SQL Server:** Used for database management.
- **Bootstrap:** Used for styling and design of the web application.


## Screenshots

Below are screenshots of various features of the project:

### Home Page

![Home Page](screenshots/homepage.png)

### Blog Posts List

![Blog Posts List](screenshots/blog-list.png)

### Blog Post Details

![Blog Post Details](screenshots/blog-details.png)

### Add Comment

![Add Comment](screenshots/add-comment.png)

## Installation and Setup

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/SelimmAlpKamil/Blog-Website.git
   ```

2. **Install Required Packages:**

   Navigate to the project directory and install the necessary NuGet packages:

   ```bash
   dotnet restore
   ```

3. **Initialize the Database:**

   Apply database migrations by running:

   ```bash
   dotnet ef database update
   ```

4. **Run the Application:**

   Start the application with:

   ```bash
   dotnet run
   ```

   You can view the application in your web browser at `http://localhost:5000`.




---

Feel free to adjust the content as needed or add more details specific to your project!
