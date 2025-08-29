using System.Drawing;
using UnityEngine;

namespace CoolerStages
{
    public class Stage5
    {

        public static void SkyMeadow(Material terrainMat, Material detailMat, Material detailMat2, Material detailMat3, UnityEngine.Color grassColor)
        {
            Transform r = GameObject.Find("HOLDER: Randomization").transform;
            Transform btp = GameObject.Find("PortalDialerEvent").transform.GetChild(0);
            if (terrainMat && detailMat && detailMat2 && detailMat3)
            {
                MeshRenderer[] meshList = Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
                foreach (MeshRenderer renderer in meshList)
                {
                    GameObject meshBase = renderer.gameObject;
                    Transform meshParent = meshBase.transform.parent;
                    if (meshBase != null)
                    {
                        if (meshParent != null)
                        {
                            if ((meshBase.name.Contains("Plateau") || meshBase.name.Contains("SMRock") && meshParent.name.Contains("FORMATION")) && renderer.sharedMaterial)
                                renderer.sharedMaterial = terrainMat;
                            if ((meshBase.name.Contains("SMRock") && meshParent.name.Contains("HOLDER: Spinning Rocks") || meshBase.name.Contains("SMRock") && meshParent.name.Contains("P13") || meshBase.name.Contains("SMPebble") && meshParent.name.Contains("Underground") || meshBase.name.Contains("Boulder") && meshParent.name.Contains("PortalDialerEvent")) && renderer.sharedMaterial)
                                renderer.sharedMaterial = detailMat;
                            if ((meshBase.name.Contains("SMRock") && meshParent.name.Contains("GROUP: Rocks") || meshBase.name.Contains("SMSpikeBridge") && meshParent.name.Contains("Underground")) && renderer.sharedMaterial)
                                renderer.sharedMaterial = detailMat2;
                            if ((meshBase.name.Contains("Terrain") || meshBase.name.Contains("Plateau Under") && meshParent.name.Contains("Underground")) && renderer.sharedMaterial)
                                renderer.sharedMaterial = terrainMat;
                        }
                        if (meshBase.name.Contains("Grass") && renderer.sharedMaterial)
                        {
                            GameObject.Destroy(meshBase);
                        }
                        /*
                        if (meshBase.name.Contains("spmSMGrass"))
                        {
                            if (renderer.sharedMaterial != null)
                            {
                                renderer.sharedMaterial.color = grassColor;
                                if (renderer.sharedMaterials.Length >= 2)
                                    renderer.sharedMaterials[1].color = grassColor;
                            }
                        }
                        */
                        if ((meshBase.name.Contains("SMPebble") || meshBase.name.Contains("Rock") || meshBase.name.Contains("mdlGeyser")) && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat;
                        if (meshBase.name.Contains("SMSpikeBridge") && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat2;
                        if (meshBase.name.Contains("Ruin") && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat3;
                    }
                }
                try
                {
                    GameObject.Find("HOLDER: Terrain").transform.GetChild(1).GetComponent<MeshRenderer>().sharedMaterial = terrainMat;
                    btp.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = terrainMat;
                    GameObject.Find("ArtifactFormulaHolderMesh").GetComponent<MeshRenderer>().sharedMaterial = detailMat2;
                    GameObject.Find("SM_Stairway").GetComponent<MeshRenderer>().sharedMaterial = terrainMat;
                } catch { Debug.LogError("Failed setting specific Material"); }
                try { GameObject.Find("Plateau 13 (1)").GetComponent<MeshRenderer>().sharedMaterial = terrainMat; } catch { }
                try
                {
                    Transform tallplat = r.GetChild(0);
                    tallplat.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().sharedMaterial = terrainMat;
                    tallplat.GetChild(0).GetChild(1).gameObject.GetComponent<MeshRenderer>().sharedMaterial = detailMat2;
                    tallplat.GetChild(1).GetChild(0).gameObject.GetComponent<MeshRenderer>().sharedMaterial = terrainMat;
                    tallplat.GetChild(1).GetChild(1).gameObject.GetComponent<MeshRenderer>().sharedMaterial = detailMat2;
                }
                catch { Debug.LogError("Error setting Materials in Tall Plateu"); }
                try
                {
                    Transform plat6 = r.GetChild(1);
                    plat6.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().sharedMaterial = terrainMat;
                    plat6.GetChild(0).GetChild(1).gameObject.GetComponent<MeshRenderer>().sharedMaterial = detailMat2;
                    plat6.GetChild(0).GetChild(2).gameObject.GetComponent<MeshRenderer>().sharedMaterial = detailMat2;
                    plat6.GetChild(1).GetChild(0).gameObject.GetComponent<MeshRenderer>().sharedMaterial = terrainMat;
                    plat6.GetChild(1).GetChild(11).gameObject.GetComponent<MeshRenderer>().sharedMaterial = detailMat2;
                    plat6.GetChild(1).GetChild(13).gameObject.GetComponent<MeshRenderer>().sharedMaterial = detailMat2;
                }
                catch { Debug.LogError("Error setting Materials in Plateu 6"); }
                try
                {
                    Transform plat9 = r.GetChild(2);
                    plat9.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().sharedMaterial = terrainMat;
                    plat9.GetChild(0).GetChild(1).gameObject.GetComponent<MeshRenderer>().sharedMaterial = detailMat2;
                    plat9.GetChild(0).GetChild(2).gameObject.GetComponent<MeshRenderer>().sharedMaterial = detailMat2;
                    plat9.GetChild(1).GetChild(0).gameObject.GetComponent<MeshRenderer>().sharedMaterial = detailMat2;
                }
                catch { Debug.LogError("Error setting Materials in Plateu 9"); }
                try
                {
                    Transform plat11 = r.GetChild(3);
                    plat11.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().sharedMaterial = terrainMat;
                }
                catch { Debug.LogError("Error setting Materials in Plateu 11"); }
                try
                {
                    Transform plat13 = r.GetChild(4);
                    r.GetChild(4).GetChild(1).GetChild(3).gameObject.GetComponent<MeshRenderer>().sharedMaterial = terrainMat;
                }
                catch { Debug.LogError("Error setting Materials in Plateu 13"); }
                try
                {
                    Transform plat15 = r.GetChild(5);
                    plat15.GetChild(0).GetChild(0).gameObject.GetComponent<MeshRenderer>().sharedMaterial = terrainMat;
                    plat15.GetChild(0).GetChild(10).gameObject.GetComponent<MeshRenderer>().sharedMaterial = detailMat2;
                    plat15.GetChild(0).GetChild(11).gameObject.GetComponent<MeshRenderer>().sharedMaterial = detailMat2;
                    plat15.GetChild(1).GetChild(0).gameObject.GetComponent<MeshRenderer>().sharedMaterial = terrainMat;
                    plat15.GetChild(1).GetChild(1).gameObject.GetComponent<MeshRenderer>().sharedMaterial = detailMat2;
                    plat15.GetChild(1).GetChild(2).gameObject.GetComponent<MeshRenderer>().sharedMaterial = detailMat2;
                    plat15.GetChild(2).GetChild(0).gameObject.GetComponent<MeshRenderer>().sharedMaterial = detailMat2;
                }
                catch { Debug.LogError("Error setting Materials in Plateu 15"); }
            }
        }

        public static void Roost(Material terrainMat, Material detailMat, Material detailMat2, Material detailMat3, UnityEngine.Color color)
        {
            if (terrainMat && detailMat && detailMat2 && detailMat3)
            {
                MeshRenderer[] meshList = UnityEngine.Object.FindObjectsOfType(typeof(MeshRenderer)) as MeshRenderer[];
                foreach (MeshRenderer renderer in meshList)
                {
                    GameObject meshBase = renderer.gameObject;
                    if (meshBase != null)
                    {
                        if (meshBase.name.Contains("HRTerrain") && !meshBase.name.Contains("Lava"))
                            renderer.sharedMaterial = terrainMat;
                        else if (meshBase.name.Contains("Grass") || meshBase.name.Contains("Weed"))
                        {
                            GameObject.Destroy(meshBase);
                        }
                        else if (meshBase.name.Contains("HRRock") && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat;
                        else if (meshBase.name.Contains("HRGroundCover") && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat3;
                        else if (meshBase.name.Contains("Worm") && renderer.sharedMaterial)
                            renderer.sharedMaterial = detailMat;
                    }
                }

                GameObject lava_light = GameObject.Find("Lava Spot Light").gameObject;
                if (lava_light != null)
                {
                    lava_light.GetComponent<Light>().intensity = 0f;
                }

                //MeshRenderer building1 = GameObject.Find("HRSection1").gameObject.GetComponent<MeshRenderer>();
                //if (building1 != null)
                //{
                //    building1.sharedMaterials[0] = detailMat;
                //    building1.sharedMaterials[1] = detailMat2;
                //    building1.sharedMaterials[2] = detailMat3;
                //}
                //MeshRenderer building2 = GameObject.Find("HRSection1").gameObject.GetComponent<MeshRenderer>();
                //if (building2 != null)
                //{
                //    building2.sharedMaterials[0] = detailMat;
                //    building2.sharedMaterials[1] = detailMat2;
                //    building2.sharedMaterials[2] = detailMat3;
                //}
                //MeshRenderer building3 = GameObject.Find("HRSection1").gameObject.GetComponent<MeshRenderer>();
                //if (building3 != null)
                //{
                //    building3.sharedMaterials[0] = detailMat;
                //    building3.sharedMaterials[1] = detailMat2;
                //    building3.sharedMaterials[2] = detailMat3;
                //}
                //MeshRenderer building4 = GameObject.Find("HRSection4").gameObject.GetComponent<MeshRenderer>();
                //if (building4 != null)
                //{
                //    building4.sharedMaterials[0] = detailMat;
                //    building4.sharedMaterials[1] = detailMat2;
                //    building4.sharedMaterials[2] = detailMat3;
                //}

                GameObject camparticles = GameObject.Find("CAMERA PARTICLES: AshParticles");
                if (camparticles != null) { camparticles.SetActive(false); }

                //GameObject particles = GameObject.Find("Particles");
                //if (particles != null) { particles.SetActive(false); }

                //MeshRenderer lava = GameObject.Find("HRLava").gameObject.GetComponent<MeshRenderer>();
                //if (lava) {
                //    lava.material.SetColor("_Color", color);
                //}
                //Renderer terrainlava = GameObject.Find("HRTerrainLava").gameObject.GetComponent<MeshRenderer>();
                //if (terrainlava)
                //{
                //    terrainlava.material.SetColor("_Color", color);
                //}
                //Renderer terrainlavacracks = GameObject.Find("HRTerrainLavaCracks").gameObject.GetComponent<MeshRenderer>();
                //if (terrainlavacracks)
                //{
                //    terrainlavacracks.material.SetColor("_Color", color);
                //}
            }
        }

    }
}
