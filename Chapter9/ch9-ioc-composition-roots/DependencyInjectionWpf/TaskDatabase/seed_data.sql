/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO task VALUES(0, 'Clean the house', 'LOW', DATEADD(d, 1, GETDATE()), 0);
INSERT INTO task VALUES(1, 'Pay the bills', 'HIGH', DATEADD(d, 2, GETDATE()), 0);
INSERT INTO task VALUES(2, 'Wash the dog', 'MED', DATEADD(d, 3, GETDATE()), 0);
INSERT INTO task VALUES(3, 'Book flights', 'HIGH', DATEADD(d, 3, GETDATE()), 0);
INSERT INTO task VALUES(4, 'Buy presents', 'HIGH', DATEADD(d, 4, GETDATE()), 0);
INSERT INTO task VALUES(5, 'Post letters', 'MED', DATEADD(d, 4, GETDATE()), 0);
INSERT INTO task VALUES(6, 'Write emails', 'LOW', DATEADD(d, 4, GETDATE()), 0);
INSERT INTO task VALUES(7, 'Read articles', 'LOW', DATEADD(d, 5, GETDATE()), 0);
INSERT INTO task VALUES(8, 'Skype family', 'HIGH', DATEADD(d, 5, GETDATE()), 0);
INSERT INTO task VALUES(9, 'Take out wife', 'HIGH', DATEADD(d, 6, GETDATE()), 0);
INSERT INTO task VALUES(10, 'Write book', 'HIGH', DATEADD(m, 1, GETDATE()), 0);

