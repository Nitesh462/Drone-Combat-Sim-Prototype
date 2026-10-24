# Drone vs Enemy Combat Simulation

A Unity prototype developed for the Unity Developer Internship assessment.

## Controls

- W / A / S / D — Move the drone
- Q / E — Descend / Ascend
- Spacebar — Fire a missile

## Features Implemented

- Player-controlled drone movement with height control.
- Follow camera.
- Missile firing with launch audio.
- Missile collision and explosion particle effects.
- Missiles destroy objects tagged `Target` on impact.
- Drone flying audio and explosion audio.
- Enemy soldiers patrol using NavMesh and waypoints.
- Enemy detects the drone, turns toward it, stops patrolling, and fires projectiles.
- Drone health and destruction when health reaches zero.
- Scene automatically restarts after the drone is destroyed.
- Enemy soldier and dummy targets can be destroyed by missiles.

## Known Bugs or Limitations

- This is a prototype focused on the required gameplay functionality.
- The scene restarts after the drone is destroyed; gameplay progress is not saved.
