﻿#region license and copyright
/*
 * The MIT License, Copyright (c) 2011-2019 Marcel Schneider
 * for details see License.txt
 */
#endregion

namespace AeonFlux.Parser
{
    internal struct Position
    {
        public string Text { get; private set; }
        public int StartLine { get; private set; }
        public int EndLine { get; private set; }
        public int StartColumn { get; private set; }
        public int EndColumn { get; private set; }

        public Position(string text, int startLine, int endLine, int startColumn, int endColumn)
            : this()
        {
            Text = text;
            StartLine = startLine;
            EndLine = endLine;
            StartColumn = startColumn;
            EndColumn = endColumn;
        }
    }
}
