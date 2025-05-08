# 🩺 Módulo de Incapacidades 2021-2024

## 🚧 Proyecto en construcción 🚧

Este repositorio alberga el desarrollo de un módulo integral para la gestión de incapacidades médicas, diseñado para automatizar y optimizar los procesos administrativos relacionados con el ausentismo laboral por motivos de salud.

---

## 📋 Tabla de Contenidos

1. [Descripción del Proyecto]
2. [Tecnologías Utilizadas]
3. [Estructura del Proyecto]
4. [Instalación y Ejecución]
5. [Contribuciones]
6. [Licencia]

---

## 🧾 Descripción del Proyecto

Este módulo permite registrar, validar y gestionar incapacidades médicas, facilitando la integración con sistemas de seguridad social y generando reportes automatizados para el área de recursos humanos. Su objetivo es mejorar la trazabilidad, reducir tiempos de procesamiento y garantizar el cumplimiento normativo en el manejo de ausencias laborales.

---

## 🛠️ Tecnologías Utilizadas

* **Backend:**

  * .NET Core (C#)
  * Web API
  * SQL Server

* **Frontend:**

  * Angular
  * JavaScript

* **Otros:**

  * Git
  * GitHub
  * Visual Studio Code

---

## 📁 Estructura del Proyecto

```plaintext
├── AccesoDatosParametros/
├── Common.Incapacidades/
├── GateWayIncapacidades3/
├── LibreriasAutorizacion/
├── LibreriasIncapacidades/
├── NegocioAutorizaciones/
├── NegocioIncapacidades/
├── NegocioParametros/
├── Notificaciones/
├── ServiciosAutorizaciones/
├── ServiciosIncapacidades/
├── ServiciosParametros/
├── WebApiAutorizaciones/
├── WebApiIncapacidades/
├── WebApiParametros/
├── incapacidades-front/
├── .gitignore
├── BrokerIncapacidades.sln
├── GatewayIncapacidades.sln
├── WebApiIncapacidades.sln
└── README.md
```

---

## ⚙️ Instalación y Ejecución

### Backend

1. Clona el repositorio:

   ```bash
   git clone https://github.com/jdiegomoreno8/Modulo_Incapacidades_2021-2024.git
   cd Modulo_Incapacidades_2021-2024
   ```

2. Restaura los paquetes NuGet:

   ```bash
   dotnet restore
   ```

3. Ejecuta la API:

   ```bash
   dotnet run --project WebApiIncapacidades/WebApiIncapacidades.csproj
   ```

### Frontend

1. Navega al directorio del frontend:

   ```bash
   cd incapacidades-front
   ```

2. Instala las dependencias:

   ```bash
   npm install
   ```

3. Inicia la aplicación:

   ```bash
   ng serve
   ```

La aplicación estará disponible en `http://localhost:4200`.

---

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas! Si deseas colaborar en este proyecto, por favor sigue estos pasos:

1. Haz un fork del repositorio.
2. Crea una nueva rama (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y haz commit (`git commit -m 'Añadir nueva funcionalidad'`).
4. Haz push a la rama (`git push origin feature/nueva-funcionalidad`).
5. Abre un Pull Request.

---

## 📄 Licencia

Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo [LICENSE](LICENSE) para más detalles.

---

Si necesitas ayuda adicional o tienes alguna pregunta sobre el proyecto, no dudes en contactarme a través de los canales disponibles en mi perfil de GitHub.

---
