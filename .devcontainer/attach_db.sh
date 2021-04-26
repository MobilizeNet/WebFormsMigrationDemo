sleep 30s
echo "Creating the HiringDb"
echo "Starting..."
/opt/mssql-tools/bin/sqlcmd -S . -U sa -P Password1$ \
-Q "CREATE DATABASE [HiringDb] ON (FILENAME ='/db/HiringDb.mdf'),(FILENAME = '/db/HiringDb_log.ldf') FOR ATTACH"
echo "Done creating HiringDb"
