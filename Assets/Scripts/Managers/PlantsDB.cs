using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsDB : MonoBehaviour
{
    public List<PlantProperties> PlantPorperties;
    public enum PlantList
    {
        Arctium_lappa,
        Pteropsida,
        Ignis_Herba,
        Corona_Flos,
        Taraxacum,
        Pluma,
        Brassica_oleracea,
        harambe_plumbus,
        Zizania,
        Vrouwentong,
        Heracleum_sphondylium,
        Kopstekel_Flora
    }
    private string[] PlantNameList = System.Enum.GetNames(typeof(PlantList));
    [System.Serializable]
    public class PlantProperties
    {
        
        public List<GameObject> plant_prefabs;
        public Material Alive_texture;
        public Material Dead_texture;
        public PlantList dropDown = PlantList.Arctium_lappa;
        [Range(1.0f, 0.0f)]
        public float oxygen;
        [Range(1.0f, 0.0f)]
        public float water;
        [Range(1.0f, 0.0f)]
        public float nutrient;
    }



}



