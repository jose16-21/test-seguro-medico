USE [Proyecto]
GO
/****** Object:  StoredProcedure [Final].[Proyecto]    Script Date: 13/11/2020 23:24:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
create PROCEDURE [Final].[ConsultaProveedor]
@codigo int = 0,
@nit varchar(50) = '',
@nacimiento datetime = null,
@cobertura datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	declare @Alerta varchar(500);
	declare 
	@NitValida int, 
	@PacienteValida int, 
	@NacimientoValida int,
	@Bandera int,
	@MyIdentity int; 

	select @NitValida = count(*) from Proveedor where Nit = @nit;
	if(@NitValida = 0) 
	begin
	set @Bandera = 1;
		set @Alerta = 'Nit no corresponde a proveedor';
	end 

	select @PacienteValida = count(*) from Paciente 
	where 
	Codigo = @codigo and 
	FechaCobertura <= @cobertura 
	and Estado = 'Activo';

	if(@PacienteValida = 0) 
	begin
		set @Bandera += 1;
		set @Alerta += ', Datos erroneos del paciente';
	end 

	select @NacimientoValida = count(*) from Persona where FechaNacimiento = @nacimiento;
	
	if(@PacienteValida = 0) 
	begin
		set @Bandera = +1;
		set @Alerta += ',Fecha Nacimiento erroneo';
	end 
	


	INSERT INTO Final.ReponseJava
           (Mensage,Estado) 
		   VALUES (@Alerta,'Activo')

		   set @MyIdentity = @@identity

    -- Insert statements for procedure here
	SELECT @MyIdentity as Autorizacion,
	CASE
		WHEN @Bandera > 0 THEN 'Sin Cobertura' 
		ELSE '' 
	END as Mensage,
	@Alerta as Alertas,
	'Activo' as Estado,
	CONVERT(decimal(10,2), 0) as Deducible,
	CONVERT(decimal(10,2), 0) as TotalAcumulado,
	CONVERT(decimal(10,2), 0) as Pendiente

END
