namespace APBD_zaj5.Classes;

public class Pet
{
    private static int _idToAdd = 1;
    public int Id { get; set; } = _idToAdd++;
    public string Name { get; set; }
    public string Category { get; set; }
    public double Mass { get; set; }
    public string Color { get; set; }
}