# Network

I detta steg lär vi oss grunderna i nätverk i Linux.

Vi tittar på:

- IP-adresser
- anslutning till andra servrar
- öppna portar i systemet

Steg 1 – Se IP-adress

Skriv:

ip a

Tryck Enter.

Detta visar nätverksinformation för datorn.

Du kan se olika nätverkskort och vilken IP-adress systemet har.

Steg 2 – Testa nätverk

Vi testar om datorn kan nå en annan server på internet.

Skriv:

ping google.com

Tryck Enter.

Om nätverket fungerar kommer du se svar från servern.

Exempel:

64 bytes from ...

Stoppa ping genom att trycka:

Ctrl + C

Steg 3 – Se öppna portar

Vi kan se vilka portar och tjänster som är aktiva i systemet.

Skriv:

ss -tuln

Tryck Enter.

Detta visar vilka portar som används och vilka tjänster som lyssnar på nätverket.
