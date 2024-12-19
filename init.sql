-- Check if the database exists and create it if not
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'BaseDB')
BEGIN
    CREATE DATABASE BaseDB;
END
GO

USE BaseDB;
GO

-- Check if the Products table exists and create it if not
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Products')
BEGIN
    CREATE TABLE Products (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Type NVARCHAR(50) NOT NULL,
        Name NVARCHAR(100) NOT NULL,
        Description NVARCHAR(500),
        Data NVARCHAR(MAX),
        Created DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
        CreatedBy NVARCHAR(100),
        LastModified DATETIME2,
        LastModifiedBy NVARCHAR(100)
    );
END
GO

-- Stored Procedure to update an entity with validation
CREATE PROCEDURE sp_UpdateEntity
    @Id INT,
    @Name NVARCHAR(100),
    @Description NVARCHAR(500),
    @Data NVARCHAR(MAX),
    @LastModifiedBy NVARCHAR(100)
AS
BEGIN
    -- Check if the entity exists
    IF NOT EXISTS (SELECT 1 FROM Products WHERE Id = @Id)
    BEGIN
        RAISERROR('Entity with ID %d not found', 16, 1, @Id);
        RETURN;
    END

    -- Proceed to update if the entity exists
    UPDATE Products
    SET Name = @Name,
        Description = @Description,
        Data = @Data,
        LastModified = GETUTCDATE(),
        LastModifiedBy = @LastModifiedBy
    WHERE Id = @Id
END
GO

-- Stored Procedure to delete an entity with validation
CREATE PROCEDURE sp_DeleteEntity
    @Id INT
AS
BEGIN
    -- Check if the entity exists
    IF NOT EXISTS (SELECT 1 FROM Products WHERE Id = @Id)
    BEGIN
        RAISERROR('Entity with ID %d not found', 16, 1, @Id);
        RETURN;
    END

    -- Proceed to delete if the entity exists
    DELETE FROM Products WHERE Id = @Id
END
GO

-- Insert some sample data (commented out for now)
-- INSERT INTO Products (Type, Name, Description, Data, CreatedBy)
-- VALUES 
--     ('Customer', 'John Doe', 'VIP Customer', '{"email":"john@example.com","level":"VIP"}', 'System'),
--     ('Product', 'Laptop', 'High-end laptop', '{"price":999.99,"stock":50}', 'System'),
--     ('Order', 'ORD-001', 'First order', '{"total":1299.99,"status":"pending"}', 'System');
-- GO
