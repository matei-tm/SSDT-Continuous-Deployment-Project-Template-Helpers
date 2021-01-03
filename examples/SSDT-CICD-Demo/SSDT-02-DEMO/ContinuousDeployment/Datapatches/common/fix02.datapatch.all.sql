-- SSDT-CD Datapatch Wrapper v1.0
-- ---------------------------------------------
-- | The content was changed by a tool         |
-- ---------------------------------------------
-- A *.all.sql file will be promotted to all sibling *.main.datapatch.sql files

EXEC sp_execute_script @sql ='
INSERT INTO sample VALUES (1, ''Alfa is a ''''leader'''''');
INSERT INTO sample VALUES (2, ''Beta is a ''''challenger'''' '');
INSERT INTO sample VALUES (3, ''Gamma is a letter'');
INSERT INTO sample VALUES (4, '''''' is a quotation mark'');
', @author = 'matei';
