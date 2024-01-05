using System.Collections;
using System.Collections.Generic;
using System.Linq;

public struct Car
{
    public string name;
    public int placeInRace;

    public Car(string name, int placeInRace)
    {
        this.name = name;
        this.placeInRace = placeInRace;
    }
}

public class LeaderBoard
{
    private static Dictionary<int, Car> board = new Dictionary<int, Car>();
    private static int carsRegistered = -1;

    public static void Reset()
    {
        board.Clear();
        carsRegistered = -1;
    }

    public static int RegisterCar(string name)
    {
        carsRegistered++;
        board.Add(carsRegistered, new Car(name, 0));
        return carsRegistered;
    }

    public static void SetPosition(int rego, int lap, int checkpoint)
    {
        int position = lap * 1000 + checkpoint;
        board[rego] = new Car(board[rego].name, position);
    }

    public static List<string> GetPlaces()
    {
        List<string> places = new List<string>();
        foreach (var pos in board.OrderByDescending(key => key.Value.placeInRace))
        {
            places.Add(pos.Value.name);
        }

        return places;
    }
}
