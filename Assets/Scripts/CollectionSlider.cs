using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionSlider : MonoBehaviour
{
    private int sliderNumber;
    public GameObject CollectionOne, CollectionTwo, CollectionThree, CollectionFour;
    public Text collectionHeader;
    void Start()
    {
        sliderNumber = 1;
    }

    private void Update()
    {
        if (sliderNumber == 1)
        {
            CollectionOne.SetActive(true);
            CollectionTwo.SetActive(false);
            CollectionThree.SetActive(false);
            CollectionFour.SetActive(false);
            collectionHeader.text = CollectionOne.gameObject.name;
        }else if (sliderNumber == 2)
        {
            CollectionOne.SetActive(false);
            CollectionTwo.SetActive(true);
            CollectionThree.SetActive(false);
            CollectionFour.SetActive(false);
            collectionHeader.text = CollectionTwo.gameObject.name;
        }
        else if (sliderNumber == 3)
        {
            CollectionOne.SetActive(false);
            CollectionTwo.SetActive(false);
            CollectionThree.SetActive(true);
            CollectionFour.SetActive(false);
            collectionHeader.text = CollectionThree.gameObject.name;
        }
        else if (sliderNumber == 4)
        {
            CollectionOne.SetActive(false);
            CollectionTwo.SetActive(false);
            CollectionThree.SetActive(false);
            CollectionFour.SetActive(true);
            collectionHeader.text = CollectionFour.gameObject.name;
        }
    }

    public void moveSliderRight()
    {
        sliderNumber++;
        if (sliderNumber == 5)
        {
            sliderNumber = 1;
        }
    }
}
