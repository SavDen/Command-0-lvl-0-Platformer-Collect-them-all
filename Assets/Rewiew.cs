using UnityEngine;
using YG;

public class Rewiew : MonoBehaviour
{
    void Start()
    {
        if (!YandexGame.EnvironmentData.reviewCanShow)
            gameObject.SetActive(false);

    }
}
