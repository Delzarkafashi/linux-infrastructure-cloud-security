# Byta branch i Git från terminalen

I Git använder man **branches** för att arbeta med olika delar av ett projekt utan att påverka main direkt.

Det gör att man kan arbeta strukturerat och säkert.

---

## Steg 1 – Se vilka branches som finns

Skriv:

git branch

Exempel:

01-install-linux  
02-shell-commands  
* main

Stjärnan (*) visar vilken branch du är på just nu.

---

## Steg 2 – Byt till en branch

För att byta branch skriver du:

git checkout namn-på-branch

Exempel:

git checkout 02-shell-commands

Terminalen visar då:

Switched to branch '02-shell-commands'

---

## Steg 3 – Kontrollera att du är på rätt branch

Skriv igen:

git branch

Exempel:

01-install-linux  
* 02-shell-commands  
main

Nu ser du att du arbetar i rätt branch.

---

## Steg 4 – Skapa och byta branch samtidigt

Du kan också skapa en ny branch och byta till den direkt.

Skriv:

git checkout -b namn-på-branch

Exempel:

git checkout -b 03-filesystem

Detta gör två saker:

- skapar en ny branch
- byter direkt till den

---

## Varför använder man branches?

Branches används för att:

- arbeta strukturerat
- separera olika delar av projektet
- testa saker utan att förstöra main
- arbeta i team

---

## Sammanfattning

De viktigaste kommandona är:

git branch  
git checkout branch-namn  
git checkout -b ny-branch
