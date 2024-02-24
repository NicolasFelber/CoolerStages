using BepInEx;
using BepInEx.Configuration;
using RoR2;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering.PostProcessing;
using System.Linq;
using System.Collections.Generic;

namespace CoolerStages
{
  [BepInPlugin("com.Nuxlar.CoolerStages", "CoolerStages", "1.6.1")]

  public class CoolerStages : BaseUnityPlugin
  {
    private static readonly PostProcessProfile danProfile = Addressables.LoadAssetAsync<PostProcessProfile>("RoR2/Base/title/ppSceneEclipseStandard.asset").WaitForCompletion();
    private static readonly PostProcessProfile droughtProfile = Addressables.LoadAssetAsync<PostProcessProfile>("RoR2/Base/title/ppSceneWispGraveyard.asset").WaitForCompletion();
    private static readonly PostProcessProfile voidProfile = Addressables.LoadAssetAsync<PostProcessProfile>("RoR2/DLC1/Common/Void/ppSceneVoidStage.asset").WaitForCompletion();

    private static readonly Material aphelianTempleMat = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/ancientloft/matAncientLoft_Temple.mat").WaitForCompletion();
    private static readonly Material aphelianTempleMat2 = Addressables.LoadAssetAsync<Material>("RoR2/Base/moon/matMoonRuinsDirty.mat").WaitForCompletion();

    private static readonly Material nightTerrainMat = Addressables.LoadAssetAsync<Material>("RoR2/Base/wispgraveyard/matWPTerrain.mat").WaitForCompletion();
    private static readonly Material nightTerrainMat2 = Addressables.LoadAssetAsync<Material>("RoR2/Base/wispgraveyard/matWPTerrainRocky.mat").WaitForCompletion();
    private static readonly Material nightDetailMat = Addressables.LoadAssetAsync<Material>("RoR2/Base/wispgraveyard/matTempleObelisk.mat").WaitForCompletion();
    private static readonly Material nightDetailMat2 = Addressables.LoadAssetAsync<Material>("RoR2/Base/Common/TrimSheets/matTrimsheetGraveyardTempleWhiteGrassy.mat").WaitForCompletion();
    private static readonly Material nightDetailMat3 = Addressables.LoadAssetAsync<Material>("RoR2/Base/foggyswamp/matFSTreeTrunkLightMoss.mat").WaitForCompletion();
    private static readonly Material nightDetailMat2Alt = Addressables.LoadAssetAsync<Material>("RoR2/Base/Common/TrimSheets/matTrimsheetGraveyardTempleWhite.mat").WaitForCompletion();

    private static readonly Material danTerrain = Addressables.LoadAssetAsync<Material>("RoR2/Base/arena/matArenaTerrainVerySnowy.mat").WaitForCompletion();
    private static readonly Material danDetail = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/voidstage/matVoidFoam.mat").WaitForCompletion();
    private static readonly Material danDetail2 = Addressables.LoadAssetAsync<Material>("RoR2/Base/Common/TrimSheets/matTrimSheetAlien1BossEmission.mat").WaitForCompletion();
    private static readonly Material danDetail3 = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/voidstage/matVoidTrim.mat").WaitForCompletion();

    private static readonly Material ruinTerrain = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itancientloft/matAncientLoft_TerrainInfiniteTower.mat").WaitForCompletion();
    private static readonly Material ruinDetail = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itancientloft/matAncientLoft_BoulderInfiniteTower.mat").WaitForCompletion();
    private static readonly Material ruinDetail2 = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itancientloft/matAncientLoft_TempleProjectedInfiniteTower.mat").WaitForCompletion();
    private static readonly Material ruinDetail3 = Addressables.LoadAssetAsync<Material>("RoR2/Base/rootjungle/matRJTree.mat").WaitForCompletion();

    private static readonly Material smSimTerrainMat = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itskymeadow/matSMTerrainInfiniteTower.mat").WaitForCompletion();
    private static readonly Material smSimDetailMat = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itskymeadow/matSMRockInfiniteTower.mat").WaitForCompletion();
    private static readonly Material smSimDetailMat2 = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itskymeadow/matTrimSheetMeadowRuinsProjectedInfiniteTower.mat").WaitForCompletion();
    private static readonly Material smSimtDetailMat3 = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itskymeadow/matSMVineInfiniteTower.mat").WaitForCompletion();

