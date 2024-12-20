﻿using Mono.Cecil.Cil;

namespace Obfuscar
{
    internal class LdStrInstructionReplacement
    {
        public LdStrInstructionReplacement(int oldIndex, Instruction newinstruction)
        {
            this.OldIndex = oldIndex;
            this.NewInstruction = newinstruction;
        }

        public int OldIndex { get; }
        
        public Instruction NewInstruction { get; }
    }
}
