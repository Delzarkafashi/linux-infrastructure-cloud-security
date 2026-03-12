# 08-services

I denna del arbetade vi med tjänster i Linux.

En tjänst är ett program som körs i bakgrunden och hanteras av systemet.  
Tjänster används till exempel för webbservrar, databaser, fjärrinloggning och containers.

Vi använde kommandot `systemctl` för att starta, stoppa och kontrollera tjänster.

---

# nginx

Nginx är en webbserver.

## Installera

sudo apt install nginx

## Kontrollera status

systemctl status nginx

## Starta

sudo systemctl start nginx

## Stoppa

sudo systemctl stop nginx

## Starta om

sudo systemctl restart nginx

---

# ssh

SSH används för fjärrinloggning till en server.

## Installera

sudo apt install openssh-server

## Kontrollera status

systemctl status ssh

## Starta

sudo systemctl start ssh

## Stoppa

sudo systemctl stop ssh

---

# mysql

MySQL är en databasserver.

## Installera

sudo apt install mysql-server

## Kontrollera status

systemctl status mysql

## Starta

sudo systemctl start mysql

## Stoppa

sudo systemctl stop mysql

## Starta om

sudo systemctl restart mysql

---

# docker

Docker används för att köra containers.

## Installera

sudo apt install docker.io

## Kontrollera status

systemctl status docker

## Starta

sudo systemctl start docker

## Stoppa

sudo systemctl stop docker

## Starta om

sudo systemctl restart docker

---

# Sammanfattning

I denna del lärde vi oss hur man arbetar med tjänster i Linux.

Viktiga kommandon:

systemctl status tjänst  
sudo systemctl start tjänst  
sudo systemctl stop tjänst  
sudo systemctl restart tjänst  

Tjänster vi installerade:

nginx  
ssh  
mysql  
docker
