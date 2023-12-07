List<string> inputs = new List<string>();
using (StreamReader reader = new StreamReader(args[0]))
{
    while (!reader.EndOfStream)
    {
        inputs.Add(reader.ReadLine());
    }
}

part1();
part2();

void part1()
{
    int runTotal = 0;
    foreach (string input in inputs)
    {
        int d1 = 0;
        int d2 = 0;
        for(int i=0; i<input.Length; i++)
        {
            if (d1 == 0 && input[i] >= '1' && input[i] <= '9')
                d1 = input[i] - '0';
            if (d2 == 0 && input[input.Length-i-1] >= '1' && input[input.Length - i - 1] <= '9')
                d2 = input[input.Length - i - 1] - '0';
            if (d1 != 0 && d2 != 0)
                break;
        }
        runTotal += d1 * 10 + d2;
    }
    Console.WriteLine(runTotal);
}

void part2()
{
    Dictionary<string, int> map = new()
    {
        {"one",1},
        {"two",2},
        {"three",3},
        {"four",4},
        {"five",5},
        {"six",6},
        {"seven",7},
        {"eight",8 },
        {"nine",9 },
    };
    int runTotal = 0;
    foreach (string input in inputs)
    {
        int d1 = 0;
        int d2 = 0;
        for (int i = 0; i < input.Length; i++)
        {
            foreach (var m in map)
            {
                if (d1 == 0 && input.Length - i >= m.Key.Length)
                {
                    if (input.Substring(i, m.Key.Length) == m.Key)
                    {
                        d1 = m.Value;
                    }
                }
                if (d2 == 0 && input.Length - (input.Length - i - 1) >= m.Key.Length)
                {
                    if (input.Substring((input.Length - i - 1), m.Key.Length) == m.Key)
                    {
                        d2 = m.Value;
                    }
                }
            }
            if (d1 == 0 && input[i] >= '1' && input[i] <= '9')
                d1 = input[i] - '0';
            if (d2 == 0 && input[input.Length - i - 1] >= '1' && input[input.Length - i - 1] <= '9')
                d2 = input[input.Length - i - 1] - '0';
            if (d1 != 0 && d2 != 0)
                break;
        }
        runTotal += d1 * 10 + d2;
    }
    Console.WriteLine(runTotal);
}