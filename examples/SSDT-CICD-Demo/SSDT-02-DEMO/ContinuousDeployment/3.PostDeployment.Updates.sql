/*
This will be executed during the post-deployment phase.
Use it to apply scripts which are supposed to modify the 
data after the schema update took place.

!!!Make sure your scripts are idempotent(repeatable)!!!

Example invocation:
EXEC sp_execute_script @sql = 'UPDATE Table....', @author = 'Your Name'
*/
IF '($DatabaseName)' = 'targetDb01'
BEGIN
    :r \Datapatches\targetDb01\_.main.datapatch.sql
END
IF '($DatabaseName)' = 'targetDb02'
BEGIN
    :r \Datapatches\targetDb02\_.main.datapatch.sql
END