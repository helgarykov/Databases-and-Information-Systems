@echo off

set PGPASSWORD=1234
set loc=%cd%\PostgreSQL\Easy_Translate.sql

psql -h localhost -U postgres -d postgres -p 5432 -f %loc%
