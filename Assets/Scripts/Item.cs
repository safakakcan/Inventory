using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item")]
    public string displayName;

    [Header("Item UI")]
    public UnityEngine.UI.Text nameText;
    public UnityEngine.UI.Button equipButton;

    void Start()
    {
        nameText.text = displayName;
    }
}
