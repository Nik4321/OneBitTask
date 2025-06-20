# OneBitTask

The solution to a a technical task from OneBit Software.

Overview:
Your task is to create an ASP.NET web project which loads data from a database into a grid. You are required to create Customer and Purchase Order entities, then visualise them in forms and grids. You are required to demonstrate that you can handle databases, data access, layered architectures and web presentation. You are free to make design decisions as you see fit, however we require you to explain your decisions and rationale.

# Task 1.
### Create a Microsoft SQL database and a table which will store the following contact information :
#### Customers Table:
- First Name
- Last Name
- Sex (male/female)
- Telephone
- Created (DateTime)
- Status (active/inactive/deleted)

#### Purchase Orders Table:
- Description
- Price
- Quantity
- Total Amount
- Created (DateTime)
- Status (active/inactive/deleted)

Relationships must exist between the Customer and Purchase Order objects. Name the database, tables and columns as you see fit. Add any fields you require in order to complete the relationship. Use column types as you see fit. The status column should contain whether the item is active, inactive or deleted. Use any SQL database. You may choose to use Code First or Database First database design strategies.

# Task 2.

Create a project containing your data access layer (if you have not used one already for creating your database). Implement methods for CRUD operations to your tables. You may use any ORM to extract and transform the data within the database. Make use of a Service layer and follow good OOP practices. You can use any architectural design concept or project structure you choose, as long as you can explain why and what features it brings you.

Bonus points for using a generic repository and implement the repository pattern. (hint: IRepository<T>)

# Task 3.

### Create an ASP.NET Core web project including the minimal set of components you need to complete the following:
1. Visualize the Customer data contained in the database in a grid/table format.
- Only non-deleted items should be shown
- The grid should have an activate/deactivate item option (and it should be apparent which items are active and which are inactive)
- The grid should have a delete item link
- Show a single grid with Purchase Order data.
- When viewing a Customer, show a grid with the relevant purchase orders. The same rules for deleted and active results must be applied.
2. The grid should have paging and the ability to sort by each column.
3. Create New and Edit forms to be able to add and edit rows.

You can use any mix of client-side and backend technologies, but stick to ASP.NET Core for the server-side. Feel free to reuse anything to style the page, grid and forms.

 

- Bonus points if the grid is loaded asynchronously and data passed through API action methods
- Bonus points if you use a Service layer
- Bonus points if the page looks presentable
- Bonus points if you deploy your solution to a free Azure App Service

# Task 4.
This task is to be submitted in English and via e-mail. Explain the reasons why you have chosen the database and schema creation method. Explain how you created the relationships. Explain the structure of your data access layer and anything that you have done to make the design better. Explain how your grids bind to data. Explain anything else you feel is valuable and constructive regarding the solution. List all links, reading material and resources you have used to help you in your development. Provide details of the time you have spent on each task.

Azure app services link: <https://onebittaskweb20190614125245.azurewebsites.net/>
