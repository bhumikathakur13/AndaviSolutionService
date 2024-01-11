CREATE PROCEDURE dbo.UpdateItem
    @Name VARCHAR,
    @Description VARCHAR,
    @ModifiedBy VARCHAR,
    @ModifiedDate VARCHAR
AS
BEGIN
    BEGIN
        -- If the user doesn't exist, insert the record
        UPDATE Items SET Description=@Description, ModifiedBy=@ModifiedBy, ModifiedDate=@ModifiedDate)
        WHERE Name=@Name;

        RETURN 1;
    END
    ELSE
        -- If the item already exists, return an error message or take appropriate action
        RETURN 0;
END