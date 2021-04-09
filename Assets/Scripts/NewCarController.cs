using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class NewCarController : MonoBehaviour
{
    [Tooltip("Movement Speed In Meters per Second")]
    public float movementSpeed = 0.1f;
    public float rotationSpeed;

    public GameObject driver;
    public PlayerInput playerInput;

    void Update()
    {

        PlayerInput playerInput = driver.GetComponent<PlayerInput>();

        bool exit = Input.GetKeyDown(playerInput.enterKey);
        bool forward = Input.GetKey(playerInput.forwardKey);
        bool backward = Input.GetKey(playerInput.backKey);
        bool left = Input.GetKey(playerInput.leftKey);
        bool right = Input.GetKey(playerInput.rightKey);
        
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();

        if (forward)
        {
            rigidbody.AddForce((Vector3)(transform.up * movementSpeed * Time.deltaTime));
        }

        if (backward)
        {
            rigidbody.AddForce((Vector3)(- transform.up * movementSpeed * Time.deltaTime)); 

            /*if (left) // This inverts backwards movement
            transform.Rotate(0, 0, rigidbody.velocity.magnitude * Time.deltaTime);
            if (right)
            transform.Rotate(0, 0, - rigidbody.velocity.magnitude * Time.deltaTime); */
        }

        if (left && backward)
        {
            var rotateBy = new Vector3(0f, 0f, - rotationSpeed * Time.deltaTime * rigidbody.velocity.magnitude);
            transform.Rotate(rotateBy);
            rigidbody.velocity = Quaternion.Euler(rotateBy) * rigidbody.velocity;
        }

        if (right && backward)
        {
            var rotateBy = new Vector3(0f, 0f, rotationSpeed * Time.deltaTime * rigidbody.velocity.magnitude);
            transform.Rotate(rotateBy);
            rigidbody.velocity = Quaternion.Euler(rotateBy) * rigidbody.velocity;
        }

        if (left && !backward)
        {
            var rotateBy = new Vector3(0f, 0f, rotationSpeed * Time.deltaTime * rigidbody.velocity.magnitude);
            transform.Rotate(rotateBy);
            rigidbody.velocity = Quaternion.Euler(rotateBy) * rigidbody.velocity;
        }

        if (right && !backward)
        {
            var rotateBy = new Vector3(0f, 0f, - rotationSpeed * Time.deltaTime * rigidbody.velocity.magnitude);
            transform.Rotate(rotateBy);
            rigidbody.velocity = Quaternion.Euler(rotateBy) * rigidbody.velocity;
        }

        if (exit)
        {
            driver.transform.position = new Vector3(this.transform.position.x -1, this.transform.position.y); 
            driver.SetActive(true);
            this.enabled = false;
            driver = null;
        }
    }
}