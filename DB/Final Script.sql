
CREATE DATABASE Proyecto

GO

USE Proyecto

GO

CREATE SCHEMA Final

GO

CREATE TABLE Final.Persona(
  Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
  PrimerNombre Varchar(250) not null,
  SegundoNombre Varchar(250) not null,
  PrimerApellido Varchar(250) not null,
  SegundoApellido Varchar(250) not null,
  Edad int,
  Direccion Varchar(250) not null,
  FechaNacimiento datetime default getdate() ,
  Estado varchar(20) not null check(Estado  in ('Activo','Inactivo') ) DEFAULT 'Activo',
)

GO 

CREATE TABLE Final.Paciente(
Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
PersonaId UNIQUEIDENTIFIER DEFAULT NULL,
Codigo int,
Telefono int,
FechaCobertura datetime default getdate() ,
MontoDeducible decimal(10,2),
MontoCobertura decimal(10,2),
Estado varchar(20) not null check(Estado  in ('Activo','Inactivo') ) DEFAULT 'Activo'
)

GO

ALTER TABLE Final.Paciente
ADD CONSTRAINT Persona_Paciente_FK FOREIGN KEY (PersonaId) REFERENCES Final.Persona(Id)

GO

CREATE TABLE Final.Pagos(
Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
PacienteId UNIQUEIDENTIFIER DEFAULT NULL,
Boleta int,
Anio int,
Mes int,
FechaPago datetime,
MontoPago decimal(10,2),
Estado varchar(20) not null check(Estado  in ('Activo','Inactivo') ) DEFAULT 'Activo'
)

GO

ALTER TABLE Final.Pagos
ADD CONSTRAINT Pagos_Paciente_FK FOREIGN KEY (PacienteId) REFERENCES Final.Paciente(Id)

GO

CREATE TABLE Final.Proveedor(
Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
Nombre Varchar(250),
Nit Varchar(250),
RazonSocial Varchar(250),
Direccion Varchar(250),
Telefono int,
Estado varchar(20) not null check(Estado  in ('Activo','Inactivo') ) DEFAULT 'Activo')

GO

CREATE TABLE Final.Servicio(
Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
ProveedorId   UNIQUEIDENTIFIER DEFAULT NULL,
Nombre Varchar(250),
Descripcion Varchar(250),
Estado varchar(20) not null check(Estado  in ('Activo','Inactivo') ) DEFAULT 'Activo')

GO

ALTER TABLE Final.Servicio
ADD CONSTRAINT Servicio_Proveedor_FK FOREIGN KEY (ProveedorId) REFERENCES Final.Proveedor(Id)

GO

CREATE TABLE Final.ServicioPaciente(
Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
PacienteId   UNIQUEIDENTIFIER DEFAULT NULL,
FechaServicio datetime,
ServicioId   UNIQUEIDENTIFIER DEFAULT NULL)

GO

ALTER TABLE Final.ServicioPaciente
ADD CONSTRAINT ServicioPersona_PacienteId_FK FOREIGN KEY (PacienteId) REFERENCES Final.Paciente(Id),
CONSTRAINT ServicioPersona_ServicioId_FK FOREIGN KEY (ServicioId) REFERENCES Final.Servicio(Id)

GO

CREATE TABLE Final.Factura(
Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
PacienteId UNIQUEIDENTIFIER DEFAULT NULL,
FechaFactura datetime,
Serie Varchar(250),
Numero Varchar(250),
Monto decimal(10,2),
CantidadMedicamentos int
)

GO

ALTER TABLE Final.Factura
ADD CONSTRAINT Factura_PacienteId_FK FOREIGN KEY (PacienteId) REFERENCES Final.Paciente(Id)

GO

CREATE TABLE Final.ReponseJava (
Autorizacion int primary key identity,
Mensage varchar(200),
Estado varchar(200),
Deducible Decimal(10,2),
TotalAcumulado Decimal(10,2),
Pendiente Decimal(10,2))

GO