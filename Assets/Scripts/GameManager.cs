using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject RedGroup;
    public GameObject BlueGroup;
    public List<Image> displayImages; // 用于显示图片的UI组件列表
    private List<Sprite> availableImages = new List<Sprite>();
    private List<Sprite> selectedImages = new List<Sprite>();
    
    [System.Serializable]
    public class HeroData
    {
        public string Name;
        public Sprite Image;
        public bool MeleeHero;
    }
    void Start()
    {
        var redHeroes = RedGroup.GetComponentsInChildren<Image>().ToList();
        var blueHeroes = BlueGroup.GetComponentsInChildren<Image>().ToList();
        
        displayImages.AddRange(redHeroes);
        displayImages.AddRange(blueHeroes);
        
        LoadAllImages();
        SelectRandomImages();
        DisplaySelectedImages();
    }

    // 从Resources文件夹中加载所有图片
    void LoadAllImages()
    {
        Sprite[] images = Resources.LoadAll<Sprite>("Icon");
        if (images.Length == 0)
        {
            Debug.LogError("没有在Resources/Images文件夹中找到任何图片！");
            return;
        }

        availableImages.AddRange(images);
    }

    // 随机选择指定数量的图片且不重复
    void SelectRandomImages()
    {
        if (displayImages.Count > availableImages.Count)
        {
            Debug.LogError("选择的图片数量超过了可用图片的数量！");
            return;
        }

        List<Sprite> tempImages = new List<Sprite>(availableImages);

        for (int i = 0; i < displayImages.Count; i++)
        {
            int randomIndex = Random.Range(0, tempImages.Count);
            Sprite selectedImage = tempImages[randomIndex];
            if (selectedImage.name == "-1")
            {
                continue;
            }
            selectedImages.Add(selectedImage);
            tempImages.RemoveAt(randomIndex);
        }
    }

    // 显示选中的图片
    void DisplaySelectedImages()
    {
        if (selectedImages.Count > displayImages.Count)
        {
            Debug.LogError("显示图片的UI组件数量不足！");
            return;
        }

        for (int i = 0; i < selectedImages.Count; i++)
        {
            displayImages[i].gameObject.GetComponent<HeroButton>().Reset();
            displayImages[i].sprite = selectedImages[i];
        }
    }

    public void RefreshClick()
    {
        int randomIndex = Random.Range(0, 100);
        
        selectedImages.Clear();
        SelectRandomImages();
        DisplaySelectedImages();
    }
}