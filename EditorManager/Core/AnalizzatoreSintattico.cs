using System.Collections.Generic;

namespace LaboratorioStack.Core
{
    public static class AnalizzatoreSintattico
    {
        public static bool VerificaParentesi(string espressione)
        {
            Stack<char> pila = new Stack<char>();
            foreach (char c in espressione)
            {
                if (c == '(') pila.Push(c);
                else if (c == ')')
                {
                    if (pila.Count == 0) return false;
                    pila.Pop();
                }
            }
            return pila.Count == 0;
        }
    }
}