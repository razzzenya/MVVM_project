using MVVM_project.Models;
using System.Collections.Generic;


namespace MVVM_project.Interfaces
{
    public interface IFileService
    {
        string GetFilePath(bool IsSaveDialog);
        void SaveData(string filePath, ModelClass data);
        List<ModelClass> LoadData(string filePath);
    }
}

