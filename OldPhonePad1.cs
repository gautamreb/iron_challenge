public class OldPhonePad
{
    public static string OldPhonePad1(string input)
    {
        if (string.IsNullOrEmpty(input)) return string.Empty;

        // Mapping of number buttons to their respective characters
        Dictionary<char, string> keyMap = new Dictionary<char, string>
        {
            { '1', "" },
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" },
            { '0', " " },
            { '*', "" }, // Backspace or ignore
            { '#', "" }  // Send button
        };

        System.Text.StringBuilder result = new System.Text.StringBuilder();
        int count = 0;
        char currentChar = '\0';
        bool pause = false;

        foreach (char ch in input)
        {
            if (ch == ' ' || ch == '#')
            {
                if (count > 0)
                {
                    if (currentChar != '\0')
                    {
                        string chars = keyMap[currentChar];
                        result.Append(chars[(count - 1) % chars.Length]);
                    }
                    count = 0;
                }

                if (ch == '#') break; // End of input
                pause = true; // Space means pause, so we reset counting for same button
                continue;
            }

            if (ch == '*')
            {
                if (result.Length > 0)
                {
                    result.Length--; // Remove last character
                }
                continue;
            }

            if (ch != currentChar || pause)
            {
                if (count > 0)
                {
                    string chars = keyMap[currentChar];
                    result.Append(chars[(count - 1) % chars.Length]);
                }
                currentChar = ch;
                count = 1;
                pause = false;
            }
            else
            {
                count++;
            }
        }

        return result.ToString();
    }
}

class Program1
{
    static void Main(string[] args)
    {
        Console.WriteLine(OldPhonePad.OldPhonePad1("33#"));               // Output: E
        Console.WriteLine(OldPhonePad.OldPhonePad1("227*#"));             // Output: B
        Console.WriteLine(OldPhonePad.OldPhonePad1("4433555 555666#"));   // Output: HELLO
        Console.WriteLine(OldPhonePad.OldPhonePad1("8 88777444666*664#")); // Output: ??????
        Console.WriteLine(OldPhonePad.OldPhonePad1("4288 826#")); // GAUTAM
    }
}