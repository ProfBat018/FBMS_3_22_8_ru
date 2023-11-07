using System.Collections.Generic;

namespace CinemaMinus.Models;

public class Row
{
    public int Id { get; set; }
    public List<Seat> Seats { get; set; }
    public Row(int id, int seatCount)
    {
        Id = id;
        Seats = new(seatCount);

        for (int i = 0; i < seatCount; i++)
        {
            Seats.Add(new(i + 1));
        }
    }
}