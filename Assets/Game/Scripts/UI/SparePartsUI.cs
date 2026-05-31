using UnityEngine;

public class SparePartsUI : MonoBehaviour
{
    private int sparePartsAmount;
    private GameObject zero;
    private GameObject one;
    private GameObject two;
    private GameObject three;
    private GameObject four;
    private GameObject five;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zero = this.transform.GetChild(0).gameObject;
        one = this.transform.GetChild(1).gameObject;
        two = this.transform.GetChild(2).gameObject;
        three = this.transform.GetChild(3).gameObject;
        four = this.transform.GetChild(4).gameObject;
        five = this.transform.GetChild(5).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(sparePartsAmount == 1)
        {
            zero.SetActive(false);
            one.SetActive(true);
        }
        else if(sparePartsAmount == 2)
        {
            one.SetActive(false);
            two.SetActive(true);
        }
        else if(sparePartsAmount == 3)
        {
            two.SetActive(false);
            three.SetActive(true);
        }
        else if(sparePartsAmount == 4)
        {
            three.SetActive(false);
            four.SetActive(true);
        }
        else if(sparePartsAmount == 5)
        {
            four.SetActive(false);
            five.SetActive(true);
        }
        else
        {
            zero.SetActive(true);
            one.SetActive(false);
            two.SetActive(false);
            three.SetActive(false);
            four.SetActive(false);
            five.SetActive(false);
        }
    }

    public void UpdateSPAmount(int amount)
    {
        sparePartsAmount = amount;
    }
}
