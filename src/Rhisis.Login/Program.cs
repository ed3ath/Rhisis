﻿using System;

namespace Rhisis.Login
{
    public static class Program
    {
        private static readonly string ProgramTitle = "Rhisis - ClusterServer";

        private static void Main(string[] args)
        {
            Console.Title = ProgramTitle;

            using (var server = new LoginServer())
                server.Start();
        }
    }
}