# Instalación de Sql Server en Linux con Docker

LA solución de Factotum se instalará con ASP.NET Core 6.0 y con
Sql Server 2019 en adelante. Por ello es necesario primero obtener
las imágenes que se van a instalar en nuestro contenedor.

1. Debemos obtener una imagen de la versión de SQL Server que va
a soportar nuestra solución. 

```
:~$ docker pull mcr.microsoft.com/mssql/server:2019-latest
2019-latest: Pulling from mssql/server
210a236fbb96: Pull complete
4d3b5ee6a318: Pull complete
b97468a53f24: Pull complete
Digest: sha256:f57d743a99a4003a085d0fd67dbb5ecf98812c08a616697a065082cad68d77ce
Status: Downloaded newer image for mcr.microsoft.com/mssql/server:2019-latest
mcr.microsoft.com/mssql/server:2019-latest
```

Ahora tenemos la imagen de sql server lista para ser ejecutada
en el contenedor

2. Debemos ejecutar la imagen de acuerdo a lo que indica la 
configuración pero en la red que hemos configurado anteriormente. 
También se coloca un nombre a la imagen para que sea facil referenciarla
en el futuro (factodb)
```
> docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=ESV1z#Za@06mErd' -p 1433:1433 --name artexactadb --network artexactanet -v /srv/db/data:/var/opt/mssql/data -v /srv/db/log:/var/opt/mssql/log -v /srv/db/secrets:/var/opt/mssql/secrets -d mcr.microsoft.com/mssql/server:2019-latest
Unable to find image 'mcr.microsoft.com/mssql/server:2019-latest' locally
2019-latest: Pulling from mssql/server
210a236fbb96: Pull complete
4d3b5ee6a318: Pull complete
b97468a53f24: Pull complete
Digest: sha256:f57d743a99a4003a085d0fd67dbb5ecf98812c08a616697a065082cad68d77ce
Status: Downloaded newer image for mcr.microsoft.com/mssql/server:2019-latest
b6cbec69cec1ed60f3d5b1f99b317cc526bb5fda94bb94d82a877a991eaff1f8
```
En vez de xxx averiguar la contraseña con el equipo de Artexacta.

3. LA forma que se hizo fue sacar un backup de la base de datos para poderla mover
con todos los datos de las empresas y las sucursales ya configuradas.

4. Luego se copia ese backup directamente en el servidor con scp para que se 
lo pueda cargar a la imagen de sql server del contenedor de nuestro servidor.

```
>scp factotum2019.bak admin@A.A.A.A:/home/admin/backups
admin@A.A.A.A's password:
factotum2019.bak
```
En vez del usuario admin y de la dirección ip falsa averiguar con el equipo
de Artexacta los datos correctos para la implementación original.

Verificar que el archivo fue copiado correctamente en el servidor:
```
admin@server:~/backups$ ls -al
total 44248
drwxrwxr-x 2 admin admin       30 Jan  4 11:19 .
drwxr-x--- 6 admin admin      180 Jan  4 11:16 ..
-rw-rw-r-- 1 admin admin 45309952 Jan  4 11:19 factotum2019.bak
```
5. Tenemos que copiar luego este archivo a la imagen donde esta el sql server
para que podamos restaurar desde ahi

```
admin@server:~/backups$ docker cp factotum2019.bak artexactadb:/tmp/factotum2019.bak
admin@server:~/backups$ docker exec -it artexactadb bash
mssql@a739c3217881:/$ cd /tmp
mssql@a739c3217881:/tmp$ ls
factotum2019.bak
```
Con el primer comando se copia el archivo al contenedor docker. El segundo
comando es para verificar que el arrchivo fue copiado al contenedor.

