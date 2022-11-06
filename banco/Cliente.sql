/****** Script do comando SelectTopNRows de SSMS  ******/
SELECT TOP (1000) [ClienteId]
      ,[Nome]
      ,[DataNascimento]
      ,[Origem]
      ,[Destino]
      ,[DataIda]
      ,[DataVolta]
  FROM [Cliente].[dbo].[Cliente]