# Possible Message Web (test web application)

This is an MVC 5 based web site built on top of the Visual Studio ASP.NET MVC web site template using Bootstrap and user registration support.

## Features implemented

* Registration (username, password, first name, last name, email address, phone number)

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