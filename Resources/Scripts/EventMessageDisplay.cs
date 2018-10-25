using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EventMessageDisplay : MonoBehaviour {

    Text text;
    public string message;
	// Use this for initialization
	void Start () {
	
	}

    void Awake()
    {
        message = "";
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update () {
        text.text = message;
	}
}
