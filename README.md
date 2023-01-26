# DDD.Example
Example how to implement DDD in c#, with webAPI as presentation layer.

### Project Structure
```
| - Presentation
| |     |---------> First layer which someone can have access, on this layers API's interact with internal layers (such application) 
| |                 to secure and assure vertical infrastructure
|  \
|  | - WebAPI
|  |     |---------> Public API (REST) to interact with application layer
|  | - Contracts
|  |     |---------> Contracts used between Presentation's API's and application layer
|  | - Application
|  |     |---------> Application layer coordenate and delegate tasks to down layer (domain) 
|    \
|    | - Domain
|          |---------> Core of application. There are all the bussiness rules
|    
| - Infrastructure
|     |---------> Implement all kind of services or providers, interact with application and domain directly.
```
