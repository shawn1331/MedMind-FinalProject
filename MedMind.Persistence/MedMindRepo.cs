using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MedMind.Logic;
public class MedMindRepo
{
    private readonly string _filePath;

    public MedMindRepo(string filePath)
    {
        _filePath = filePath;
    }

    public MedMindData LoadData()
    {
        if (!File.Exists(_filePath))
        {
            return new MedMindData();
        }

        var json = File.ReadAllText(_filePath);
        var data = JsonSerializer.Deserialize<MedMindData>(json);

        return data ?? new MedMindData();
    }

    public void SaveData(MedMindData data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, json);
    }
}
