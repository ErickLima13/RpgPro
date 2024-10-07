using System.Collections;
using UnityEngine;

public class ControlTime : MonoBehaviour
{
    public int idObj;
    public GameObject[] dayNight;
    public Material[] sky;
    public GameObject fireFx;

    private void Start()
    {
        SetHour(1);
    }

    public void SetHour(int id)
    {
        foreach (GameObject g in dayNight)
        {
            g.SetActive(false);
        }

        dayNight[id].SetActive(true);
        RenderSettings.skybox = sky[id];

        fireFx.SetActive(id == 1);
    }

    public IEnumerator StartGame()
    {
        Transition._instance.Fade();
        yield return new WaitForEndOfFrame();
        yield return new WaitUntil(() => Transition._instance.isFadeComplete);
        SetHour(0);
        GameManager.Instance.playerAnimator.SetBool("isSit", false);
        Transition._instance.Fade();
        GameManager.Instance.camGameplay.SetActive(true);
        yield return new WaitForEndOfFrame();
        yield return new WaitUntil(() => Transition._instance.isFadeComplete);
        GameManager.Instance.ChangeGameState(GameState.Gameplay); 
    }
}
