using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Presentation : MonoBehaviour {

	private GameObject image;
    public GameObject squidward;

	void Start () {
		
	}
	
	void Update () {
		image = GameObject.Find ("Images");
		if (image.GetComponent<SpriteRenderer>().sprite.name == "blank" || Input.anyKey)
		{
			SceneManager.LoadScene (1);
		}
        if (image.GetComponent<SpriteRenderer>().sprite.name == "nombres 2")
        {
            squidward.GetComponent<Animator>().SetBool("dance", true);
        }
	}
}
