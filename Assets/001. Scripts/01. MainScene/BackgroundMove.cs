using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour {

    private RectTransform rtr;

    public float speed;
	// Use this for initialization
	void Start () {
        rtr = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {

		if(rtr.anchoredPosition.x >= -3840.0f)
        {
            rtr.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            rtr.anchoredPosition = new Vector2(0.0f, 0);
        }

	}
}
