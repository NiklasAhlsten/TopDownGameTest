using UnityEngine;

public class CarController : MonoBehaviour
{

    public float rotationSpeed = 0.5f;
    public float movementSpeed = 0.5f;
    public KeyCode rotateLeftKey;
    public KeyCode rotateRightKey;
    public KeyCode moveForwardKey;
    public KeyCode moveBackwardKey;
    //private Rigidbody2D car;

    // Start is called before the first frame update
    void Start()
    {
        //car = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool rotateLeft = UnityEngine.Input.GetKey(rotateLeftKey);
        bool rotateRight = UnityEngine.Input.GetKey(rotateRightKey);
        bool moveForward = UnityEngine.Input.GetKey(moveForwardKey);
        bool moveBackward = UnityEngine.Input.GetKey(moveBackwardKey);

        if (rotateLeft)
    {
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
        if (rotateRight)
    {
        transform.Rotate(0f, 0f, - rotationSpeed * Time.deltaTime);
    }
    
       if (moveForward)
    {
        transform.Translate(Vector3.up * (movementSpeed * Time.deltaTime));
    }
       
        if (moveBackward)
    {
        transform.Translate(Vector3.down * (movementSpeed * Time.deltaTime));
    }

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.AddForce((Vector2)(transform.up*movementSpeed));

    }
}