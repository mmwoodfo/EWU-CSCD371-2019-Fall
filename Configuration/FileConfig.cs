using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Configuration
{
    public class FileConfig : IConfig
    {
        private readonly string filePath;

        public FileConfig(string filePath)
        {
            this.filePath = filePath;
        }

        public bool GetConfigValue(string name, out string? value)
        {
            string[] lines = File.ReadLines(filePath).ToArray();

            foreach(string line in lines)
            {
                Console.WriteLine($"* {line}\n");
                string[] parsedLine = ParseLine(line);
                if(string.Equals(name, parsedLine[0]))
                {
                    value = parsedLine[1];
                    return true;
                }
            }

            value = null;
            return false;
        }

#pragma warning disable CA1822 // Mark members as static
        public string[] ParseLine(string line)
#pragma warning restore CA1822 // Mark members as static
        {
            if(line is null)
            {
                throw new ArgumentNullException();
            }

            string[] parsedLine = line.Split("=");
            if(parsedLine.Length != 2)
            {
                throw new ArgumentException("There can only be one equals sign on the line");
            }
            else
            {
                return parsedLine;
            }
        }

        public bool SetConfigValue(string name, string? value)
        {
            ValidateNameAndValue(name, value);

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{name}={value}");
                return true;
            }
        }

#pragma warning disable CA1822 // Mark members as static
        public bool ValidateNameAndValue(string name, string? value)
#pragma warning restore CA1822 // Mark members as static
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"{nameof(name)} should not be null or empty");
            }
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"{nameof(value)} should not be null or empty");
            }
            if(name.Contains(' ') || name.Contains('='))
            {
                throw new ArgumentException($"{nameof(name)} is invalid formatting = and whitespace is not allowed");
            }
            if(value.Contains(' ') || value.Contains('='))
            {
                throw new ArgumentException($"{nameof(value)} is invalid formatting = and whitespace is not allowed");
            }
            return true;
        }
    }
}
