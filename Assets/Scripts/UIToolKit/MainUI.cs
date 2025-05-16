using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class MainUI : MonoBehaviour
{
    [SerializeField] UIDocument myUI;

    private Button TopButton;
    private Button SliderButton;
    private Slider mySlider;

    public Player player;

    private void Start()
    {
        VisualElement root = myUI.rootVisualElement;

        TopButton = root.Q<Button>("TopButton");
        SliderButton = root.Q<Button>("MaxSliderButton");
        mySlider = root.Q<Slider>("Damage");

        mySlider.RegisterValueChangedCallback(v =>
        {
            var oldValue = v.previousValue;
            var newValue = v.newValue;
            Debug.Log(v.newValue);
            player.Damage = v.newValue;
        });

        if (TopButton != null)
        {
            TopButton.clicked += OnMyButtonClick;
        }

        if (SliderButton != null)
        {
            SliderButton.clicked += OnMyMaxSliderClick;
        }

    }
    
    private void OnMyButtonClick()
    {
        Debug.Log("Button clicked!");
    }

    private void OnMyMaxSliderClick()
    {
        mySlider.value = 0;
        StartCoroutine(AddSliderValue());
    }


    private IEnumerator AddSliderValue()
    {
        while (true)
        {
            mySlider.value++;
            yield return new WaitForSeconds(0.05f);
            if (mySlider.value == mySlider.highValue)
                break;
        }
    }

    internal void UpdatePowerSlider(int power)
    {
        //throw new NotImplementedException();
    }
}
