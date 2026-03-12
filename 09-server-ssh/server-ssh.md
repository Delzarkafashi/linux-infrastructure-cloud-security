# Lesson 9 – Server och SSH

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

## Sammanfattning

I denna lesson har vi:

- installerat och kontrollerat SSH-servern
- testat SSH-anslutning
- skapat en SSH-nyckel
- installerat nyckeln på servern
- konfigurerat säkrare SSH-inställningar
- startat om och verifierat SSH-tjänsten
