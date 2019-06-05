# Possible Message Web (test web application)

This is an MVC 5 based web site built on top of the Visual Studio ASP.NET MVC web site template using Bootstrap and user registration support.

It uses EF 6 the default data provider for Identity services to store and read user and messages data.

Supports most places async for better throughput.

## Features implemented

* Registration
* Confirmation email
* Users can hide themselves from the list
* Marking messages as unread / read

## Features TO DO

* Users can allow / block other users to send messages to them
* Facebook connect
* List of favourites
* Visualizing incoming messages & periodically checking incoming messages
* By clicking on usernames (on the userlist) users can send popup messages
* implement a webservice API that could be integrated by third party systems (get a user’s messages, send message, etc.)
* sending invitation email to non-registered users, list invitations, display status (sent, user registered)

## Outstanding DEV tasks

* Refactor code into more services
* Implement IoC with Unity or similar with the repositories
* Implement unit tests for controllers
* Make sure controller methods are correctly secured with [Authorize] [AllowAnonymous] [RequireHttps] where applicable
* Add logging i.e. log4net
* Finish Facebook connect with code stubs (app.UseFacebookAuthentication(), AccountController.ExternalLoginCallback, ExternalLoginConfirmation, etc...)

## Original requirements

```
### Mission: message sending and receiving system

After registration, users can send messages to each other. They can send maximum 5 messages per day. Messages and users are stored in DB.

Required information to register: username, password (at least 6 characters, small and capital letters & numbers), first name and surname, email address, phone number (optional)

User list: list registered users, messages can be sent by clicking on usernames

Message sending interface (UI): select the recipient (could be a search with predictive results) or the recipient could be pre-selected if the user is coming from the user list

### Features:

* Registration
* Confirmation email
* Users can hide themselves from the list
* Users can allow / block other users to send messages to them
* Marking messages as unread / read

Extra:
* Facebook connect
* List of favourites
* Visualizing incoming messages & periodically checking incoming messages
* By clicking on usernames (on the userlist) users can send popup messages
* implement a webservice API that could be integrated by third party systems (get a user’s messages, send message, etc.)
* sending invitation email to non-registered users, list invitations, display status (sent, user registered)
```