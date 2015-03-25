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
Support Scripts
========

- Bolt Entity Playmaker Proxy "Proxy and Initialization script for all Bolt Entities."
- Bolt PlayMaker Utils "Scripting shortcuts and helper classes."
- CallbackEvent "A script for a custom Callback on an Entity."
- CallbackGlobalProxy "A static class for proxying Bolt Global Callbacks as Broadcasted FsmEvents."
- TooltipAttribute "Inspector tooltips."

========
Editor Scripts
========

- BPEditorUtils "Custom Action Editor support scipt. Accesses Bolt.Compiler for static data. "
- CallbackEditor "Custom Action Editor for *Bolt Global Callback Get Data*. "
- EventSendEditor "Custom Action Editor for *Bolt Event Send*. "
- Menus "Menu buttons for the Unity Editor.. "
- TooltipDrawer "Draws the tooltips for Inspector scripts. "

========
Entity Actions
========

- Bolt Entity Get Prefab Id
- Bolt Entity Get Property
- Bolt Entity Has Control
- Bolt Entity Take Control
- Bolt Entity Release Control

========
Basic API Actions
========

- Bolt Instantiate
- Bolt Is Client
- Bolt Is Server
- Bolt Load Level
- Bolt Server Get Client Count
- Bolt Server Get Connection Data
- Bolt Start Client
- Bolt Start Server
- ...

========
States
========

- Bolt State Property Add Callback
- Bolt State Property Remove Callback
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
Events
========

- Bolt Event Send
- Bolt Event Send By Name
- Bolt Global Callback Get Data
- Bolt Global Event Listener
- ...


========
Objects
========

- ...

========
Commands
========

- ...


