using UnityEngine;
using UnityEngine.UI;

public class HeroButton : MonoBehaviour
{
    public GameObject Ban;
    public Image icon;
    public bool isBan;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Reset()
    {
        Ban.SetActive(false);
        icon.color = Color.white;
    }

    // Update is called once per frame
    public void IconClick()
    {
        isBan = !isBan;
        Ban.SetActive(isBan);
        icon.color = isBan ? Color.gray : Color.white;
    }
}
