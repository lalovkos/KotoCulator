using KotoCulator.Models;
using KotoCulator.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KotoCulator.Input
{
    public class SaveEditor
    {
        public string InputPath = ".";
        public string OutputPath = ".";
        public string MaterialsPath = "/Materials.txt";
        public string CreationsPath = "/Creations.txt";

        public SaveEditor(string inputpath = ".", string outputpath = ".")
        {
            InputPath = inputpath;
            OutputPath = outputpath;
        }

        public List<Material> LoadMaterials()
        {
            string materialsPath = InputPath + MaterialsPath;
            var parseResult = JsonFileParser.ReadJsonFromFile<List<Material>>(materialsPath);
            if (parseResult == null)
            {
                parseResult = new List<Material>() { };
            }
            return parseResult;
        }

        public List<Creation> LoadCreations() 
        {
            string materialsPath = InputPath + CreationsPath;
            var parseResult = JsonFileParser.ReadJsonFromFile<List<Creation>>(materialsPath);
            if (parseResult == null)
            {
                parseResult = new List<Creation>() { };
            }
            return parseResult;
        }

        public void SaveMaterials(List<Material> materials)
        {
            string materialsPath = OutputPath + MaterialsPath;
            JsonFileParser.WriteJsonToFile(materials, materialsPath);
        }

        public void SaveCreations(List<Creation> creations)
        {
            string materialsPath = OutputPath + CreationsPath;
            JsonFileParser.WriteJsonToFile(creations, materialsPath);
        }


    }
}
