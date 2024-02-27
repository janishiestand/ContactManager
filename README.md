# Contact Manager
### Introduction
Contact Manager is a web application aimed at simplifying the management of contacts by facilitating addition, update, and removal functionalities within a MySQL database.

### Motivation
This web application was developed to delve deeper into the intricacies of Entity Framework Core 7.0, exploring the changes from previous versions, and implementing essential features required for an efficient contact manager.

### Purpose
A Contact Manager app presents a comprehensive challenge, covering various web-related topics such as CSHTML, backend communication through the repository pattern, and integration with a MySQL database. The implementation of CRUD features offers flexibility and opportunity for exploration of different approaches.

### Functionality
The current functionality of the application includes basic operations like storing, updating, and deleting contacts from the MySQL database. However, a feature to list addresses and emails is yet to be implemented, providing avenues for future development.

### 1. Dashboard
The dashboard provides an overview of all stored contacts and facilitates updating and deleting.
<img width="1141" alt="Screenshot 2024-02-27 at 14 05 18" src="https://github.com/janishiestand/ContactManager/assets/100535567/b5006722-c9b4-486a-9432-aab3c4be51de">

### 2. Updating
The application allows users to update existing contacts.
<img width="257" alt="Screenshot 2024-02-27 at 14 05 32" src="https://github.com/janishiestand/ContactManager/assets/100535567/a8d0d94a-67ee-4179-88c9-daddc7d1c343">

### Learning Outcomes
The development of this application has led to a deeper understanding of implementing the repository pattern in EF Core 7.0 applications and establishing communication with a MySQL Database, thereby enhancing proficiency in these areas.

### Usage
To utilize the Contact Manager app, ensure the existence of a local MySQL database named 'ContactManagerDB'. Within this database, create a table named 'Contacts' with the following columns: 'id' (Auto Increment), 'FirstName', 'LastName', 'PhoneNumber', and 'Birthday' (all of type varchar except 'id'). Once configured, the application can be accessed and utilized for efficient contact management.
