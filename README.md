<div align="center" >
# 🧬 LifeGame 
*Simulacion del "Juego de la vida" en c# con OpenTK + OpenGL*
</div>

## 🧠 Descripción

**LifeGame** es una simulación interactiva del clásico **"Juego de la Vida"** de Conway, desarrollada completamente en **C#** usando **OpenTK** y **OpenGL**.  
El motor gráfico aprovecha el **renderizado directo en GPU**, lo que permite una ejecución extremadamente fluida incluso con cuadrículas de gran tamaño.

El sistema implementa las reglas del autómata celular donde cada célula ("humano") vive, muere o nace en función de sus vecinos, generando patrones visuales emergentes complejos.


## 🧮 Reglas del Juego de la Vida

- Una célula muerta con exactamente 3 vecinos vivos → nace

- Una célula viva con más de 3 vecinos vivos → muere por sobrepoblación

- Una célula viva con menos de 2 vecinos vivos → muere por soledad

- Una célula viva con 2 o 3 vecinos vivos → sobrevive


## ⚙️ Características principales

- 🧩 Implementado desde cero con **OpenTK (C#)**  
- ⚡ Renderizado **en GPU mediante OpenGL**  
- 🧠 Algoritmo optimizado: cada célula solo verifica sus 8 vecinos  
- 🧱 Cuadrículas escalables (por ejemplo 50x50, 100x100, etc.)  
- ⏸️ Sistema de **pausa y reinicio**  
- 🎨 Personalización de colores y velocidad de simulación

# 🏗️ Instalación y ejecución

### 1. Clonar el repositorio  
```bash

   https://github.com/Litardo-Jardy/LifeGame.git

```

### 2. Restaurar dependencias
```bash

   dotnet restore

```

### 3. Ejecucion del proyecto
```bash

   dotnet run

```

# Autor

- Jardy Litardo [Litardo-Jardy](https://github.com/Litardo-Jardy)

