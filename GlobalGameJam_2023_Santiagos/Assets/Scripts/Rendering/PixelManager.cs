using System.Linq;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PixelManager : MonoBehaviour
{
    [SerializeField] private UniversalRendererData _rendererData;
    enum SceneType { MainMenu, Intro, Level, LevelInBetween }
    [SerializeField] private SceneType _sceneType;
    
    [Header("Screen Sizes")]
    [SerializeField] private int defaultSize = 200;
    [SerializeField] private int mainMenuSize = 200;
    [SerializeField] private int introSize = 200;
    [SerializeField] private int levelSize = 200;
    [SerializeField] private int levelInBetweenSize = 200;

    private void Start()
    {
        PixelizeFeature pixelizeFeature = _rendererData.rendererFeatures.OfType<PixelizeFeature>().FirstOrDefault();
        SetScreenSize(pixelizeFeature);
    }

    private void SetScreenSize(PixelizeFeature pixelizeFeature)
    {
        if (_sceneType == SceneType.MainMenu) pixelizeFeature.settings.screenHeight = mainMenuSize;
        else if (_sceneType == SceneType.Intro) pixelizeFeature.settings.screenHeight = introSize;
        else if (_sceneType == SceneType.Level) pixelizeFeature.settings.screenHeight = levelSize;
        else if (_sceneType == SceneType.LevelInBetween) pixelizeFeature.settings.screenHeight = levelInBetweenSize;
        else pixelizeFeature.settings.screenHeight = defaultSize;
    }
}
