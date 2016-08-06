# Notes for Users
This document sets out some of the design principles for DQME including the extent to which it supports

## Stable Saving
When you open a mod directory, make changes and save, DQME merges your changes back into the existing XML files rather than overwriting them. This means that any XML that DQME does not understand, including XML comments, is (in most cases) preserved. The order in which the information is given in the file is also preserved. Similarly, DQME preserves any files present in the mod directory that it is not able to understand.

## Format Requirements
DQME does not tolerate the following problems in mod XML files:
  * Malformed XML (e.g. unclosed elements)
  
DQME does tolerate the following:
  * References to entities that are not defined (e.g. an enemy defined as using an attack with a particular id where that attack is not defined)
  
DQME also imposes the following additional requirements, which may go beyond what is required in order for the game to load a mod directory correctly.
  * All New Game Plus enemies (i.e. those defined in MOD_FOLDER/xml/enemy_plus.xml) must have ids ending with "_plus". Enemies that are not new game plus (i.e. those defined in MOD_FOLDER/xml/enemy.xml) must now have ids ending with "_plus".
  * All HD skins (skins are defined in the files in MOD_FOLDER/xml/entities/enemies) must have ids ending with "_hd". Non-HD skins must not have ids ending with "_hd".
  * DQME may in general be less tolerant of issues such as misformatted numbers, duplication of elements which should only appear once (e.g. two \<graphic\> elements within the same enemy definition in enemy.xml) than the game itself is.
