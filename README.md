# WhisperOfNature

## Checkpoint System
-- How to add a check point: 
1. Add Managers/RespawnManager to the game
2. Use Empty Objects to represent checkpoints
3. Drag the checkpoint objects into the list in RespawnManager as Transforms
4. In the corresponding gate, or in the function setting up checkpoints, get the RespawnManager.
5. FindObjectWithType<RespawnManager>() then RespawnManager.setRespawn(index), where index is the checkpoint index in the list createed in step 3
6. Then the checkpoint is set up. Test it and debug

## Respawn Menu
-- How to include a Respawn Menu:

1. Go to the Level 1 - Beta scene
2. Copy the Managers/RespawnMenuManager gameobject to the same Managers folder in the scene you are editing
3. Copy the GUI/RespawnCanvas gameobject to the same GUI folder in the scene you are editing
4. in the Managers/RespawnMenuManager gameobject, drag and drop the GUI/RespawnCanvas/RespawnMenu gameobject to the "Canvas" field