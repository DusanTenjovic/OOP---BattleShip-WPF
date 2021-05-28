# OOP---BattleShip-WPF
Seminarski iz OOP

## Zahrevi
1 Grafika
  - Dve matrice promenljive velicine (8x8, 10x10, 12x12) koje se mogu selektovati u settings kartici
  - Brojac poteza
  - Na pocetku igre igra trazi imena igraca i imenuje matrice po njima

2. Engine
  - Dve matrice koje predstavljaju polja za potapanje
  - Brod je validan samo ukoliko je svaki njegov segment direktno susedan nekom drugom (nema dijagonale)
  - za 8x8 brodovi: (broj_brodova x broj segmenata)
    - 1x4, 1x3, 2x2
  - za 10x10 brodovi:
    - 1x5 ,1x4, 2x3, 3x2
  - za 12x12 brodovi:
    - 1x6, 1x5, 2x4, 2x3, 2x2 
  - Prva faza igre je postavljanje brodova, jedan igrac za drugim
  - Druga faza je potapanje
