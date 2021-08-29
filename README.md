# Providor Test
## Running the project
1. Need Docker desktop installed
2. Command to run the project: docker-compose up --build -d
3. To view Swagger documentation for API- http://localhost:5000/index.html
4. To view the UI - http://localhost:3000/

## Dependencies/Libraries Used
1. NUnit - For unit testing
2. Moq - For mocking the dependencies of business functions during unit test
3. AutoFixture - For mocking of objects/data in unit test
4. Swashbuckle - For api documentation
5. EntityFramework Core - ORM/Code first Db creation
6. Material UI - React project, Accordion
7. https://github.com/eficode/wait-for - To wait for the SQL server to be up before executing the Web API
