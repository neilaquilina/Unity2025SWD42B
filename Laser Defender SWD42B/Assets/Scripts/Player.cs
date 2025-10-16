using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// The movement speed of the player.
    /// Adjust this value to change how fast the player moves.
    /// </summary>
    [SerializeField] float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Get horizontal input (left/right arrow keys or A/D)
        float horizontal = Input.GetAxis("Horizontal");

        // Get vertical input (up/down arrow keys or W/S)
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement vector (X and Y axes, Z=0 for 2D)
        Vector3 movement = new Vector3(horizontal, vertical, 0f) * speed * Time.deltaTime;

        // Apply the movement to the player's transform
        transform.Translate(movement);
    }
}
