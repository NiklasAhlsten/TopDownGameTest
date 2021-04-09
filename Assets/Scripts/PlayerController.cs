using UnityEngine;


public class PlayerController : MonoBehaviour

{
    [Tooltip("Movement Speed In Meters per Second")]
    public float movementSpeed = 0.1f;
    public PlayerInput playerInput;


    //public GameObject driver;


    // Update is called once per frame
    void Update()

    {
       bool enter = UnityEngine.Input.GetKeyDown(playerInput.enterKey);
       bool forward = UnityEngine.Input.GetKey(playerInput.forwardKey);
       bool left = UnityEngine.Input.GetKey(playerInput.leftKey);
       bool right = UnityEngine.Input.GetKey(playerInput.rightKey);
       bool back = UnityEngine.Input.GetKey(playerInput.backKey);

       if (forward)
    {
        transform.Translate(Vector3.up * (movementSpeed * Time.deltaTime));
    }
       if (left)
    {
        transform.Translate(Vector3.left * (movementSpeed * Time.deltaTime));
    }
       if (right)
    {
        transform.Translate(Vector3.right * (movementSpeed * Time.deltaTime));
    }
       if (back)
    {
        transform.Translate(Vector3.down * (movementSpeed * Time.deltaTime));
    }

      if (enter)
        {   // find the car gameobject through its name "NewCar"
            GameObject NewCar = GameObject.Find("NewCar");

            float distance = Vector3.Distance(NewCar.transform.position, this.transform.position);
            if (distance < 2f)

            {
                // Assign the value true
                // to the CarController-component (NewCarController)
                // On the NewCar GameObject
                NewCarController NewCarController = NewCar.GetComponent<NewCarController>();
                NewCarController.enabled = true;
                NewCarController.driver = this.gameObject;
                // And disable this' (the Human's) game object
                this.gameObject.SetActive(false);
            }
        }
    
    }

    //void start()
    //{
        
    //}

}
