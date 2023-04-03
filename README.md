# Contact Manager
## Introduction
The Contact Manager is a web application designed to facilitate the addition, update, and removal of contacts from a MySQL database.

### Motivation
This web app has been created to learn more about Entity Framework Core 7.0 and how to implement various features necessary for a contact manager.
There are a number of changes from EF Core 6.0 to 7.0 and creating this app has helped a lot to understand them.

### Purpose
A C# Contact Manager app is a well-rounded challenge that covers web-related topics including CSHTML, communication with the backend through
the repository pattern, and connectivity to a mySQL database. 
The implementation of CRUD features can vary significantly, and this project provided an opportunity to explore various approaches.

### Functionality
The application currently provides basic functionality to store, update, and delete contacts from the MySQL database. 
However, a feature to list addresses and emails is yet to be implemented.

### Learning Outcomes
I've learned how to successfully implement the repository pattern an EF Core 7.0 app and how to make it communicate with a mySQL Database.

### Usage
To use the Contact Manager app, ensure that you have created a local MySQL database named 'ContactManagerDB'. 
Inside this database, create a table named 'Contacts' with the following columns: int 'id' (Auto Increment), 'FirstName', 'LastName', 'PhoneNumber', and 'Birthday' (all of type varchar apart from 'id'). 
Once this is done, the app can be accessed and used to manage your contacts.
