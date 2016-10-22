using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    public GameObject player;
    PlayerControls playerControls;

	// Use this for initialization
	void Start ()
    {
        playerControls = player.GetComponent<PlayerControls>();
	}
	
	// Update is called once per frame
	void Update ()
    {
               	
	}
    
}
