### README for Wall.prefab ###

Overview:
	The purpose of this prefab is to have a wall sprite with a rectangular collider that can be easily copied around the map.
	
Child GameObjects:
	-none
		
Usage:
	The prefab can be positioned manually or by modifying its transform component with code at runtime.
		
Troubleshooting:
	If other GameObjects are not properly colliding with the wall, check that they have active colliders as well, and that the isTrigger flag on both GameObjects' colliders is set to false.