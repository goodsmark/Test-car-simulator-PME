using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class FaderC : MonoBehaviour
{
    private static FaderC Instance;
    [SerializeField] private Image background;

    private void Awake()
    {
        Instance = this;
        background.color = new Color(0, 0, 0, 1);
    }

    public static void DoFadeIn()
    {
        Instance.background.gameObject.SetActive(true);
        Instance.background.DOFade(1, 1);
    }

    public static void DoFadeIn(float duration)
    {
        Instance.background.gameObject.SetActive(true);
        Instance.background.DOFade(1, duration);
    }


    public static void DoFadeOut()
    {
        Instance.background.DOFade(0, 1).OnComplete(() =>
        {
            Instance.background.gameObject.SetActive(false);
        });
    }

    public static void DoFadeOut(float duration)
    {
        Instance.background.DOFade(0, duration).OnComplete(() =>
        {
            Instance.background.gameObject.SetActive(false);
        });
    }
}