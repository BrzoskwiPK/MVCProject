# Library Management System

Library Management System is a final project created for the "Programowanie w ASP.NET" course.

### Technology Stack

- **ASP.NET Core 6.0**

# Navigation

1. [Getting Started](#getting-started)

- [Prerequisites](#prerequisites)
- [How to ...?](#how-to)
  - [Dependencies](#dependencies)
  - [How to run application](#how-to-run-application)
  - [How to run tests](#how-to-run-tests)
  - [How to access swagger](#how-to-access-swagger)
  - [Connection string](#connection-string)
  
2. [FAQ](#faq)

1. [DEFINITIONS](#definitions)

- [What is this app?](#what-is-this-app)
- [Site access](#site-access)
- [Contributors](#contributors)

2. [FEATURES](#features)

- [Authentication](#authentication)
- [Displaying personal information](#displaying-personal-information)
- [Displaying a list of books](#displaying-a-list-of-books)
- [Adding a book](#adding-a-book)
- [Editing a book](#editing-a-book)
- [Displaying details of a particular book](#displaying-details-of-a-particular-book)
- [Deleting a book](#deleting-a-book)
- [Pagination](#pagination)

## Getting started

### Prerequisites

### How to

1. #### Dependencies

- Microsoft SQL Server 
- Visual Studio

2. #### How to run application

In order to run this application, we need to have the project downloaded.

- Clone this repository via GIT or just download a zip with the content.
- Open the project in Visual Studio.
- On the top of the application, click the green arrow or just simply click **Ctrl + F5**.

3. #### How to run tests

After loading the project into the Visual Studio, please go to the **Test** tab and choose **Run all tests** or just simply click **Ctrl + R, Ctrl + A**.<br>
Test suites should be loaded and after a few seconds result will be displayed.

4. #### How to seed the data into the database

In order to seed the entities data into the database, you have to create a migration.<br>
Move into the project directory and use below commands:

`
dotnet tool install --global dotnet-ef<br>
dotnet add package Microsoft.EntityFrameworkCore.Design<br>
dotnet ef migrations add CompleteMigration<br>
dotnet ef database update<br>
`

It should create a migration, which has to be applied to the database with usage of the last command.

Now it's the time to seed the user + roles related data into the database.<br>YOU NEED TO DO THIS, IF YOU WANT TO TRY ACCOUNT WITH ELEVATED PRIVILEGES!

Please, use this command:

> dotnet run seed

Script should load two test users to the database.<br>One of them has elevated privileges (librarian) and one is just a standard user (student).<br>
Here you can find credentials:

`
- ADMIN:
- Login: librarian@gmail.com
- Password: librarian123
` 

`
- STUDENT:
- Login: student@gmail.com
- Password: student123
`

5. #### How to access Swagger

If we have our application loaded, we can access the Swagger, where we can try our REST API.<br>
In order to get there, we have to visit this link: **https://localhost:7085/swagger/index.html**.

Here, how it looks like:

![swagger](https://user-images.githubusercontent.com/101000424/213552894-33307395-4899-4fe5-89ed-5984b1d8ec29.png)

6. #### Connection string

Application uses Microsoft SQL Server.<br> We can adjust the connection string that is located in the *appsetings.json* file.<br>
By default, it looks like this:

`
"ConnectionStrings": {
    "LibraryDatabase": "Server=(localdb)\\MSSQLLocalDB;Database=LibraryDatabase;Trusted_Connection=True;MultipleActiveResultSets=True"
},
`

## FAQ

If you have some more questions, you may find an answer in the following topics.

1. [DEFINITIONS](#definitions)

- [What is this app?](#what-is-this-app)
- [Site access](#site-access)
- [Contributors](#contributors)

2. [FEATURES](#features)

- [Authentication](#authentication)
- [Displaying personal information](#displaying-personal-information)
- [Displaying a list of books](#displaying-a-list-of-books)
- [Adding a book](#adding-a-book)
- [Editing a book](#editing-a-book)
- [Displaying details of a particular book](#displaying-details-of-a-particular-book)
- [Deleting a book](#deleting-a-book)
- [Pagination](#pagination)

### Definitions

#### What is this app?

This is a standard library management system, where authenticated user is moved to its own dashboard, on which he can perform many actions.
There are two types of users with the access to the dashboard on this platform:
  - a normal user (student)
  - user with elevated privileges (librarian)

#### Site access

1. Unauthorized guest is only allowed to view the main page, on which he can either login or register.
2. Authorized user (student) has privileges to view dashboard, where he can display personal information, view collection of books.
3. Authorized admin (librarian) is able to perform basic CRUD operations with books on the dashboard.

#### Contributor

- [Gabriel Brzoskwinia](https://github.com/BrzoskwiPK)

### Features

#### Authentication

Once user starts the application, he'll be able to see a main page, where he can authenticate to see the content.
User goes through a form with a validation, and if he provides correct credentials -> he will get access to the service.

![mainPage](https://user-images.githubusercontent.com/101000424/212485901-100e0fd4-23b7-4792-ad18-2ad6aaeb1105.png)

1. Register

Here we can create a standard account. There is only one admin in the database and we can't create another one.

![registerPage](https://user-images.githubusercontent.com/101000424/212485556-6747136c-5ba1-435e-a1bf-56dc3e9aef42.png)

2. Login

Here we can login into the system. 

![loginPage](https://user-images.githubusercontent.com/101000424/212485731-0c0ad519-86b7-40fd-b048-d8aa560ad9bd.png)

3. Logout
We will be asked if we want to logout from the system and if so, our session will be terminated.

![logoutPage](https://user-images.githubusercontent.com/101000424/212485794-76df716f-123f-4444-b142-509c540ecc40.png)

#### Displaying personal information

When we are authenticated, we can see a personal dashboard with our information and adjusted possibilities to browse the site's resources.
The image differs between a student and librarian role.

![studentInfo](https://user-images.githubusercontent.com/101000424/212485948-6942d66a-80f1-4b64-823e-95e3bd485005.png)
![adminInfo](https://user-images.githubusercontent.com/101000424/212485954-52711cc6-d071-4ad4-a9e3-4bcab0784baf.png)

#### Displaying a list of books

A paginated grid with a list of books that are stored in database can be reached from the dashboard. 
User with elevated privileges (librarian) has extra three buttons to edit, delete and display extra info about each book.

![booksAdmin](https://user-images.githubusercontent.com/101000424/212486196-6cd306b4-abb0-4924-b81a-ca890d181207.png)

#### Adding a book

Librarian has a possibility to add a new book to the database.

![addBook](https://user-images.githubusercontent.com/101000424/212486416-cd7f7107-ac9d-499a-82c5-a85f652f4b1a.png)

#### Editing a book

When librarian wants to, he can click the "Edit" button on the grid and a book that was chosen, can be adjusted and saved by him.

#### Displaying details of a particular book

After clicking "Details" on the grid, we'll be redirected to a page with all information about the chosen book.

#### Deleting a book

When librarian wants to, he can click the "Delete" button on the grid and a book that was chosen, will be deleted from the database.

#### Pagination

The grid has an option of dividing a list of books into pages of 5. 
