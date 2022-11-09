/*
 * Bullet.cs
 * Bryce Hendrickson
 * Bullet controller script
 */
using UnityEngine;

/*
 * Bullet class to control the bullet prefab
 * 
 * member variables:
 * bulletSpeed - speed of the bullet
 * bulletDamage - damage of the bullet
 * rb - ridged body of the bullet
 * OnCollisionEnter2D() - Unity oncollision to inactivate bullet on any collision
 * GetDamage() - returns the damage value of the bullet
 *  OnObjectSpawn() - spawn function for the bullet
 */
public class Bullet : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private float bulletSpeed = 15f;
    private float bulletDamage = 100f;

    private Rigidbody2D rb;

    //Unity oncollision to inactivate bullet on any collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
    
    //Returns damage value of the bullet
    public float GetDamage() {
        return bulletDamage;

    }

    //Spawn function for the bullet
    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;

        Vector2 force = transform.right * bulletSpeed;
        rb.AddForce(force, ForceMode2D.Impulse);
        
    }

}
