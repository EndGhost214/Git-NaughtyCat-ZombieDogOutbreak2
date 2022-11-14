### README for BasicRoom.prefab ###

Overview:
	This prefab contains the two basic components for rooms in Zombie Dog Outbreak 2.
	
Child GameObjects:
	-'door':
		This object will be copied as needed for all doors on the map and should block the player and enemies from passing. It has a BoxCollider2D component and a child GameObject 'sprite' with a SpriteRenderer component that displays a basic gray door sprite.
	-'vent':
		Has a SpriteRenderer component that displays the closed vent sprite taken from Among Us. It also 