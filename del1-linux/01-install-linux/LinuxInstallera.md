# Installera Linux på Windows med WSL och Ubuntu

## Steg 1 – Öppna Kommandotolken som administratör

1. Klicka på **Start**
2. Skriv **cmd**
3. Högerklicka på **Kommandotolken**
4. Välj **Kör som administratör**

---

## Steg 2 – Installera WSL

Skriv i Kommandotolken:
wsl --install
Tryck **Enter**.

---

## Steg 3 – Starta om datorn

När installationen är klar behöver datorn startas om.

1. Starta om datorn
2. Logga in igen

---

## Steg 4 – Installera Ubuntu (om den inte startar automatiskt)

Öppna **Kommandotolken som administratör** igen och skriv:
wsl --install -d Ubuntu
Tryck **Enter**.

---

## Steg 5 – Vänta på installationen

Ubuntu kommer nu installeras. Du kan se text som:
Installing: Ubuntu
Provisioning the new WSL instance Ubuntu
This might take a while...

## Steg 6 – Skapa användare och lösenord

När installationen är klar kommer Ubuntu be dig skapa en användare.

Exempel:
Create a default Unix user account: username

Gör följande:

1. Skriv ett **användarnamn**
2. Skriv ett **lösenord**
3. Skriv lösenordet **igen**

OBS: När du skriver lösenordet syns inga tecken. Det är normalt i Linux.

---

## Steg 7 – Kontrollera att Linux fungerar

När du ser något liknande detta är Linux igång:
username@DESKTOP:~$

Testa genom att skriva:
echo "Hello world"
Tryck **Enter**.

Om texten `Hello world` visas fungerar Linux.

---

## Steg 8 – Uppdatera paketlistan

Skriv:
sudo apt update

Tryck **Enter**.

Systemet kommer fråga efter ditt lösenord.

---

## Steg 9 – Uppgradera systemet

Skriv:
sudo apt upgrade

Tryck **Enter**.

När systemet frågar om du vill fortsätta skriver du:
Y

Tryck **Enter**.

---

## Klart

Nu har du:

- installerat **WSL**
- installerat **Ubuntu**
- startat **Linux**
- skapat användare och lösenord
- testat att Linux fungerar
- uppdaterat systemet
