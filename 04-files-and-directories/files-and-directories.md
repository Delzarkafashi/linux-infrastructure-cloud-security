# Files och mappar i Linux

I denna del lär vi oss hur man arbetar med filer och mappar i Linux-terminalen.
Vi använder viktiga kommandon för att skapa, kopiera, flytta, byta namn på och ta bort filer.

---

## mkdir

Skapar en ny mapp.

mkdir mappnamn

Exempel:

mkdir test-folder
mkdir docs
mkdir backup

Kontrollera mapparna:

ls

---

## touch

Skapar en ny fil.

touch filnamn

Exempel:

touch file1.txt
touch file2.txt

Kontrollera filerna:

ls

---

## cp

Kopierar en fil.

cp filnamn destination

Exempel:

cp file1.txt docs/

Kontrollera att filen kopierats:

ls docs

---

## mv

Flyttar en fil eller byter namn på en fil.

Flytta en fil:

mv filnamn mapp/

Exempel:

mv file2.txt backup/

Kontrollera att filen flyttats:

ls backup

Byta namn på en fil:

mv gammalt-namn nytt-namn

Exempel:

mv file1.txt newfile.txt

Kontrollera namnbytet:

ls

---

## rm

Tar bort en fil.

rm filnamn

Exempel:

rm newfile.txt

Kontrollera att filen tagits bort:

ls

OBS: Filen tas bort permanent.

---

## Sammanfattning

De viktigaste kommandona för filer och mappar i Linux är:

mkdir
touch
cp
mv
rm

De används för att skapa mappar, skapa filer, kopiera filer, flytta eller byta namn på filer och ta bort filer.
