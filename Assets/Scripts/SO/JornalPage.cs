using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JornalPage", menuName = "ScriptableObjects/JornalPage", order = 1)]
public class JornalPage : ScriptableObject
{
    public int Day;
    public string PageText;
}