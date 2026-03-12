# Program och paket i Linux

I denna del lär vi oss hur man installerar och hanterar program i Linux.

Linux använder ett system som kallas **pakethanterare** för att installera och uppdatera program.

I Ubuntu och Debian används verktyget:

apt

Med apt kan vi:

- uppdatera paketlistor
- installera program
- ta bort program
- söka efter program

---

## Uppdatera paketlistan

Innan man installerar nya program bör man uppdatera listan över tillgängliga paket.

sudo apt update

Detta hämtar information från Linux programarkiv (repositories) så att systemet vet vilka program som finns tillgängliga.

---

## Installera program

För att installera ett program använder man:

sudo apt install paketnamn

---

## Paket vi installerade

I denna del installerade vi fyra vanliga verktyg:

tree  
htop  
curl  
neofetch

---

## tree

tree visar filer och mappar som en trädstruktur.

Installera:

sudo apt install tree

Exempel:

tree

Det gör det lättare att se projektstrukturer och mappar.

---

## htop

htop är ett verktyg som visar systemets processer, CPU och RAM användning.

Installera:

sudo apt install htop

Starta:

htop

Det används ofta för att övervaka systemets prestanda.

---

## curl

curl används för att hämta data från internet, till exempel API:er eller webbsidor.

Installera:

sudo apt install curl

Exempel:

curl https://example.com

---

## neofetch

neofetch visar systeminformation om datorn.

Installera:

sudo apt install neofetch

Kör:

neofetch

Det visar bland annat:

- operativsystem
- kernel
- CPU
- RAM
- systeminformation

---

## Kontrollera version av paket

Efter att ett paket är installerat kan man kontrollera vilken version som finns installerad.

Exempel:

tree --version
htop --version
curl --version
neofetch --version

Detta visar vilken version av programmet som är installerad i systemet.

---
<<<<<<< HEAD

=======
>>>>>>> 07-packages
## Sammanfattning

I denna del lärde vi oss hur man installerar program i Linux med apt.

Viktiga kommandon:

sudo apt update  
sudo apt install paketnamn

Vi installerade även fyra användbara verktyg:

tree  
htop  
curl  
neofetch

Dessa verktyg används ofta i Linux för att arbeta med systemet, felsöka och hämta information.
