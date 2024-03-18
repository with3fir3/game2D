using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MenuButtonsManager : MonoBehaviour
{
    public List<GameObject> buttons;

    [Header("animation")]
    public float duration = .5f;
    public float delay = .1f;
    public Ease ease = Ease.OutBack;
    private void Awake()
    {
        HideAllButtons();
        showbuttons();
    }
    private void HideAllButtons()
    {
        foreach (var b in buttons) 
        { 
           b.transform.localScale = Vector3.zero;
           b.SetActive(false);
        }

    }
    private void showbuttons()
    {
        for (int i=0; i< buttons.Count; i++) 
        {
            var b = buttons[i];
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(1*delay).SetEase(ease);
        
        
        }
    }


}
