#Setup local db (Sql server)
 docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU21-ubuntu-20.04
 
 yourStrong(!)Password
 
 
 Host: gatosddbb.cqqxlretd9wc.us-east-1.rds.amazonaws.com
       
 Contraseña: QgrcJHrhvWgXFcnlZgtlCRfZZTjxTBZNskv
 
 docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d agimenezg/redaguapo:1.0
 
 
 Eliminar DB
 
 DROP DATABASE GatosDB;