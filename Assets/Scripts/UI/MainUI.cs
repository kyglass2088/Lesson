using System;
using UnityEngine;
using UnityEngine.UIElements;

public class MainUI : MonoBehaviour
{
    public VisualElement mainUI;

    const int minHp = 0;

    PlayerData playerData;

    ProgressBar HpBar;
    Label LifeLabel;
    Label TimeLabel;
    Label Stage;
    Label ETCLabel;
    Label ClearMessage;
    Label GameOverMessage;
    Button AgainButton;
    Button ExitButton;

    private void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        HpBar = root.Q<ProgressBar>("Hp");
        LifeLabel = root.Q<Label>("Life");
        TimeLabel = root.Q<Label>("Time");
        Stage = root.Q<Label>("State");
        ETCLabel = root.Q<Label>("Etc");
        ClearMessage = root.Q<Label>("ClearMessage");
        GameOverMessage = root.Q<Label>("GameOver");
        AgainButton = root.Q<Button>("AgainButton");
        ExitButton = root.Q<Button>("ExitButton");

        ClearMessage.visible = false;
        GameOverMessage.visible = false;
        AgainButton.visible = false;
        ExitButton.visible = false;

        //HpBar.value = Player.Power

        Player.OnGameOverEvent += Player_OnGameOverEvent;
        Goal.OnGameClearEvent += Player_OnGameClearEvent;
        BaseTrap.OnDamageTrapCollisionEvent += PlayerHit;
    }

    public void PlayerHit(int Damage)
    {
        playerData.HP -= Damage;
    }

    public void UpdateDecreaseHpBar(float number)
    {
        HpBar.value -= number;
    }

    private void Player_OnGameOverEvent()
    {
        GameOverMessage.visible = true;
        AgainButton.visible = true;
        ExitButton.visible = true;
    }

    private void Player_OnGameClearEvent()
    {
        ClearMessage.visible = true;
        AgainButton.visible = true;
        ExitButton.visible = true;
    }

}

//using System;
//using System.Collections;
//using UnityEngine;
//using UnityEngine.UIElements;

//public class MainUI : MonoBehaviour
//{
//    [SerializeField] UIDocument myUI;

//    private Button TopButton;
//    private Button SliderButton;
//    private Slider mySlider;

//    public Player player;

//    private void Start()
//    {
//        VisualElement root = myUI.rootVisualElement;

//        TopButton = root.Q<Button>("TopButton");
//        SliderButton = root.Q<Button>("MaxSliderButton");
//        mySlider = root.Q<Slider>("Damage");

//        mySlider.RegisterValueChangedCallback(v =>
//        {
//            var oldValue = v.previousValue;
//            var newValue = v.newValue;
//            Debug.Log(v.newValue);
//            player.Damage = v.newValue;
//        });

//        if (TopButton != null)
//        {
//            TopButton.clicked += OnMyButtonClick;
//        }

//        if (SliderButton != null)
//        {
//            SliderButton.clicked += OnMyMaxSliderClick;
//        }

//    }

//    private void OnMyButtonClick()
//    {
//        Debug.Log("Button clicked!");
//    }

//    private void OnMyMaxSliderClick()
//    {
//        mySlider.value = 0;
//        StartCoroutine(AddSliderValue());
//    }


//    private IEnumerator AddSliderValue()
//    {
//        while (true)
//        {
//            mySlider.value++;
//            yield return new WaitForSeconds(0.05f);
//            if (mySlider.value == mySlider.highValue)
//                break;
//        }
//    }

//    internal void UpdatePowerSlider(int power)
//    {
//        //throw new NotImplementedException();
//    }
//}
