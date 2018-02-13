#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("Microsoft.Quantum.Examples.Teleportation", "Teleport (msg : Qubit, there : Qubit) : ()", new string[] { }, "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs", 2167L, 44L, 57L)]
[assembly: OperationDeclaration("Microsoft.Quantum.Examples.Teleportation", "TeleportClassicalMessage (message : Bool) : Bool", new string[] { }, "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs", 3680L, 88L, 63L)]
#line hidden
namespace Microsoft.Quantum.Examples.Teleportation
{
    public class Teleport : Operation<(Qubit,Qubit), QVoid>
    {
        public Teleport(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.Allocate), typeof(Microsoft.Quantum.Primitive.CNOT), typeof(Microsoft.Quantum.Primitive.H), typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.Release), typeof(Microsoft.Quantum.Canon.Reset), typeof(Microsoft.Quantum.Primitive.X), typeof(Microsoft.Quantum.Primitive.Z) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected Allocate Allocate
        {
            get
            {
                return this.Factory.Get<Allocate, Microsoft.Quantum.Primitive.Allocate>();
            }
        }

        protected IUnitary<(Qubit,Qubit)> MicrosoftQuantumPrimitiveCNOT
        {
            get
            {
                return this.Factory.Get<IUnitary<(Qubit,Qubit)>, Microsoft.Quantum.Primitive.CNOT>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.H>();
            }
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        protected Release Release
        {
            get
            {
                return this.Factory.Get<Release, Microsoft.Quantum.Primitive.Release>();
            }
        }

        protected ICallable<Qubit, QVoid> MicrosoftQuantumCanonReset
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, QVoid>, Microsoft.Quantum.Canon.Reset>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.X>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveZ
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.Z>();
            }
        }

        public override Func<(Qubit,Qubit), QVoid> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Microsoft.Quantum.Examples.Teleportation.Teleport", OperationFunctor.Body, _args);
                var __result__ = default(QVoid);
                try
                {
                    var (msg,there) = _args;
#line 47 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    var register = Allocate.Apply(1L);
                    // Ask for an auxillary qubit that we can use to prepare
                    // for teleportation.
#line 50 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    var here = register[0L];
                    // Create some entanglement that we can use to send our message.
#line 53 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    MicrosoftQuantumPrimitiveH.Apply(here);
#line 54 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    MicrosoftQuantumPrimitiveCNOT.Apply((here, there));
                    // Move our message into the entangled pair.
#line 57 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    MicrosoftQuantumPrimitiveCNOT.Apply((msg, here));
#line 58 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    MicrosoftQuantumPrimitiveH.Apply(msg);
                    // Measure out the entanglement.
#line 61 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    if ((M.Apply<Result>(msg) == Result.One))
                    {
#line 61 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                        MicrosoftQuantumPrimitiveZ.Apply(there);
                    }

#line 62 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    if ((M.Apply<Result>(here) == Result.One))
                    {
#line 62 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                        MicrosoftQuantumPrimitiveX.Apply(there);
                    }

                    // Reset our "here" qubit before releasing it.
#line 65 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    MicrosoftQuantumCanonReset.Apply(here);
#line hidden
                    Release.Apply(register);
#line hidden
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Microsoft.Quantum.Examples.Teleportation.Teleport", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Qubit msg, Qubit there)
        {
            return __m__.Run<Teleport, (Qubit,Qubit), QVoid>((msg, there));
        }
    }

    public class TeleportClassicalMessage : Operation<Boolean, Boolean>
    {
        public TeleportClassicalMessage(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.Allocate), typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.Release), typeof(Microsoft.Quantum.Canon.ResetAll), typeof(Microsoft.Quantum.Examples.Teleportation.Teleport), typeof(Microsoft.Quantum.Primitive.X) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected Allocate Allocate
        {
            get
            {
                return this.Factory.Get<Allocate, Microsoft.Quantum.Primitive.Allocate>();
            }
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        protected Release Release
        {
            get
            {
                return this.Factory.Get<Release, Microsoft.Quantum.Primitive.Release>();
            }
        }

        protected ICallable<QArray<Qubit>, QVoid> MicrosoftQuantumCanonResetAll
        {
            get
            {
                return this.Factory.Get<ICallable<QArray<Qubit>, QVoid>, Microsoft.Quantum.Canon.ResetAll>();
            }
        }

        protected ICallable<(Qubit,Qubit), QVoid> Teleport
        {
            get
            {
                return this.Factory.Get<ICallable<(Qubit,Qubit), QVoid>, Microsoft.Quantum.Examples.Teleportation.Teleport>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.X>();
            }
        }

        public override Func<Boolean, Boolean> Body
        {
            get => (message) =>
            {
#line hidden
                this.Factory.StartOperation("Microsoft.Quantum.Examples.Teleportation.TeleportClassicalMessage", OperationFunctor.Body, message);
                var __result__ = default(Boolean);
                try
                {
#line 90 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    var measurement = false;
#line 92 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    var register = Allocate.Apply(2L);
                    // Ask for some qubits that we can use to teleport.
#line 94 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    var msg = register[0L];
#line 95 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    var there = register[1L];
                    // Encode the message we want to send.
#line 98 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    if (message)
                    {
#line 98 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                        MicrosoftQuantumPrimitiveX.Apply(msg);
                    }

                    // Use the operation we defined above.
#line 101 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    Teleport.Apply((msg, there));
                    // Check what message was sent.
#line 104 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    if ((M.Apply<Result>(there) == Result.One))
                    {
#line 104 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                        measurement = true;
                    }

                    // Reset all of the qubits that we used before releasing
                    // them.
#line 108 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    MicrosoftQuantumCanonResetAll.Apply(register);
#line hidden
                    Release.Apply(register);
#line hidden
                    __result__ = measurement;
#line 111 "C:\\Users\\Frances\\source\\repos\\QuantumTeleportation\\QuantumTeleportation\\Operation.qs"
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Microsoft.Quantum.Examples.Teleportation.TeleportClassicalMessage", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<Boolean> Run(IOperationFactory __m__, Boolean message)
        {
            return __m__.Run<TeleportClassicalMessage, Boolean, Boolean>(message);
        }
    }
}