using TMPro;
using UnityEngine;

public class DescriptionPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string defaultText;

    public static DescriptionPanel Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }

    public void SetDefaultText()
    {
        this.text.text = defaultText;
    }
}
