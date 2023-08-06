﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zelt.AST
{
    public static class ErrorHandler
    {
        public static void ThrowError(string message)
        {
            string errorPrefix = $"Error :: Not in code??\n\n";
            Console.WriteLine(errorPrefix + message + "\n");
            Environment.Exit(1);
        }

        public static void ThrowError(
            string message,
            int line,
            int column,
            string[] sourceCodeLines
        )
        {
            string lineOfCode = sourceCodeLines[line - 1];
            string errorPointer = new string(' ', column) + "^";
            string errorPrefix = $"Error :: Line = {line}, Position = {column}\n{lineOfCode}\n{errorPointer}\n\n";
            Console.WriteLine(errorPrefix + message + "\n");
            Environment.Exit(1);
        }
    }
}
