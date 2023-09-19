namespace SOLID.Models.Classes;

class EntityApiPath
{
    public string Link { get; init; }
    public string Key { get; init; }

    public EntityApiPath(string link, string key)
    {
        Link = link;
        Key = key;
    }
}