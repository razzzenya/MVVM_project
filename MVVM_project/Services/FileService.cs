using Microsoft.Win32;
using MVVM_project.Models;
using MVVM_project.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MVVM_project.Services
{
    public class FileService : IFileService
    {
        public string GetFilePath(bool isSaveDialog)
        {
            if (isSaveDialog)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    return saveFileDialog.FileName;
                }
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    return openFileDialog.FileName;
                }
            }
            return null;
        }

        public void SaveData(string filePath, ModelClass data)
        {
            List<ModelClass> calculations = new List<ModelClass>();

            if (File.Exists(filePath))
            {
                string existingData = File.ReadAllText(filePath);
                calculations = JsonConvert.DeserializeObject<List<ModelClass>>(existingData) ?? new List<ModelClass>();
            }
            calculations.Add(data);

            string jsonData = JsonConvert.SerializeObject(calculations, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }

        public List<ModelClass> LoadData(string filePath)
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<ModelClass>>(jsonData) ?? new List<ModelClass>();
            }

            return new List<ModelClass>();
        }
    }
}
