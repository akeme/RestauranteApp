# Projeto Final do WCC 6 / Final Project WCC6 C#

## Task description
**Problem #1** – The Kitchen Routing System

You are tasked with writing a piece of software to do a Restaurant Order Routing. Assume that you have a restaurant with multiple POS (point-of-sale) instances sending orders that should be routed to specific areas of a kitchen.
It must comprise a HTTP Server with an endpoint to receive an Order and place it in a queue representing a destination kitchen area.
Create a C# solution in Visual Studio.
We really encourage you to write down any assumptions you had as comments on the top of your code for better understanding

*Requirements:*

The application must be executable both in Windows and Unix based machines;
You don't have to worry about databases; it's fine to use in-process, in-memory storage;
It must be production quality according to your understanding of it - tests, README, etc.

*General notes:*

This challenge will be extended by you and an RDI developer/architect on a different step of the process;
Please make sure to anonymize your submission by removing your name from file headers and such;
Feel free to expand your design in writing;
You will submit the source code for your solution to us as a compressed file containing all the code and possible documentation. You can share this via Google Drive, Dropbox, or any other such service. Please don’t share as an attachment because our Exchange Server may reject your message;
Please do not upload your solution to public repositories in GitHub, BitBucket, etc.
Things we're looking for:
- Immutability;
- Proper concurrency handling;
- Separation of concerns;
- Unit and integration tests;
- API design;
- Code readability;
- Dependency Injection;
- Async/Sync examples;
- Error handling.


*FAQ:*

Q: What are the kitchen areas? 
A: fries, grill, salad, drink, desert


Q: Can I use third-party applications in my program?
A: Yes, you can use. Just make sure that you write the correct installation instructions.




### Pacotes
Install-Package Swashbuckle.AspNetCore -Version 6.2.3