using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessUnlock : MonoBehaviour
{
    public int GrantAccessKey;
    public void GrantAccess()
    {
        PlayerPrefs.SetInt("Access Reached", GrantAccessKey);
        PlayerPrefs.Save();
    }
}
