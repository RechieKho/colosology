### Unity Code Base 2D
This is framework (I'm not sure should I name it as a framework) for making Unity 2D game.

It contains:
 - Leantween (last updated: 2020-8-10; not dare to update as I modified it to allow tween TextMeshPro's color)
 - Delight (A component-based UI tool, https://delight-dev.github.io/)
 - Some Kenney's Asset (https://www.kenney.nl/assets)
 - Task.cs (Start Coroutine with better interface)
 - Homemade Code: 
   - Movement class (move rigidbody by applying calculated force based on desired velocity)
   - Health System (A Health system for attack system)
   - Attack System (An attack system with lots of parameter)
   - Twn (A system allow you to LeanTween stuff precisely)
   - Timer (timer created from Task.cs)
   - GizmoDebug (A better OnDrawGizmo that allow you to draw gizmo without worrying your class is inherit by monobehaviour or not)
   - MinorAudioManager (Best for control background music, audio can be played across scene)
   - ZonalAudioManager (Best for sound effect, 3D audio but cannot be played across scene)
   - SceneDirector (SceneManager.LoadScene but with transition that you can create one your own)
   - ParticleManager (Extremely Easy particle system manager, control particle system's Play, Pause, Stop "cleanly" as all particle system is in one obj)
