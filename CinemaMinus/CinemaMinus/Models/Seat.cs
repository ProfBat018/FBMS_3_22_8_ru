namespace CinemaMinus.Models;
public class Seat
{
    public Seat(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
    public bool IsFree { get; set; }
    public bool IsSelected { get; set; }
    public float Price { get; set; }
}