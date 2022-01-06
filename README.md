PaymentSystem
PaymentSystem is a .net core web api that uses entity framework core that returns a specific user and list of payments . User has an account balance and Payment list has Id, Amount, Status,Date and userId.

The application does only getting of Users by their Ids.

I used Entity Framework (EF) Core because it is a lightweight, extensible, open source version of EF. It also makes the work of dealing with the database easier, since developers can interact with it using .NET objects (models).

To Use the Application

Download the zip file and Extract in a local folder.

First is to create tables and insert values in your local database using the database.txt file,

Clean and build and run the application.

Using Postman

Run https://localhost:44363/api/users/1 using Get

Assumptions and Considerations

The most important thing to consider for creating APIs is to have consistency by following web conventions and standards. For this API, JSON, SSL and HTTP Response/Status codes are the building blocks. The system is created using a database first approach.The solution should be divided into several projects to make it a multi layered project structure.

The endpoints accepts and responds with JSON payload. Nouns are also used in the endpoint paths. Paths of endpoints should be consistent and should use only nouns since the HTTP methods indicate the action we want to take. 

For the extensibility, Middleware is a very good example when it comes to extensibility of the code. 
