# Instalación Docker

La conexión con el servidor se realiza solamente a través de una
conexión SSH con la siguiente información. (favor ver los datos
reales con el personal de Artexacta autorizado)

```
IP Publica: A.A.A.A
IP Privada: B.B.B.B
Usuario: admin
Contraseña: admin123
```

Cuando se conecta por SSH el mensaje es:

```
Welcome to Ubuntu 22.04.1 LTS (GNU/Linux 5.15.0-43-generic x86_64)
```

Así tenemos la versión y el tipo de distribución que se tiene 
instalado. 
Para lograr instalar se corrieron los siguientes comandos 
en el servidor Linux.

1. Primero ver si no se tiene el comando ya instalado

```
:~$ docker
Command 'docker' not found,
```
2. Si no está instalado entonces ejecutar lo siguiente para su
instalación

```
:~$ sudo snap install docker
[sudo] password for admin:
docker 20.10.17 from Canonical✓ installed

sudo apt install docker.io docker-compose
sudo reboot
```

3. Verificar que la instalación permite ejecutar el comando 
docker

```
:~$ docker ps
Got permission denied while trying to connect to the Docker daemon socket at unix:///var/run/docker.sock: Get "http://%2Fvar%2Frun%2Fdocker.sock/v1.24/containers/json": dial unix /var/run/docker.sock: connect: permission denied
```
4. Ejecutar lo siguiente para habilitar permisos para el 
grupo docker y cambiar los permisos dentro del nodo que
maneja docker

```
:~$ sudo groupadd docker
:~$ sudo usermod -aG docker administrator
```
Luego de este comando hacer logout y login con el usuario
para que tome los permisos necesarios. Luego:

```
:~$ sudo chmod 666 /var/run/docker.sock
[sudo] password for admin:
```
5. En este momento debería poder ejecutar docker sin
problemas, para probarlo podemos ejecutar un hello world
```
:~$ docker run hello-world
Unable to find image 'hello-world:latest' locally
latest: Pulling from library/hello-world
2db29710123e: Pull complete
Digest: sha256:94ebc7edf3401f299cd3376a1669bc0a49aef92d6d2669005f9bc5ef028dc333
Status: Downloaded newer image for hello-world:latest

Hello from Docker!
This message shows that your installation appears to be working correctly.

To generate this message, Docker took the following steps:
 1. The Docker client contacted the Docker daemon.
 2. The Docker daemon pulled the "hello-world" image from the Docker Hub.
    (amd64)
 3. The Docker daemon created a new container from that image which runs the
    executable that produces the output you are currently reading.
 4. The Docker daemon streamed that output to the Docker client, which sent it
    to your terminal.

To try something more ambitious, you can run an Ubuntu container with:
 $ docker run -it ubuntu bash

Share images, automate workflows, and more with a free Docker ID:
 https://hub.docker.com/

For more examples and ideas, visit:
 https://docs.docker.com/get-started/
```
En este momento ya podemos ver los contenedores y las imágenes
que se están ejecutando:
```
:~$ docker ps
CONTAINER ID   IMAGE     COMMAND   CREATED   STATUS    PORTS     NAMES
```

6. Si por cualquier motivo su instalación de docker no está
ejecutándose de manera correcta, entonces puede tratar de desinstalar 
e instlaar con apt que es una alternativa

```
sudo snap remove docker
sudo reboot

sudo apt update
sudo apt upgrade

sudo apt install docker.io docker-compose
sudo reboot
```
Lo primero que hacemos es desinstalar docker y luego instalamos
nuevamente pero con apt. Lo que hacemos finalmente es reiniciar
nuestro servidor para ver si todo está funcionando correctamente.

7. Adicionalmente, y para los ejercicios que haremos a futuro no
es mala idea crear una red para todas nuestras imágenes de Docker.
Esto permite compartir ciertos recursos de red que pueden ser beneficiosos
como por ejemplo una sola base de datos o aplicaciones tipo microservicios.
```
docker network create artexactanet
```
