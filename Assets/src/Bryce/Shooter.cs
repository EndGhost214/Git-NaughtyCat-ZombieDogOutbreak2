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
 * mag - size of mag
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
    private float MAX_AMMO = 270;
    public float ammoCount = 270;
    private float mag = 30;

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
        float rotateY = 0f;



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

        if (Input.GetKeyDown(KeyCode.R))
        {

            float reload = 30 - mag;
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

    //Plays gun sound and spawns a bullet from the ObjectPooler
    private void Shoot()
    {
        SoundManager.Instance.gunSoundFunction();
       
        ObjectPooler.Instance.SpawnFromPool("Bullet", firePoint.transform.position, firePoint.transform.rotation);
     
    }

   

}
