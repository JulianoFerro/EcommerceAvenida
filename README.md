# EcommerceAvenida

Categoria e produtos prontos

OBS: FluentMigration não está colocando autoincrement na key
ALTER TABLE Categoria DROP COLUMN ID 
ALTER TABLE Categoria ADD ID INT IDENTITY(1,1)
ou faz pelo VisualStudio mesmo.

Vou mudar depois pro entity as migrations.
