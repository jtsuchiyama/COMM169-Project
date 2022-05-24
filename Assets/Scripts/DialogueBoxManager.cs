using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueBoxManager : MonoBehaviour
{
    public void SetVisibility(bool value)
    {
        foreach (Transform child in transform)
            child.gameObject.SetActive(value);
    }
}
