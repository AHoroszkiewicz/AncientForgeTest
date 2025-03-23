using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{
    private bool isLocked = false;
    [SerializeField] private List<RecipeSO> recipes = new List<RecipeSO>();
}