    private static readonly Material dcSimTerrainMat = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itdampcave/matDCTerrainFloorInfiniteTower.mat").WaitForCompletion();
    private static readonly Material dcSimDetailMat = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itdampcave/matDCBoulderInfiniteTower.mat").WaitForCompletion();
    private static readonly Material dcSimDetailMat2 = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itdampcave/matTrimSheetLemurianRuinsLightInfiniteTower.mat").WaitForCompletion();
    private static readonly Material dcSimDetailMat3 = Addressables.LoadAssetAsync<Material>("RoR2/Base/dampcave/matDCCoral.mat").WaitForCompletion();

    private static readonly Material gpSimTerrainMat = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itgolemplains/matGPTerrainInfiniteTower.mat").WaitForCompletion();
    private static readonly Material gpSimDetailMat = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itgolemplains/matGPBoulderMossyProjectedInfiniteTower.mat").WaitForCompletion();
    private static readonly Material gpSimDetailMat2 = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itgolemplains/matTrimSheetMossyProjectedHugeInfiniteTower.mat").WaitForCompletion();
    private static readonly Material gpSimDetailMat3 = Addressables.LoadAssetAsync<Material>("RoR2/Base/foggyswamp/matFSTreeTrunkLightMoss.mat").WaitForCompletion();

    private static readonly Material gooSimTerrainMat = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itgoolake/matGoolakeTerrainInfiniteTower.mat").WaitForCompletion();
    private static readonly Material gooSimDetailMat = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itgoolake/matGoolakeRocksInfiniteTower.mat").WaitForCompletion();
    private static readonly Material gooSimDetailMat2 = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itgoolake/matGoolakeStoneTrimLightSandInfiniteTower.mat").WaitForCompletion();
    private static readonly Material gooSimDetailMat3 = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/itgoolake/matEelSkeleton2InfiniteTower.mat").WaitForCompletion();

    private static readonly Material moonTerrainMat = Addressables.LoadAssetAsync<Material>("RoR2/Base/moon/matMoonTerrain.mat").WaitForCompletion();
    private static readonly Material moonDetailMat = Addressables.LoadAssetAsync<Material>("RoR2/Base/moon/matMoonBoulder.mat").WaitForCompletion();
    private static readonly Material moonDetailMat2 = Addressables.LoadAssetAsync<Material>("RoR2/Base/moon/matMoonBridge.mat").WaitForCompletion();
    private static readonly Material moonDetailMat3 = Addressables.LoadAssetAsync<Material>("RoR2/Base/moon/matMoonBaseStandTriplanar.mat").WaitForCompletion();

    private static readonly Material voidTerrainMat = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/voidstage/matVoidTerrain.mat").WaitForCompletion();
    private static readonly Material voidDetailMat = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/voidstage/matVoidCoralPlatformOrange.mat").WaitForCompletion();
    private static readonly Material voidDetailMat2 = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/voidstage/matVoidMetalTrimGrassyVertexColorsOnly.mat").WaitForCompletion();
    private static readonly Material voidDetailMat3 = Addressables.LoadAssetAsync<Material>("RoR2/DLC1/voidstage/matVoidCoral.mat").WaitForCompletion();

    private static readonly List<Material[]> themeMaterials1 = new List<Material[]> {
      new Material[] { nightTerrainMat2, nightDetailMat, nightDetailMat2, nightDetailMat3 },
      new Material[] { danTerrain, danDetail, danDetail2, danDetail3 },
      new Material[] { ruinTerrain, ruinDetail, ruinDetail2, ruinDetail3 },
      new Material[] { smSimTerrainMat, smSimDetailMat, smSimDetailMat2, smSimtDetailMat3 },
      new Material[] { dcSimTerrainMat, dcSimDetailMat, dcSimDetailMat2, dcSimDetailMat3 },
      new Material[] { gpSimTerrainMat, gpSimDetailMat, gpSimDetailMat2, gpSimDetailMat3 },
      new Material[] { gooSimTerrainMat, gooSimDetailMat, gooSimDetailMat2, gooSimDetailMat3 },
      new Material[] { moonTerrainMat, moonDetailMat, moonDetailMat2, moonDetailMat3 },
      new Material[] { voidTerrainMat, voidDetailMat, voidDetailMat2, voidDetailMat3 }
    };

