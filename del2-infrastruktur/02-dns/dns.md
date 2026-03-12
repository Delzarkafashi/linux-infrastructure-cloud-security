# DNS

I detta steg lär vi oss hur DNS fungerar.

DNS betyder Domain Name System och används för att översätta ett domännamn till en IP-adress.

Exempel:

google.com → 172.217.22.142

Det gör att vi kan skriva ett namn istället för en IP-adress när vi ansluter till en server.

Steg 1 – Installera DNS-verktyg

Om kommandot `nslookup` inte finns installerat kan vi installera det.

Skriv:

sudo apt install dnsutils

Tryck Enter.

När systemet frågar om du vill fortsätta skriver du:

Y

Tryck Enter.

Steg 2 – Testa DNS med nslookup

Skriv:

nslookup google.com

Tryck Enter.

Du kommer se något liknande:

Name: google.com  
Address: 172.217.xx.xxx

Det betyder att DNS har översatt domännamnet till en IP-adress.

Steg 3 – Testa DNS med dig

Skriv:

dig google.com

Tryck Enter.

Detta kommando visar mer detaljerad information om DNS-uppslaget.

Exempel:

ANSWER SECTION:
google.com.   243   IN   A   172.217.xx.xxx

Det visar vilken IP-adress domännamnet pekar på.

Klart

Nu har du:

testat DNS-uppslag  
sett hur ett domännamn översätts till en IP-adress  
använt kommandona `nslookup` och `dig`
