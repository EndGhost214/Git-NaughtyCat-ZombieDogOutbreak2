### README for Door.prefab ###

Overview:
	The purpose of this prefab is to have a door sprite with a collider that can be easily copied to each room created in the map.
	
Video:
	https://youtu.be/FBkZXyQ0b28
		This video demonstrates one door being unlocked and another that is still blocking access to a room.

Child GameObjects:
	-'sprite':
		This has a SpriteRenderer component that displays a basic gray door sprite.
		
Usage:
	The prefab and its child GameObject can be positioned manually or by modifying their transform components with code at runtime.
		
Troubleshooting:
	-Code integration:
		In order to get the child components dynamically, you have to use the Find method in Transform, not the more common GameObject Find.
	
	-Manual adjustments:
		If you want to change the size of the door, it's easiest to use the scale tool on the parent object (named 'door'), as that changes the box collider as well. If you adjust the size or position of just the child object (named 'sprite'), then the collider will not be positioned correctly, and the door may have an offset from the parent position.