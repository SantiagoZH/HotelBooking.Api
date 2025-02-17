# HotelBooking API

Este proyecto es una API para la gestión de hoteles y reservas. Sigue estos pasos para ejecutar el proyecto correctamente.

## Requisitos previos

1. **.NET SDK**: Asegúrate de tener instalado el SDK de .NET. Puedes obtenerlo desde [aquí](https://dotnet.microsoft.com/download/dotnet).
2. **MySQL Server**: El entorno de desarrollo fue configurado con Laragon utilizando MySQL, pero puedes modificar las credenciales y la configuración según tu entorno.

## Instrucciones de instalación

### 1. Clonar el proyecto

```bash
git clone https://github.com/SantiagoZH/HotelBooking.Api.git
cd HotelBooking.Api
2. Instalar dependencias
Para restaurar las dependencias necesarias, ejecuta el siguiente comando:

dotnet restore

3. Compilar el proyecto
Para compilar el proyecto, utiliza:
dotnet build

4. Configurar las credenciales de la base de datos
En el archivo appsettings.json, encontrarás los valores por defecto para la conexión a la base de datos. En el entorno de desarrollo se utilizó un servidor Laragon con las siguientes credenciales:

Usuario: root
Contraseña: (vacía)
Si estás utilizando un servidor de base de datos diferente, por favor actualiza estos valores en el archivo appsettings.json:


"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=hotel_booking;User=root;Password=;"
}
5. Ejecutar migraciones
Para crear las tablas en la base de datos, ejecuta las migraciones con el siguiente comando:


dotnet ef database update
Asegúrate de tener las credenciales correctas y que tu base de datos esté disponible.

6. Base de datos manual
Si prefieres montar la base de datos directamente, en la carpeta HotelBooking.Domain encontrarás un script SQL llamado en el proyecto de HotelBooking.Domain database.sql, que puedes ejecutar para crear la base de datos con un par de registros iniciales.

7. Información de credenciales de la base de datos
El entorno donde se trabajó es un servidor Laragon con MySQL, usando las siguientes credenciales:

Usuario: root
Contraseña: (vacía)
Puedes modificar estos valores directamente en el archivo appsettings.json de acuerdo a tu configuración.

Usuario de prueba swaggerEndPoint Login(Caso de base de datos usando el Script si no se uso el script y se ejecuto las migraciones usar el endpoint de registrarse y colocar en el Rol "Agent")
Para probar el login del agente, puedes utilizar el siguiente usuario:

Email: sasty11234@gmail.com
Contraseña: ultragroup
Uso de Swagger
Para acceder a Swagger y probar los endpoints de la API, sigue estos pasos:

Inicia el proyecto:


dotnet run
Accede a la interfaz de Swagger en: https://localhost:7205/swagger/index.html

Autenticación: Para autenticarte en Swagger, agrega el prefijo bearer seguido del token en el campo de autorización.

Primero, obtén el token utilizando el endpoint de login (POST /api/auth/login).

Luego, en el campo de autorización en Swagger, agrega el token con el prefijo '"bearer" {token}"'


bearer <tu-token-aqui>
Notas adicionales
Dependencias: El proyecto tiene como dependencias MySQL y la autenticación por JWT.
Conexión a MySQL: Si estás utilizando un servidor de base de datos diferente, asegúrate de actualizar las configuraciones en appsettings.json.
Migraciones: Las migraciones de base de datos pueden necesitar ser ejecutadas manualmente con dotnet ef database update si no se han realizado automáticamente.
Swagger: En Swagger, puedes agregar el token con el prefijo "bearer" para acceder a los endpoints protegidos.
Si tienes alguna duda o problema, asegúrate de revisar los registros del contenedor de Docker y la configuración de tu servidor de base de datos.

Nota Importante! 
Faltaron algunas funcionalidades breves, la función de envio de correos se encuentra en el codigo pero no se usa ya que para esta debia configurar un correo con SMTP y lo intente con outlook personal peroe stos cambiaron sus condiciones de uso para ese servicio
¡Disfruta trabajando con la API de HotelBooking!