using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour {

    Transform myTransform;

	// Use this for initialization
	void Start ()
    {
        myTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        myTransform.position += new Vector3(0, -0.16f, 0);
    }
}
