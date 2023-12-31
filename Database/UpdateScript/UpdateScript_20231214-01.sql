DROP PROCEDURE IF EXISTS CheckUserLogin
GO
CREATE PROCEDURE CheckUserLogin
(
	@USER_ID NVARCHAR(100),
	@PASSWORD NVARCHAR(100),
	@ISVALID BIT OUT
)
AS
BEGIN
SET @ISVALID = (SELECT COUNT(1) FROM ACC_USER WHERE USER_ID = @USER_ID AND PASSWORD = @PASSWORD AND SYNCOPERATION<>'D')
END
GO
