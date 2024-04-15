# IMI Provider
Faculty project for Internet\TV providers that incorporates Design Patterns\Windows Forms\C#\MySQL\SQLite

# Project Overview
The aim of this project is to utilize the ProviderDatabaseLibrary as a DLL (Class Library) within a Windows Forms GUI project. This project is built on .NET 8.0, so ensure you have it installed if you plan on running the project files in Visual Studio.

This application utilizes two databases: MySQL and SQLite. Ensure that you have a MySQL server running to access the MySQL database, while the SQLite database is provided within the project files.

For importing provider configurations, a simple text file format is employed. Please ensure that you set the correct path for your connection strings and provider name to whatever you wish. Additionally, SQL query files for creating basic databases for each SQL version are included in the project files.

# Running

1.The application executable files are included in the project files for convenience.

2.With Visual Studio, you can independently test the GUI project and DLL project. Ensure that you set the startup project to the one you wish to test. Note that if you intend to test the DLL project, you will need to change the output type from "Class Library" to "Console Application." To do so, right-click on the ProviderDatabaseLibrary project, navigate to Properties, and then adjust the Output Type setting.

3. Database Import: For correct database importing, refer to the "Project Overview" section.
