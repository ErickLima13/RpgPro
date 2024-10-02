using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public enum HairType
{
    Full, Half, None
}

public enum GameState
{
    Title, Main, Gameplay
}

[Serializable]
public struct ItemHead
{
    public GameObject item;
    public HairType hairType;
}

public class GameManager : MonoBehaviour
{
    private Customization customization;
    private HudManager hudManager;

    public GameState gameState;
    public static GameManager Instance;

    public enum Stance
    {
        NoWeapon, WeaponShield, DualWeapon, LongWeapon
    }

    public Stance stance;

    [Header("Points")]
    public int pontosDisponiveis;


    [HideInInspector] public int pontosUsadosForca;
    [HideInInspector] public int pontosUsadosDestreza;
    [HideInInspector] public int pontosUsadosConstituicao;
    [HideInInspector] public int pontosUsadosInteligencia;

    [Header("Status Base")]
    public int hpBase;
    public int mpBase;
    public Vector2 dmgMeleeBase;
    public Vector2 dmgMeleeBonusBase;
    public Vector2 dmgMagicBase;
    public Vector2 dmgMagicBonusBase;
    public Vector2 dmgDistanceBase;
    public Vector2 dmgDistanceBonusBase;
    public int physicalDefenseBase;
    public int magicDefenseBase;
    public int dodgeBase;
    public int criticoBase;
    public int pesoMaxBase;
    public int resVenenoBase;


    [Header("Atributtes")]
    public string namePlayer;
    public int level;
    public int xp;
    public int[] xpToLevel;

    [HideInInspector] public int hpMax;
    [HideInInspector] public int mpMax;
    [HideInInspector] public int forca;
    [HideInInspector] public int destreza;
    [HideInInspector] public int constituicao;
    [HideInInspector] public int inteligencia;

    [Header("Status")] // vector2 x = valor min, y = valor max
    public Vector2 dmgMelee;
    [HideInInspector] public Vector2 dmgMeleeBonus;
    [HideInInspector] public Vector2 dmgMagic;
    [HideInInspector] public Vector2 dmgMagicBonus;
    [HideInInspector] public Vector2 dmgDistance;
    [HideInInspector] public Vector2 dmgDistanceBonus;
    [HideInInspector] public int physicalDefense;
    [HideInInspector] public int magicDefense;
    [HideInInspector] public int dodge;
    [HideInInspector] public int critico;

    [Header("Res")]
    [HideInInspector] public int resFogo;
    [HideInInspector] public int resGelo;
    [HideInInspector] public int resRaio;
    [HideInInspector] public int resTerra;
    [HideInInspector] public int resVento;
    [HideInInspector] public int resVeneno;

    [HideInInspector] public int pesoMax;

    [Header("Equip")]
    [HideInInspector] public int idBelt;
    [HideInInspector] public int idCloth;
    [HideInInspector] public int idGlove;
    [HideInInspector] public int idShoe;
    [HideInInspector] public int idShouder;

    [Header("Head")]
    public int idHair;
    public int idHead;

    [Header("Skin")]
    [HideInInspector] public int idSkin;

    [Header("Weapons")]
    [HideInInspector] public int idRightHand;
    [HideInInspector] public int idLeftHand;

    [Header("Animators")]
    public Animator playerAnimator;
    public RuntimeAnimatorController[] controllers;

    public int idEquip;

