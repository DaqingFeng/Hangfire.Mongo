﻿using System;

namespace Hangfire.Mongo.Sample.NETCore
{
    public class Program
    {
        private const int JobCount = 100;

        public static void Main(string[] args)
        {
            JobStorage.Current = new MongoStorage("mongodb://localhost", "Mongo-Hangfire-Sample-NETCore");

            using (new BackgroundJobServer())
            {
                for (var i = 0; i < JobCount; i++)
                {
                    var jobId = i;
                    BackgroundJob.Enqueue(() => Console.WriteLine($"Fire-and-forget ({jobId})"));
                }

                Console.WriteLine($"{JobCount} job(s) has been enqued. They will be executed shortly!");
                Console.WriteLine($"");
                Console.WriteLine($"If you close this application before they are executed, ");
                Console.WriteLine($"they will be executed the next time you run this sample.");
                Console.WriteLine($"");
                Console.WriteLine($"Press any key to exit...");

                Console.ReadKey(true);
            }
        }
    }
}
