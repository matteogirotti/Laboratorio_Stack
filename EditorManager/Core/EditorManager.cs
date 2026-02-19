using System;
using System.Collections.Generic;

namespace LaboratorioStack.Core
{
    public class EditorManager
    {
        private Stack<string> _undoStack = new Stack<string>();
        private Stack<string> _redoStack = new Stack<string>();
        private string _testoCorrente = "";

        public string TestoCorrente
        {
            get { return string.IsNullOrEmpty(_testoCorrente) ? "[Vuoto]" : _testoCorrente; }
        }

        public void Digita(string nuovaParola)
        {
            _undoStack.Push(_testoCorrente); // Salvo lo stato attuale
            _redoStack.Clear();             // Scrittura nuova = reset Redo
            _testoCorrente += nuovaParola + " ";
        }

        public void Annulla()
        {
            if (_undoStack.Count > 0)
            {
                _redoStack.Push(_testoCorrente);
                _testoCorrente = _undoStack.Pop();
            }
        }

        public void Ripristina()
        {
            if (_redoStack.Count > 0)
            {
                _undoStack.Push(_testoCorrente);
                _testoCorrente = _redoStack.Pop();
            }
        }

        // Metodo didattico: mostra cosa c'è "dentro" la memoria
        public void StampaDebug()
        {
            Console.WriteLine($"\n--- DEBUG STACK ---");
            Console.WriteLine($"Undo Stack (storia): {string.Join(" | ", _undoStack)}" + "Elementi: " + _undoStack.Count);
            Console.WriteLine($"Redo Stack (futuro): {string.Join(" | ", _redoStack)}" + "Elementi: " + _redoStack.Count);
            Console.WriteLine("-------------------\n");
        }
    }
}