    private CalculateAttributes calculateAttributes;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        customization = Customization.Instance;
        hudManager = HudManager.Instance;
        calculateAttributes = GetComponent<CalculateAttributes>();
    }

    private void Update()
    {
        //if (Input.mouseScrollDelta.y > 0)
        //{
        //    InputChangeWeapon(true);
        //}

        //if (Input.mouseScrollDelta.y < 0)
        //{
        //    InputChangeWeapon(false);
        //}
    }

    public void AtrPlus(string atr)
    {
        if (pontosDisponiveis <= 0)
        {
            return;
        }

        pontosDisponiveis--;

        switch (atr)
        {
            case "forca":
                forca++;
                pontosUsadosForca++;
                break;
            case "destreza":
                destreza++;
                pontosUsadosDestreza++;
                break;
            case "constituicao":
                constituicao++;
                pontosUsadosConstituicao++;
                break;
            case "inteligencia":
                inteligencia++;
                pontosUsadosInteligencia++;
                break;
        }

        hudManager.UpdateHud();
    }

    public void AtrMinus(string atr)
    {
        switch (atr)
        {
            case "forca":
                if (pontosUsadosForca > 0)
                {
                    forca--;
                    pontosUsadosForca--;
                    pontosDisponiveis++;
                }
                break;
            case "destreza":
                if (pontosUsadosDestreza > 0)
                {
                    destreza--;
                    pontosUsadosDestreza--;
                    pontosDisponiveis++;
                }
                break;
            case "constituicao":
                if (pontosUsadosConstituicao > 0)
                {
                    constituicao--;
                    pontosUsadosConstituicao--;
                    pontosDisponiveis++;
                }
                break;
            case "inteligencia":
                if (pontosUsadosInteligencia > 0)
                {
                    inteligencia--;
                    pontosUsadosInteligencia--;
                    pontosDisponiveis++;
                }
                break;
        }

        hudManager.UpdateHud();
    }

    public int SetDamage(Vector2 dmgTotal)
    {
        int dmg = 0;


        return dmg;
    }

    public bool CheckPerc(int perc)
    {
        int rand = Random.Range(0, 100);
        return rand <= perc;
    }

    public void SetEquip(int equip)
    {
        switch (equip)
        {
            case 0:
                idLeftHand = -1;
                idRightHand = -1;
                playerAnimator.runtimeAnimatorController = controllers[0];
                break;
            case 1:
                idLeftHand = -1;
                idRightHand = 4;
                playerAnimator.runtimeAnimatorController = controllers[1];
                playerAnimator.SetLayerWeight(2, 0);
                break;
            case 2:
                idLeftHand = 4;
                idRightHand = 4;
                playerAnimator.runtimeAnimatorController = controllers[1];
                playerAnimator.SetLayerWeight(2, 1);
                break;
            case 3:
                idLeftHand = 11;
                idRightHand = -1;
                playerAnimator.runtimeAnimatorController = controllers[2];
                break;
        }
    }

    private void InputChangeWeapon(bool value)
    {
        if (value)
        {
            idEquip++;
        }
        else
        {
            idEquip--;
        }

        if (idEquip > 3)
        {
            idEquip = 0;
        }

        if (idEquip < 0)
        {
            idEquip = 3;
        }

        SetEquip(idEquip);
    }

    public void SetBonus()
    {
        // forca - dmgmelee,peso
        // destreza - dmgdistance e dodge
        //constituicao - hpmax,resfisica,resveneno
        //inteligencia - spmax,dmgmagic,resmagica

        calculateAttributes.SetForDex(forca, ref dmgMelee, ref pesoMax, pesoMaxBase);
        calculateAttributes.SetForDex(destreza, ref dmgDistance, ref dodge, dodgeBase);
        calculateAttributes.SetCon(constituicao, ref hpMax, hpBase, ref physicalDefense, physicalDefenseBase, ref resVeneno, resVenenoBase);
        calculateAttributes.SetInt(inteligencia, ref dmgMagic, ref mpMax, mpBase, ref magicDefense, magicDefenseBase);
    }

    public void ChangeGameState(GameState newState)
    {
        gameState = newState;
    }

    public bool HasLoad()
    {
        return File.Exists(Application.persistentDataPath + "/save.dat");
    }

    public void NewChar()
    {
        idBelt = -1;
        idCloth = 0;
        idGlove = 0;
        idShoe = 0;
        idShouder = -1;
        idHead = -1;
        idHair = 3;
        idSkin = 2;
        idRightHand = -1;
        idLeftHand = -1;

        forca = 1;
        destreza = 1;
        constituicao = 1;
        inteligencia = 1;
        level = 1;
        xp = 0;
        namePlayer = "Hero";
        pontosDisponiveis = 3;

        customization.SetEquip(customization.belt, idBelt);
        customization.SetEquip(customization.cloth, idCloth);
        customization.SetEquip(customization.skin, idSkin);
        customization.SetEquip(customization.glove, idGlove);
        customization.SetEquip(customization.shoe, idShoe);
        customization.SetEquip(customization.shouder, idShouder);
        customization.SetEquip(customization.rightHand, idRightHand);
        customization.SetEquip(customization.leftHand, idLeftHand);
        customization.SetHead();
        SaveGame();
    }

    #region SaveLoad
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(
            Application.persistentDataPath + "/save.dat");

        SaveData data = new SaveData();

        data.idBelt = idBelt;
        data.idCloth = idCloth;
        data.idGlove = idGlove;
        data.idShoe = idShoe;
        data.idShouder = idShouder;
        data.idHead = idHead;
        data.idHair = idHair;
        data.idSkin = idSkin;
        data.idRightHand = idRightHand;
        data.idLeftHand = idLeftHand;
        data.forca = forca;
        data.destreza = destreza;
        data.constituicao = constituicao;
        data.inteligencia = inteligencia;
        data.level = level;
        data.xp = xp;
        data.namePlayer = namePlayer;
        data.pontosDisponiveis = pontosDisponiveis;


        bf.Serialize(file, data);
        file.Close();

        print(Application.persistentDataPath + "/save.dat");
    }

    public void LoadGame()
    {
        if (!File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            print("Arquivo não encontrado");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();

        FileStream file = File.Open(
            Application.persistentDataPath + "/save.dat", FileMode.Open);

        SaveData data = (SaveData)bf.Deserialize(file);
        file.Close();

        idBelt = data.idBelt;
        idCloth = data.idCloth;
        idGlove = data.idGlove;
        idShoe = data.idShoe;
        idShouder = data.idShouder;
        idHead = data.idHead;
        idHair = data.idHair;
        idSkin = data.idSkin;
        idRightHand = data.idRightHand;
        idLeftHand = data.idLeftHand;
        forca = data.forca;
        destreza = data.destreza;
        constituicao = data.constituicao;
        inteligencia = data.inteligencia;
        level = data.level;
        xp = data.xp;
        namePlayer = data.namePlayer;
        pontosDisponiveis = data.pontosDisponiveis;

        customization.SetEquip(customization.belt, idBelt);
        customization.SetEquip(customization.cloth, idCloth);
        customization.SetEquip(customization.skin, idSkin);
        customization.SetEquip(customization.glove, idGlove);
        customization.SetEquip(customization.shoe, idShoe);
        customization.SetEquip(customization.shouder, idShouder);
        customization.SetEquip(customization.rightHand, idRightHand);
        customization.SetEquip(customization.leftHand, idLeftHand);
        customization.SetHead();
    }
    #endregion
}

[Serializable]
class SaveData
{
    [Header("Atributtes")]
    public string namePlayer;
    public int hpMax;
    public int mpMax;
    public int level;
    public int xp;
    public int forca;
    public int destreza;
    public int constituicao;
    public int inteligencia;

    [Header("Equip")]
    public int idBelt;
    public int idCloth;
    public int idGlove;
    public int idShoe;
    public int idShouder;

    [Header("Head")]
    public int idHair;
    public int idHead;

    [Header("Skin")]
    public int idSkin;

    [Header("Weapons")]
    public int idRightHand;
    public int idLeftHand;

    public int pontosDisponiveis;
}


#if UNITY_EDITOR
[CustomEditor(typeof(GameManager)), CanEditMultipleObjects]
public class Save : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space(10f);
        GameManager gameManager = (GameManager)target;
        if (GUILayout.Button("Save Game"))
        {
            gameManager.SaveGame();

        }
        if (GUILayout.Button("Load Game"))
        {
            gameManager.LoadGame();
        }

    }
}
#endif
