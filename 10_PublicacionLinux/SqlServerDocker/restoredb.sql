RESTORE DATABASE [FacturacionDB] FROM DISK = N'/tmp/factotum2019.bak'
WITH   
   MOVE 'FacturacionDB' TO '/var/opt/mssql/data/FacturacionDB.mdf',   
   MOVE 'FacturacionDB_log' TO '/var/opt/mssql/data/FacturacionDB_Log.ldf';
GO