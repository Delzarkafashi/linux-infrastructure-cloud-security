# Koppla GitHub till din terminal med SSH

## Steg 1 – Skapa en SSH-nyckel

Skriv i terminalen:

ssh-keygen -t ed25519 -C "din-email@gmail.com"

Tryck **Enter** när den frågar om filnamn.

När den frågar om lösenord kan du trycka **Enter** två gånger om du vill hoppa över det.

Efter detta skapas två filer:

~/.ssh/id_ed25519  
~/.ssh/id_ed25519.pub

---

## Steg 2 – Visa din public key

Skriv:

cat ~/.ssh/id_ed25519.pub

Du kommer se något liknande:

ssh-ed25519 AAAAC3NzaC1lZDI1NTE5AAAAIxxxxxxxxxxxxxxxx user@email.com

Kopiera **hela raden**.

---

## Steg 3 – Lägg till SSH-nyckeln i GitHub

Gå till:

https://github.com/settings/keys

Klicka på:

New SSH key

Fyll i:

Title:

WSL Laptop

Key:

Klistra in din **SSH-nyckel**.

Klicka på:

Add SSH key

---

## Steg 4 – Koppla projektet till SSH

Gå till din projektmapp i terminalen och skriv:

git remote set-url origin git@github.com:USERNAME/REPOSITORY.git

Exempel:

git remote set-url origin git@github.com:Delzarkafashi/linux-infrastructure-cloud-security.git

---

## Steg 5 – Testa anslutningen

Skriv:

git push

Första gången kommer Git fråga:

Are you sure you want to continue connecting (yes/no)?

Skriv:

yes

Tryck **Enter**.

---

## Klart

Nu är GitHub kopplat till din terminal via SSH och du kan pusha kod direkt från terminalen utan lösenord eller token.
