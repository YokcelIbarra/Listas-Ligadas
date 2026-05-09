```powershell
@"
# Listas Ligadas

Proyecto de consola en C# para el Taller #5 sobre listas ligadas.

El programa implementa una lista doblemente ligada genérica usando nodos. Permite adicionar datos en orden ascendente, mostrar la lista hacia adelante y hacia atrás, ordenar descendentemente, buscar elementos, eliminar ocurrencias, mostrar la moda y generar un gráfico de ocurrencias.

## Tecnologías

- C#
- .NET
- Visual Studio Code

## Ejecución

Para ejecutar el proyecto, usar el comando:

dotnet run

## Autor

Yokcel Ibarra
"@ | Out-File -Encoding UTF8 README.md

git add README.md
git commit -m "Corrige formato del README"
git push