    private static readonly List<Material[]> themeMaterials2 = new List<Material[]> {
      new Material[] { nightTerrainMat2, nightDetailMat, nightDetailMat2, nightDetailMat3 },
      new Material[] { danTerrain, danDetail, danDetail2, danDetail3 },
      new Material[] { ruinTerrain, ruinDetail, ruinDetail2, ruinDetail3 },
      new Material[] { dcSimTerrainMat, dcSimDetailMat, dcSimDetailMat2, dcSimDetailMat3 },
      new Material[] { voidTerrainMat, voidDetailMat, voidDetailMat2, voidDetailMat3 }
    };

    private static readonly List<PostProcessProfile> themeProfiles = new List<PostProcessProfile> {
      droughtProfile,
      voidProfile,
      danProfile,
      Addressables.LoadAssetAsync<PostProcessProfile>("RoR2/Base/title/ppSceneArenaCleared.asset").WaitForCompletion(),
      Addressables.LoadAssetAsync<PostProcessProfile>("RoR2/Base/title/ppSceneArtifactWorld.asset").WaitForCompletion(),
      Addressables.LoadAssetAsync<PostProcessProfile>("RoR2/Base/title/ppSceneBlackbeach_Eclipse.asset").WaitForCompletion(),
      Addressables.LoadAssetAsync<PostProcessProfile>("RoR2/Base/title/ppSceneFoggyswamp.asset").WaitForCompletion(),
      Addressables.LoadAssetAsync<PostProcessProfile>("RoR2/Base/title/ppSceneGolemplainsFoggy.asset").WaitForCompletion(),
      Addressables.LoadAssetAsync<PostProcessProfile>("RoR2/Base/title/ppSceneGolemplains.asset").WaitForCompletion(),
      Addressables.LoadAssetAsync<PostProcessProfile>("RoR2/Base/title/ppSceneMoon.asset").WaitForCompletion(),
      Addressables.LoadAssetAsync<PostProcessProfile>("RoR2/Base/title/ppSceneWispGraveyard.asset").WaitForCompletion(),
      Addressables.LoadAssetAsync<PostProcessProfile>("RoR2/Base/title/ppSceneRootJungleRain.asset").WaitForCompletion(),
      Addressables.LoadAssetAsync<PostProcessProfile>("RoR2/Base/title/ppSceneSkyMeadow.asset").WaitForCompletion(),
    };

    private System.Random rng = new System.Random();
    public static ConfigEntry<bool> shouldRollVanilla;
    private static ConfigFile CSConfig { get; set; }
    private static readonly string[] whitelistedMaps = new string[] {
      "snowyforest",
      "blackbeach",
      "blackbeach2",
      "golemplains",
      "golemplains2",
      "goolake",
      "foggyswamp",
      "ancientloft",
      "frozenwall",
      "wispgraveyard",
      "sulfurpools",
      "shipgraveyard",
      "rootjungle",
      "dampcavesimple",
      "skymeadow",
      "moon2"
};
    public void Awake()
    {
      CSConfig = new ConfigFile(Paths.ConfigPath + "\\com.Nuxlar.CoolerStages.cfg", true);
      shouldRollVanilla = CSConfig.Bind<bool>("General", "Include Vanilla", true, "Add vanilla stage materials/post processing to the pool");
      On.RoR2.SceneDirector.Start += SceneDirector_Start;
    }

