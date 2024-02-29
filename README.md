# Proyecto de Universidad

Este proyecto es una aplicación web desarrollada en ASP.NET Core para gestionar información relacionada con una universidad. Utiliza Entity Framework Core para interactuar con una base de datos SQL Server.

## Configuración de la base de datos

La aplicación se conecta a una base de datos SQL Server llamada "UniversityDB". Asegúrate de tener configurada correctamente la cadena de conexión en el archivo de configuración (`appsettings.json`) bajo la clave "ConnectionStrings". Puedes encontrar un ejemplo de configuración en el siguiente formato:

```json
{
  "ConnectionStrings": {
    "UniversityDB": "Server=<nombre_servidor>;Database=<nombre_base_datos>;User=<usuario>;Password=<contraseña>;"
  }
}
```

## Instalación y ejecución

1. Clona este repositorio en tu máquina local.
2. Abre el proyecto en tu entorno de desarrollo preferido (Visual Studio, Visual Studio Code, etc.).
3. Asegúrate de tener .NET Core SDK instalado en tu sistema.
4. En la terminal, navega hasta el directorio raíz del proyecto.
5. Ejecuta el comando `dotnet run` para iniciar la aplicación.
6. La aplicación estará disponible en la URL `https://localhost:5001` (o similar, dependiendo de la configuración).

## Documentación API

La aplicación está configurada para generar documentación API utilizando Swagger/OpenAPI. Una vez que la aplicación esté en ejecución, puedes acceder a la documentación API en la siguiente URL:

```
https://localhost:5001/swagger
```

## Contribución

Si quieres contribuir a este proyecto, ¡eres bienvenido! Siéntete libre de hacer fork del repositorio, implementar nuevas características, solucionar problemas o mejorar la documentación, y luego enviar un pull request.
