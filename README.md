# customer-account

## Dependencies

`Docker`

## Installation
Run the below command
```sh
docker-compose up -d
```
*Alternatively VS can be used to run the solution.*
## Cleanup
Run the below commands
```sh
docker-compose down -v --rmi all
```
*Alternatively VS can be used to clean resources*

### Technologies
- `NET 5` used for the Microservices
- `NETstandard 2.1` used for Libraries
- `Swagger` used as Documentation UI
- `Docker` used for Containerisation
- `GitHub Actions` used for CI
 
 
## Building Blocks
 
### Customer API
- URI: http://localhost:5001/swagger/index.html
- Description: Responsible to Play the Game
 
Swagger Can be used in order to play the game and retreive results.
 

 ## Methodologies and Pattern
 - `DDD`
 - `Domain Event` 
 - `CQRS` is used in the Application Layer

 ## CI
 Github Action is configured to 
 - Run Test


