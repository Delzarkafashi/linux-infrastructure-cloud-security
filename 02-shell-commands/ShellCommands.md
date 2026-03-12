# Shell och grundläggande Linux-kommandon

I denna del lär vi oss de första kommandona i Linux-terminalen.  
De används för att navigera i systemet och arbeta med filer och mappar.

---

## pwd

Visar vilken mapp du befinner dig i just nu.

pwd
Exempel output:
/home/delzar

---

## ls

Visar filer och mappar i den aktuella mappen.
ls

---

## cd

Byter mapp.

Gå in i en mapp:
cd mappnamn

Exempel:
cd 01-install-linux
Gå tillbaka en nivå:
cd ..

Gå till din home-mapp:
cd ~

---

## mkdir

Skapar en ny mapp.
mkdir mappnamn

Exempel:
mkdir projekt
---

## touch

Skapar en ny fil.
touch filnamn.md

Exempel:
touch README.md


---

## cat

Visar innehållet i en fil.
cat filnamn.md

Exempel:
cat README.md
---

## nano

Öppnar en fil i terminalens texteditor.
nano filnamn.md

Spara:
CTRL + O

Avsluta:
CTRL + X

---

## cp

Kopierar en fil.
cp filnamn kopiafil

Exempel:
cp README.md README-kopia.md

---

## mv

Flyttar eller byter namn på en fil.

Flytta en fil:
mv filnamn mapp/

Exempel:
mv README.md 01-install-linux/


Byta namn på en fil:
mv gammalt-namn.md nytt-namn.md

---

## rm

Tar bort en fil.
rm filnamn

Exempel:
rm test.md
OBS: Filen tas bort permanent.

---

## clear

Rensar terminalen.
clear

Detta tar bort all text från terminalfönstret så att du får en ren vy.


## Sammanfattning

De första kommandona man lär sig i Linux är:


pwd
ls
cd
mkdir
touch
cat
nano
cp
mv
rm
clear

De används för att navigera i systemet och skapa filer och mappar.
