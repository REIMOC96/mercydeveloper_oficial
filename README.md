lo# Sistema Oficial Mercy Developer

Sistema funcional Mercy Developer para la generación de ficha tecnica en el área de soporte Técnico

## Comenzando 🚀

_Las siguientes instrucciones les permitirá obtener una copia del proyecto para seguir con su desarrollo._

Mira **Despliege 📦** para conocer como desplegar el proyecto.


### Pre-requisitos 📋

_Que cosas necesitas para instalar el software y como instalarlas_

```
1. .NET Core 8.0 + 
2. Visual Studio 2021+
3. WOrkBench 6.3+. Modelo de base de datos relacional
4. XAMPP para el ambiente local de base de datos MYSQL
5. Sincronizar la base de datos, el nombre de la DB es: "mercy_developer" 
```

### Ejecución del proyecto 🔧

_Si realizaste todo lo anterior (Pre-requisitos) puedes ejecutar el proyecto siguiendo estos pasos

_Se debe Ejecutar en terminal:_

```
1. Clona el repositorio con: git clone link del repositorio
```
_Para abrir el proyecto_
```
1. Localiza y ejecuta el archivo que esta dentro de tu proyecto clonado: MercDevs_ej2.sln
```
_Prueba o ejecuta el proyecto que este funcionando_
```
Depura el proyecto y prueba todos los módulos del mismo
```

_Si no se crean los registros con la DB, revisa el archivo en la instrucción ConnectionStrings en appsettings.json_

```
"ConnectionStrings": {
  "connection": "server=localhost;port=3306;database=mercy_developer;uid=root"
}
```

<!-- ## Ejecutando las pruebas ⚙️

_Explica como ejecutar las pruebas automatizadas para este sistema_

### Analice las pruebas end-to-end 🔩

_Explica que verifican estas pruebas y por qué_

```
Da un ejemplo
```

### Y las pruebas de estilo de codificación ⌨️

_Explica que verifican estas pruebas y por qué_

```
Da un ejemplo
``` -->

## Despliegue 📦

_Aún no esta listo el sistema para desplegarlo en producción (Web)_

## Construido con 🛠️

_Menciona las herramientas que utilizaste para crear tu proyecto_

