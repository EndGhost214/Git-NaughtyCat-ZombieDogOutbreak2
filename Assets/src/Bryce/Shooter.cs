using UnityEngine;

public class Shooter : MonoBehaviour
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

    private float maxAmmo = 270;

    public float ammoCount = 270;
    private float mag = 30;



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
            //ShootCoolDown();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SoundManager.Instance.gunReloadSoundFunction();

            float reload = 30 - mag;
            if(ammoCount >= 30)
            {
                ammoCount = ammoCount - reload;
                mag = 30;
            }
            else
            {
                mag = ammoCount;
                ammoCount = 0;
            }
        }

    }

    private void Shoot()
    {
        SoundManager.Instance.gunSoundFunction();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        //Quaternion casingRotation = Quaternion.Euler(0, 0, -90);
       // GameObject bulletCasing = Instantiate(bulletCasingPrefab, ejectPoint.transform.position, casingRotation);
        Destroy(bullet, 5f);
       // Destroy(bulletCasing, 15f);
        //Debug.Log("Shoot!");
    }

   

}
