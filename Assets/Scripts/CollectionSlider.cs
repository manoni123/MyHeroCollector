using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectionSlider : MonoBehaviour
{
    private int sliderNumber;
    public GameObject CollectionOne, CollectionTwo, CollectionThree;
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
            collectionHeader.text = CollectionOne.gameObject.name;
        }else if (sliderNumber == 2)
        {
            CollectionOne.SetActive(false);
            CollectionTwo.SetActive(true);
            CollectionThree.SetActive(false);
            collectionHeader.text = CollectionTwo.gameObject.name;
        }
        else if (sliderNumber == 3)
        {
            CollectionOne.SetActive(false);
            CollectionTwo.SetActive(false);
            CollectionThree.SetActive(true);
            collectionHeader.text = CollectionThree.gameObject.name;
        }
    }

    public void moveSliderRight()
    {
        sliderNumber++;
        if (sliderNumber == 4)
        {
            sliderNumber = 1;
        }
    }
}
