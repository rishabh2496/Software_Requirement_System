To Run this project follow the below mentioned steps
1) Create a database in MS SQL Server with name "Software_Requirement_System" and run commands those are mentioned in Software_Requirement_System.sql file.
2) Update the connection string which is mentioned in the Web.Config file as mentioned below. Update the Data Source name with your server name.

<connectionStrings>
    <add name="DefaultConnection" connectionString="Data Source=SYSTEM;Initial Catalog=Software_Requirement_System;Integrated Security=True"
      providerName="System.Data.SqlClient" />
  </connectionStrings>
  

  3) below is the user name and password of the Admin account

  User email : admin@admin.com
  Password : Admin@123