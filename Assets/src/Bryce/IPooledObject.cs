/*
 * IPooledObject.cs
 * Bryce Hendrickson
 * Interface for any object used by the object pooler
 */

//Interface for any pooled object, must have a OnObjectSpawn function, that will act as the spawning/awake function
public interface IPooledObject
{
    void OnObjectSpawn();
}

   