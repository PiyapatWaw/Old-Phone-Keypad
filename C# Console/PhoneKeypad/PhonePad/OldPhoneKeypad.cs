namespace PhoneKeypad.Script
{
    internal class OldPhoneKeypad
    {
        public const char DeleteKey = '*';
        public const char SendKey = '#';
        public const char SpaceKey = '0';
        public const string DeleteCode = "";
        public const string SendCode = "";
        public const char SpaceCode = ' ';

        public char[,] Keys =
        {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' },
            { DeleteKey, SpaceKey, SendKey }
        };

        private Keycode[,] keycodes =
        {
            { new Keycode(new[] { "&", "'", "(" }),         new Keycode(new[] { "A", "B", "C" }),   new Keycode(new[] { "D", "E", "F" }) },
            { new Keycode(new[] { "G", "H", "I" }),         new Keycode(new[] { "J", "K", "L" }),   new Keycode(new[] { "M", "N", "O" }) },
            { new Keycode(new[] { "P", "Q", "R", "S" }),    new Keycode(new[] { "T", "U", "V" }),   new Keycode(new[] { "W", "X", "Y", "Z" }) },
            { new Keycode(new[] { DeleteCode}),               new Keycode(new[] { SpaceCode.ToString() }),             new Keycode(new[] { SendCode}) }
        };

        public string[] GetCodes(char key)
        {
            for (int i = 0; i < Keys.GetLength(0); i++)
            {
                for (int j = 0; j < Keys.GetLength(1); j++)
                {
                    if (Keys[i, j] == key)
                    {
                        return GetCharacters(i, j);
                    }
                }
            }

            return new string[0];
        }

        public string[] GetCharacters(int row, int column)
        {
            return keycodes[row, column].Keys;
        }

        /// <summary>
        /// Returns the mapped character for specific key
        /// If the key is pressed more times than the available characters, it loops back to the beginning of the character array.
        /// </summary>
        /// <param name="key">the character was press</param>
        /// <param name="pressCount">the numner of time was press</param>
        /// <returns>the mapped character</returns>
        public string GetMappedCharacter(char key, int pressCount)
        {
            for (int i = 0; i < Keys.GetLength(0); i++)
            {
                for (int j = 0; j < Keys.GetLength(1); j++)
                {
                    if (Keys[i, j] == key)
                    {
                        string[] characters = GetCharacters(i, j);
                        if (characters.Length == 0)
                            return "";

                        int index = (pressCount - 1) % characters.Length;
                        return characters[index];
                    }
                }
            }
            return "";
        }
    }
}


internal struct Keycode
{
    public string[] Keys;

    public Keycode(string[] Keys)
    {
        this.Keys = Keys;
    }
}

