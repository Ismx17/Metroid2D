# 🕹️ Pixel Metroid 2D - Prototipo en Unity & C#

Este proyecto es un prototipo funcional de un videojuego de plataformas 2D inspirado en la estética y mecánicas de Metroid. Desarrollado como proyecto personal para profundizar en la lógica de videojuegos y el dominio del motor Unity.

---

## 🚀 Funcionalidades Técnicas Implementadas

A través del desarrollo de este proyecto, he aplicado y consolidado los siguientes conceptos técnicos:

- **Character Controller Pro**: Lógica de movimiento lateral y sistema de salto optimizado mediante físicas de Unity (`Rigidbody2D`).
- **Sistema de Animación Dinámica**: Implementación de una máquina de estados en el `Animator` para transiciones fluidas basadas en parámetros de velocidad y estado.
- **IA de Enemigos (Patrullaje)**: Creación de entidades enemigas con lógica de movimiento automatizado y detección de bordes/paredes.
- **Feedback Sonoro (Audio Manager)**: Implementación de un sistema de audio para efectos de sonido (SFX) y música de fondo que enriquecen la experiencia de juego.
- **Arquitectura Basada en Componentes**: Organización limpia del código en scripts C# desacoplados (movimiento, sonido, colisiones).
- **Diseño de Niveles con Tilemaps**: Uso eficiente de las herramientas de Unity para la creación de escenarios y gestión de capas de colisión.

---

## 🛠️ Stack Tecnológico

- **Motor:** [Unity 2D](https://unity.com/)
- **Lenguaje de Programación:** C# 
- **Físicas:** Uso avanzado de `Colliders2D` y `Trigger Events` para la interacción entre entidades.
- **Control de Versiones:** Git utilizado para la gestión del flujo de trabajo.

---

## 📂 Estructura del Repositorio

- `Assets/Scripts`: Contiene toda la lógica de programación en C#.
- `Assets/Sprites`: Recursos visuales y hojas de animación.
- `Assets/Sounds`: Efectos sonoros y pistas de audio.
- `Assets/Prefabs`: Objetos reutilizables (Player, Enemigos) que facilitan la escalabilidad del proyecto.

---
