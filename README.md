# Banking App
## Description

# Technologies
- C#, .NET, Angular & TS, HTML, CSS, Bootstrap 5, SQLite

# Endpoints
### Default api Url 
`https://localhost:5001/api/`

### Default angular app Url
`https://localhost:4200`

## Get all users
### Request
`GET /users`
- Return all users 

## Get user by id
### Request
`GET /users/{id}`
- Return user with specific id

## Get user by username
### Request
`GET /users/name/{username}`
- Return user with specific username

## Register user
### Request
`POST /account/register`
- Register new user

## Login user
### Request
`POST /account/login`
- Login user 

## Update user
### Request
`PUT /account`
- Update user's info

## Delete user
### Request
`DELETE /account/delete/{username}`
- Delete user and remove from database

# Future improvements of app
1. Change storing data in SQLite to SQL Server Express.
2. Add integration and unit tests (xUnit.net, NUnit).
3. Add payment functionality for users.
4. Add caching, improve app performance.
