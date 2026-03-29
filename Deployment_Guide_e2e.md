Deployment Guide – Shopping List Application
1. Követelmények

Az alkalmazás futtatásához az alábbi szoftverek szükségesek:

Docker
Docker Compose

Ellenőrzés:

docker --version
docker compose version
2. Projekt letöltése

Klónozd a repository-t:

git clone https://github.com/NagyRichard/ALKFET.git
cd ALKFET
3. Alkalmazás indítása

Az alkalmazás Docker Compose segítségével indítható.

3.1. Image-ek letöltése (GHCR-ből)
docker compose -f source/docker-compose.yml pull

Ez letölti a következő image-eket:

backend
frontend
MongoDB (hivatalos image)
3.2. Konténerek indítása
docker compose -f source/docker-compose.yml up -d

Ez elindítja:

MongoDB adatbázist
Backend API-t
Frontend alkalmazást
4. Alkalmazás elérése

Sikeres indítás után az alkalmazás az alábbi címeken érhető el:

Frontend: http://localhost:4200
Backend API (Swagger): http://localhost:8080/swagger
5. Konténerek ellenőrzése

Futtasd:

docker ps

Elvárt konténerek:

shoppinglist-mongodb
shoppinglist-backend
shoppinglist-frontend
6. Leállítás

Az alkalmazás leállítása:

docker compose -f source/docker-compose.yml down
7. Frissítés (új verzió futtatása)

Ha új verzió kerül fel a registry-be:

docker compose -f source/docker-compose.yml pull
docker compose -f source/docker-compose.yml up -d
8. Hibaelhárítás
Port ütközés

Ha valamelyik port foglalt:

4200 (frontend)
8080 (backend)
27017 (MongoDB)

akkor módosítani kell a docker-compose.yml fájlban.

Konténer nem indul

Logok megtekintése:

docker logs shoppinglist-backend
docker logs shoppinglist-frontend
Adatbázis kapcsolat hiba

Ellenőrizd, hogy a backend környezeti változója helyes:

MongoDbSettings__ConnectionString=mongodb://mongodb:27017
9. Megjegyzés

Az alkalmazás teljesen konténerizált, ezért nem szükséges:

Node.js telepítése
.NET telepítése
MongoDB külön telepítése

Minden komponens Docker konténerben fut.