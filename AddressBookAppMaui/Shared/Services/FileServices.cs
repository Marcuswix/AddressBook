using Newtonsoft.Json;
using Shared.Interfaces;
using Shared.Models;
using System.Diagnostics;

namespace Shared.Services;

public class FileService : IFileService
{
    private readonly string _filePath;

    public FileService(string filePath)
    {
        _filePath = filePath;
    }

    public bool SaveContentToFile(string content)
    {
        try
        {
            using (var sw = new StreamWriter(_filePath))
            {
                sw.WriteLine(content);
            }
            return true;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return false;
    }

    public string GetContentFromFile()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                using var sr = new StreamReader(_filePath);
                return sr.ReadToEnd();
            }

        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }
        return null!;
    }

    public bool DeleteContactFromFile(string email)
    {
        try
        {
            var content = GetContentFromFile();

            if (!string.IsNullOrEmpty(content))
            {
                var contacts = JsonConvert.DeserializeObject<List<Contact>>(content);

                var contactToRemove = contacts!.FirstOrDefault(c => c.Email == email);

                if (contactToRemove != null)
                {
                    contacts!.Remove(contactToRemove);
                    SaveContentToFile(JsonConvert.SerializeObject(contacts));
                    return true;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
        return false;
    }
}

