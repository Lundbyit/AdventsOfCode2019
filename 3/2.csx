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

foreach (var item in data[0].Split(','))
{
    int noOfSteps = int.Parse(item.Substring(1));
    char direction = item[0];

    switch (direction)
    {
        case 'R':
            for (int i = 0; i < noOfSteps; i++)
            {
                wire1.Add(new Points { X = x, Y = y });
                x++;
            }
            break;
        case 'D':
            for (int i = 0; i < noOfSteps; i++)
            {
                wire1.Add(new Points { X = x, Y = y });
                y--;
            }
            break;
        case 'L':
            for (int i = 0; i < noOfSteps; i++)
            {
                wire1.Add(new Points { X = x, Y = y });
                x--;
            }
            break;
        case 'U':
            for (int i = 0; i < noOfSteps; i++)
            {
                wire1.Add(new Points { X = x, Y = y });
                y++;
            }
            break;

        default:
            break;
    }
}

int CalculateIntersectionWithLowestSteps(int x, int y, int steps, int currentLow)
{
    if (x == 0 && y == 0)
    {
        return currentLow;
    }

    int intersectionIndex = wire1.FindIndex(point => point.X == x && point.Y == y);

    if (!(intersectionIndex == -1))
    {
        int totalSteps = steps + intersectionIndex;
        return currentLow <= totalSteps ? currentLow : totalSteps;
    }

    return currentLow;
}

x = 0;
y = 0;
int steps = 0;
int intersectionWithLowestSteps = int.MaxValue;

foreach (var item in data[1].Split(','))
{
    int noOfSteps = int.Parse(item.Substring(1));
    char direction = item[0];

    switch (direction)
    {
        case 'R':
            for (int i = 0; i < noOfSteps; i++)
            {
                intersectionWithLowestSteps = CalculateIntersectionWithLowestSteps(x, y, steps, intersectionWithLowestSteps);
                x++;
                steps++;
            }
            break;
        case 'D':
            for (int i = 0; i < noOfSteps; i++)
            {
                intersectionWithLowestSteps = CalculateIntersectionWithLowestSteps(x, y, steps, intersectionWithLowestSteps);
                y--;
                steps++;
            }
            break;
        case 'L':
            for (int i = 0; i < noOfSteps; i++)
            {
                intersectionWithLowestSteps = CalculateIntersectionWithLowestSteps(x, y, steps, intersectionWithLowestSteps);
                x--;
                steps++;
            }
            break;
        case 'U':
            for (int i = 0; i < noOfSteps; i++)
            {
                intersectionWithLowestSteps = CalculateIntersectionWithLowestSteps(x, y, steps, intersectionWithLowestSteps);
                y++;
                steps++;
            }
            break;

        default:
            break;
    }
}

Console.WriteLine(intersectionWithLowestSteps);
