# WebOrderSystem

Este proyecto contiene soluciones a una serie de ejercicios de desarrollo web, que incluyen la implementación de endpoints de API, consumo de API externas, serialización de datos y consultas LINQ.

## Ejercicios implementados
### Ejercicio 1: Manejo de Git y explicación del proyecto
1. Se pide crear un proyecto web usando .Net 8
2. Este proyecto debe exponer varios endpoint, uso de ORM y LINQ (Explicación a continuación de cada punto)
3. El resultado del proyecto se entregará en un repositorio público de github.
4. El repositorio debe tener una rama main y al menos otra rama en la que se desarrollen los ejercicios.
5. Se debe incluir un pequeño documento (Readme) con anotaciones, explicaciones de las decisiones tomadas. Pudiendo incluir capturas de pantalla si es necesario.

### Ejercicio 2: Entity Framework y SQL Server
1. Puedes utilizar SQL Server como instancia instalada localmente o usarla con docker [SQL Server docker](https://hub.docker.com/_/microsoft-mssql-server)
2. Sigue el tutorial [Entity Framework - Getting Started](https://learn.microsoft.com/es-es/ef/core/) para crear un proyecto utilizando Entity Framework y la base de datos SQL Server
3. Crea tres tablas con la siguiente estructura:

### Diseño de las Tablas:

1. **Tabla `Member`:**
   - **id (long):** Identificador único del miembro.
   - **name (string, max 500):** Nombre del miembro, con un límite de 500 caracteres.

   **Explicación:** La tabla `Member` almacena información sobre los miembros, con un identificador único (`id`) y un campo para el nombre del miembro.

2. **Tabla `Product`:**
   - **id (long):** Identificador único del producto.
   - **name (string, max 500):** Nombre del producto, con un límite de 500 caracteres.

   **Explicación:** La tabla `Product` registra información sobre los productos, con un identificador único (`id`) y un campo para el nombre del producto.

3. **Tabla `Order`:**
   - **id (long):** Identificador único de la orden.
   - **memberId (long, FK Member):** Clave foránea que referencia al miembro asociado a la orden.
   - **productId (long, FK Product):** Clave foránea que referencia al producto asociado a la orden.
   - **dateOrder (Datetime):** Fecha y hora de la orden.

   **Explicación:** La tabla `Order` representa las órdenes realizadas por los miembros. Contiene un identificador único (`id`), claves foráneas que vinculan la orden a un miembro y un producto, y la fecha de la orden.

### Tipos de Datos:

- **long (Int64):** Se utiliza para almacenar valores enteros largos, como identificadores únicos.
- **string (max 500):** Almacena cadenas de texto con un límite de 500 caracteres, adecuado para nombres de miembros y productos.
- **Datetime (smallDatetime2(0)):** Almacena fechas y horas precisas, con una escala de segundos.

### Consideraciones de Diseño:

- **Relaciones de Claves Foráneas (FK):** Las claves foráneas (`memberId` y `productId` en `Order`) establecen relaciones con las tablas `Member` y `Product`, garantizando la integridad referencial.

- **Longitud de Cadenas de Texto:** Se limita la longitud de las cadenas de texto (`name`) para optimizar el rendimiento y asegurar que los datos sean manejables.

- **Precisión de Fecha y Hora:** Se utiliza `smallDatetime2(0)` para registrar la fecha y hora de las órdenes con una precisión de segundos.

Explicar estos aspectos proporciona una guía clara sobre cómo se estructuran las tablas, qué datos se almacenan y cómo se relacionan entre sí. Esto facilita la comprensión y evaluación del diseño de la base de datos.


### Ejercicio 3: Generación de Script SQL
1. Genera un [script SQL](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli#sql-scripts) con la migración anterior, adecuado para ser utilizado en el sistema de Continuous Deployment (CD).

### Ejercicio 4: Inserción de Datos de Prueba
1. Inserta algunos datos de prueba en las tres tablas que has creado.

### Ejercicio 5: Endpoint para Último Pedido por Miembro
1. Crea un endpoint que devuelva el último pedido para cada miembro.
2. La respuesta debe incluir el nombre del miembro, el nombre del producto y el nombre del pedido.

### Ejercicio 6: Consumo de API Externa
1. Realiza una llamada a la API [https://jsonplaceholder.typicode.com/comments](https://jsonplaceholder.typicode.com/comments) utilizando RestClient.
2. Serializa la respuesta a un modelo tipado en C#.
3. Utilizando LINQ, devuelve los tres ID de posts con más comentarios.

### Ejercicio 7: Endpoint para los Tres Posts con Más Comentarios
1. Crea un endpoint que devuelva los tres posts con más comentarios, obtenidos de la API mencionada en el ejercicio anterior.
2. La respuesta debe incluir información sobre el ID del post y la cantidad de comentarios.

Recuerda incluir en tus resultados el código fuente, la estructura del repositorio de Git, y cualquier detalle adicional que consideres necesario para evaluar la implementación de los ejercicios. ¡Buena suerte!


## Arquitectura de carpetas
![image](https://github.com/JaviPaez/WebOrderSystem/assets/69802155/c1a74bd3-d5af-4380-85fb-bf061240e036)

## Instrucciones de Instalación y Ejecución
- Clona el Repositorio: Abre una terminal y ejecuta el siguiente comando para clonar el repositorio de GitHub:
```git clone https://github.com/JaviPaez/WebOrderSystem```

- Instala Dependencias: Navega hasta el directorio del proyecto y ejecuta el siguiente comando para instalar las dependencias del proyecto:

```cd WebOrderSystem/WebOrderSystem
dotnet restore```

- Configura la Base de Datos: Asegúrate de tener una instancia de SQL Server disponible. Puedes utilizar una instancia local. Si necesitas ayuda para configurar una instancia de SQL Server, consulta la documentación oficial. Modifica el archivo appsettings.json con tu cadena de conexión ("DefaultConnection").

- Migraciones de la Base de Datos: Ejecuta las migraciones de Entity Framework Core para crear la estructura de la base de datos:
'dotnet ef database update'

- Ejecuta la Aplicación: Una vez completados los pasos anteriores, puedes ejecutar la aplicación con F5 en Visual Studio 2022.

- Explora los Endpoints API: Una vez que la aplicación esté en funcionamiento, puedes explorar los diferentes endpoints API utilizando una herramienta como Postman o cualquier navegador web.

## Endpoints

- /api/Orders/LastOrdersByMember

Devuelve el último pedido para cada miembro. Incluye el nombre del miembro, el nombre del producto y el nombre del pedido.

- /api/Comments/TopPostIdsWithMostComments
  
Devuelve los tres ID de posts con más comentarios de una API externa [https://jsonplaceholder.typicode.com/comments]

- /api/Comments/TopPostWithMostComments

Devuelve los tres posts con más comentarios, obtenidos de la API mencionada en el ejercicio anterior. Incluye información sobre el ID del post y la cantidad de comentarios.
