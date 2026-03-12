# Users och rättigheter i Linux

I denna del lär vi oss hur man arbetar med användare i Linux och hur olika användare kan ha olika rättigheter till filer.

Linux är ett fleranvändarsystem där varje användare kan ha egna rättigheter och tillgång till olika delar av systemet.

Denna del täcker två viktiga områden:

5 Användare  
6 Rättigheter (permissions)

---

## Skapa användare

Vi skapade två nya användare utöver admin-användaren.

Admin i detta fall är användaren som redan finns i systemet.

delzar → admin  
staff → anställd  
viewer → läsare  

Skapa användare:

sudo useradd -m staff  
sudo passwd staff  

sudo useradd -m viewer  
sudo passwd viewer  

---

## Byta användare

För att testa olika rättigheter kan man logga in som en annan användare.

su staff  

Kontrollera vilken användare du är inloggad som:

whoami  

Gå tillbaka till din vanliga användare:

exit  

---

## Skapa testmapp

Vi skapade en mapp där vi testar olika rättigheter.

mkdir permission-test  
cd permission-test  

---

## Skapa filer

Vi skapade två filer som ska ha olika rättigheter.

touch admin-only.txt  
touch staff-edit.txt  

---

## Sätta rättigheter

### Admin-fil

Denna fil ska bara admin kunna läsa och skriva.

chmod 600 admin-only.txt  

Det betyder:

admin → läsa och skriva  
staff → ingen access  
viewer → ingen access  

---

### Staff-fil

Denna fil ska admin och staff kunna skriva i.  
Viewer ska bara kunna läsa.

Ändra grupp:

sudo chown delzar:staff staff-edit.txt  

Sätt rättigheter:

chmod 664 staff-edit.txt  

Det betyder:

admin → läsa och skriva  
staff → läsa och skriva  
viewer → läsa  

---

## Lägga till text i filer

Som admin skrev vi text i filerna.

echo "Detta är admin-fil. Bara admin ska kunna läsa och skriva här." > admin-only.txt  

echo "Detta är staff-fil. Staff och admin kan skriva. Viewer kan bara läsa." > staff-edit.txt  

---

## Testa rättigheter

### Testa viewer

su viewer  

Försök läsa admin-filen:

cat admin-only.txt  

Resultat:

Permission denied  

Viewer kan däremot läsa staff-filen:

cat staff-edit.txt  

---

### Testa staff

su staff  

Kontrollera användare:

whoami  

staff kan läsa staff-filen:

cat staff-edit.txt  

staff kan också skriva i filen:

echo "Staff har skrivit detta." >> staff-edit.txt  

Kontrollera:

cat staff-edit.txt  

---

## Sammanfattning

I denna del har vi arbetat med två viktiga delar i Linux:

### 5 Användare

Vi lärde oss att:

- skapa användare
- sätta lösenord
- logga in som olika användare

Kommandon:

useradd  
passwd  
su  
whoami  

---

### 6 Rättigheter (permissions)

Vi lärde oss att:

- skapa filer
- sätta rättigheter
- ändra ägare och grupp
- testa vad olika användare får göra

Kommandon:

chmod  
chown  
ls -l  

---

## Resultat

Vi skapade två filer med olika rättigheter:

admin-only.txt  
bara admin kan läsa och skriva

staff-edit.txt  
admin och staff kan skriva  
viewer kan bara läsa
