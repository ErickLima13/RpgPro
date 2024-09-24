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

[Serializable]
public struct ItemHead
{
    public GameObject item;
    public HairType hairType;
}

public class GameManager : MonoBehaviour
{
    private Customization customization;

    public static GameManager Instance;

    public enum Stance
    {
        NoWeapon, WeaponShield, DualWeapon, LongWeapon
    }

    public Stance stance;

    [Header("Points")]
    public int pontosDisponiveis;
    public int pontosUsadosForca;
    public int pontosUsadosDestreza;
    public int pontosUsadosConstituicao;
    public int pontosUsadosInteligencia;

    [Header("Atributtes")]
    public int level;
    public int xp;
    public int forca;
    public int destreza;
    public int constituicao;
    public int inteligencia;

    [Header("Status")] // vector2 x = valor min, y = valor max
    public Vector2 dmgMelee;
    public Vector2 dmgMeleeBonus;
    public Vector2 dmgMagic;
    public Vector2 dmgMagicBonus;
    public Vector2 dmgDistance;
    public Vector2 dmgDistanceBonus;
    public int physicalDefense;
    public int magicDefense;
    public int dodge;
    public int critico;

    [Header("Res")]
    public int resFogo;
    public int resGelo;
    public int resRaio;
    public int resTerra;
    public int resVento;
    public int resVeneno;

    public int pesoMax;

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
    public int idFace;

    [Header("Weapons")]
    public int idRightHand;
    public int idLeftHand;

    [Header("Animators")]
    public Animator playerAnimator;
    public RuntimeAnimatorController[] controllers;

    public int idEquip;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        customization = Customization.Instance;
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
                break;
            case "inteligencia":
                break;
        }
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
                break;
            case "inteligencia":
                break;
        }
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
        data.idFace = idFace;
        data.idRightHand = idRightHand;
        data.idLeftHand = idLeftHand;
        data.forca = forca;
        data.destreza = destreza;
        data.constituicao = constituicao;
        data.inteligencia = inteligencia;
        data.level = level;
        data.xp = xp;


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
        idFace = data.idFace;
        idRightHand = data.idRightHand;
        idLeftHand = data.idLeftHand;
        forca = data.forca;
        destreza = data.destreza;
        constituicao = data.constituicao;
        inteligencia = data.inteligencia;
        level = data.level;
        xp = data.xp;

        customization.SetEquip(customization.belt, idBelt);
        customization.SetEquip(customization.cloth, idCloth);
        customization.SetEquip(customization.face, idFace);
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
    public int idFace;

    [Header("Weapons")]
    public int idRightHand;
    public int idLeftHand;
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
