using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace reserveringsysteem_project_B
{

    public struct Menu
    {
        [JsonPropertyName("categorie")]
        public string Categorie { get; set; }

        [JsonPropertyName("naam")]
        public string Naam { get; set; }

        [JsonPropertyName("prijs")]
        public double? Prijs { get; set; }

        [JsonPropertyName("allergenen")]
        public string Allergenen { get; set; }

        [JsonPropertyName("subnaam")]
        public string Subnaam { get; set; }

        [JsonPropertyName("subnaam1")]
        public string Subnaam1 { get; set; }
        
        [JsonPropertyName("subnaam2")]
        public string Subnaam2 { get; set; }

        [JsonPropertyName("subprijs")]
        public double SubPrijs { get; set; }

        [JsonPropertyName("subprijs1")]
        public double SubPrijs1 { get; set; }

        [JsonPropertyName("subprijs2")]
        public double SubPrijs2 { get; set; }
    }

    internal class Menus
    {
        private List<Menu> _LunchMenu;
        private List<Menu> _DinerMenu;
        private List<Menu> _OntbijtMenu;
        private static Menus _instance = null;

        public Menus()
        {
            var data = new Data<Menu>();
            _LunchMenu = data.Load("LunchMenu.json");
            _DinerMenu = data.Load("DinerMenu.json");
            _OntbijtMenu = data.Load("OntbijtMenu.json");
        }

        public List<Menu> GetLunch(bool includeDrinks = false)
        {
            return _LunchMenu;
        }

        public List<Menu> GetDiner()
        {
            return _DinerMenu;
        }

        public List<Menu> GetOntbijt()
        {
            return _OntbijtMenu;
        }

        public static Menus GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Menus();
            }
            return _instance;
        }
    }
}
