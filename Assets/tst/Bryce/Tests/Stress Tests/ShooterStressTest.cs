using UnityEngine;

public class ShooterStressTest : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    //[SerializeField]
    //private GameObject bulletCasingPrefab;

    [SerializeField]
    private Transform firePoint;

   // [SerializeField]
   // private Transform ejectPoint;

    [SerializeField]
    private float fireRate = 10f;
    private float nextTimeToFire = 0f;

    long bulletCount = 0;

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
          if ( Time.time >= nextTimeToFire)
          {
             nextTimeToFire =  1f / fireRate;
             Shoot();
             fireRate++;
             bulletCount++;
             Debug.Log("Bullet Count: " + bulletCount);
             Debug.Log("Fire Rate: " + fireRate);

          }


    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        
       // Destroy(bullet, 5f);
     
    }

   

}
