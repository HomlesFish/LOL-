using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;

public class HeroDataListGenerator : MonoBehaviour
{
    [MenuItem("Tools/Generate HeroDataList")]
    public static void GenerateHeroDataList()
    {
        // 指定图片所在的文件夹路径
        string folderPath = "Assets/Resources/Icon";  // 请确保路径正确

        // 获取所有图片文件
        string[] imagePaths = Directory.GetFiles(folderPath, "*.png");  // 可以根据需要修改扩展名

        // 创建或更新 HeroDataList 资产
        HeroDataList heroDataList = ScriptableObject.CreateInstance<HeroDataList>();
        heroDataList.HeroDats = new List<HeroData>();

        foreach (string path in imagePaths)
        {
            HeroData heroData = new HeroData();
            heroData.Image = AssetDatabase.LoadAssetAtPath<Sprite>(path);
            heroData.MeleeHero = false; // 或者根据你的逻辑设置
            heroDataList.HeroDats.Add(heroData);
        }

        // 将 HeroDataList 资产保存到指定路径
        string assetPath = "Assets/Resources/HeroDataList.asset";
        AssetDatabase.CreateAsset(heroDataList, assetPath);
        AssetDatabase.SaveAssets();

        Debug.Log("HeroDataList has been generated and saved at " + assetPath);
    }
}
