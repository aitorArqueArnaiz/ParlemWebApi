ParlemAPI :

Implementation / Developement Steps : 

Domain-Driven-Developement

1. Think how ti create the data base table/s and how infrastructure module should be
2. Create the API (controllers, startup, error handling, logs , etc...)
3. Create the service : Domin and business logics (depending on the controller)
4. Create Unit Testing for basic flows (add, get, update and delete)
5. Unit Testing


How to test the project : Run it with IIS Express in local machine

Data Base :
	MDF file in solution items folder with already some data created. Attach it to your local machine SQLServer with SQl Management Studio

ENDPOINTS

En cas que el projecte creixi molt , m'agrada dividir el domini en dues capes :

	- Bussines : Definicions i interfaces, dtos , entitats, etc ...
	- Domain : La pròpia lògica de negoci amb les implementacions dels algoritmes.

	A més a mesura que es van afeguint mes capes també m'agrada afeguir integration test , tot i que es dur, 
	per testejr el correcte funcionament de tot el fluxe desde el controlador fins a la infrastructura.
	Si s'escau es moquejen dades o es pot fer servir Docker per aixecar serveis com un Redis o Base de dades "Real".