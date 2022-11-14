/*
 * Gun.cs
 * Bryce Hendrickson
 * Gun movement
 */
using UnityEngine;


/*
 * Gun class to control the gun movement
 * 
 * mousePos - Position of the mouse
 * gunPos - Position of the gun
 * angle - Position for the gun to rotate to
 * Update() - Called every frame, will update the gun's position to face the mouse position
 */
public class Gun : MonoBehaviour
{
    //Called every frame will update the gun's position to face the mouse position
    private void Update()
    {
        //Current mouse position
        Vector3 mousePos = Input.mousePosition;

        //Current gun position
        Vector3 gunPos = Camera.main.WorldToScreenPoint(transform.position);

        //setting difference of mouse and gun positions
        mousePos.x = mousePos.x - gunPos.x;
        mousePos.y = mousePos.y - gunPos.y;

        //Calculating the absolute angle of gun 
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        
        //Checking if the gun has passed the center line, flips sprite if so
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(new Vector3(180f,0f,-angle));
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        }
    }

}
