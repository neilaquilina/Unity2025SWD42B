using UnityEngine;

public class Rotate : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //create a script in Unity 2D that rotates a cube on the y-axis.
        //explain using comments
        print("Game started");
    }
    
    /// The rotation speed in degrees per second.
    /// Adjust this value to change how fast the cube rotates.
    
    [SerializeField] float rotationSpeed = 50f;
    /// <summary>
    /// The amount to increase or decrease the speed by per key press.
    /// </summary>
    [SerializeField] float speedIncrement = 10f;

    // Update is called once per frame
    void Update()
    {
        // Check for up arrow key press to increase rotation speed
        // Clamp the speed to a maximum of 300 and a minimum of 5
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rotationSpeed += speedIncrement;
            rotationSpeed = Mathf.Clamp(rotationSpeed, 5f, 300f);
            Debug.Log("Current rotation speed: " + rotationSpeed);
        }

        // Check for down arrow key press to decrease rotation speed
        //limit the speed to a minimum of 5 and a maximum of 300
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            rotationSpeed -= speedIncrement;
            rotationSpeed = Mathf.Clamp(rotationSpeed, 5f, 300f);
            Debug.Log("Current rotation speed: " + rotationSpeed);
        }

        // Rotate the object around the Y-axis (up vector) at the specified speed.
        // Multiply by Time.deltaTime to make rotation frame-rate independent.
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }
}