# 8 kiálynő probléma dokumentáció - Mesterséges Intelligencia gyakorlat beadandó I. Kállai Viktor L88I9I

## Bevezetés

A "8 Királynő probléma" egy jól ismert számítógépes probléma, amely arra törekszik, hogy nyolc királynőt helyezzen el egy 8x8-as sakktáblán úgy, hogy egyik királynő se tudjon megtámadni egy másikat. A probléma megoldásához minden királynőnek külön sorban, oszlopban és átlóban kell lennie. A probléma egy lehetséges megoldása az, hogy minden sorban pontosan egy királynő legyen.

Ebben a dokumentációban két különböző algoritmust mutatok be a "8 Királynő probléma" megoldására: a backtracking és a hegymászó algoritmusokat.

## State osztály

A State osztály az összes lehetséges állapotot tartalmazza, amelyekben a probléma megoldása lehetséges. Minden állapotban egy 8x8-as sakktábla van, ahol a "Q" jelöli a királynőt, és a "." az üres mezőt.

## Operator osztály

Az operator osztály felelős az állapotok manipulálásáért. Az egyik operátor a királynő elhelyezését végzi el egy adott sorban és oszlopban a sakktáblán. A másik operátor a királynő eltávolítását végzi az adott pozícióból.

## BacktrackingSolver osztály

A backtracking algoritmus egy mélységi keresést alkalmaz, amely minden lehetséges lépést végigjár, majd visszalép, ha egy adott lépés nem vezet megoldáshoz. A backtracking algoritmus lényege az, hogy próbálkozik minden lehetséges lépéssel, és ha egy lépés nem megfelelő, visszalép a korábbi állapotba és más útvonalat próbál.

### A Solver mondatszerű leírása

1. Kezdeti sakktábla generálása
2. Ellenőrzés: Megoldható-e az állapot?
    - Igen: Folytatás a 3. lépésnél
    - Nem: Megoldás nem lehetséges, kilépés
3. Következő üres oszlop kiválasztása
4. Az összes lehetséges sor kiértékelése az oszlopon
5. Ellenőrzés: Megfelelő-e az állapot?
    - Igen: Királynő elhelyezése, folytatás a 2. lépésnél
    - Nem: Visszalépés az előző oszlophoz
6. Minden királynő elhelyezve? (Minden oszlop megnézve)
    - Igen: Megoldás megtalálva, kiírás és kilépés
    - Nem: Visszalépés az előző oszlophoz
  
### Solver ábra rajza




## HillClimbingSolver osztály

A hegymászó algoritmus egy olyan megközelítést alkalmaz, amely az aktuális legjobb lépést választja ki a jelenlegi állapotból. Az algoritmus megpróbálja minimalizálni az ütközéseket (azaz a konfliktusokat), amelyek akkor következnek be, ha egy királynő támadja a másikat. Az algoritmus minden lépésben a legjobb lépést választja ki, és ezzel halad előre a megoldás felé.

### A Solver mondatszerű leírása

1. Kezdeti sakktábla generálása
2. Ellenőrzés: Megfelelő-e az állapot? (Nincs ütközés)
    - Igen: Megoldás megtalálva, kilépés
    - Nem: Folytatás a következő lépésre
3. Összes lehetséges lépés kiértékelése
4. Legjobb lépés kiválasztása (minimális ütközéssel)
5. Lépés végrehajtása
6. Visszatérés a 2. lépéshez

### Solver ábra rajza




## Megoldások gyorsasága

A backtracking algoritmus minden lehetséges állapotot végigpróbál, ezért akkor működik hatékonyan, ha a korai szakaszban talál megoldást. A hegymászó algoritmus gyorsabban talál megoldást, ha az állapottér kezdeti részei közel állnak a megoldáshoz. A gyorsaság mindkét algoritmusnál függ a kezdőállapottól és az alkalmazott heurisztikától. Az optimalizációk különbsége miatt az algoritmusok eredményei eltérhetnek.

