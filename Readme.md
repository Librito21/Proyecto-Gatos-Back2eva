#Setup local db (Sql server)
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1443:1433 -d mcr.microsoft.com/mssql/server:2019-CU21-ubuntu-20.04

yourStrong(!)Password


Eliminar DB

DROP DATABASE GatosDB;