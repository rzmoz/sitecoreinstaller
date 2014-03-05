--All dbs
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('ArchivedFields'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON ArchivedFields(RowId)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('ArchivedItems'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON ArchivedItems(RowId)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('Blobs'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON Blobs(Id)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('ClientData'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON ClientData(Id)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('History'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON History(Id)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('IDTable'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON IDTable(Id)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('Items'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON Items(Id)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('Links'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON Links(Id)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('Notifications'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON Notifications(Id)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('Properties'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON Properties(Id)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('PublishQueue'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON PublishQueue(Id)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('Shadows'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON Shadows(Id)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('Sharedfields'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON Sharedfields(Id)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('Tasks'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON Tasks(Id)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('UnversionedFields'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON UnversionedFields(Id)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('VersionedFields'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON VersionedFields(Id)
END
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name='ClusteredIndexForAzure' AND object_id = OBJECT_ID('WorkflowHistory'))
BEGIN
    CREATE CLUSTERED INDEX ClusteredIndexForAzure ON WorkflowHistory(Id)
END
