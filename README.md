# Drones Simulation
https://www.youtube.com/watch?v=mSe_0SYkPcg

Unity Test Task: "Simulation of resource collection by fraction drones"

## Overview
This project simulates resource collection by drones belonging to different factions in a 3D environment. Drones navigate the field, collect resources, and return them to their faction bases while competing with other factions.

## Features
- Resource spawning on the game field
- Resource collection simulation by faction drones
- UI controls for:
  - Adjusting number of drones
  - Changing drone movement speed
  - Controlling resource spawn rate
  - Toggling drone path visualization

## Core Components

### Drone System
- **DroneBehavior**:
  - Uses NavMeshAgent for navigation
  - Implements finite state machine (search -> collect -> return)
  - Utilizes coroutines for smooth task execution
  - Belongs to specific factions (FractionData)

### Faction System
- Each **FractionData** has:
  - Base (FractionBase)
  - Distinctive color
  - Resource counter
- **FractionInfoView** displays faction information

### Spawning System
- **PoolSpawner** and **CycleSpawner** for drone creation
- **DroneSpawnerController** manages active drones
- Object pooling for optimization

### Visual Effects
- **DronePathVisualizer** renders movement paths
- **DroneEffectsScript** handles unloading visual effects
- **PathVisualizerSwitcher** toggles path display

### Resources
- **Supply** objects represent collectible resources
- **IsTaken** flag prevents drone competition

### Parameter Control
- Managed via **ScriptableObject** (IntegerValue, BoolValue)
- **DroneSpeedChanger** adjusts drone speeds
- Path visibility controls

## Workflow Logic

### Initialization
1. Factions with bases are created
2. Drones are spawned for each faction
3. Parameters are configured (speed, color, etc.)

### Drone Main Cycle
1. Find nearest available resource (FindNearestResource)
2. Move to resource using NavMeshAgent
3. "Collect" resource (wait + deactivate object)
4. Return to faction base
5. Increment faction resource counter
6. Play unloading visual effects

### Controls
- Adjust number of drones (via IntegerValue)
- Modify movement speed
- Toggle path visibility
- Change resource spawn rate

## Technical Implementation
- **ScriptableObjects** for object-controller-UI communication
- **MVC** architectural pattern
- **Object pooling** for resource and drone spawners

## Requirements
- Unity 2022.3 or later
- NavMesh components

## Setup
1. Clone the repository
2. Open in Unity
3. Run the main scene
