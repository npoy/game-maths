using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AttributeManager : MonoBehaviour
{
    static public int MAGIC = 16;
    static public int INTELLIGENCE = 8;
    static public int CHARISMA = 4;
    static public int FLY = 2;
    static public int INVISIBLE = 1;

    static public int BLUEKEY = 4;
    static public int REDKEY = 2;
    static public int GREENKEY = 1;
    
    public Text attributeDisplay;
    public int attributes = 0;

    private void OnTriggerEnter(Collider other) {
        // First group of doors
        if (other.gameObject.tag == "MAGIC") {
            attributes ^= MAGIC;
        } else if (other.gameObject.tag == "INTELLIGENCE") {
            attributes |= INTELLIGENCE;
        } else if (other.gameObject.tag == "CHARISMA") {
            attributes |= CHARISMA;
        } else if (other.gameObject.tag == "FLY") {
            attributes |= FLY;
        } else if (other.gameObject.tag == "INVISIBLE") {
            attributes |= INVISIBLE;
        } else if (other.gameObject.tag == "ANTIMAGIC") {
            attributes &= ~MAGIC;
        } else if (other.gameObject.tag == "REMOVE") {
            attributes &= ~(INTELLIGENCE | MAGIC);
        } else if (other.gameObject.tag == "ADD") {
            attributes |= (INTELLIGENCE | MAGIC | CHARISMA);
        } else if (other.gameObject.tag == "RESET") {
            attributes = 0;
        }

        // Keys and doors
        if (other.gameObject.tag == "BLUE_KEY") {
            attributes |= BLUEKEY;
            Destroy(other.gameObject);
        } else if (other.gameObject.tag == "RED_KEY") {
            attributes |= REDKEY;
            Destroy(other.gameObject);
        } else if (other.gameObject.tag == "GREEN_KEY") {
            attributes |= GREENKEY;
             Destroy(other.gameObject);
        } else if (other.gameObject.tag == "GOLD_KEY") {
            attributes |= (BLUEKEY | REDKEY | GREENKEY);
            Destroy(other.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        attributeDisplay.transform.position = screenPoint + new Vector3(0,-50,0);
        attributeDisplay.text = Convert.ToString(attributes, 2).PadLeft(8, '0');
    }
}
