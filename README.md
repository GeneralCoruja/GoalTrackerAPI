# Goal Tracking API

.NETCORE API that manages users and their habits/goals


## How to run locally

1. Clone project locally
2. Start up a local MongoDB database (might need to change ConnectionString in appsettings.json)
3. Run API in debug mode
4. SwaggerUI should pop up, enabling the endpoints for use

## Auth

The authentication in this app is JWT based.
Make sure to register an user first using the [HttpGet]/register endpoint and use the returned JWT Token.
