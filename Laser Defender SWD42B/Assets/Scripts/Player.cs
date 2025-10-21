using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// The movement speed of the player.
    /// Adjust this value to change how fast the player moves.
    /// </summary>
    [SerializeField] float speed = 5f;

    // Reference to the main camera
    private Camera mainCamera;

    [SerializeField] GameObject laserPrefab;

    Vector3 playerPosition;

    IEnumerator laserCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;

        laserCoroutine = ShootLaserContinuously();
    }

    /// <summary>
    /// Handles screen wrapping for the player.
    /// If the player goes off one side of the screen, they appear on the opposite side.
    /// </summary>
    private void WrapPlayer()
    {
        // Convert screen coordinates to world coordinates
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        // Check horizontal wrapping
        if (viewportPosition.x > 1f)
        {
            viewportPosition.x = 0f;
        }
        else if (viewportPosition.x < 0f)
        {
            viewportPosition.x = 1f;
        }

        // Check vertical wrapping
        if (viewportPosition.y > 1f)
        {
            viewportPosition.y = 0f;
        }
        else if (viewportPosition.y < 0f)
        {
            viewportPosition.y = 1f;
        }

        // Convert back to world coordinates and apply
        transform.position = mainCamera.ViewportToWorldPoint(viewportPosition);
    }


    void PlayerMove()
    {
        // Get horizontal input (left/right arrow keys or A/D)
        float horizontal = Input.GetAxis("Horizontal");

        // Get vertical input (up/down arrow keys or W/S)
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement vector (X and Y axes, Z=0 for 2D)
        Vector2 movement = new Vector2(horizontal, vertical) * speed * Time.deltaTime;

        // Apply the movement to the player's transform
        transform.Translate(movement);
    }

    void ShootLaser()
    {

        // Check for left mouse button click to start shooting
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(laserCoroutine);
        }

        // Check for left mouse button release to stop shooting
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(laserCoroutine);
        }
    }

    IEnumerator ShootLaserContinuously()
    {

        //loop until coroutine is stopped
        while (true)
        {
            playerPosition = new Vector3 (transform.position.x, transform.position.y + 0.5f, 0f);
            // Instantiate the laser prefab at the player's position with no rotation
            GameObject laser = Instantiate(laserPrefab, playerPosition, Quaternion.identity);
            //move the laser upward
            laser.GetComponent<Rigidbody2D>().linearVelocityY = 10f;
            // Optionally, destroy the laser after a certain time to avoid clutter
            Destroy(laser, 5f);
            yield return new WaitForSeconds(0.2f); // pause for 0.2 seconds before next shot
        }
    }


    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        WrapPlayer();
        ShootLaser();
        
    }
}
