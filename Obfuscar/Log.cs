using System;

namespace Obfuscar
{
    /// <summary>
    /// Logging utility.
    /// </summary>
    public static class Log
    {
        private static bool isAtNewLine = true;

        /// <summary>
        /// Write a line of text with line-end to output.
        /// </summary>
        /// <param name="messageCode">Message code.</param>
        /// <param name="output">Text.</param>
        public static void OutputLine(string messageCode, string? output)
        {
            Output(messageCode, output, true);
        }

        /// <summary>
        /// Write a line of text to output.
        /// </summary>
        /// <param name="messageCode">Message code.</param>
        /// <param name="output">Text.</param>
        /// <param name="addNewLine">Whether to append a new line.</param>
        public static void Output(string messageCode, string? output, bool addNewLine = false)
        {
            string? line;

            if (isAtNewLine || addNewLine)
            {
                string dateTxt = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss");

                if (addNewLine)
                {
                    line = String.Concat(dateTxt, ": ", messageCode, " ", output, "\n");
                    isAtNewLine = true;
                }
                else
                {
                    line = String.Concat(dateTxt, ": ", messageCode, " ", output);
                    isAtNewLine = output?.EndsWith("\n") ?? false;
                }
            }
            else
            {
                line = output;
                isAtNewLine = output?.EndsWith("\n") ?? false;
            }

            Console.Write(line);
        }
    }
}
