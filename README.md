# Banking System
Please be advised that this application was developed as part of a programming test, with a primary focus on demonstrating 'Good' Programming Practices. As a result, the application has been intentionally designed to showcase these practices rather than prioritize functionality typical of a business-oriented application of this scale.

# How to Run –
Open the solution file named BankingSystem.sln and hit run.

# Task – Using the provided application
1. Debugging:
  •	Identify and fix all bugs that prevent the application from running correctly.
  •	Ensure that all functionality (adding accounts, depositing, withdrawing, and displaying
  •	account details) works as intended.
2. Refactoring:
  •	Improve the code structure by applying object-oriented principles.
  •	Use appropriate design patterns where necessary (e.g., Repository Pattern for data
  •	handling).
  •	Rename variables and methods to be more descriptive and follow naming conventions.
  •	Optimize any inefficient algorithms or redundant code.
  •	Add comments and documentation to make the code easier to understand.
3. Testing:
  •	Write unit tests to verify that the fixed and refactored code works correctly.
  •	Ensure the tests cover various edge cases and scenarios.
Bonus: 
  •	Implement additional features such as account transfers or transaction history. 
  •	Add exception handling and validation to ensure robust input handling.

Assumptions – 
  •	An account will never have a negative ID.
  •	Transactions must be made with a positive value.
  •	Users will not need to view all accounts and will know the ID of whichever account they wish to view as if by magic.
  •	For the basic account functionality, It is A-Okay to withdraw or deposit values with any amount decimal places
  •	We only care about holding the: ID, DateTime, Amount, and type of transaction. We also have no reason to think the user should be able to update them. nor do we believe that the transactions should ever have to change in future. 
Review – 
Good Practice:
  •	The application is commented throughout.
  •	Design Patterns used: Singleton, Event Aggregator, Mediator
  •	Basic account has tests
  •	Application is abstract and allows for changes to the Account, Account manager, and the UI.
  •	Uses error handling throughout.
Could be better:
  •	More testing could be added for edge cases, and to cover more of the application. 
  •	It would be reasonable if you didn’t want to Display the Account from the account obj.
  •	One could argue that the number of changes go beyond refactoring, is wasted time.
  •	Not limiting the number of decimal places in the transaction amount is a decision that is very hard to justify especially as it is a simple change. 
