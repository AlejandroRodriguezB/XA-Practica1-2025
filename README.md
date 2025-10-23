# XA-Practica1-2025
Practica 1 de Redes Avanzadas 2025

# Guía de instalación
>TODO: Hacer en cuanto acabe con el proyecto paso a paso

Check BD
docker exec -it <id docker> psql -U <userBd> -d <nombreBd>

# Descripción de entornos
>TODO: explicar en detalle, basicamente hay 2 entornos dev y pro, en dev no hay cache, en pro sí 
# Diagrama de arquitectura del servicio
>TODO: explicar en cuanto se acabe el proyecto pero será algo parecido a:
## DEV
```
Cliente-> WEB -> BD  (y vuelta)
```
## PRO
```
 Cliente-> WEB -> Cache  (y vuelta si ya esta en cache) -> BD (y vuelta si ha llegado aqui actualizar cache)
```
# Resultado de pruebas y verificaciones

- [x] Deben crearse dos archivos de orquestación separados: docker-compose.dev.yml y dockercompose.prod.yml
- [X] Cada entorno debe disponer de su propio archivo .env con las variables de entorno
correspondientes (puertos, credenciales, etc.).
- [X] Los servicios deben ejecutarse sobre una red interna de Docker donde se comuniquen la aplicación, la base de datos y la caché.
- [X] Solo la aplicación web podrá exponerse al exterior a través de un puerto publicado; los demás servicios permanecerán accesibles únicamente desde la red interna.
- [X] Todos los contenedores deberán incluir un healthcheck configurado en el docker-compose.yml o en sus Dockerfile, que permita comprobar si el servicio está activo y respondiendo correctamente.
- [X] El estado de salud deberá verse reflejado en la aplicación web mediante su endpoint /status.
- El proyecto deberá implementar medidas básicas de seguridad:
    - [X] No incluir credenciales hardcodeadas en el código ni en los archivos YAML.
    - [X] Utilizar variables de entorno para contraseñas y configuración sensible.
    - [X] Evitar exponer puertos innecesarios.
    - [X] Aplicar permisos mínimos requeridos en los archivos de configuración.
    - [X] La automatización del despliegue es obligatoria.
- Se deberá incluir un Makefile o script bash (setup.sh, run.sh, etc.) que permita:
    - [X] Construir las imágenes
    - [X] Levantar el entorno (make up-dev, make up-prod)
    - [X] Detener y limpiar (make down)
- [X] La persistencia de datos deberá demostrarse insertando información en la base de datos, eliminando el contenedor y volviendo a iniciarlo, verificando que los datos se mantienen.

# Explicación de los healthchecks
>TODO: explicar

# Instrucciones de uso del Makefile o script
>TODO: Explicar