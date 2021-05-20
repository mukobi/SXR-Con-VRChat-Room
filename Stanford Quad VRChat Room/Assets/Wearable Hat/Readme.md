# Wearable Hat Prefab

Prefab created by: Ostinyo

[Discord](http://discordapp.com/users/140989494936600576)

[Twitter](https://twitter.com/ostinyo)

----------
## About

Wearable hat prefab that you can put on yourself and friends! Use the trigger when it's
near someone's head to place it on them!

This hat is originally from my world Putt Putt Pond, so it includes that texture.

Model source: https://www.cgtrader.com/free-3d-models/sports/equipment/thrasher-snapback
----------
## Installation

Drag the WearableHat.prefab asset into your scene, then set the "Max Players" variable
on the "Hat Pickup" object to the hard player cap of your world (double the player limit).
----------
## Known Issues

* When players move around quickly, the hat sometimes becomes de-synced for a time.
* When placing the hat on a player's head, an 'InvalidOperationException' is thrown.
  This exception doesn't halt the UdonBehaviour, so it appears to be happening internally.
----------
## Requirements

* [Vrchat SDK3](https://vrchat.com/download/sdk)
* [UdonSharp](https://github.com/Merlin-san/UdonSharp)
----------
