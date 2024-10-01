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
    public Button[] btnPlus;
    public Button[] btnMinus;

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
        sliderSkin.maxValue = customization.skin.Length - 1;

        btnSaveChar.GetComponent<Button>().onClick.AddListener(BtnSaveChar);
        btnNewGame.GetComponent<Button>().onClick.AddListener(BtnNewGame);
        btnContinue.GetComponent<Button>().onClick.AddListener(BtnContinue);

        // inputName.onValueChanged.AddListener(OnChangeName);

        UpdateHud();

    }

    public void UpdateHud()
    {
        gameManager.SetBonus();

        pontosRestantes.text = gameManager.pontosDisponiveis.ToString();
        forcaText.text = gameManager.forca.ToString();
        destrezaText.text = gameManager.destreza.ToString();
        constituicaoText.text = gameManager.constituicao.ToString();
        inteligenciaText.text = gameManager.inteligencia.ToString();

        foreach (Button b in btnPlus)
        {
            b.interactable = gameManager.pontosDisponiveis > 0;
        }

        foreach (Button b in btnMinus)
        {
            b.interactable = false;
        }

        DisableButton(gameManager.pontosUsadosForca, 0);
        DisableButton(gameManager.pontosUsadosDestreza, 1);
        DisableButton(gameManager.pontosUsadosConstituicao, 2);
        DisableButton(gameManager.pontosUsadosInteligencia, 3);

        //Status


        //public TextMeshProUGUI hpTextStatus;
        //public TextMeshProUGUI mpTextStatus;

        nomeTextStatus.text = gameManager.namePlayer;
        levelTextStatus.text = gameManager.level.ToString();
        expTextStatus.text =  gameManager.xp + "/" + gameManager.xpToLevel[gameManager.level].ToString();
        hpTextStatus.text =  gameManager.hpMax.ToString();
        mpTextStatus.text =  gameManager.mpMax.ToString();
     
        forcaTextStatus.text = gameManager.forca.ToString();
        destrezaTextStatus.text = gameManager.destreza.ToString();
        constituicaoTextStatus.text = gameManager.constituicao.ToString();
        inteligenciaTextStatus.text = gameManager.inteligencia.ToString();
        dmgMeleeTextStatus.text = gameManager.dmgMelee.ToString("N0");
        dmgMagicTextStatus.text = gameManager.dmgMagic.ToString("N0");
        dmgDistanceTextStatus.text = gameManager.dmgDistance.ToString("N0");
        dodgeTextStatus.text = gameManager.dodge.ToString("N0") + "%";
        physicalDefenseTextStatus.text = gameManager.physicalDefense.ToString("N0") + "%";
        magicDefenseTextStatus.text = gameManager.magicDefense.ToString("N0") + "%";
        resVenenoTextStatus.text = gameManager.resVeneno.ToString("N0") + "%";
        pesoMaxTextStatus.text = gameManager.pesoMax.ToString("N0") + " kg";



    }

    public void BtnSaveChar()
    {
        gameManager.SaveGame();
    }

    public void BtnNewGame()
    {
        print("legal1");
    }

    public void BtnContinue()
    {
        print("legal2");
        UpdateHud();
        gameManager.LoadGame();
    }

    public void OnChangeName(string text)
    {
        gameManager.namePlayer = text;
        UpdateHud();
    }

    public void OnChangeSkin(float value)
    {
        gameManager.idSkin = (int)value;
        customization.SetEquip(customization.skin, gameManager.idSkin);
    }

    public void OnChangeHair(float value)
    {
        gameManager.idHair = (int)value;
        customization.SetEquip(customization.hair, gameManager.idHair);
    }

    private void DisableButton(int value, int id)
    {
        if (value > 0)
        {
            btnMinus[id].interactable = true;
        }
    }

}
