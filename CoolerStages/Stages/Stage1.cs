using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CoolerStages
{
    public class Stage1
    {
        private static Texture2D terrainSandTex = Addressables.LoadAssetAsync<Texture2D>("RoR2/DLC2/lakes/Assets/texTLTerrainSand.tga").WaitForCompletion();
        private static Texture2D tlDirtTex = Addressables.LoadAssetAsync<Texture2D>("RoR2/DLC2/lakes/Assets/texTLTerrainDirt.tga").WaitForCompletion();

        public static void Falls(Material terrainMat, Material detailMat, Material detailMat2, Material detailMat3, Color32 color)
        {
            if (terrainMat && detailMat && detailMat2 && detailMat3)
            {
                MeshRenderer[] meshList = UnityEngine.Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
                foreach (MeshRenderer renderer in meshList)
                {
                    GameObject meshBase = renderer.gameObject;
                    if (meshBase != null)
                    {
                        if (meshBase.name.Contains("TLTerrain") && !meshBase.name.Contains("Vines") && !meshBase.name.Contains("GiantFlower") && !meshBase.name.Contains("Ship") && renderer.sharedMaterial)
                            renderer.sharedMaterial = terrainMat;
                        if ((meshBase.name.Contains("TLTerrain_GiantFlower") || meshBase.name.Contains("TLTerrain_TreePads")) && renderer.sharedMaterial)
                        {
                            /*
                            if (meshBase.name.Contains("TreePads"))
                                renderer.sharedMaterials = new Material[] { terrainMat, renderer.sharedMaterials[1], renderer.sharedMaterials[2] };
                            else
                                renderer.sharedMaterials = new Material[] { terrainMat, renderer.sharedMaterials[1] };
                                */
                            foreach (Material mat in renderer.sharedMaterials)
                            {
                                mat.color = color;
                            }
                        }
                        if (meshBase.name.Contains("Grass") && renderer.sharedMaterial)
                        {
                            GameObject.Destroy(meshBase);
                        }
                        if (meshBase.name.Contains("Vines") || meshBase.name.Contains("TLRoot") && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat3;
                        if ((meshBase.name.Contains("TLTerrain_Ship") || meshBase.name.Contains("TLArchi") || meshBase.name.Contains("TLDoor")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat2;
                        if (meshBase.name.Contains("TLRock") && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat;
                    }
                }
            }
            // TLTerrain without Vines/GiantFlower/TreePads/Ship/VinesLeaves
            // TLRock
            // TLArchi/TLDoor
        }

        public static void NightFalls(Material terrainMat, Material detailMat, Material detailMat2, Material detailMat3, Color32 color)
        {
            if (terrainMat && detailMat && detailMat2 && detailMat3)
            {
                MeshRenderer[] meshList = UnityEngine.Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
                foreach (MeshRenderer renderer in meshList)
                {
                    GameObject meshBase = renderer.gameObject;
                    if (meshBase != null)
                    {
                        if (meshBase.name.Contains("TLTerrain") && !meshBase.name.Contains("Vines") && !meshBase.name.Contains("GiantFlower") && !meshBase.name.Contains("Ship") && renderer.sharedMaterial)
                            renderer.sharedMaterial = terrainMat;
                        if ((meshBase.name.Contains("TLTerrain_GiantFlower") || meshBase.name.Contains("TLTerrain_TreePads")) && renderer.sharedMaterial)
                        {
                            /*
                            if (meshBase.name.Contains("TreePads"))
                                renderer.sharedMaterials = new Material[] { terrainMat, renderer.sharedMaterials[1], renderer.sharedMaterials[2] };
                            else
                                renderer.sharedMaterials = new Material[] { terrainMat, renderer.sharedMaterials[1] };
                                */
                            foreach (Material mat in renderer.sharedMaterials)
                            {
                                mat.color = color;
                            }
                        }
                        if (meshBase.name.Contains("Grass") && renderer.sharedMaterial)
                        {
                            GameObject.Destroy(meshBase);
                        }
                        if (meshBase.name.Contains("Vines") || meshBase.name.Contains("TLRoot") && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat3;
                        if ((meshBase.name.Contains("TLTerrain_Ship") || meshBase.name.Contains("TLArchi") || meshBase.name.Contains("TLDoor")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat2;
                        if (meshBase.name.Contains("TLRock") && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat;
                    }
                }
            }
            // TLTerrain without Vines/GiantFlower/TreePads/Ship/VinesLeaves
            // TLRock
            // TLArchi/TLDoor
        }
        public static void Shattered(Material terrainMat, Material detailMat, Material detailMat2, Material detailMat3)
        {
            if (terrainMat && detailMat && detailMat2)
            {
                MeshRenderer[] meshList = UnityEngine.Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
                foreach (MeshRenderer renderer in meshList)
                {
                    GameObject meshBase = renderer.gameObject;
                    if (meshBase != null)
                    {
                        if (meshBase.name.Contains("Terrain") || meshBase.name.Contains("Dune") || meshBase.name.Contains("Coral"))
                        {
                            renderer.sharedMaterials = [terrainMat, terrainMat];
                        }
                        if (meshBase.name.Contains("Grass") && renderer.sharedMaterial)
                        {
                            GameObject.Destroy(meshBase);
                        }
                        if ((meshBase.name.Contains("Boulder") || meshBase.name.Contains("Rock") || meshBase.name.Contains("Step") || meshBase.name.Contains("Tile") || meshBase.name.Contains("Pebble") || meshBase.name.Contains("Detail")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat;
                        if ((meshBase.name.Contains("Bowl") || meshBase.name.Contains("Marker") || meshBase.name.Contains("Chime") || meshBase.name.Contains("Gate")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat3;
                        if ((meshBase.name.Contains("Pillar") || meshBase.name.Contains("Altar")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat2;
                        if ((meshBase.name.Contains("Arc") || meshBase.name.Contains("House")) && renderer.sharedMaterial)
                            renderer.sharedMaterials = [detailMat, terrainMat];
                    }
                }
                GameObject.Find("LVArc_StormOutlook").gameObject.GetComponent<MeshRenderer>().sharedMaterials = [terrainMat, detailMat];
            }
        }

        public static void NightShattered(Material terrainMat, Material detailMat, Material detailMat2, Material detailMat3)
        {
            if (terrainMat && detailMat && detailMat2)
            {
                MeshRenderer[] meshList = UnityEngine.Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
                foreach (MeshRenderer renderer in meshList)
                {
                    GameObject meshBase = renderer.gameObject;
                    if (meshBase != null)
                    {
                        if (meshBase.name.Contains("Terrain") || meshBase.name.Contains("Dune") || meshBase.name.Contains("Coral"))
                        {
                            renderer.sharedMaterials = [terrainMat, terrainMat];
                        }
                        if (meshBase.name.Contains("Grass") && renderer.sharedMaterial)
                        {
                            GameObject.Destroy(meshBase);
                        }
                        if ((meshBase.name.Contains("Boulder") || meshBase.name.Contains("Rock") || meshBase.name.Contains("Step") || meshBase.name.Contains("Tile") || meshBase.name.Contains("Pebble") || meshBase.name.Contains("Detail")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat;
                        if ((meshBase.name.Contains("Bowl") || meshBase.name.Contains("Marker") || meshBase.name.Contains("Chime") || meshBase.name.Contains("Gate")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat3;
                        if ((meshBase.name.Contains("Pillar") || meshBase.name.Contains("Altar")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat2;
                        if ((meshBase.name.Contains("Arc") || meshBase.name.Contains("House")) && renderer.sharedMaterial)
                            renderer.sharedMaterials = [detailMat, terrainMat];
                    }
                }
                GameObject.Find("LVArc_StormOutlook").gameObject.GetComponent<MeshRenderer>().sharedMaterials = [terrainMat, detailMat];
            }
        }

        public static void Roost1(Material terrainMat, Material detailMat, Material detailMat2)
        {
            if (terrainMat && detailMat && detailMat2)
            {

                MeshRenderer[] meshList = UnityEngine.Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
                foreach (MeshRenderer renderer in meshList)
                {
                    GameObject meshBase = renderer.gameObject;
                    if (meshBase != null)
                    {
                        if (meshBase.name.Contains("Grass") && renderer.sharedMaterial)
                        {
                            GameObject.Destroy(meshBase);
                        }
                        if ((meshBase.name.Contains("Boulder") || meshBase.name.Contains("Rock") || meshBase.name.Contains("Step") || meshBase.name.Contains("Tile") || meshBase.name.Contains("mdlGeyser") || meshBase.name.Contains("Pebble") || meshBase.name.Contains("Detail")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat;
                        if ((meshBase.name.Contains("Bowl") || meshBase.name.Contains("Marker") || meshBase.name.Contains("RuinPillar") || meshBase.name.Contains("RuinArch") || meshBase.name.Contains("RuinGate")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat2;
                        if ((meshBase.name.Contains("DistantPillar") || meshBase.name.Contains("Cliff") || meshBase.name.Contains("ClosePillar")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = terrainMat;
                    }
                }
            }
        }

        public static void Roost2(Material terrainMat, Material detailMat, Material detailMat2)
        {
            if (terrainMat && detailMat && detailMat2)
            {
                try
                {
                    Transform terrain = GameObject.Find("HOLDER: Terrain").transform.GetChild(0);
                    terrain.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = terrainMat;
                    terrain.GetChild(1).GetComponent<MeshRenderer>().sharedMaterial = terrainMat;
                    terrain.GetChild(2).GetComponent<MeshRenderer>().sharedMaterial = terrainMat;
                }
                catch { Debug.LogError("Failed to set the Material for some Terrain. Please report this to the Mod's Maintainer."); }

                MeshRenderer[] meshList = UnityEngine.Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
                foreach (MeshRenderer renderer in meshList)
                {
                    GameObject meshBase = renderer.gameObject;
                    if (meshBase != null)
                    {
                        if (meshBase.name.Contains("Grass") && renderer.sharedMaterial)
                        {
                            GameObject.Destroy(meshBase);
                        }
                        if ((meshBase.name.Contains("Boulder") || meshBase.name.Contains("boulder") || meshBase.name.Contains("Rock") || meshBase.name.Contains("Step") || meshBase.name.Contains("Tile") || meshBase.name.Contains("mdlGeyser") || meshBase.name.Contains("Bowl") || meshBase.name.Contains("Marker") || meshBase.name.Contains("RuinPillar") || meshBase.name.Contains("DistantBridge")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat;
                        if ((meshBase.name.Contains("Bowl") || meshBase.name.Contains("Marker") || meshBase.name.Contains("RuinPillar") || meshBase.name.Contains("RuinArch") || meshBase.name.Contains("RuinGate")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat2;
                        if ((meshBase.name.Contains("DistantPillar") || meshBase.name.Contains("Cliff") || meshBase.name.Contains("ClosePillar")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = terrainMat;
                    }
                }
            }
        }

        public static void Plains(Material terrainMat, Material detailMat, Material detailMat2)
        {
            if (terrainMat && detailMat && detailMat2)
            {
                MeshRenderer[] meshList = UnityEngine.Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
                foreach (MeshRenderer renderer in meshList)
                {
                    GameObject meshBase = renderer.gameObject;
                    if (meshBase != null)
                    {
                        if (meshBase.name.Contains("Grass") && renderer.sharedMaterial)
                        {
                            GameObject.Destroy(meshBase);
                        }
                        if ((meshBase.name.Contains("Terrain") || meshBase.name == "Wall North") && renderer.sharedMaterial)
                            renderer.sharedMaterial = terrainMat;
                        if ((meshBase.name.Contains("Rock") || meshBase.name.Contains("Boulder") || meshBase.name.Contains("mdlGeyser")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat;
                        if (meshBase.name.Contains("Ring") && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat2;
                        if ((meshBase.name.Contains("Block") || meshBase.name.Contains("MiniBridge") || meshBase.name.Contains("Circle")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat2;
                    }
                }
            }
        }

        public static void Forest(Material terrainMat, Material detailMat, Material detailMat2, Material detailMat3)
        {
            if (terrainMat && detailMat && detailMat2 && detailMat3)
            {
                MeshRenderer[] meshList = UnityEngine.Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];

                foreach (MeshRenderer renderer in meshList)
                {
                    GameObject meshBase = renderer.gameObject;
                    if (meshBase != null)
                    {
                        if (meshBase.name.Contains("Grass") && renderer.sharedMaterial)
                        {
                            GameObject.Destroy(meshBase);
                        }
                        if (meshBase.name == "meshSnowyForestGiantTreesTops")
                            meshBase.gameObject.SetActive(false);
                        if ((meshBase.name.Contains("Terrain") || meshBase.name.Contains("SnowPile")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = terrainMat;
                        if ((meshBase.name.Contains("Pebble") || meshBase.name.Contains("Rock") || meshBase.name.Contains("mdlSFCeilingSpikes")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat;
                        if ((meshBase.name.Contains("RuinGate") || meshBase.name.Contains("meshSnowyForestAqueduct") || meshBase.name == "meshSnowyForestFirepitFloor" || meshBase.name.Contains("meshSnowyForestFirepitRing") || meshBase.name.Contains("meshSnowyForestFirepitJar") || (meshBase.name.Contains("meshSnowyForestPot") && meshBase.name != "meshSnowyForestPotSap") || meshBase.name.Contains("mdlSFHangingLantern") || meshBase.name.Contains("mdlSFBrokenLantern") || meshBase.name.Contains("meshSnowyForestCrate")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat2;
                        if ((meshBase.name.Contains("meshSnowyForestTreeLog") || meshBase.name.Contains("meshSnowyForestTreeTrunk") || meshBase.name.Contains("meshSnowyForestGiantTrees") || meshBase.name.Contains("meshSnowyForestSurroundingTrees")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat3;
                        if (meshBase.name.Contains("mdlSnowyForestTreeStump") && renderer.sharedMaterial)
                        {
                            renderer.sharedMaterial = detailMat3;
                            renderer.sharedMaterials = new Material[] { detailMat3, detailMat3 };
                        }
                    }
                }
            }
        }

    }
}
