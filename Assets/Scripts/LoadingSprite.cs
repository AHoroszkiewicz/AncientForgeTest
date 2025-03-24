using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSprite : MonoBehaviour
{
    [SerializeField] private Image loadingImage;

    public IEnumerator StartLoading(float time)
    {
        float timer = 0;
        while (timer < time)
        {
            timer += Time.deltaTime;
            loadingImage.fillAmount = timer / time;
            yield return null;
        }
        loadingImage.fillAmount = 0;
    }
}
