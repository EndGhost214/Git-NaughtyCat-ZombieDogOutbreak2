
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    [SerializeField]
    private float bulletSpeed = 15f;
    private float bulletDamage = 10f;

    public float getDamage() {
        return bulletDamage;

    }

    Rigidbody2D rb;

    public void OnObjectSpawn()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;

        Vector2 force = transform.right * bulletSpeed;
        rb.AddForce(force, ForceMode2D.Impulse);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.SetActive(false);
    }
}
