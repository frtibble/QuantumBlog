// Copyright (c) Microsoft Corporation. All rights reserved. Licensed under the 
// Microsoft Software License Terms for Microsoft Quantum Development Kit Libraries 
// and Samples. See LICENSE in the project root for license information.

using Microsoft.Quantum.Simulation.Simulators;
using System.Linq;

namespace Microsoft.Quantum.Examples.Teleportation
{
    class Program
    {
        static void Main(string[] args)
        {
            var sim = new QuantumSimulator();
            var rand = new System.Random();

            #region Teleport Classical Message
            foreach (var idxRun in Enumerable.Range(0, 8))
            {
                var sent = rand.Next(2) == 0;
                var received = TeleportClassicalMessage.Run(sim, sent).Result;
                System.Console.WriteLine($"Round {idxRun}:\tSent {sent},\tgot {received}.");
                System.Console.WriteLine(sent == received ? "Teleportation successful!!\n" : "\n");
            }
            #endregion

            #region Teleport Quantum Message
            // In this region, we call the TeleportQuantumMessage operation
            // from Operation.qs, which prepares a qubit in the |+〉 ≔ H|0〉
            // state and asserts that the probability of observing a Zero
            // result is 50%.

            // Thus, we will run the operation several times and report
            // the mean.

            System.Console.WriteLine("\n\nPress Enter to continue...\n\n");
            System.Console.ReadLine();

            var averageResult = Enumerable.Range(0, 1000).Select((idx) =>
               TeleportQuantumMessage.Run(sim).Result == Simulation.Core.Result.One ? 1 : 0
            ).Average();
            System.Console.WriteLine($"Frequency of '0' in teleported message: {averageResult}");
            #endregion

            System.Console.WriteLine("\n\nPress Enter to exit...\n\n");
            System.Console.ReadLine();

        }
    }
}
