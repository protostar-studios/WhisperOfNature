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
1. Copy the Prefabs/RespawnMenuManager to Managers parent object in the scene you are editing
2. Copy the Prefabs/RespawnCanvas to the GUI object in the scene you are editing
3. in the Managers/RespawnMenuManager gameobject, drag and drop the GUI/RespawnCanvas/RespawnMenu gameobject to the "Canvas" field
