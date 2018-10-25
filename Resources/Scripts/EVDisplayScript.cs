using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EVDisplayScript : MonoBehaviour {

    public int ev_score;

    Text text;
	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        text = GetComponent<Text>();
        ev_score = 100;
    }

    // Update is called once per frame
    void Update () {
        text.text = "EV: " + ev_score;
	}
}
