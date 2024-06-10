using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class HeroData
{
    public Sprite Image;
    public bool MeleeHero;
}

[CreateAssetMenu(fileName = "HeroDataList", menuName = "ScriptableObjects/英雄数据", order = 0)]
public class HeroDataList : ScriptableObject
{
    public List<HeroData> HeroDats;
}