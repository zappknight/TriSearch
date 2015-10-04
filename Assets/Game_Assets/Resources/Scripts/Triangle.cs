﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Triangle : Default {
	public List<GameObject> options;
    public int faixa;
	void Awake() {
		options = new List<GameObject>();
	}

	public override void OnTouch(object t)
	{
		if(Input.GetMouseButtonDown(0)) {
            if(FindObjectOfType<GameManager>().selected == null) {
                Debug.Log("Added to selected");
                FindObjectOfType<GameManager>().selected = this.gameObject;
            } else if (CheckTriangles(FindObjectOfType<GameManager>().selected)
			        && FindObjectOfType<GameManager>().selected.GetComponent<SpriteRenderer>().color != gameObject.GetComponent<SpriteRenderer>().color) {
                Color c = GetComponent<SpriteRenderer>().color;
                GetComponent<SpriteRenderer>().color = FindObjectOfType<GameManager>().selected.GetComponent<SpriteRenderer>().color;
                FindObjectOfType<GameManager>().selected.GetComponent<SpriteRenderer>().color = c;
                FindObjectOfType<GameManager>().moves++;
                FindObjectOfType<GameManager>().selected = null;
            } else {
                FindObjectOfType<GameManager>().selected = this.gameObject; 
            }
        }
	}
    
	public bool CheckTriangles (GameObject tri) {
        foreach(GameObject g in options)
        {
            if (g == tri) return true;
        }

        return false;

		
	}

	new void Update () {
		base.Update ();
	}
}