6. Ahora tenemos que restaurar la base de datos en el sqlserver. Para eso lo primero 
que haremos es crearnos un script para restaurar la base de datos.
```
RESTORE DATABASE [FacturacionDB] FROM DISK = N'/tmp/factotum2019.bak'
WITH   
   MOVE 'FacturacionDB' TO '/var/opt/mssql/data/FacturacionDB.mdf',   
   MOVE 'FacturacionDB_log' TO '/var/opt/mssql/data/FacturacionDB_Log.ldf';
GO
```
Este script asume que el backup se encuentra en la carpeta tmp. La razón por
la cual tenemos que utilizar MOVE es que la base de datos original viene de una
instalación windows que tiene direcciones propias de windows.

Este script tenemos que copiarlo desde nuestra máquina a nuestro docker y de ahí
a la imagen del Sql Server
```
>scp restoredb.sql admin@A.A.A.A:/home/admin/backups
admin@A.A.A.A's password:
restoredb.sql 	100%  231    15.9KB/s   00:00
```

Ahora nos conectamos con un shell a nuestro docker y copiamos ese archivo en 
la imagen del sql server
```
:~$ cd backups/
administrator@server:~/backups$ docker cp restoredb.sql factodb:/tmp/restoredb.sql
```

Luego nos conectamos con bash a nuestra imagen
```
admin@server:~/backups$ docker exec -it factodb bash
```

Una vez conectados y en nuestra imagen podemos ejecutar el sqlcmd para restaurar
la base de datos ejecutando el script que teníamos anteriormente
```
mssql@a739c3217881:/$ /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P xxxxx -i /tmp/restoredb.sql
Processed 5432 pages for database 'FacturacionDB', file 'FacturacionDB' on file 1.
Processed 2 pages for database 'FacturacionDB', file 'FacturacionDB_log' on file 1.
Converting database 'FacturacionDB' from version 869 to the current version 904.
Database 'FacturacionDB' running the upgrade step from version 869 to version 875.
Database 'FacturacionDB' running the upgrade step from version 875 to version 876.
Database 'FacturacionDB' running the upgrade step from version 876 to version 877.
Database 'FacturacionDB' running the upgrade step from version 877 to version 878.
Database 'FacturacionDB' running the upgrade step from version 878 to version 879.
Database 'FacturacionDB' running the upgrade step from version 879 to version 880.
Database 'FacturacionDB' running the upgrade step from version 880 to version 881.
Database 'FacturacionDB' running the upgrade step from version 881 to version 882.
Database 'FacturacionDB' running the upgrade step from version 882 to version 883.
Database 'FacturacionDB' running the upgrade step from version 883 to version 884.
Database 'FacturacionDB' running the upgrade step from version 884 to version 885.
Database 'FacturacionDB' running the upgrade step from version 885 to version 886.
Database 'FacturacionDB' running the upgrade step from version 886 to version 887.
Database 'FacturacionDB' running the upgrade step from version 887 to version 888.
Database 'FacturacionDB' running the upgrade step from version 888 to version 889.
Database 'FacturacionDB' running the upgrade step from version 889 to version 890.
Database 'FacturacionDB' running the upgrade step from version 890 to version 891.
Database 'FacturacionDB' running the upgrade step from version 891 to version 892.
Database 'FacturacionDB' running the upgrade step from version 892 to version 893.
Database 'FacturacionDB' running the upgrade step from version 893 to version 894.
Database 'FacturacionDB' running the upgrade step from version 894 to version 895.
Database 'FacturacionDB' running the upgrade step from version 895 to version 896.
Database 'FacturacionDB' running the upgrade step from version 896 to version 897.
Database 'FacturacionDB' running the upgrade step from version 897 to version 898.
Database 'FacturacionDB' running the upgrade step from version 898 to version 899.
Database 'FacturacionDB' running the upgrade step from version 899 to version 900.
Database 'FacturacionDB' running the upgrade step from version 900 to version 901.
Database 'FacturacionDB' running the upgrade step from version 901 to version 902.
Database 'FacturacionDB' running the upgrade step from version 902 to version 903.
Database 'FacturacionDB' running the upgrade step from version 903 to version 904.
RESTORE DATABASE successfully processed 5434 pages in 8.346 seconds (5.086 MB/sec).
```
7. Instalar mssql-tools en nuestro ambiente Linux para ver si desde afuera nos 
podemos conectar al Sql Server publicado en la imagen de docker.

