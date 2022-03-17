# Cryptomonedas

>Aplicación para ver la cotización de cryptomonedas y convertir un determinado monto entre las mismas.

### Configuración

1- Requerimientos

* nodejs, angular cli
* dotnet 3.1

2- Clonar el repositorio

```bash
git clone git@gitlab.com:leo-orellana/nec-challenge.git
```

3- Levantar el backend

Editar archivo ./backend/backend/appsettings.json y configurar el campo **CoinMarketAPIKey** con la APIKEY que obtenemos en la cuenta de CoinMarket.

```json
{
  ...
  "CoinMarketBaseURI": "https://pro-api.coinmarketcap.com/v1/cryptocurrency/",
  "CoinMarketAPIKey": "<poner-api-key-acá>"
}
```

Podemos levantar el backend de 2 maneras:

a- cargar el proyecto en VisualStudio y darle click al botón de ejecutar en IIS Express.

La URL será: http://localhost:47696

b- desde una terminal ejecutar desde la raíz del proyecto
```
cd backend
dotnet run --project backend
```
La URL en este caso será: http://localhost:5000

4- Levantar el frontend

Editar archivo ./src/environments/environment.ts y configurar el campo **apiUrl** con la URL en dónde se haya deployado el backend.

Desde una terminal ejecutar

```
cd frontend
npm install
ng serve
```

El sitio estará disponible en la URL http://localhost:4200
