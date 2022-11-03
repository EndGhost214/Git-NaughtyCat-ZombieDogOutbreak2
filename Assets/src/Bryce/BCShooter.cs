using UnityEngine;

public class BCShooter : MonoBehaviour
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
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire )
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();

            //ShootCoolDown();
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
