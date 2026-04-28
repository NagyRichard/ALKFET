# Shopping List Application – User Guide

## 1. Az alkalmazás célja

Az alkalmazás célja egy egyszerű bevásárlólista-kezelő rendszer biztosítása, amelyben a felhasználó:

- bevásárlólistákat hozhat létre,
- listákhoz elemeket adhat hozzá,
- elemek állapotát kezelheti (kész / nem kész),
- elemeket törölhet.

## 2. Alkalmazás elérése

Az alkalmazás böngészőből érhető el:

- Frontend: http://localhost:4200
- Backend API (Swagger): http://localhost:8080/swagger

## 3. Lista létrehozása

1. Nyisd meg az alkalmazást.
2. Add meg a lista nevét a megfelelő mezőben.
3. Kattints a **Create / Add** gombra.

- Ekkor a lista megjelenik a listák között.

## 4. Lista megnyitása

1. A listák között keresd meg a kívánt listát.
2. Kattints a **Megnyitás (Open)** gombra.

- Megnyílik a lista részletező oldala.

## 5. Elem hozzáadása a listához

1. A lista részletező oldalon add meg az új elem nevét.
2. Kattints az **Add item** gombra.

- Az elem megjelenik a listában.

## 6. Elem állapotának kezelése

Az elem mellett található jelölőnégyzet (checkbox) segítségével:

- bejelölheted → kész
- kiveheted → nem kész

- A rendszer automatikusan menti az állapotot.

## 7. Elem törlése

1. Keresd meg a törölni kívánt elemet.
2. Kattints a **Delete** gombra.

- Az elem eltávolításra kerül a listából.

## 8. Alkalmazás működése röviden

- A frontend Angular alkalmazás.
- A backend ASP.NET API.
- Az adatok MongoDB adatbázisban tárolódnak.
- A rendszer Docker konténerekben fut.

## 9. Megjegyzés

Az alkalmazás helyes működéséhez szükséges, hogy a frontend, a backend és az adatbázis-szolgáltatás is elinduljon.
