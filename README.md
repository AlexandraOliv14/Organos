# Visualización Anatómica Inmersiva en VR/AR

Este proyecto corresponde al Trabajo de Fin de Máster del Máster en Ingeniería Informática y tiene como objetivo desarrollar una experiencia inmersiva en realidad virtual y aumentada (VR/AR) que permita a los estudiantes explorar y comprender de forma intuitiva la organización espacial del cuerpo humano, así como su relación con el entorno físico desde una perspectiva interactiva.

____

## Características principales

- Aplicación desarrollada en Unity 6.
- Visualización inmersiva de cuatro sistemas anatómicos: sistema digestivo, sistema cerebral, sistema ocular y sistema circulatorio.
- Modo VR y AR (passthrough) activables desde toda la aplicación.
- Interfaz multilingüe: español, catalán e inglés.
- Funcionalidades interactivas con retroalimentación visual y sonora.

____
## Requisitos del sistema

- Unity 2022.3 LTS o superior
- Dispositivo Meta Quest 2, 3, 3S o Pico 4
- Android SDK configurado en Unity
- XR Plugin Management habilitado con soporte para OpenXR
- Activación del modo desarrollador en el visor
____
## Instalación y despliegue

### Clonación del repositorio

```bash
git clone https://github.com/AlexandraOliv14/Organos.git
```

### Apertura del proyecto en Unity

1. Abrir Unity Hub y seleccionar la carpeta clonada.

2. Asegurarse de que la plataforma de compilación sea Android.

3. Verificar que el plugin de OpenXR esté correctamente configurado.

### Compilación e instalación en Meta Quest

1. Desde Unity: `File > Build Settings > Build` para generar el `.apk.`

2. Conectar el visor por USB y transferir el archivo usando:

- Meta Quest Developer Hub

- SideQuest

- o ADB:
    ```bash
    adb install AnatomyApp.apk
    ```

3. Ejecutar desde el visor, sección “Fuentes desconocidas”.
____
## Estructura del proyecto

```
Assets/
├── Animacions/
├── Fonts/
├── Materials/
├── Modelo/
├── Prefab/
├── Resources/
│       ├── audios/
│       └── lenguajes/
├── Scenes/
└── Sprite/
```
____
## Licencia

Proyecto académico sin fines comerciales.

____

Alexandra Olivares

Trabajo de Fin de Máster – Máster en Ingeniería Informática
Universitat Politècnica de Catalunya (UPC)
Junio 2025
