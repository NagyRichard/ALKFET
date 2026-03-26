Követelmény specifikáció (REQSPEC)

1\. Projekt áttekintés



Projekt neve: Smart Shopping List



Cél:

A projekt célja egy egyszerű webalapú alkalmazás fejlesztése, amely lehetővé teszi bevásárlólisták létrehozását, kezelését és a listákhoz tartozó tételek nyilvántartását. Az alkalmazás támogatja a tételek állapotának kezelését (pl. megvásárolva / nem megvásárolva), valamint azok szűrését és kategorizálását.



A projekt célja továbbá egy teljes end-to-end (e2e) fejlesztési és telepítési folyamat bemutatása, amely magában foglalja:



az alkalmazás fejlesztését,



konténerizálását,



CI pipeline kialakítását,



valamint a rendszer dokumentálását.



2\. Hatókör (Scope)



Az alkalmazás egy egyszerű domain modellre épülő rendszer, amely nem tartalmaz komplex üzleti logikát vagy jogosultságkezelést. A rendszer egy felhasználó által használható, lokálisan futtatható webalkalmazás.



A rendszer fő célja:



CRUD műveletek biztosítása bevásárlólisták és tételek kezelésére



modern webes architektúra bemutatása



CI/CD pipeline demonstrálása



3\. Funkcionális követelmények

3.1 Bevásárlólista kezelés



A felhasználó képes új bevásárlólistát létrehozni



A felhasználó megtekintheti az összes bevásárlólistát



A felhasználó szerkesztheti egy bevásárlólista nevét



A felhasználó törölheti a bevásárlólistát



3.2 Tételek kezelése



A felhasználó képes új tételt hozzáadni egy listához



Egy tétel tartalmazza:



név



mennyiség



mértékegység



kategória



megjegyzés (opcionális)



A felhasználó szerkesztheti a tételeket



A felhasználó törölheti a tételeket



3.3 Állapotkezelés



A felhasználó megjelölheti a tételeket megvásároltként



A felhasználó visszaállíthatja a tételeket nem megvásárolt állapotba



3.4 Szűrés és megjelenítés



A felhasználó szűrheti a tételeket:



összes



megvásárolt



nem megvásárolt



A felhasználó kategória szerint csoportosíthatja a tételeket



4\. Nem funkcionális követelmények



Az alkalmazás konténerizált formában futtatható



A frontend és backend külön Docker konténerben fut



Az alkalmazás Docker Compose segítségével egy paranccsal indítható



A rendszer platformfüggetlen (Docker alapú futtatás)



A kód verziókezelése Git alapú repository-ban történik



5\. Technológiai stack

Frontend



Angular (TypeScript)



Backend



ASP.NET Core Web API (C#)



Adatbázis



MongoDB



Konténerizáció



Docker



Docker Compose



CI/CD



GitHub Actions



GitHub Container Registry (GHCR)



6\. Rendszer architektúra



A rendszer három fő komponensből áll:



Frontend



Angular alapú SPA



HTTP kéréseken keresztül kommunikál a backenddel



Backend



REST API ASP.NET Core-ban



üzleti logika és adatkezelés



Adatbázis



MongoDB



dokumentum alapú adattárolás



A komponensek Docker konténerekben futnak, és Docker Compose segítségével kerülnek összekapcsolásra.



7\. Domain modell (high-level)

ShoppingList



id



name



createdAt



updatedAt



ShoppingItem



id



listId



name



quantity



unit



category



isPurchased



note



createdAt



updatedAt



Kapcsolat:



Egy ShoppingList több ShoppingItem-et tartalmaz (1-N kapcsolat)



8\. CI/CD pipeline



A rendszer tartalmaz egy automatizált CI pipeline-t, amely:



buildeli a frontend alkalmazást



buildeli a backend alkalmazást



Docker image-eket készít



feltölti az image-eket a GitHub Container Registry-be



A pipeline GitHub Actions segítségével valósul meg.



9\. Felhasználói dokumentáció



A projekt tartalmaz egy user guide-ot, amely bemutatja:



az alkalmazás indítását



az alap funkciók használatát



a bevásárlólisták kezelését



a tételek kezelését



10\. Telepítés és futtatás



Az alkalmazás Docker Compose segítségével indítható:



docker-compose up



Ez elindítja:



a frontend alkalmazást



a backend API-t



a MongoDB adatbázist



11\. Korlátozások



Az alkalmazás nem tartalmaz autentikációt



Egyfelhasználós használatra készült



Nem production-ready rendszer, demonstrációs célokat szolgál

