/*
 * Shooter.cs
 * Bryce Hendrickson
 * Gun movement and inputs for playable survival player
 */
using UnityEngine;


/*
 * Shooter class to control gun and gun inputs
 * 
 * member variables:
 * bulletPrefab - bulletprefab
 * firePoint - where the bullet will spawn
 * fireRate - rate of fire
 * nextTimeToFire - time between gun fire
 * MAX_AMMO - maximum amount of ammo the player can carry
 * ammoCount - current count of player ammo
 * rotateY - rotation variable for flipping character
 * mag - size of mag
 * Update() - called every frame
 * ReserveAmmoCount() - returns the count of the reserve ammo
 * MagAmmoCount() - returns the count of the ammo in the mag
 * OnCollisionEnter2D() - Inactivates the bullet drop on colission
 * Shoot() - spawns a bullet in from the object pool
 */
public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private float fireRate = 10f;
    private float nextTimeToFire = 0f;
    private int MAX_AMMO = 270;
    private int ammoCount = 270;
    private int mag = 30;
    private int MAG_SIZE = 30;
    float rotateY = 0f;

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
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire && mag!=0)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
            mag--;
            
        }
        else if (Input.GetMouseButton(0) && mag == 0)
        {
            SoundManager.Instance.gunEmptySoundFunction();
        }

        //Repload with R
        if (Input.GetKeyDown(KeyCode.R))
        {

            int reload = 30 - mag;
            if(ammoCount >= 30)
            {
                SoundManager.Instance.gunReloadSoundFunction();
                ammoCount = ammoCount - reload;
                mag = 30;
            }
            else
            {
                SoundManager.Instance.gunReloadSoundFunction();
                mag = ammoCount;
                ammoCount = 0;
            }
        }

    }

    //OnTrigger to check for bullet pickup, adds bullets then inactivates bullet drop
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bulletdrop")
        {
            
            SoundManager.Instance.pickUpFunction();
            ammoCount = ammoCount + (MAG_SIZE * 3);
            if (ammoCount > MAX_AMMO)
            {
                ammoCount = MAX_AMMO;
            }
            other.gameObject.SetActive(false);
        }
    }

   

    //Returns the count of thr reserve ammo
    public int ReserveAmmoCount()
    {
        return ammoCount;
    }

    //Returns the count of the ammo left in the mag
    public int MagAmmoCount()
    {
        return mag;
    }



    //Plays gun sound and spawns a bullet from the ObjectPooler
    private void Shoot()
    {
        SoundManager.Instance.gunSoundFunction();
       
        ObjectPooler.Instance.SpawnFromPool("Bullet", firePoint.transform.position, firePoint.transform.rotation);
     
    }

}
