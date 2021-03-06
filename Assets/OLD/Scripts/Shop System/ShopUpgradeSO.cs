﻿using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Shop Upgrade")]
public class ShopUpgradeSO : ScriptableObject
{
    [SerializeField] private int _cost = 0;
    [SerializeField, TextArea(5, 5)] private string _desc = null;

    public int Cost => _cost;
    public string Desc => _desc;
}
