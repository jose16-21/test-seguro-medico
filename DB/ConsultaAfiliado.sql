USE [Proyecto]
GO
/****** Object:  StoredProcedure [Final].[ConsultaAfiliado]    Script Date: 14/11/2020 02:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [Final].[ConsultaAfiliado]
@codigo int = 0,
@nacimiento datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	declare @Alerta varchar(500), @Estado varchar(100);
	declare @PacienteValida int;
	declare @Deducible decimal(10,2)=0, 
			@Acumulado decimal(10,2) =0,
			@Pendiente decimal(10,2) =0;
	
	select 
		@PacienteValida = count(*) 	
	from Final.Paciente p
	inner join Final.Persona per on p.PersonaId = per.Id
	where 
	p.Codigo = @codigo and 
	CONVERT(date,per.FechaNacimiento) = CONVERT(date,@nacimiento);

	select @Deducible = MontoDeducible ,
	@Estado = Estado
	from Final.Paciente where Codigo = @codigo;

	if(@PacienteValida = 0) 
	begin
		set @Alerta = 'Datos erroneos del paciente';
	end 	

    select @Acumulado = sum(p.MontoPago) from Final.Pagos p
	inner join Final.Paciente pa on p.PacienteId = pa.id
	where pa.Codigo = @codigo
	group by p.PacienteId;

	SELECT 	
	-1 as Autorizacion,
	'' as Mensage,
	@Alerta as Alertas,
	@Estado as Estado,
	CONVERT(decimal(10,2), @Deducible) as Deducible,
	CONVERT(decimal(10,2), @Acumulado) as TotalAcumulado,
	CONVERT(decimal(10,2), @Pendiente) as Pendiente

END
