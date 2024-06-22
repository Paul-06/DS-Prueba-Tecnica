# Prueba Técnica de Digital Solutions 324 SL
Este proyecto consiste en una Web API desarrollada con .NET Core, siguiendo la arquitectura hexagonal. Se ha utilizado una base de datos SQLite, la cual se generará automáticamente al ejecutar el proyecto. Las migraciones necesarias ya están incluidas en el repositorio.

## Tecnologías Utilizadas
- .NET Core
- C#
- ASP.NET Core
- Entity Framework Core
- SQLite

## Instrucciones para ejecutar el proyecto
1. Clona este repositorio: 
   ```bash
   git clone https://github.com/Paul-06/DS-Prueba-Tecnica.git
   ```
2. Navegar al directorio del proyecto
   ```bash
   cd DS-Prueba-Tecnica
   ```
3. Compila y ejecuta el proyecto.
   - **Visual Studio 2022**: Abrir el archivo `.sln` con Visual Studio y ejecutar el proyecto.
   - **Visual Studio Code**: Si abres el proyecto con Visual Studio Code, se ejecutará automáticamente.

4. La base de datos SQLite se creará automáticamente al iniciar el proyecto, y se aplicarán las migraciones necesarias.

## Nota sobre el uso de la base de datos
Para abrir el archivo de la base de datos (SocialApp.db), se recomienda utilizar Visual Studio Code con la extensión SQLite de alexcvzz. Sigue estos pasos:
1. Instala la extensión SQLite de alexcvzz desde aquí: https://marketplace.visualstudio.com/items?itemName=alexcvzz.vscode-sqlite.
2. Abre Visual Studio Code y navega a la paleta de comandos presionando `Ctrl + Shift + P`.
3. Escribe `SQLite: Open Database` y selecciona la opción correspondiente.
4. Selecciona el archivo de la base de datos (en este caso, SocialApp.db).
5. Se abrirá la base de datos en esta sección:
   ![Base de datos abierta](https://1drv.ms/i/s!An8Gy-RDqyoYsC4XXI2U9vWk6vG3?e=pPtlDY)

## Frontend
La parte frontend del proyecto ha sido desarrollada con Flutter. Puedes encontrar el repositorio del frontend en el siguiente enlace:
https://github.com/Paul-06/DS-P-Tecnica-Frontend
