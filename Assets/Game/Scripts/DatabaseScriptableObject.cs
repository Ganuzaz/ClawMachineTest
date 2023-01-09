using RotaryHeart.Lib.SerializableDictionary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PrizeType
{
    Watermelon,
    Olive,
    Hotdog,
    Hamburger,
    Cheese,
    Banana
}

[CreateAssetMenu(fileName="Database", menuName = "ScritableObjects/DatabaseScriptableObject")]
public class DatabaseScriptableObject : ScriptableObject
{
    public PrizeDictionary prizeDictionary;
}

[System.Serializable]
public class PrizeDictionary : SerializableDictionaryBase<PrizeType, GameObject> { }
