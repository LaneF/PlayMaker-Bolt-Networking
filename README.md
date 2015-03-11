PlayMaker Bolt Networking Actions
================

Bolt is a Networking solution with a lot of front end features but still requires extensive scripting to use. This set of actions offloads all of the coding to Playmaker Actions and generic scripts so you can visually design the networking logic for your game in Playmaker.

========
Requirements
========

- Requires the Unity 5 RC3 DEBUG version due to NetworkTransform missing GetDynamic(). 
- Playmaker 1.8 (1.7.x will work, but the examples are done with 1.8).
- PlaymakerUtils git rep



========
Scripts
========

- Bolt Entity PlayMaker Proxy
... For initialization of Bolt Entity components. More features TBD.

- Bolt PlayMaker Utils
... This is where class shortcuts are made.

- BPCallback
... This is for generic State Property callbacks. Added at runtime.

- BPProjectHelper
... This script is not implemented. Vague code for accessing property lists through the compiler.

- TooltipAttribute
... This is for showing Inspector Tooltips in the Editor. I hate editor code.

========
Entity Actions
========

- Bolt Entity Get Prefab Id
- Bolt Entity Get Property
- Bolt Entity Has Control
- Bolt Entity Take Control

========
Basic API Actions
========

- Bolt Instantiate
- Bolt Is Client
- Bolt Is Server
- Bolt Start Client
- Bolt Start Server
- Bolt Load Level
- ...

========
States
========

- // Get
- Bolt State Get Bool
- Bolt State Get Color
- Bolt State Get Float
- Bolt State Get Int
- Bolt State Get Quaternion
- Bolt State Get Rect
- Bolt State Get String
- Bolt State Get Transform
- Bolt State Get Vector2
- Bolt State Get Vector3
- // Set
- Bolt State Set Bool
- Bolt State Set Color
- Bolt State Set Float
- Bolt State Set Int
- Bolt State Set Quaternion
- Bolt State Set Rect
- Bolt State Set String
- Bolt State Set Transform
- Bolt State Set Vector2
- Bolt State Set Vector3
- ...


========
Objects
========

- ...

========
Commands
========

- ...

========
Events
========

- ...
