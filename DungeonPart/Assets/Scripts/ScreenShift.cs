using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShift : MonoBehaviour {

    private static Animator screenShift;

	// Use this for initialization
	void Start () {
        screenShift = GetComponent<Animator>();	
	}
		
	public static void In()
    {
        screenShift.SetBool("isSet", true);
        screenShift.SetBool("isFunction", false);
        screenShift.Play("in_screen_shift");
    }

    public static void Out()
    {
        screenShift.SetBool("isFunction", true);
        screenShift.SetBool("isSet", false);
    }
}
