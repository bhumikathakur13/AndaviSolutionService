CREATE PROCEDURE dbo.AddItem
    @Name VARCHAR,
    @Description VARCHAR,
    @CreatedBy VARCHAR,
    @CreatedDate VARCHAR
AS
BEGIN
    -- Check if the user already exists
    IF NOT EXISTS (SELECT 1 FROM Items WHERE Name = @Name)
    BEGIN
        -- If the user doesn't exist, insert the record
        INSERT INTO Items (Name, Description, CreatedBy, CreatedDate)
        VALUES (@Name, @Description, @CreatedBy, @CreatedDate);

        RETURN 1;
    END
    ELSE
        -- If the item already exists, return an error message or take appropriate action
        RETURN 0;
END