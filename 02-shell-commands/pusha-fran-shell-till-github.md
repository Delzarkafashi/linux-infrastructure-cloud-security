# Pusha kod från terminalen till GitHub

## Steg 1 – Gå till projektmappen

Öppna terminalen och gå till din projektmapp.

Exempel:

cd linux-infrastructure-cloud-security

Kontrollera att du är i rätt mapp:

pwd

---

## Steg 2 – Skapa en ny branch

Skapa en ny branch för den del du arbetar med.

Exempel:

git checkout -b 02-shell-commands

Detta skapar en ny branch och byter till den.

---

## Steg 3 – Lägg till ändringar

Lägg till filer som ska skickas till GitHub.

git add .

Punkten betyder att alla ändringar läggs till.

---

## Steg 4 – Gör en commit

Skriv en commit som beskriver vad du gjort.

Exempel:

git commit -m "Add shell commands lesson"

---

## Steg 5 – Push till GitHub

Skicka branchen till GitHub.

Exempel:

git push origin 02-shell-commands

Nu ligger branchen på GitHub.

---

## Steg 6 – Byt till main

När arbetet är klart går du tillbaka till main.

git checkout main

---

## Steg 7 – Hämta senaste version

git pull

Detta hämtar senaste ändringarna från GitHub.

---

## Steg 8 – Merge din branch

Merge:a branchen till main.

Exempel:

git merge 02-shell-commands

---

## Steg 9 – Push main

Skicka uppdaterad main till GitHub.

git push

---

## Klart

Nu har du:

- skapat en branch
- lagt till ändringar
- gjort en commit
- pushat till GitHub
- mergeat till main
