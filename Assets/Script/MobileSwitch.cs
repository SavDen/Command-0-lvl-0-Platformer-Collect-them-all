using UnityEngine;
using YG;

public class MobileSwitch : MonoBehaviour
{
    [SerializeField] private GameObject _mobileControlUI;
    // Start is called before the first frame update
    private void Awake()
    {
        if(YandexGame.EnvironmentData.isDesktop)
        {
            _mobileControlUI.SetActive(false);
        }

        else if(YandexGame.EnvironmentData.isMobile || YandexGame.EnvironmentData.isTablet)
        {
            _mobileControlUI.SetActive(true);
        }
    }
}
