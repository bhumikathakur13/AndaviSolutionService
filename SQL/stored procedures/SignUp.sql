CREATE PROCEDURE dbo.InsertUser
    @Username VARCHAR(20),
    @Password VARCHAR(50)
AS
BEGIN
    -- Check if the user already exists
    IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = @Username)
    BEGIN
        -- If the user doesn't exist, insert the record
        INSERT INTO Users (Username, Password)
        VALUES (@Username, @Password);

        RETURN 1;
    END
    ELSE
        -- If the user already exists, return an error message or take appropriate action
        RETURN 0;
END