* [.NET Core 8.0](https://dotnet.microsoft.com/es-es/download/dotnet/8.0) - El framework web usado
* [Visual Studio](https://visualstudio.microsoft.com/es/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false) - Codificar el proyecto
* [WorkBench 8.0](https://dev.mysql.com/downloads/workbench/) - Para la sincronización de la base de datos

## Contribuyendo 🖇️

Por favor lee el [El Profe](https://cftaricainformatica.cl) 

## Fortalece tu aprendizaje 📖

Invierte tiempo en tu formación profesional informática, accede a cualquier curso disponible y compeltalos [Cursos Gratis](https://www.udemy.com/courses/search/?price=price-free&q=.net+core+asp+web&sort=relevance&src=ukw)

## Versionado 📌

Usamos [SemVer](http://semver.org/) para el versionado. Para todas las versiones disponibles, mira los [tags en este repositorio](https://github.com/tu/proyecto/tags).

## Autores ✒️

_Menciona a todos aquellos que ayudaron a levantar el proyecto desde sus inicios_

* **Reinaldo Ordoñez** - *Trabajo Inicial* - [Reinaldo GitHub](https://github.com/REIMOC96)
* **Edgardo Cayo** - *Documentación* - [cayocft](https://github.com/cayocft)


## Licencia 📄

Este proyecto está bajo la Licencia _FREE_ - mira el archivo [LICENSE.md](LICENSE.md) para detalles

## Expresiones de Gratitud 🎁

* Comenta a otros sobre este proyecto 📢
* Invita una cerveza 🍺 o un café ☕ a alguien del equipo. 
* Da las gracias públicamente 🤓.





## Actualizaciones Recientes 🚀🚀
### Version 1.1.6 (15-07-2024)
- se avanzo hasta la etapa 6 de desarrollo, adjunto el documento: https://classroom.google.com/u/2/c/Njc4ODQ0NzkzOTAx/a/Njk4NDQ3NTA3NDY4/details
- aun no se implementa la ficha tecnica, pero se tiene en los documentos del proyecto, falta crear un modelo para este  y ver como iterar los datos
- se actualizo la BBDD para cumplir con los nuevos requerimientos
-  boton de ir a detalle en la tabla que muestra las recepciones activas
- se agrego boton de completar Recepcion, con una vista de confirmacion
- Se muestra el nombre del cliente y del servicio en la tabla de recepciones activas
- Se hizo un enlace en la vista de recepciones activas para ir al detalle del cliente y del servicio respectivo a cada registro
- se crearon crud de diagnosticos  && ficha tecnica, y se fixearon los detalles de crear cada dato y editar cada dato

### observaciones 1.1.6
- se requiere un mejor control de errores, no se puede borar un registro que tiene un registro como llave foranea, controlar ese detalle
- extendere el tiempo de login de la pagina, para poder mantenerla abierta mas tiempo
- traduccion de todos los textos
- botones bootsrap para cada cosa (borra  detales editar y funciones propias en botones)
- hare un listado de cosas para tornar el proyecto mucho mas real,adjuntare el documento, pero aun no tiene nada: https://docs.google.com/document/d/1mTL_RL3zokZh1DXjTdPQ-DtceRCq1JuxfgE8Yje4YL8/edit


extras:
- etapas completas antes de esta actualizacion (omitiendo la ficha tecnica) https://docs.google.com/document/d/1Nh5RZVnCjYv-pK0wqIWSN2655xOvgOVT/edit
- Actualizaciones de readme y de proyecto por **Reinaldo Ordoñez**, github [REIMOC96](https://github.com/REIMOC96)
- informacion y requerimientos enviados por **Edgardo Cayo**, github: [cayocft](https://github.com/cayocft)  

## *----------------------------------------------------------------------------------------------------------*


# old fixes🛠️🛠️

### Version 1.1.2 (14-07-2024)
- Se arreglaron muuuchos bugs
- Se agrego un boton de completar la recepcion que atualiza el estado a 0
- se arreglaron todas las funciones, poner mas ojo
- se agrego las descripciones de servicios por servicio.

### Version 1.1.1 (13-06-2024)
- Se agrego contenido al index de home segun requerimientos de la pauta
- Se omitio la parte del hashing, ya que fue completada en la Version anterior (10-06-2024)
- Se agrego la columna de Estado en la BBDD y a nivel codigo usando migraciones.
- Se agrego mensaje de no hay nada para mostrar en el index.
- Se agrego mensaje de bienvenida en la navbar
- Se corrigio la posicion de cerrar sesion motivo, la clickeaba sin querer
- Se actualizo el DB context de manera manual, se agrego el valor de estado a la entidad de recepcion equipos.
- Se actualizo el modelo de recepcion equipos para incluir la nueva columna de estado.
- Se mejoro la posicion de los textos para hacer la pagina mas legible.

### Observaciónes 1.1.1

- Tuve pequeños problemas para ajustar el controlador, resuelto.
- Originalmente no me mostraba las ids de los clientes y del servicio, resuelto
- Ojo con tocar el controlador de recepciones, ya que sin querer en un punto perdi la funcionalidad de crear
  recepciones ya que ingrese mal el llamado a un valor, resuelto.
- Validadores siguen desactivados, ya que no son necesarios por ahora, se requiere de ajustarlos en los modelos, 
  algunos ya los tienen construidos pero no esta aplicados y tampoco ajustados a parametros mas reales.


### Versión 1.1.0 (10-06-2024)
- Se agregó la funcionalidad de Registrarse a la pagina.
- Se agrego la funcionalidad de Login en la pagina.
- Se agrego el bloqueo de usuarios no logeados en el sistma, obligando a registrarse y logear.
- Se agrego vista de Loggeo y Registraese.
- Se agrego Funcion de Logout y se muestra en la navbar
- Se Optmimizacionde codigo, se uso el ddbb context propio del proyecto para no ser redundante y mejorar rendimiento.

### Detalles 1.1.0
- Se agregaron Validadores, en estado inhabilitado, lambda usado para los filtros pero falta ajustar detalles.
- Se requiere de mejorar la visual del proyecto, emplear mas bootstrap y crear diseños propios.
- Agregar Descripcion de servicios en una vista mas amigable.
- Mejorar la recepcion de equipos para poder imprimir una orden de trabajo (O.T.)
- Mejorar formato de la pagina Recepcion de equipo para hacerla mas parecida a una O.T.


   