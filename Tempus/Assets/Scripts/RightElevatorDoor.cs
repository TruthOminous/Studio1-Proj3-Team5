using UnityEngine;
using System.Collections;

public class RightElevatorDoor : MonoBehaviour {

    Transform myTransform;

    PlayerControls playerControls;

    // Use this for initialization
    void Start ()
    {
        myTransform = this.transform;

        playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z >= 236.15f)
        {
            myTransform.position += new Vector3(0, 0, -0.01f);
        }

        if(transform.position.z <= 237.99f)
        {
            if (playerControls.transform.position.x <= 242f)
            {
                myTransform.position += new Vector3(0, 0, 0.02f);
            }
        }
    }
}
