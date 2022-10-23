# WhisperOfNature

## Checkpoint System
-- How to add a check point: 
1. Add Managers/RespawnManager to the game
2. Use Empty Objects to represent checkpoints
3. Drag the checkpoint objects into the list in RespawnManager as Transforms
4. In the corresponding gate, or in the function setting up checkpoints, get the RespawnManager.
5. FindObjectWithType<RespawnManager>() then RespawnManager.setRespawn(index), where index is the checkpoint index in the list createed in step 3
6. Then the checkpoint is set up. Test it and debug
