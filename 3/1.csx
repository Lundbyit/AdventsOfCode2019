class Points
{
    public int X { get; set; }
    public int Y { get; set; }
}

string dataPath = Directory.GetCurrentDirectory() + "\\data.txt";
string[] data = System.IO.File.ReadAllLines(dataPath);

List<Points> wire1 = new List<Points>();

int x = 0;
int y = 0;

//Create points for wire1
foreach (var item in data[0].Split(','))
{
    int steps = int.Parse(item.Substring(1));
    char direction = item[0];

    switch (direction)
    {
        case 'R':
            for (int i = 0; i < steps; i++)
            {
                wire1.Add(new Points { X = x, Y = y });
                x++;
            }
            break;
        case 'D':
            for (int i = 0; i < steps; i++)
            {
                wire1.Add(new Points { X = x, Y = y });
                y--;
            }
            break;
        case 'L':
            for (int i = 0; i < steps; i++)
            {
                wire1.Add(new Points { X = x, Y = y });
                x--;
            }
            break;
        case 'U':
            for (int i = 0; i < steps; i++)
            {
                wire1.Add(new Points { X = x, Y = y });
                y++;
            }
            break;

        default:
            break;
    }
}

x = 0;
y = 0;
int closestIntersectionDistance = int.MaxValue;

public static int SetClosestIntersectionDistance(int x, int y, int lowestDistance)
{
    if (x == 0 && y == 0) { return lowestDistance; }
    int distance = Math.Abs(x) + Math.Abs(y);
    return distance < lowestDistance ? distance : lowestDistance;
}

foreach (var item in data[1].Split(','))
{
    int steps = int.Parse(item.Substring(1));
    char direction = item[0];

    switch (direction)
    {
        case 'R':
            for (int i = 0; i < steps; i++)
            {
                if (wire1.Any(point => point.X == x && point.Y == y))
                {
                    closestIntersectionDistance = SetClosestIntersectionDistance(x, y, closestIntersectionDistance);
                };
                x++;
            }
            break;
        case 'D':
            for (int i = 0; i < steps; i++)
            {
                if (wire1.Any(point => point.X == x && point.Y == y))
                {
                    closestIntersectionDistance = SetClosestIntersectionDistance(x, y, closestIntersectionDistance);
                };
                y--;
            }
            break;
        case 'L':
            for (int i = 0; i < steps; i++)
            {
                if (wire1.Any(point => point.X == x && point.Y == y))
                {
                    closestIntersectionDistance = SetClosestIntersectionDistance(x, y, closestIntersectionDistance);
                };
                x--;
            }
            break;
        case 'U':
            for (int i = 0; i < steps; i++)
            {
                if (wire1.Any(point => point.X == x && point.Y == y))
                {
                    closestIntersectionDistance = SetClosestIntersectionDistance(x, y, closestIntersectionDistance);
                };
                y++;
            }
            break;

        default:
            break;
    }
}


System.Console.WriteLine(closestIntersectionDistance);