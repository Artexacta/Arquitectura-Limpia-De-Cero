# Configuración de la red de Docker

Debemos crear una red para poder comunicar fácilmente la imagen
de la base de datos y la imagen de la aplicación factotum.

1. Se debe crear la red factonet

```
:~$ docker network create factonet
7154520f034ffd6e9ca22699425282703be5affb4b032afef7d3380b5fa65bab
```

2. Para cada una de las imágenes que vamos a publicar en nuestro 
docker se debe utilizar la red donde se la va a publicar dentro
de nuestro docker

```
$ docker run -d --name my-container1 --network my-network my-image1
$ docker run -d --name my-container2 --network my-network my-image2
```
