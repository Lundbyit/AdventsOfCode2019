int low = 235741;
int high = 706948;
int validPasswords = 0;

for (int i = low; i <= high; i++)
{
    List<int> digits = i.ToString().Select(c => int.Parse(c.ToString())).ToList();
    if (digits.Count() > 6)
    {
        break;
    }

    if (MatchesCriterias(digits))
    {
        validPasswords++;
    }
}

Console.WriteLine(validPasswords);

bool MatchesCriterias(List<int> input)
{
    bool haveSameAdjacent = false;
    bool onlyRisingNumbers = true;

    for (int i = 1; i < input.Count(); i++)
    {
        if (input[i] == input[i - 1])
        {
            haveSameAdjacent = true;
        }

        if (input[i] < input[i - 1])
        {
            onlyRisingNumbers = false;
        }
    }

    return haveSameAdjacent && onlyRisingNumbers;
}
