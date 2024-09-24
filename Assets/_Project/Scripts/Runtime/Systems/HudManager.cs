using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    private GameManager gameManager;
    private Customization customization;

    public static HudManager Instance;

    public GameObject panelCustomization;
    public GameObject panelNewGame;

    public GameObject btnSaveChar;
    public GameObject btnNewGame;
    public GameObject btnContinue;

    public TMP_InputField inputName;

    public Slider sliderSkin;
    public Slider sliderHair;

    [Header("Texts New Game")]
    public TextMeshProUGUI forcaText;
    public TextMeshProUGUI destrezaText;
    public TextMeshProUGUI constituicaoText;
    public TextMeshProUGUI inteligenciaText;
    public Text pontosRestantes;

    [Header("Texts Status")]
    public TextMeshProUGUI nomeTextStatus;
    public TextMeshProUGUI levelTextStatus;
    public TextMeshProUGUI expTextStatus;
    public TextMeshProUGUI hpTextStatus;
    public TextMeshProUGUI mpTextStatus;
    public TextMeshProUGUI dmgMeleeTextStatus;
    public TextMeshProUGUI dmgMagicTextStatus;
    public TextMeshProUGUI dmgDistanceTextStatus;
    public TextMeshProUGUI dodgeTextStatus;
    public TextMeshProUGUI physicalDefenseTextStatus;
    public TextMeshProUGUI magicDefenseTextStatus;
    public TextMeshProUGUI resVenenoTextStatus;
    public TextMeshProUGUI pesoMaxTextStatus;
    public TextMeshProUGUI forcaTextStatus;
    public TextMeshProUGUI destrezaTextStatus;
    public TextMeshProUGUI constituicaoTextStatus;
    public TextMeshProUGUI inteligenciaTextStatus;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
        customization = Customization.Instance;

        sliderHair.maxValue = customization.hair.Length - 1;
        sliderSkin.maxValue = customization.face.Length - 1;

        btnSaveChar.GetComponent<Button>().onClick.AddListener(BtnSaveChar);
        btnNewGame.GetComponent<Button>().onClick.AddListener(BtnNewGame);
        btnContinue.GetComponent<Button>().onClick.AddListener(BtnContinue);

       // inputName.onValueChanged.AddListener(OnChangeName);

       
    }

    public void BtnSaveChar()
    {
        print("legal");
    }

    public void BtnNewGame()
    {
        print("legal1");
    }

    public void BtnContinue()
    {
        print("legal2");
    }

    public void OnChangeName()
    {

    }

    public void OnChangeSkin()
    {

    }

    public void OnChangeHair()
    {

    }
}
