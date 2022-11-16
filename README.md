# TasksApp

Ukázková aplikace vytvoøená na základì zadání spoleènosti [COMPUTER HELP, spol. s r. o.](https://www.computerhelp.cz/) pro otestování znalostí uchazeèù o práci.

## Vývojové prostøedí

Pro vývoj bylo použito Visual studio ve verzi 17.4.0

Pro obì èásti je použit .Net Framewor 7

## Serverová èást

Projekt TaskAPI poskytuje REST API rozhraní pro práci s daty. 

K vytvoøení je použito [ASP.NET Core Minimal APIs](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-7.0)

### Datový model

**Úkoly:**

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
	Get:	"tasks/" - všechny úkoly bez úkolù ve stavu Deleted	
	Get:	"tasks/incdel" - všechny úkoly
	Get:	"tasks/{id}" - jeden úkol
	Post:	"tasks/" - nový úkol
	Put:	"tasks/{id}" - úprava úkolu 
	Delete:	"tasks/{id}" - smazání úkolu
`

** Komentáøe

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
	Get:	"comments/" - všechny komentáøe	
	Get:	"comments/{MyTask.Id}" - všechny komentáøe k úkolu
	Post:	"comments/" - nový komentáø
	Put:	"comments/{id}" - úprava komentáøe 
	Delete:	"comments/{id}" - smazání komentáøe
`

**Uživatel**

`
User
	string UserName (primary key)
	string Password
`

Api endpoints:

`
	Get:	"users/" - všichni uživatelé	
	Get:	"users/{id}" - jeden uživatel
	Get:	"users/{username}/{password}" - ovìøení hesla
	Post:	"users/" - nový uživatel
`

