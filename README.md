# Immersia_Tank
## TurnBased Tanks game

El reto consiste en crear un juego en el que debes implementar un juego por turnos en el que
jugará una persona contra el ordenador. En concreto la dinámica del juego se basará en
turnos en los que cada usuario podrá realizar la siguiente secuencia de acciones: mover el
tanque (clic and go a una distancia máxima definida), apuntar (orientación y elevación de
cañón) y determinar fuerza de disparo.
El proyectil, en caso de impacto, siempre hará el mismo daño al enemigo.
Quien primero deje sin vida al enemigo contrario, gana la partida.
En cuanto a la programación del enemigo, la finalidad no es implementar un algoritmo
perfecto que siempre gane, si no conseguir un “nivel” de juego equilibrado, que se adapte de
alguna manera al nivel del usuario.

### TO DO

- [ ] Point and click movement.
- [ ] Aim system.
- [ ] Shooting system with "charge" force.
- [ ] Enemy Movement.
- [ ] Enemy Shooting system.
- [ ] Difficulty Adjustment.

### Complementary Info
- There is a flat game world with obstacles placed on it.
- The tanks start from two fixed locations.
- One tank (computer) will move to a random position on the map.
- The player will click a location and the other tank will go to the clicked location.
- When both tanks are at their locations they will take turns firing at each other.
- Player can control the elevation and shot power of the gun for each shot. The computer will control the other one.
- The computer must iteratively find the correct elevation and power.
- When a shell hits its target there will be an explosion and the winner displayed
- All shells must be simulated not calculated 
