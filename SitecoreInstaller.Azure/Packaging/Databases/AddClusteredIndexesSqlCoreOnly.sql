--Core Only
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('RolesInRoles'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON RolesInRoles(Id)
END