### README for Vent.prefab ###

Overview:
	This prefab is for copying to each new room created on the map to mark where enemies should spawn in Zombie Dog Outbreak 2. The basic closed vent sprite was stolen from Among Us, though the other animation frames were made by me.
	
Video:
	https://youtu.be/dhBcAJklQ_c
	This video demonstrates the vent opening animation.

Child GameObjects:
	-none
		
Usage:
	Normally, the SpriteRenderer component displays the closed vent sprite from Among Us. There is also an Animator component that references the VentController animator controller. The animator controller contains three stages: Closed, Ready and Open. Closed is the default stage, where the vent displays the closed vent sprite. When Open is played, the vent open animation plays for roughly half a second and returns to Closed. The animator has one parameter: bool spawning, which causes the animator controller to wait in the Ready stage as long as it's true. Ready changes the normal closed sprite to a red glowing vent sprite. When spawning is set to false, the animator controller returns to Closed, finishing the Open animation first if needed.
	
	See the nextSpawn method in MapManager for an example:
		-Gets the Animator component of the vent that is about to spawn
		-Calls the Play method in Animator to jump to the Open stage
		-Resets the spawning parameter in the Animator for the current vent
		-Sets the spawning parameter in the Animator for the next vent that will be used
		
Troubleshooting:
	-Code integration:
		If the stages are not transitioning as intended or at all, ensure that the correct animator controller is attached to the Animator component, Update Mode is set to Normal, and Culling Mode is set to Always Animate.
		
		Please use the Play command only to jump to the Open stage, and use the spawning parameter to switch between the other two stages. If this pattern is not followed, the stages may interrupt each other or not respond to later changes to the parameter.
	
	-Manual adjustments:
		The sprite can be repositioned and resized as needed, but note that the final frame of the open animation increases the y dimension of the sprite by 30% for about 0.2s. If the sprite looks squished or shifts down during that frame, ensure that the Pivot option in the VentClosed Texture2D is set to Bottom.