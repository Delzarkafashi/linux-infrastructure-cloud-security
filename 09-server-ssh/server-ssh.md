# Lesson 9 - Server och SSH

I denna del lärde vi oss hur man installerar och konfigurerar en SSH-server i Linux för att kunna ansluta säkert till en server.

## Kontrollera SSH-server

Först kontrollerade vi om SSH-servern fanns installerad och om tjänsten kördes.

systemctl status ssh

Om tjänsten inte körs kan man starta den med:

sudo systemctl start ssh


## Testa SSH lokalt

Vi testade att ansluta till vår egen maskin.

ssh localhost

Detta skapade två filer:

~/.ssh/id_ed25519  
~/.ssh/id_ed25519.pub  

Den privata nyckeln stannar på klienten och den publika nyckeln kan delas med servern.


## Installera nyckeln på servern

Vi installerade den publika nyckeln på servern.

ssh-copy-id delzar@localhost

Detta lägger till nyckeln i filen:

~/.ssh/authorized_keys

Nu kan vi logga in utan lösenord.


## Testa SSH-inloggning

Efter att nyckeln installerats testade vi igen.

ssh delzar@localhost

Nu loggar vi in via SSH-nyckel istället för lösenord.


## Säkerhetsinställningar

För att göra servern säkrare ändrade vi SSH-konfigurationen.

sudo nano /etc/ssh/sshd_config

Vi ändrade följande inställningar:

PermitRootLogin no  
PasswordAuthentication no  

Detta gör att:

- root inte kan logga in via SSH
- lösenordsinloggning är avstängd
- endast SSH-nycklar tillåts


## Starta om SSH

Efter ändringar måste tjänsten startas om.

sudo systemctl restart ssh


## Kontrollera att SSH körs

systemctl status ssh

Om status visar `active (running)` fungerar servern korrekt.


## GitHub SSH authentication

För att kunna pusha till GitHub utan lösenord kopplade vi vår SSH-nyckel till GitHub.

### Visa SSH-nyckeln

cat ~/.ssh/id_ed25519.pub

Den publika nyckeln kopierades och lades in i GitHub under:

Settings → SSH and GPG keys → New SSH key


### Testa GitHub SSH

ssh -T git@github.com

Om allt fungerar visas ett meddelande som:

Hi username! You've successfully authenticated, but GitHub does not provide shell access.


## Arbeta från servermiljön

Vi arbetade direkt från vår Linux-miljö (WSL) som fungerade som vår servermiljö.

Vi skapade en ny branch för denna lesson.

git checkout -b 09-server-ssh

Sedan skapade vi en mapp för lektionen.

mkdir 09-server-ssh

Vi skapade dokumentationsfilen.

nano server-ssh.md

Efter det lade vi till filen i Git.

git add .
git commit -m "add server and ssh lesson"

Sedan pushade vi branchen till GitHub via SSH.

git push origin 09-server-ssh

Eftersom GitHub är kopplat via SSH behövdes inget lösenord, bara passphrase för SSH-nyckeln.


## Merge till main

När branchen var pushad mergade vi den till main.

git checkout main  
git pull origin main  
git merge 09-server-ssh  
git push origin main


## Sammanfattning

I denna lesson har vi:

- installerat och kontrollerat SSH-servern
- testat SSH-anslutning
- skapat en SSH-nyckel
- installerat nyckeln på servern
- konfigurerat säkrare SSH-inställningar
- startat om och verifierat SSH-tjänsten
- kopplat SSH till GitHub
- arbetat direkt från Linux-servermiljön
- pushat kod till GitHub via SSH
- mergat branchen till main
