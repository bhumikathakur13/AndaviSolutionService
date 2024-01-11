CREATE PROCEDURE dbo.DeleteItem
    @Name NVARCHAR(50),
    @RowsAffected INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM YourTableName
    WHERE Name = @Name;

    -- Capture the number of rows affected
    SELECT @RowsAffected = @@ROWCOUNT;
    
    RETURN @RowsAffected;
END
