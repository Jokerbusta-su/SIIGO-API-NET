# SIIGO-API-NET
Este proyecto contiene el código fuente de un ejemplo de integración con la API de SIIGO. Cubre cómo autenticarse y consumir métodos para obtener registros, insertar y eliminar.

## Instrucciones

### 1. Requisitos
Para poder ejecutar el siguiente proyecto requiere en su aplicación web.

```
          - * jQuery -> https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js
          - Bootstrap -> https://getbootstrap.com/

*Este requisito es indispensable, dado que el lenguaje usado es javascript sobre jQuery
```

### 2. Métodos
A continuación los ejemplos de los métodos necesarios para interactuar con el API de SIIGO.

#### Obtener Token
Para interactuar con el API es necesario usar la seguridad por token, para eso se debe consumir el servicio https://siigonube.siigo.com:50050/connect/token que solicita el usuario y contraseña; retornando finalmente el token que se usara en el resto de solicitudes.

Ejemplo con C#
```
public static async Task<string> getToken()
        {
            string token = "";
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", TOKEN_BASIC);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Content-Type", "application/x-www-form-urlencoded");
                var uri = "https://siigonube.siigo.com:50050/connect/token";
                HttpResponseMessage response;
                byte[] byteData = Encoding.UTF8.GetBytes(BODY_TOKEN_SERVICE);

                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(uri, content);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return token;
        }
```
#### Consultas
Una vez se obtiene el token, se puede realizar consultas a los métodos definidos en el API <URL>, a continuación un ejemplo de la solicitud por C#.

Ejemplo con C# (Obtener lista de desarrolladores)
```
public static async Task<List<Developer>> GetDevelopers()
        {
            List<Developer> result = null;
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SUBSCRIPTION_KEY);
                client.DefaultRequestHeaders.Add("Authorization", await getToken());
                var uri = "http://siigoapi.azure-api.net/siigo/api/v1/Developers/GetAll?namespace=v1";
                HttpResponseMessage response = await client.GetAsync(uri);
                result = Util.fromJson<List<Developer>>(response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
```

Ejemplo con C# (Obtener lista de productos)
```
public static async Task<List<Product>> GetProducts()
        {
            List<Product> result = null;
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SUBSCRIPTION_KEY);
                client.DefaultRequestHeaders.Add("Authorization", await getToken());
                var uri = "http://siigoapi.azure-api.net/siigo/api/v1/Products/GetAll?numberPage=0&namespace=v1";
                HttpResponseMessage response = await client.GetAsync(uri);
                result = Util.fromJson<List<Product>>(response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
```

#### Eliminar
Para realizar una eliminación es necesario enviar el id del objecto a eliminar, en este caso vamos a eliminar un producto.

Ejemplo con C#
```
public static async void DeleteProduct(long id)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SUBSCRIPTION_KEY);
                client.DefaultRequestHeaders.Add("Authorization", await getToken());
                var uri = "http://siigoapi.azure-api.net/siigo/api/v1/Products/Delete/" + id + "?namespace=v1";
                var response = await client.DeleteAsync(uri);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
```

#### Crear
Para realizar una creación se requiere enviar los campos solicitados del objecto a crear.

Ejemplo con C#
```
public static async Task<Product> CreateProduct(Product product)
        {
            try
            {
                var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SUBSCRIPTION_KEY);
                client.DefaultRequestHeaders.Add("Authorization", await getToken());
                var uri = "http://siigoapi.azure-api.net/siigo/api/v1/Products/Create?namespace=v1";
                HttpResponseMessage response;
                string productStr = Util.toJson(product);
                byte[] byteData = Encoding.UTF8.GetBytes(productStr);

                using (var content = new ByteArrayContent(byteData))
                {
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    response = await client.PostAsync(uri, content);
                    product = Util.fromJson<Product>(response.Content.ReadAsStringAsync().Result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return product;
        }
```
### 3. Estructura del Proyecto
En el proyecto se encuentra desarrollado con el  framework Entity Framework 4.5 utilizando el lenguaje c#.

Se encuentran las siguientes carpetas y archivos
          <p>Controller</p>
          <p>Model</p>
          <p>Utils</p>
          <p>Default.aspx</p>
          <p>Default.aspx.cs</p>
          <p>Default.aspx.designer.cs</p>
          <p>packages.config</p>
          <p>Web.config</p>
#### Controller
```
Se encuentra en controlador de la aplicación.
```
    
#### Model
```
Se encuentra los modelos utilizados en el llamado de los servicios.
```

#### Utils
```
Metodos globales necesarios para el procesamiento de los datos enviados y obtenidos de los servicios.
```

### 4. Configuración

- Clonar el proyecto
- Configurar <a href="https://medium.freecodecamp.org/how-to-get-https-working-on-your-local-development-environment-in-5-minutes-7af615770eec">HTTPS en su computador</a> *Esto para evitar el error por <a href="https://developer.mozilla.org/es/docs/Web/HTTP/Access_control_CORS">CORS</a>*
- Debe tener .NET Framework 4.5 <a href="https://www.microsoft.com/es-co/download/details.aspx?id=30">Instalar .Net Framework</a>
- Ejecute los siguientes pasos para correr la aplicación sin necesidad de Visual Studio 2017 <a href="https://dailydotnettips.com/run-asp-net-web-application-from-command-prompt/">Ejecutar aplicación web ASP.NET desde la linea de comandos.</a>
- Para ejecutar la aplicacion desde Visual Studio, abra el proyecto como una solucion desde el IDE.
- Abra la consola de administracion de paquetes de Visual Studio y ejecute el siguiente comando: *Update-Package*
- Pulse la tecla *F5* para ejeutar la aplicación.
