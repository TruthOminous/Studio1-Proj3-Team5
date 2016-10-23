using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlueCube : MonoBehaviour {

    public Text text;

    public Text dialogueText;

    public AudioSource blueCubeNarration;

	// Use this for initialization
	void Start ()
    {
        text.enabled = false;

        dialogueText.enabled = false;

        blueCubeNarration.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
