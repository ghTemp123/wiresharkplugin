use [msqq]
GO
BULK INSERT msqqBulk 
    FROM 'G:\chensheng\QQץ������\��½2\aa.csv' 
    WITH 
    ( 
        FIELDTERMINATOR = ';', 
        ROWTERMINATOR = '\n' 
    )
	
update msqqBulk set message_type='��½2' where message_type='4'