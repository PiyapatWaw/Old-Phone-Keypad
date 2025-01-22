using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace PhoneKeypad.Script
{
    public class OldPhonePad : PhonePad
    {
        internal OldPhoneKeypad keypad = new OldPhoneKeypad();

        /// <summary>
        /// Parse the input string to a string representung mapped
        /// Key Behavior:
        /// - SendKey (#): Ends the input sequence and returns the result.
        /// - DeleteKey (*): Removes the last entered character from the result.
        /// - SpaceKey (0): Resets the current key sequence and adds a space to the result.
        /// </summary>
        /// <param name="input"></param> The input string to be parsed
        /// <returns>A result string was mapping by "input"</returns>
        public string ParseInput(string input)
        {
            if (input.Length == 0 || input.Last() != OldPhoneKeypad.SendKey)
            {
                return "ERROR: Format is wrong. Input must end with #";
            }

            var validKeys = new List<char>();
            validKeys.Add(OldPhoneKeypad.SpaceCode);
            foreach (var key in keypad.Keys)
            {
                validKeys.Add(key);
            }
            foreach (var key in input)
            {
                if (!validKeys.Contains(key))
                {
                    return $"ERROR: Invalid key '{key}' found in input.";
                }
            }

            return Parse(input);
        }

        private string Parse(string input)
        {
            StringBuilder result = new StringBuilder();
            char previousKey = '\0';
            int pressCount = 0;

            foreach (var key in input)
            {
                if (key == OldPhoneKeypad.SendKey)
                {
                    if (previousKey != '\0')
                    {
                        AppendCharacter(result, previousKey, pressCount);
                    }
                    break;
                }
                else if (key == OldPhoneKeypad.DeleteKey)
                {
                    if (previousKey == '\0' && result.Length > 0)
                    {
                        result.Remove(result.Length - 1, 1);
                    }
                    previousKey = '\0';
                    pressCount = 0;
                    continue;
                }
                else if (key == OldPhoneKeypad.SpaceKey)
                {
                    if (previousKey != '\0')
                    {
                        AppendCharacter(result, previousKey, pressCount);
                    }
                    result.Append(OldPhoneKeypad.SpaceCode);// add space
                    previousKey = '\0';
                    pressCount = 0;
                    continue;
                }
                else if (key == previousKey)
                {
                    pressCount++;
                }
                else
                {
                    if (previousKey != '\0')
                    {
                        AppendCharacter(result, previousKey, pressCount);
                    }

                    previousKey = key;
                    pressCount = 1;
                }
            }

            return result.ToString();
        }

        private void AppendCharacter(StringBuilder result, char previousKey, int pressCount)
        {
            result.Append(keypad.GetMappedCharacter(previousKey, pressCount));
        }

        public char GetPhoneKey(int row, int column)
        {
            return keypad.Keys[row, column];
        }

        public string[] GetCodesByKey(char key)
        {
            return keypad.GetCodes(key);
        }
    }
}
