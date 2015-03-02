PlayMaker Bolt Networking Actions
================

Bolt is a Networking solution with a lot of front end features but still requires extensive scripting to build a proper networking solution. The idea with these actions is to offer actions that can handle as much of the basic API directly as possible and supply a Proxy Script which has the purpose of offloading generic workload that custom scripts would typically handle.

- Requires latest patch for the Transform sync to work due to NetworkTransform missing GetDynamic().


========
Proxy Script
========
Depending on how generic these segments can be, the scope may change drastically.

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
- Bolt Is Host

========
States
========

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
