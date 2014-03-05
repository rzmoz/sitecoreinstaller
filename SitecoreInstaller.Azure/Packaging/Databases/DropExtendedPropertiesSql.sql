IF EXISTS (SELECT NULL FROM SYS.EXTENDED_PROPERTIES WHERE [major_id] = OBJECT_ID('Fields') AND [name] = N'MS_DiagramPaneCount' AND [minor_id] = 0)
BEGIN
EXEC sp_dropextendedproperty 
@name = N'MS_DiagramPaneCount'
,@level0type = 'schema' 
,@level0name = dbo
,@level1type = 'view'
,@level1name = 'Fields';
END
IF EXISTS (SELECT NULL FROM SYS.EXTENDED_PROPERTIES WHERE [major_id] = OBJECT_ID('Fields') AND [name] = N'MS_DiagramPane1' AND [minor_id] = 0)
BEGIN
EXEC sp_dropextendedproperty 
@name = N'MS_DiagramPane1'
,@level0type = 'schema' 
,@level0name = dbo
,@level1type = 'view'
,@level1name = 'Fields';
END