    private void SceneDirector_Start(On.RoR2.SceneDirector.orig_Start orig, SceneDirector self)
    {
      string sceneName = SceneManager.GetActiveScene().name;
      SceneInfo currentScene = SceneInfo.instance;
      if (currentScene && whitelistedMaps.Contains(sceneName))
      {
        PostProcessVolume volume = currentScene.GetComponent<PostProcessVolume>();
        if (!volume || !volume.isActiveAndEnabled)
        {
          GameObject alt = GameObject.Find("PP + Amb");
          if (!alt || (!alt?.GetComponent<PostProcessVolume>()?.isActiveAndEnabled ?? true))
            alt = GameObject.Find("PP, Global");
          if (!alt || (!alt?.GetComponent<PostProcessVolume>()?.isActiveAndEnabled ?? true))
            alt = GameObject.Find("GlobalPostProcessVolume, Base");
          if (!alt || (!alt?.GetComponent<PostProcessVolume>()?.isActiveAndEnabled ?? true))
            alt = GameObject.Find("PP+Amb");
          if (!alt || (!alt?.GetComponent<PostProcessVolume>()?.isActiveAndEnabled ?? true))
            alt = GameObject.Find("MapZones")?.transform?.Find("PostProcess Zones")?.Find("SandOvercast")?.gameObject;
          if (alt)
            volume = alt.GetComponent<PostProcessVolume>();
          if (sceneName == "moon2")
          {
            volume = currentScene.gameObject.AddComponent<PostProcessVolume>();
            volume.profile.AddSettings<RampFog>();

            volume.enabled = true;
            volume.isGlobal = true;
            volume.priority = 9999f;
          }
        }
        if (volume)
        {

          int idx = rng.Next(themeMaterials1.Count);
          Material[] themeMaterials = themeMaterials1[idx];
          int idx2 = rng.Next(themeMaterials2.Count);
          Material[] themeMaterialsAlt = themeMaterials2[idx2];

          Material testTerrainMat = themeMaterials[0];
          Material testDetailMat = themeMaterials[1];
          Material testDetailMat2 = themeMaterials[2];
          Material testDetailMat3 = themeMaterials[3];

          Material testTerrainMatAlt = themeMaterialsAlt[0];
          Material testDetailMatAlt = themeMaterialsAlt[1];
          Material testDetailMat2Alt = themeMaterialsAlt[2];
          Material testDetailMat3Alt = themeMaterialsAlt[3];

          int idx3 = rng.Next(themeProfiles.Count);
          PostProcessProfile testProfile = themeProfiles[idx3];

          if (sceneName != "moon2")
            volume.profile = testProfile;

          RampFog testFog = testProfile.GetSetting<RampFog>();
          GameObject sun = GameObject.Find("Directional Light (SUN)");
          if (sun)
          {
            Light mainLight = sun.GetComponent<Light>();
            Color.RGBToHSV(testFog.fogColorEnd, out float fogHue, out float fogSaturation, out float fogValue);
            Color.RGBToHSV(mainLight.color, out float lightHue, out float lightSaturation, out float lightValue);
            mainLight.color = Color.HSVToRGB(fogHue, lightSaturation, lightValue);

            if (IsBright(testTerrainMat))
            {
              mainLight.shadowStrength = 1f;
              if (sceneName == "snowyforest")
                mainLight.intensity = 2f;
              else if (sceneName == "frozenwall" || testTerrainMat.name.Contains("VoidTerrain"))
              {
                mainLight.intensity = 1f;
                mainLight.shadowStrength = 0.5f;
              }
              else
                mainLight.intensity = 0.5f;
            }
            else
            {
              mainLight.shadowStrength = 0.5f;
              if (sceneName == "snowyforest")
                mainLight.intensity = 3f;
              else if (sceneName == "frozenwall")
                mainLight.intensity = 1.25f;
              else
                mainLight.intensity = 1f;
            }

            if (sceneName == "goolake" || sceneName == "frozenwall")
            {
              Light sunLight2 = GameObject.Instantiate(GameObject.Find("Directional Light (SUN)")).GetComponent<Light>();
              sunLight2.color = mainLight.color;
              sun.SetActive(false);
              sun.name = "Fake Sun";
            }
          }

          Debug.LogWarning($"Terrain Material: {testTerrainMat.name}");
          Debug.LogWarning($"Detail (Rocks) Material: {testDetailMat.name}");
          Debug.LogWarning($"Detail2 (Ruins) Material: {testDetailMat2.name}");
          Debug.LogWarning($"Detail3 (Trees) Material: {testDetailMat3.name}");
          Debug.LogWarning($"Post Process Profile: {testProfile.name}");

          switch (sceneName)
          {
            case "blackbeach":
              Stage1.Roost1(testTerrainMat, testDetailMat, testDetailMat2);
              break;
            case "blackbeach2":
              Stage1.Roost2(testTerrainMat, testDetailMat, testDetailMat2);
              break;
            case "golemplains":
              Stage1.Plains(testTerrainMat, testDetailMat, testDetailMat2);
              break;
            case "golemplains2":
              Stage1.Plains(testTerrainMat, testDetailMat, testDetailMat2);
              break;
            case "snowyforest":
              Stage1.Forest(testTerrainMat, testDetailMat, testDetailMat2, testDetailMat3);
              break;
            case "goolake":
              Stage2.Aqueduct(testTerrainMat, testDetailMat, testDetailMat2, testDetailMat3);
              break;
            case "ancientloft":
              Stage2.Aphelian(testTerrainMat, testDetailMat2, testDetailMat3, testDetailMat, testDetailMat2);
              break;
            case "foggyswamp":
              Stage2.Wetland(testTerrainMatAlt, testDetailMatAlt, testDetailMat2Alt, testDetailMat3Alt);
              break;
            case "frozenwall":
              Stage3.RPD(testTerrainMat, testDetailMat, testDetailMat2);
              break;
            case "wispgraveyard":
              Stage3.Acres(testTerrainMat, testDetailMat, testDetailMat2);
              break;
            case "sulfurpools":
              GameObject.Find("CameraRelative").transform.GetChild(1).gameObject.SetActive(false);
              Stage3.Pools(testTerrainMat, testDetailMat, testDetailMat2);
              break;
            case "rootjungle":
              Stage4.Grove(testTerrainMat, testDetailMat, testDetailMat2, testDetailMat3);
              break;
            case "shipgraveyard":
              Stage4.Sirens(testTerrainMatAlt, testDetailMatAlt, testDetailMat2Alt);
              break;
            case "dampcavesimple":
              Stage4.Abyssal(testTerrainMatAlt, testDetailMatAlt, testDetailMat3Alt, testDetailMat2Alt);
              if (GameObject.Find("DCPPInTunnels"))
                GameObject.Find("DCPPInTunnels").SetActive(false);
              break;
            case "skymeadow":
              Stage5.SkyMeadow(testTerrainMat, testDetailMat, testDetailMat3, testDetailMat2);
              break;
            case "moon2":
              RampFog fog = volume.profile.GetSetting<RampFog>();
              fog.fogIntensity.value = testFog.fogIntensity.value;
              fog.fogPower.value = testFog.fogPower.value;
              fog.fogZero.value = testFog.fogZero.value;
              fog.fogOne.value = testFog.fogOne.value;
              fog.fogColorStart.value = testFog.fogColorStart.value;
              fog.fogColorMid.value = testFog.fogColorMid.value;
              fog.fogColorEnd.value = testFog.fogColorEnd.value;
              fog.skyboxStrength.value = testFog.skyboxStrength.value;

              PostProcessVolume bruh = GameObject.Find("HOLDER: Gameplay Space").transform.GetChild(0).Find("Quadrant 4: Starting Temple").GetChild(0).GetChild(0).Find("FX").GetChild(0).GetComponent<PostProcessVolume>();
              bruh.weight = 0.28f;
              HookLightingIntoPostProcessVolume bruh2 = GameObject.Find("HOLDER: Gameplay Space").transform.GetChild(0).Find("Quadrant 4: Starting Temple").GetChild(0).GetChild(0).Find("FX").GetChild(0).GetComponent<HookLightingIntoPostProcessVolume>();
              // 0.1138 0.1086 0.15 1
              // 0.1012 0.1091 0.1226 1
              bruh2.overrideAmbientColor = new Color(0.4138f, 0.4086f, 0.45f, 1);
              bruh2.overrideDirectionalColor = new Color(0.4012f, 0.4091f, 0.4226f, 1);
              Stage6.Moon(testTerrainMat, testDetailMat, testDetailMat2, testDetailMat3);
              break;
          }
        }
      }
      orig(self);
    }

    private bool IsBright(Material material)
    {
      Color materialColor = material.color;
      float luminance = 0.2126f * materialColor.r + 0.7152f * materialColor.g + 0.0722f * materialColor.b;
      if (luminance < 0.7f)
      {
        return false;
      }
      else
      {
        return true;
      }
    }
  }
}