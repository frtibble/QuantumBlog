#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("Quantum.Bell", "Set (desired : Result, q1 : Qubit) : ()", new string[] { }, "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs", 160L, 7L, 5L)]
[assembly: OperationDeclaration("Quantum.Bell", "BellTest (count : Int, initial : Result) : (Int, Int, Int)", new string[] { }, "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs", 361L, 19L, 2L)]
#line hidden
namespace Quantum.Bell
{
    public class Set : Operation<(Result,Qubit), QVoid>
    {
        public Set(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.X) };
        }

        public override Type[] Dependencies
        {
            get;
        }

        protected ICallable<Qubit, Result> M
        {
            get
            {
                return this.Factory.Get<ICallable<Qubit, Result>, Microsoft.Quantum.Primitive.M>();
            }
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get
            {
                return this.Factory.Get<IUnitary<Qubit>, Microsoft.Quantum.Primitive.X>();
            }
        }

        public override Func<(Result,Qubit), QVoid> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.Bell.Set", OperationFunctor.Body, _args);
                var __result__ = default(QVoid);
                try
                {
                    var (desired,q1) = _args;
#line 10 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                    var current = M.Apply<Result>(q1);
#line 11 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                    if ((desired != current))
                    {
#line 13 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                        MicrosoftQuantumPrimitiveX.Apply(q1);
                    }

#line hidden
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.Bell.Set", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Result desired, Qubit q1)
        {
            return __m__.Run<Set, (Result,Qubit), QVoid>((desired, q1));
        }
    }

    public class BellTest : Operation<(Int64,Result), (Int64,Int64,Int64)>
    {
        public BellTest(IOperationFactory m) : base(m)
        {
            this.Dependencies = new Type[] { typeof(Microsoft.Quantum.Primitive.Allocate), typeof(Microsoft.Quantum.Primitive.CNOT), typeof(Microsoft.Quantum.Primitive.H), typeof(Microsoft.Quantum.Primitive.M), typeof(Microsoft.Quantum.Primitive.Release), typeof(Quantum.Bell.Set) };
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

        protected ICallable<(Result,Qubit), QVoid> Set
        {
            get
            {
                return this.Factory.Get<ICallable<(Result,Qubit), QVoid>, Quantum.Bell.Set>();
            }
        }

        public override Func<(Int64,Result), (Int64,Int64,Int64)> Body
        {
            get => (_args) =>
            {
#line hidden
                this.Factory.StartOperation("Quantum.Bell.BellTest", OperationFunctor.Body, _args);
                var __result__ = default((Int64,Int64,Int64));
                try
                {
                    var (count,initial) = _args;
#line 22 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                    var numOnes = 0L;
#line 23 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                    var agree = 0L;
#line 24 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                    var qubits = Allocate.Apply(2L);
#line 26 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                    foreach (var test in new Range(1L, count))
                    {
#line 28 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                        Set.Apply((initial, qubits[0L]));
#line 29 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                        Set.Apply((Result.Zero, qubits[1L]));
#line 31 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                        MicrosoftQuantumPrimitiveH.Apply(qubits[0L]);
#line 32 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                        MicrosoftQuantumPrimitiveCNOT.Apply((qubits[0L], qubits[1L]));
#line 33 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                        var res = M.Apply<Result>(qubits[0L]);
#line 35 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                        if ((M.Apply<Result>(qubits[1L]) == res))
                        {
#line 37 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                            agree = (agree + 1L);
                        }

                        // Count the number of ones we saw:
#line 41 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                        if ((res == Result.One))
                        {
#line 43 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                            numOnes = (numOnes + 1L);
                        }
                    }

#line 46 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                    Set.Apply((Result.Zero, qubits[0L]));
#line 47 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                    Set.Apply((Result.Zero, qubits[1L]));
#line hidden
                    Release.Apply(qubits);
#line hidden
                    __result__ = ((count - numOnes), numOnes, agree);
                    // Return number of times we saw a |0> and number of times we saw a |1>
#line 50 "c:\\users\\frances\\source\\repos\\Bell\\Bell\\Operation.qs"
                    return __result__;
                }
                finally
                {
#line hidden
                    this.Factory.EndOperation("Quantum.Bell.BellTest", OperationFunctor.Body, __result__);
                }
            }

            ;
        }

        public static System.Threading.Tasks.Task<(Int64,Int64,Int64)> Run(IOperationFactory __m__, Int64 count, Result initial)
        {
            return __m__.Run<BellTest, (Int64,Result), (Int64,Int64,Int64)>((count, initial));
        }
    }
}