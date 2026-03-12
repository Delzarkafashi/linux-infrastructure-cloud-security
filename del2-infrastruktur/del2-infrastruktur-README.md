# Del 2 – Infrastruktur

I denna del bygger vi upp infrastrukturen bakom en applikation. Vi lär oss hur nätverk, servrar och databaser fungerar tillsammans genom att samtidigt bygga en enkel fullstack-miljö.

## Arbetsmetod

Vi arbetar steg för steg och kopplar varje del till en riktig applikation med frontend, backend och databas.

## Steg

### 1. Nätverk
Förstå hur klient och server kommunicerar i ett nätverk.  
Vi tittar på IP-adresser, portar och testar verktyg som `ping`, `ip` och `ss`.

### 2. DNS
Lära oss hur ett domännamn översätts till en IP-adress.  
Testa uppslag med `nslookup` eller `dig`.

### 3. Webserver
Installera och konfigurera en webserver som **Nginx** eller **Apache**.  
Servern ska kunna ta emot trafik på port 80 eller 443 och visa en webbsida.

### 4. Databasserver
Installera en databas som **PostgreSQL** eller **MySQL**.  
Skapa databaser och tabeller och låt backend ansluta till databasen.

### 5. Virtualisering
Förstå hur system kan köras isolerat från varandra.  
Testa exempelvis **Docker** för att köra olika delar av systemet i containers.

### 6. Serverarkitektur
Sätta ihop hela systemet:

Frontend → Webserver → Backend → Databas

Målet är att förstå hur hela infrastrukturen bakom en applikation fungerar.

## Mål

Efter denna del ska vi förstå:

- hur nätverk fungerar mellan klient och server  
- hur DNS kopplar domännamn till servrar  
- hur en webserver levererar en applikation  
- hur backend kommunicerar med en databas  
- hur containers och virtualisering används  
- hur hela serverarkitekturen hänger ihop
