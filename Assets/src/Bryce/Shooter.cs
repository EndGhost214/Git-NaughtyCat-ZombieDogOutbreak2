using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform firePoint;

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
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
            //ShootCoolDown();
        }

    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        Destroy(bullet, 5f);
        Debug.Log("Shoot!");
    }

   

}
