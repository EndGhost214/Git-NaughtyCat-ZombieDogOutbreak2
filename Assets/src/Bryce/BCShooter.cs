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

    //Oncollision to check for bullet pickup and deletes bullet drop
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bulletdrop")
        {
            Destroy(collision.gameObject);
        }
        
    }

    private void Shoot()
    {
        SoundManager.Instance.gunSoundFunction();
        ObjectPooler.Instance.SpawnFromPool("Bullet", firePoint.transform.position, firePoint.transform.rotation);

    }

   

}
