using UnityEngine;
using System.Collections;

public class LeftElevatorDoor : MonoBehaviour {

    Transform myTransform;

    BWEffect bWEffect;

    PlayerControls playerControls;

    public bool canRunGrey = true;

    public bool activateMovement = false;

	// Use this for initialization
	void Start ()
    {
        bWEffect = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<BWEffect>();

        myTransform = this.transform;

        playerControls = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControls>();        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (transform.position.z >= 241.85f)
        {
            bWEffect.enabled = true;
        }*/

        if (transform.position.z <= 241.85f)
        {
            myTransform.position += new Vector3(0, 0, 0.01f);

            if (canRunGrey == true)
            {
                bWEffect.intensity += 0.0055f;
            }               
        }

        if (transform.position.z >= 240.03f)
        {
            if (playerControls.transform.position.x <= 242f)
            {
                canRunGrey = false;                

                myTransform.position += new Vector3(0, 0, -0.02f);
            }
        }

        if(transform.position.z >= 241.75f)
        {
            activateMovement = true;
        }
    }    
}
