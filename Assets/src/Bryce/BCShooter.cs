/*
 * BCShooter.cs
 * Bryce Hendrickson
 * BC player shooting script
 */
using UnityEngine;

/*
 * BCShooter class to control the shooting inputs for the BC players gun
 * 
 * member variables:
 * bulletPrefab - bulletprefab
 * firePoint - where the bullet will spawn
 * fireRate - rate of fire
 * nextTimeToFire - time between gun fire
 * rotateY - rotation variable for flipping character
 * Update() - called every frame
 * OnCollisionEnter2D() - Inactivates the bullet drop on colission
 * Shoot() - spawns a bullet in from the object pool
 */
public class BCShooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private float fireRate = 10f;
    private float nextTimeToFire = 0f;
    private float rotateY = 0f;

    /*
    * Update function
    * Will rotate sprite based off of mouse position
    * Will check for M1 click for gun fire
    * Will check for "R" for reload
    */
    private void Update()
    {
        //retreiving mouse position for gun movement
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //rotation variable for flipping character
        rotateY = 0f;

        //checking if the mouse flipped to the opposite side of the character - sets roate to 180deg
        if(mousePos.x < transform.position.x)
        {
            rotateY = 180f;
        }

        //rotates sprite based off of rotation variable 
        transform.eulerAngles = new Vector3(transform.rotation.x, rotateY, transform.rotation.z);
        
        //Shooting with M1 click
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire )
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

    }

    //OnTrigger to check for bullet pickup and inactivates bullet drop
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bulletdrop")
        {
            SoundManager.Instance.pickUpFunction();
            other.gameObject.SetActive(false);
        }
        
    }

    //Plays gun sound and spawns a bullet from the ObjectPooler
    private void Shoot()
    {
        SoundManager.Instance.gunSoundFunction();
        ObjectPooler.Instance.SpawnFromPool("Bullet", firePoint.transform.position, firePoint.transform.rotation);
    }

   

}
