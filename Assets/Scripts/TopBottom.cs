using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBottom : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the other collider is the player
        if (other.CompareTag("Player"))
        {
            // Get the player's position
            Vector3 playerPos = other.transform.position;

            // Get the border's dimensions
            Vector2 borderSize = GetComponent<BoxCollider2D>().size;

            // Calculate the x and y boundaries of the border
            float bottomBound = transform.position.y - borderSize.y / 2f;
            float topBound = transform.position.y + borderSize.y / 2f;

            // Keep the player within the boundary
            
            float clampedY = Mathf.Clamp(playerPos.y, bottomBound, topBound);
            other.transform.position = new Vector3(clampedY, playerPos.z);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
