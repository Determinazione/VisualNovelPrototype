using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialoguePrinter : MonoBehaviour
{
    [SerializeField]
    private Text mDialogueText;

    [SerializeField]
    [Range(0f, 5f)]
    private float mDuration;

    void Start()
    {
        string str = "Procaster Miss. Miss posted a photo about workout. It get million repost after two hour.";
        mDialogueText = GetComponentInChildren<Text>();
        mDialogueText.DOText(str, mDuration, false);
    }
}
