using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
       /*Vector3 direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Ensure the mouse position is in the same Z-axis as the arrow

        // Calculate the direction from the arrow to the mouse
        Vector2 direction = (mousePos - transform.position).normalized;

        // Calculate the rotation angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the arrow to face the mouse
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}
