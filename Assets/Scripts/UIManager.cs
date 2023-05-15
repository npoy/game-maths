using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject tank;
    public GameObject fuel;
    public Text tankPosition;
    public Text fuelPosition;
    public Text energyAmt;

    // Start is called before the first frame update
    void Start()
    {
        tankPosition.text = tank.transform.position + "";
        fuelPosition.text = fuel.GetComponent<ObjectManager>().objPosition + "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddEnergy(string amt) {
        int n;
        if (int.TryParse(amt, out n)) {
            energyAmt.text = amt;
        }
    }
}
