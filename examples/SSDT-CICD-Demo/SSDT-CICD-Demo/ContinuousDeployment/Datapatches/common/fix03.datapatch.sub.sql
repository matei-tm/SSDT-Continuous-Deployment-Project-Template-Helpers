-- SSDT-CD Datapatch Wrapper v1.0
-- ---------------------------------------------
-- | The content was changed by a tool         |
-- ---------------------------------------------
-- A *.sub.sql file will provide a configuration UI allowing a filtered promotion

EXEC sp_execute_script @sql ='
INSERT INTO sample VALUES (1, ''Alfa is a ''''leader'''''');
INSERT INTO sample VALUES (2, ''Beta is a ''''challenger'''' '');
INSERT INTO sample VALUES (3, ''Gamma is a letter'');
INSERT INTO sample VALUES (5, '' is just an item'');
', @author = 'matei';