Debemos traer los certificados para poder traer los repositorios donde están los
ejecutables.
```
:~$ curl https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -
[sudo] password for admin:   % Total    % Received % Xferd  Average Speed   Time    Time     Time  Current
                                 Dload  Upload   Total   Spent    Left  Speed
100   983  100   983    0     0    828      0  0:00:01  0:00:01 --:--:--   828

Sorry, try again.
[sudo] password for admin:
Warning: apt-key is deprecated. Manage keyring files in trusted.gpg.d instead (see apt-key(8)).
OK
```

Aparece un warning pero no debería haber mayor problema. Luego se añade el repositorio
de los ejecutables a la lista normal de paquetes.
```
admin@server:~$ curl https://packages.microsoft.com/config/ubuntu/20.04/prod.list | sudo tee /etc/apt/sources.list.d/msprod.list
  % Total    % Received % Xferd  Average Speed   Time    Time     Time  Current
                                 Dload  Upload   Total   Spent    Left  Speed
100    89  100    89    0     0     78      0  0:00:01  0:00:01 --:--:--    78
deb [arch=amd64,armhf,arm64] https://packages.microsoft.com/ubuntu/20.04/prod focal main
```

Ahora sí podemos realizar la seguidilla de apt-get update y apt-get install para poder
instalar nuestro útil
```
admin@server:~$ sudo apt-get update
Hit:1 http://archive.ubuntu.com/ubuntu jammy InRelease
Hit:2 http://archive.ubuntu.com/ubuntu jammy-updates InRelease
Hit:3 https://packages.microsoft.com/ubuntu/20.04/mssql-server-2019 focal InRelease
Get:4 https://packages.microsoft.com/ubuntu/20.04/prod focal InRelease [10.5 kB]
Hit:5 http://archive.ubuntu.com/ubuntu jammy-backports InRelease
Get:6 https://packages.microsoft.com/ubuntu/20.04/prod focal/main armhf Packages [30.6 kB]
Hit:7 http://archive.ubuntu.com/ubuntu jammy-security InRelease
Get:8 https://packages.microsoft.com/ubuntu/20.04/prod focal/main amd64 Packages [222 kB]
Get:9 https://packages.microsoft.com/ubuntu/20.04/prod focal/main arm64 Packages [47.7 kB]
Fetched 311 kB in 2s (179 kB/s)
Reading package lists... Done

admin@server:~$ sudo apt-get install mssql-tools
Reading package lists... Done
Building dependency tree... Done
Reading state information... Done
The following additional packages will be installed:
  libltdl7 libodbc2 libodbcinst2 msodbcsql17 odbcinst unixodbc unixodbc-common
Suggested packages:
  odbc-postgresql tdsodbc
The following NEW packages will be installed:
  libltdl7 libodbc2 libodbcinst2 msodbcsql17 mssql-tools odbcinst unixodbc unixodbc-common
0 upgraded, 8 newly installed, 0 to remove and 128 not upgraded.
Need to get 1,232 kB of archives.
After this operation, 1,201 kB of additional disk space will be used.
Do you want to continue? [Y/n] Y
```
El sistema preguntará varias veces si desea confirmar y aceptar la licencia. Luego de
darle Y entonces comienza la instalación.

8. Tratar de conectarnos con el sqlcmd desde nuestro host a la imagen de sqlserver
que está corriendo en nuestro docker.

```
:~$ sqlcmd -S localhost -U SA -P xxxxx
1> use FacturacionDB
2> go
Changed database context to 'FacturacionDB'.
1> exit
```
De esta manera ya tenemos nuestra base de datos funcionando como imagen de un Docker.
Además, por la forma como fue publicada, el puerto 1433 de nuestro host puede estar
expuesto a internet (detrás de un firewall) y adicionalmente se puede ver la base 
de datos desde nuestro SSMS.

## Backup de una base de datos

