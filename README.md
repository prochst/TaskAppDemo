# TasksApp

Uk�zkov� aplikace vytvo�en� na z�klad� zad�n� spole�nosti [COMPUTER HELP, spol. s r. o.](https://www.computerhelp.cz/) pro otestov�n� znalost� uchaze�� o pr�ci.

## V�vojov� prost�ed�

Pro v�voj bylo pou�ito Visual studio ve verzi 17.4.0

Pro ob� ��sti je pou�it .Net Framewor 7

## Serverov� ��st

Projekt TaskAPI poskytuje REST API rozhran� pro pr�ci s daty. 

K vytvo�en� je pou�ito [ASP.NET Core Minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-7.0)

### Datov� model

**�koly:**

`
MyTask	
	int Id (primary key)
	string Title
	string Description
	string State (enum {New, Processed, Finished, Deleted})
	string Owner
`

Api endpoints:
`
	Get:	"tasks/" - v�echny �koly bez �kol� ve stavu Deleted	
	Get:	"tasks/incdel" - v�echny �koly
	Get:	"tasks/{id}" - jeden �kol
	Post:	"tasks/" - nov� �kol
	Put:	"tasks/{id}" - �prava �kolu 
	Delete:	"tasks/{id}" - smaz�n� �kolu
`

** Koment��e

`
Comments
    int Id (primary key)
    int MyTaskId
    string UserName
    string Content
    DateTime Create
`
Api endpoints:

`
	Get:	"comments/" - v�echny koment��e	
	Get:	"comments/{MyTask.Id}" - v�echny koment��e k �kolu
	Post:	"comments/" - nov� koment��
	Put:	"comments/{id}" - �prava koment��e 
	Delete:	"comments/{id}" - smaz�n� koment��e
`

**U�ivatel**

`
User
	string UserName (primary key)
	string Password
`

Api endpoints:

`
	Get:	"users/" - v�ichni u�ivatel�	
	Get:	"users/{id}" - jeden u�ivatel
	Get:	"users/{username}/{password}" - ov��en� hesla
	Post:	"users/" - nov� u�ivatel
`

