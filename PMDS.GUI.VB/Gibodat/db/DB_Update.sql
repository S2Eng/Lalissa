

/****** Skript für Abteilungsview (Gibodat-Schnittstelle ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vAbteilungen]'))
DROP VIEW [dbo].[vAbteilungen]

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vAbteilungen]
AS
SELECT     ID, Bezeichnung
FROM         dbo.Abteilung

GO
