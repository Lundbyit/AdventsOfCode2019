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

    if (OnlyRisingNumbers(digits) && ValidPair(digits))
    {
        validPasswords++;
    }
}

Console.WriteLine(validPasswords);

bool OnlyRisingNumbers(List<int> input)
{
    bool onlyRisingNumbers = true;

    for (int i = 1; i < input.Count(); i++)
    {
        if (input[i] < input[i - 1])
        {
            onlyRisingNumbers = false;
        }
    }

    return onlyRisingNumbers;
}

bool ValidPair(List<int> input)
{
    int validPair = 1;
    for (int i = 1; i < input.Count(); i++)
    {
        if (input[i] == input[i - 1])
        {
            validPair++;
        }
        else
        {
            if (validPair == 2)
            {
                return true;
            }

            validPair = 1;
        }
    }

    return validPair == 2;
}
