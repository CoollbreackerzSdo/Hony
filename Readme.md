# Hony API
___

Hony es una API de blogs diseñada para proporcionar funcionalidades básicas para crear, leer, actualizar y eliminar publicaciones de blog, así como gestionar usuarios y comentarios. Esta API sigue el estilo RESTful y utiliza JSON para la transferencia de datos.

### Características:

Publicaciones de blog: Crear, leer, actualizar y eliminar publicaciones.
Usuarios: Registro de usuarios, autenticación y gestión de perfiles.
Comentarios: Añadir y gestionar comentarios en las publicaciones.

### Building and running your application

When you're ready, start your application by running:
`docker compose up --build`.

Your application will be available at http://localhost:8080.

### Deploying your application to the cloud

First, build your image, e.g.: `docker build -t myapp .`.
If your cloud uses a different CPU architecture than your development
machine (e.g., you are on a Mac M1 and your cloud provider is amd64),
you'll want to build the image for that platform, e.g.:
`docker build --platform=linux/amd64 -t myapp .`.

Then, push it to your registry, e.g. `docker push myregistry.com/myapp`.

Consult Docker's [getting started](https://docs.docker.com/go/get-started-sharing/)
docs for more detail on building and pushing.

### References
* [Docker's .NET guide](https://docs.docker.com/language/dotnet/)
* The [dotnet-docker](https://github.com/dotnet/dotnet-docker/tree/main/samples)
  repository has many relevant samples and docs.