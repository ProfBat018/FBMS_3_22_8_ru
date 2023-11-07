using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaMinus.Models;

public class CinemaHall
{
    public List<Row> Rows { get; private set; }
    public CinemaHall(int rows)
    {
        Rows = new List<Row>(rows);
        int seatCount = 14;

        for (int i = rows; i > 0; i--)
        {
            Rows.Add(new Row(i, seatCount));
            seatCount -= 2;
        }
    }
}
